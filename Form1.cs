using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using TIS.Imaging;
using TIS.Imaging.VCDHelpers;
using ICSpec;
using static ICSpec.ServiceFunctions;
using static ICSpec.AO_Devices;

namespace ICSpec
{

    public partial class Form1 : Form
    {
        //Инициализация всех переменных, необходимых для работы
        private VCDSimpleProperty vcdProp = null;
        private VCDAbsoluteValueProperty AbsValExp = null;// специально для времени экспонирования
        bool ChangingActivatedTextBoxExp = true;
        bool ChangingActivatedTextBoxGain = true;
        ImageStyle SnapImageStyle = new ImageStyle();
        TIS.Imaging.BaseSink m_oldSink;
        TIS.Imaging.FrameHandlerSink curfhs;
        string filedatename = null;
        public string fileName = null;//Application.StartupPath + @"\\SettingsOfWriting.txt";
        public bool WarningofCapt = false;
        public bool WarningofImage = false;
        string WarningofCaptMessage = "";
        string WarningofImgMessage = "";
        int Xx = 0;
        int Yy = 0;
        int PrevSelectedBinning = 1;
        const byte ediam = 12;
        bool ACenterFlag = false;
        bool UserROIVisualFlag = false;
        bool FPSChangeCausedByUser = true;
        bool AutoSetActivated = false;
        bool AOFSimulatorActivated = false;
        Rectangle UserROIGraphics = new Rectangle();
        Rectangle UserROIGraphics2 = new Rectangle();
        int PointXMax = 0;
        int PointYMax = 0;
        bool DependenceTBWL = true, DependenceTBWN = true, DependenceTrBWL = true, DependenceTrBWN = true, LoadingAOFValues = false;
        int AttachmentFactor = 100;
        FrameFilter FlipFilter, FlipFilterFHS;

        //для перестройки времени экспонирования по кривой
        string WayToCurv_exp = "";
        string WayToCurv_wl = "";
        float[] WLs_toTune = null;


        // Все для работы АО
        bool AO_WL_Controlled_byslider = false;
        double AO_WL_precision = 100.0;
        double AO_HZ_precision = 1000.0;

        //Все для sweep
        double AO_FreqDeviation_Max_byTime = 0;
        double AO_FreqDeviation = 0.5;
        double AO_TimeDeviation = 10;
        bool AO_Sweep_Needed = false;
        float[,] AO_All_CurveSweep_Params = new float[0, 0];
        bool AO_Sweep_CurveTuning_isEnabled = false;
        bool AO_Sweep_CurveTuning_inProgress = false;
        bool AO_Sweep_CurveTuning_StopFlag = false;

        List<object> ParamList_bkp = new List<object>();
        List<object> ParamList_final = new List<object>();

        UI.Log.Logger Log;
        AO_Filter Filter = null;
        System.Diagnostics.Stopwatch timer_for_sweep = new System.Diagnostics.Stopwatch();

        string AO_ProgramSweepCFG_filename = "AOData.txt";

        public Form1()
        {
            InitializeComponent();//функция инициалиции элементов управления
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //this.Text = "Перестраиваемый источник " + version;
            Log = new UI.Log.Logger(LBConsole);
            Log.Message(" - текущее время");
            Filter = ICSpec.AO_Devices.Find_and_connect_AnyFilter();
            if (Filter.FilterType == FilterTypes.Emulator) { Log.Message("ПРЕДУПРЕЖДЕНИЕ: Не обнаружены подключенные АО фильтры. Фильтр будет эмулирован."); }
            else { Log.Message("Обнаружен подключенный АО фильтр. Тип фильтра: " + Filter.FilterType.ToString()); }
            ChB_Power.Enabled = false;
            //GB_AllAOFControls.Enabled = false;
            //ReadData();
            //tests();
            this.KeyPreview = true;

            /* int st = 500; int fn = 610;
             List<int> wls = new List<int>();
             List<double> exps = new List<double>();
             ExpCurve.GetCurveFromDirectory("TestCurv3.expcurv", ref wls, ref exps);
             ExpCurve.GetNiceCurve(450,740, 500, 621,15, ref wls, ref exps);
             LogMessage("Done!");*/

            try
            {
                if (!icImagingControl1.DeviceValid)
                {
                    TIS.Imaging.LibrarySetup.SetLocalizationLanguage("ru");
                    //var data_sink = new FrameHandlerSink(false, new FrameType("Y800"));
                    //icImagingControl1.Sink = data_sink;
                    icImagingControl1.ShowDeviceSettingsDialog();
                    if (!icImagingControl1.DeviceValid)
                    {
                        MessageBox.Show("Не было выбрано ни одного устройства", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                    else
                    {
                        CreateAttachmentFactor(ref AttachmentFactor, LBConsole);
                        this.Text = "IC Spectrometer v1.9 Beta";
                        fileName = Application.StartupPath + @"\SettingsOfWriting.txt";
                        TrBZoomOfImage.Value = (int)(icImagingControl1.LiveDisplayZoomFactor * 100.00f);
                        vcdProp = new VCDSimpleProperty(icImagingControl1.VCDPropertyItems);
                        icImagingControl1.ScrollbarsEnabled = true;
                        TrBZoomOfImage.Value = (int)(icImagingControl1.LiveDisplayZoomFactor * 100);
                        L_Zoom.Text = TrBZoomOfImage.Value.ToString() + "%";
                        icImagingControl1.ImageRingBufferSize = 301;
                        ReadAllSettingsFromFile(false);
                        icImagingControl1.LiveDisplayDefault = false;
                        ContTransAfterSnapshot.Visible = false;
                        GrBAOFWlSet.Enabled = false;
                    }

                    CreateAttachmentFactor(ref AttachmentFactor, LBConsole);
                    TestAvailability(false);
                    InitSliders();
                    bool liverun = icImagingControl1.LiveVideoRunning;

                    try
                    {
                        AnalyseFormats();
                        m_oldSink = New_SetSelectedCamera_SignalStream_Format();
                    }
                    catch { }
                    // GetAllResolutionsByFormat(); //Вызывается автоматически после AnalyseFormats(), т.к. есть привязка по событию изменения разрешения
                    // FindCurrentFormat(true);     //Вызывается автоматически после AnalyseFormats(), т.к. есть привязка по событию изменения разрешения
                    try { DetectCameraPixelFormats(); } catch { }
                    try { GetAllAvailibleFPS(); } catch { }
                    try { FindCurrentFPS(false); } catch { }

                    try
                    {
                        if (icImagingControl1.LiveVideoRunning) icImagingControl1.LiveStop();
                        GetAllPixelFormats();
                        GetAllPixelFormatsForSaving();
                        SwitchOverlay(icImagingControl1.OverlayBitmapAtPath[PathPositions.Display], true);
                    }
                    catch { }

                    try
                    {
                        icImagingControl1.LiveDisplayDefault = false;

                        icImagingControl1.LiveCaptureLastImage = false;

                        icImagingControl1.LiveStart();
                    }
                    catch { }
                    DisableAlltheShit();
                    FormatAdaptation();



                    //создание контекстного меню

                    /*  System.Windows.Forms.ContextMenu MyContextMenu=new System.Windows.Forms.ContextMenu();                 
                      System.Windows.Forms.MenuItem menuItem1=new System.Windows.Forms.MenuItem();
                      System.Windows.Forms.MenuItem menuItem2 = new System.Windows.Forms.MenuItem();
                      MyContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItem1, menuItem2 });
                      menuItem1.Index = 0;
                      menuItem1.Text = "Сохранение изображения";
                      menuItem2.Index = 1;
                      menuItem2.Text = "Измерения";
                      icImagingControl1.ContextMenu = MyContextMenu;
                      menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
                      menuItem2.Click += new System.EventHandler(this.menuItem2_Click);*/
                }
            }
            catch (Exception ext)
            {
                MessageBox.Show(ext.Message);
            }
            finally { if (icImagingControl1.DeviceValid) icImagingControl1.LiveStart(); }
        }//функция предзагрузки окна для динамической инициализации некоторых элементов управления 

        private void ExitBut_Click(object sender, EventArgs e)//функция выхода из приложения
        {
            Close();
        }

        private void SaveImgParBut_Click(object sender, EventArgs e)//функция открытия диалового окна сохраниния изображения
        {
            CreateDialog(false);
        }

        private void PropBut_Click(object sender, EventArgs e)//функция,вызывающая диалоговое окно свойств
        {
            icImagingControl1.ShowPropertyDialog();
            if (!vcdProp.Available(VCDIDs.VCDID_Exposure))
            {
                TrBExposureVal.Enabled = false;
                TBExposureVal.Enabled = false;
            }
            else
            {
                if (AbsValExp.Value < 1) TBExposureVal.Text = "1/" + ((int)(1 / (AbsValExp.Value))).ToString();
                else TBExposureVal.Text = (AbsValExp.Value).ToString();
                ChBExposureAuto.Checked = vcdProp.Automation[VCDIDs.VCDID_Exposure];
                TrBExposureVal.Enabled = !ChBExposureAuto.Checked;
            }
            if (!vcdProp.Available(VCDIDs.VCDID_Gain))
            {
                TrBGainVal.Enabled = false;
                TBGainVal.Enabled = false;
            }
            else
            {
                TBGainVal.Text = vcdProp.RangeValue[VCDIDs.VCDID_Gain].ToString();
                ChBGainAuto.Checked = vcdProp.Automation[VCDIDs.VCDID_Gain];
                TrBGainVal.Enabled = !ChBGainAuto.Checked;
            }
            RefreshROIControls(false);
        }
        private void Form1_WheelScrolled(object sender, MouseEventArgs e)//фукция,обрабатывающая прокрутку колеса мыши для увеличения в live режиме
        {
            float ZFactCurrent = icImagingControl1.LiveDisplayZoomFactor;
            float abs = (float)((PerfectRounding(ZFactCurrent * 100, 0)) % 5) / 100.0f;
            if (abs != 0)
            {
                icImagingControl1.LiveDisplayZoomFactor = ZFactCurrent - abs;
                TrBZoomOfImage.Value = (int)(icImagingControl1.LiveDisplayZoomFactor * 100.0f);
                L_Zoom.Text = TrBZoomOfImage.Value.ToString() + "%";
            }
            if (!(((TrBZoomOfImage.Value > (TrBZoomOfImage.Maximum - (e.Delta / 24) + 1)) && (e.Delta > 0)) || ((TrBZoomOfImage.Value < TrBZoomOfImage.Minimum - (e.Delta / 24) - 1) && (e.Delta < 0))))
            {
                TrBZoomOfImage.Value += e.Delta / 24;
                ScrollOcc();
            }
        }
        private void ZoomOfImage_Scroll(object sender, EventArgs e)//событие увеличения изображения
        {
            ScrollOcc();
        }

        private void icImagingControl1_Scroll(object sender, ScrollEventArgs e)//функция,запоминающая координаты положения увеличения в live окне
        {
            Point p = icImagingControl1.AutoScrollPosition;
        }

        private void TimerForRenew_Tick(object sender, EventArgs e)//Пока включена автоматическая регулировка, эта функция отвечает за отображения значения параметра 
        {
            try
            {
                if (AbsValExp.Value < 1) TBExposureVal.Text = "1/" + ((int)(1.0 / (AbsValExp.Value))).ToString();
                else TBExposureVal.Text = (AbsValExp.Value).ToString();
                TrBExposureVal.Value = Exposure_real2slide(AbsValExp.Value);
                //ChBExposureAuto.Checked = vcdProp.Automation[VCDIDs.VCDID_Exposure];

                TBGainVal.Text = vcdProp.RangeValue[VCDIDs.VCDID_Gain].ToString();
                TrBGainVal.Value = vcdProp.RangeValue[VCDIDs.VCDID_Gain];
                //ChBGainAuto.Checked = vcdProp.Automation[VCDIDs.VCDID_Gain];
            }
            catch { }
        }


        private void SnapshotBut_Click(object sender, EventArgs e)//событие создания скриншота окна
        {
            //if (FlipFilter.GetBoolParameter("Flip H")) FlipFilter.SetBoolParameter("Flip H", false);
            // else FlipFilter.SetBoolParameter("Flip H", true);
            SnapShot();
            SaveImageBut.Visible = true;
            DisableFlipButtons();

            /*  if (FlipFilterFHS.GetBoolParameter("Flip H")) FlipFilterFHS.SetBoolParameter("Flip H", false);
              else FlipFilterFHS.SetBoolParameter("Flip H", true);*/
        }

        private void ContTransAfterSnapshot_Click(object sender, EventArgs e)//функция, вызывающия появление кновки "продолжить трансляцию" после скриншота
        {
            icImagingControl1.LiveStart();
            SnapshotBut.Enabled = true;
            ContTransAfterSnapshot.Visible = false;
            SaveImageBut.Visible = false;
            EnableFlipButtons();
            // if (FlipFilter.GetBoolParameter("Flip H")) FlipFilter.SetBoolParameter("Flip H", false);
            // else FlipFilter.SetBoolParameter("Flip H", true);
            /*  if (FlipFilterFHS.GetBoolParameter("Flip H")) FlipFilterFHS.SetBoolParameter("Flip H", false);
            else FlipFilterFHS.SetBoolParameter("Flip H", true);*/
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)//функция,запоминающая позицию курсора в окне при движении по нему
        {
            Xx = Cursor.Position.X;
            Yy = Cursor.Position.Y;
        }



        private void SaveImageBut_Click(object sender, EventArgs e)
        {
            try
            {
                ReadAllSettingsFromFile(false);
                if (WarningofImage)
                {
                    MessageBox.Show(WarningofImgMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (icImagingControl1.LiveVideoRunning) icImagingControl1.LiveStop();
                    ContTransAfterSnapshot.Visible = true;
                    string SCRName = CheckScreenShotBasicName();
                    string date = GetDateString();
                    var buf = curfhs.LastAcquiredBuffer;
                    string exactname = SnapImageStyle.Directory + SCRName + "_" + date + "_" + wlcurrentg.ToString() + SnapImageStyle.Extension;
                    buf.SaveAsTiff(exactname);
                    LogMessage("Сохранено: " + exactname);
                }
            }
            catch (ICException exc)
            {
                LogError("ORIGINAL: " + exc.Message);
                LogError("Code: " + exc.TargetSite);
            }
        }

        private void BStartS_Click(object sender, EventArgs e)
        {
            int stepss = CalculateSteps();
            //   Bitmap[] Massive = StartSession(stepss); 
            // SaveMassive(Massive);
            DisableFlipButtons();
            if (!ChB_LoadWLCurve.Checked)
            {
                WLs_toTune = null;
            }
            New_SnapAndSaveMassive((int)StartL, (int)EndL, stepss, WLs_toTune);
            EnableFlipButtons();
        }

        private void BDevOpen_Click(object sender, EventArgs e)
        {
            string AO_DEV_loaded = null;
            string AO_DEV_loaded_fullPath = null;

            var DR = OpenDevSearcher(ref AO_DEV_loaded, ref AO_DEV_loaded_fullPath);

            if (DR == DialogResult.OK)
                try
                {
                    var Status = Filter.Read_dev_file(AO_DEV_loaded_fullPath);
                    if (Status == 0)
                        Log.Message(AO_DEV_loaded_fullPath + " - файл считан успешно!");
                    else
                        throw new Exception(Filter.Implement_Error(Status));
                }
                catch (Exception exc)
                {
                    Log.Message("Произошла ошибка при прочтении .dev файла");
                    Log.Error("ORIGINAL:" + exc.Message);
                    return;
                }
            else return;

            AO_FreqDeviation_Max_byTime = AO_TimeDeviation / (1000.0f / Filter.AO_ExchangeRate_Min);
            InitializeComponents_byVariables();
        }

        private void BPower_Click(object sender, EventArgs e)
        {
        }

        private void BFolderOpen_Click(object sender, EventArgs e)
        {
            OpenSomeFolder();
        }


        private void TBCurrentWL_Scroll(object sender, EventArgs e)
        {
            if (DependenceTrBWL && !LoadingAOFValues)
            { SetInactiveDependence(3); TrBWL_OnScroll(); SetInactiveDependence(0); }
        }
        private void TrBWLNumber_Scroll(object sender, EventArgs e)
        {
            if (DependenceTrBWN && !LoadingAOFValues)
            {
                SetInactiveDependence(4); TrBWN_OnScroll(); SetInactiveDependence(0);
            }
        }
        private void TBwl_TextChanged(object sender, EventArgs e)
        {
            if (DependenceTBWL && !LoadingAOFValues) { SetInactiveDependence(1); TBWLTextChanged(); SetInactiveDependence(0); }
        }

     
        private void SetInactiveDependence(int state)
        {
            switch (state)
            {
                case 1: { DependenceTBWL = true; DependenceTBWN = false; DependenceTrBWL = false; DependenceTrBWN = false; } break;
                case 2: { DependenceTBWL = false; DependenceTBWN = true; DependenceTrBWL = false; DependenceTrBWN = false; } break;
                case 3: { DependenceTBWL = false; DependenceTBWN = false; DependenceTrBWL = true; DependenceTrBWN = false; } break;
                case 4: { DependenceTBWL = false; DependenceTBWN = false; DependenceTrBWL = false; DependenceTrBWN = true; } break;
                default: { DependenceTBWL = true; DependenceTBWN = true; DependenceTrBWL = true; DependenceTrBWN = true; } break;
            }
        }

        private void BSetWL_Click(object sender, EventArgs e)
        {

            float data_CurrentWL = (float)(TrB_CurrentWL.Value / AO_WL_precision);
            NUD_CurrentWL.Value = (decimal)(data_CurrentWL);

            if (AO_Sweep_Needed)
            {
                try
                {
                    ReSweep(data_CurrentWL);
                }
                catch (Exception exc)
                {
                    Log.Error(exc.Message);
                }
            }
            else
            {
                try
                {
                    if (Filter.is_inSweepMode) Filter.Set_Sweep_off();
                    System.Threading.Thread.Sleep(50);
                    var state = Filter.Set_Wl(data_CurrentWL);
                    if (state != 0) throw new Exception(Filter.Implement_Error(state));
                    Log.Message("Перестройка на длину волны " + data_CurrentWL.ToString() + " нм прошла успешно!");
                }
                catch (Exception exc)
                {
                    Log.Error(exc.Message);
                }
            }
        }

        private void BSetROI_Click(object sender, EventArgs e)
        {
            //if (!CheckRight()) return;
            var ic = icImagingControl1;
            ic.LiveStop();
            var oldS = New_SetSelectedCamera_SignalStream_Format();
            bool result = SetSelectedFormatAndBinning();
            result = SetSelectedPartialScan();
            ROISeted = true;
            //  SetSelectedCameraPixelFormat();
            //   SetSelectedPixelFormat();
            /*   GetAllAvailibleFPS();
               FindCurrentFPS(true);*/
            try { ic.LiveStart(); }
            catch (ICException exc)
            {
                LogError("ORIGINAL: " + exc.Message);
                LogMessage("Неудача при выставлении нового формата. Попытка возврата к предыдущему...");
                ic.Sink = oldS;
                try
                {
                    ic.LiveStart();
                    LogMessage("Возврат к предыдущему формату осуществлен успешно");
                }
                catch (ICException exc2)
                {
                    LogError("ORIGINAL: " + exc2.Message);
                }
            }
            FormatAdaptation();
            GetAllAvailibleFPS();
            FindCurrentFPS(false);
            RefreshROIControls(false, result);
            GetValuesAfterSet();
            if (ic.LiveVideoRunning)
            {
                try
                {
                    LogMessage("MemoryCurrentGrabberColorformat is " + ic.MemoryCurrentGrabberColorformat.ToString() + " now.");
                    LogMessage("MemoryPixelFormat is " + ic.MemoryPixelFormat.ToString() + " now.");
                }
                catch (Exception exc) { LogError("ORIGINAL: " + exc.Message); }
            }
        }

        private void TBExposureVal_TextChanged(object sender, EventArgs e)
        {
            if ((ChangingActivatedTextBoxExp) && (TBExposureVal.Text != "") && (!vcdProp.Automation[VCDIDs.VCDID_Exposure]))
            {
                int toslide = 0;
                toslide = Exposure_real2slide(NormalConvertToFloat(TBExposureVal.Text));
                if ((toslide < (TrBExposureVal.Maximum + 1)) && (toslide > (TrBExposureVal.Minimum - 1)))
                    TrBExposureVal.Value = toslide;
                else
                    TrBExposureVal.Value = Exposure_real2slide(AbsValExp.Default);
            }
        }

        private void TBGainVal_TextChanged(object sender, EventArgs e)
        {
            if ((ChangingActivatedTextBoxGain) && (TBGainVal.Text != "") && (!vcdProp.Automation[VCDIDs.VCDID_Gain]))
            {
                int toslide = 0;
                toslide = Convert.ToInt32(TBGainVal.Text);
                if ((toslide < (TrBGainVal.Maximum + 1)) && (toslide > (TrBGainVal.Minimum - 1)))
                    TrBGainVal.Value = toslide;
                else
                    TrBGainVal.Value = vcdProp.DefaultValue(VCDIDs.VCDID_Gain);
            }
        }

        private void TrBExposureVal_Scroll(object sender, EventArgs e)
        {
            try
            {
                ChangingActivatedTextBoxExp = false;
                double value = Exposure_Slide2real(TrBExposureVal.Value);
                LoadExposure(ref AbsValExp, value);
                int promval = ((int)(1.0 / Exposure_Slide2real(TrBExposureVal.Value)));
                if (promval > 1) TBExposureVal.Text = "1/" + promval.ToString();
                else TBExposureVal.Text = (AbsValExp.Value).ToString();
                ChangingActivatedTextBoxExp = true;
            }
            catch (Exception ex) { LogError("ORIGINAL: " + ex.Message); }
        }
        private static void LoadExposure(ref VCDAbsoluteValueProperty var, double pvalue)
        {
            if (pvalue < var.RangeMin) var.Value = var.RangeMin;
            else if (pvalue > var.RangeMax) var.Value = var.RangeMax;
            else var.Value = pvalue;
        }
        private void LoadGain(ref VCDSimpleProperty SProp, double pvalue)
        {
            string ChangeVCDID2 = VCDIDs.VCDID_Gain;
            if (pvalue < SProp.RangeMin(ChangeVCDID2))
            {
                TBGainVal.Text = SProp.RangeMin(ChangeVCDID2).ToString();

            }
            else if (pvalue > SProp.RangeMax(ChangeVCDID2))
            {
                TBGainVal.Text = SProp.RangeMax(ChangeVCDID2).ToString();

            }
            else
            {
                TBGainVal.Text = pvalue.ToString();
                SProp.RangeValue[ChangeVCDID2] = (int)pvalue;

            }

        }
        private void TrBGainVal_Scroll(object sender, EventArgs e)
        {
            ChangingActivatedTextBoxGain = false;
            vcdProp.RangeValue[VCDIDs.VCDID_Gain] = TrBGainVal.Value;
            TBGainVal.Text = TrBGainVal.Value.ToString();
            ChangingActivatedTextBoxGain = true;
        }

        private void TBExposureVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != Convert.ToChar(8)) && (e.KeyChar != Convert.ToChar(46)) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
            if (((e.KeyChar == Convert.ToChar(46)) || (e.KeyChar == '/')) && (dots(TBExposureVal.Text) == true))//блок на введение второй точки или слэша
            {
                e.Handled = true;
            }
        }

        private void TBGainVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != Convert.ToChar(8)) && (e.KeyChar != Convert.ToChar(46)) && (e.KeyChar != '/'))
            {
                e.Handled = true;
            }
            if (((e.KeyChar == Convert.ToChar(46)) || (e.KeyChar == '/')) && (dots(TBExposureVal.Text) == true))//блок на введение второй точки или слэша
            {
                e.Handled = true;
            }
        }

        private void ChBGainAuto_CheckedChanged(object sender, EventArgs e)
        {
            vcdProp.Automation[VCDIDs.VCDID_Gain] = ChBGainAuto.Checked;
            TrBGainVal.Enabled = !ChBGainAuto.Checked;
            if (ChBGainAuto.Checked)
            {
                TimerForRenew.Enabled = true;
                TimerForRenew.Start();
            }
            else
            {
                TimerForRenew.Stop();
                TimerForRenew.Enabled = false;
            }
        }

        private void ChBExposureAuto_CheckedChanged(object sender, EventArgs e)
        {
            vcdProp.Automation[VCDIDs.VCDID_Exposure] = ChBExposureAuto.Checked;
            TrBExposureVal.Enabled = !ChBExposureAuto.Checked;
            if (ChBExposureAuto.Checked)
            {
                TimerForRenew.Enabled = true;
                TimerForRenew.Start();
            }
            else
            {
                TimerForRenew.Stop();
                TimerForRenew.Enabled = false;
            }
        }

        private void BAdapt_Click(object sender, EventArgs e)
        {
            FormatAdaptation();
        }

        private void m_AcquireButton_Click(object sender, EventArgs e)
        {

        }

        private void TBNamePrefix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (TBNamePrefix.Text.Length > 14) e.Handled = true;
            if (e.KeyChar == Convert.ToChar(8)) e.Handled = false;
        }

        private void CBSignalFormats_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllResolutionsByFormat();
            FindCurrentFormat(false);
        }

        private void CBMResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshROIControls(true);
        }

        private void ChBROIAutoCent_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBROIAutoCent.Checked)
            {
                ACenterFlag = true; TBROIPointX.Enabled = TBROIPointY.Enabled = false;
                Set_Partial_scan_Auto_center_Switch(icImagingControl1, true);
            }
            else
            {
                ACenterFlag = false; TBROIPointX.Enabled = TBROIPointY.Enabled = true;
                Set_Partial_scan_Auto_center_Switch(icImagingControl1, false);
            }

        }

        private void CbBinning_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBMResolution.SelectedIndex == 0) CorrectROIValues();
        }

        private void BSelectUserResolution_Click(object sender, EventArgs e)
        {
            CBMResolution.SelectedIndex = 0;
        }

        private void CBAvFPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFPS();
        }

        private void FPSTimer_Tick(object sender, EventArgs e)
        {
            if (icImagingControl1.DeviceValid)
            {
                try
                { LFPSCurrent.Text = icImagingControl1.DeviceFrameRate.ToString(); }
                catch { }
            }
        }

        private void icImagingControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (UserROIVisualFlag)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ROISeted = false; ChBROIAutoCent.Checked = false;
                    UserROIGraphics2.X = (int)(((float)e.Location.X) / icImagingControl1.LiveDisplayZoomFactor);
                    UserROIGraphics2.Y = (int)(((float)e.Location.Y) / icImagingControl1.LiveDisplayZoomFactor);
                    /* int devide = icImagingControl1.VideoFormatCurrent.BinningFactor;
                     UserROIGraphics.X /= devide;
                     UserROIGraphics.Y /= devide;*/
                }
            }
        }

        private void icImagingControl1_MouseMove(object sender, MouseEventArgs e)
        {
            if (UserROIVisualFlag)
            {
                if (e.Button == MouseButtons.Left)
                {
                    UserROIGraphics2.Width = (int)(((float)e.Location.X) / icImagingControl1.LiveDisplayZoomFactor);
                    UserROIGraphics2.Height = (int)(((float)e.Location.Y) / icImagingControl1.LiveDisplayZoomFactor);
                    NormalizeRect(UserROIGraphics2, false);
                    /* int devide = icImagingControl1.VideoFormatCurrent.BinningFactor;
                     UserROIGraphics.Height /= devide;
                     UserROIGraphics.Height /= devide;*/
                }
            }
        }
        private void icImagingControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (UserROIVisualFlag)
            {
                if (e.Button == MouseButtons.Left)
                {
                    UserROIGraphics2.Width = (int)(((float)e.Location.X) / icImagingControl1.LiveDisplayZoomFactor);
                    UserROIGraphics2.Height = (int)(((float)e.Location.Y) / icImagingControl1.LiveDisplayZoomFactor);
                    /*int devide = icImagingControl1.VideoFormatCurrent.BinningFactor;
                    UserROIGraphics.X /= devide;
                    UserROIGraphics.Y /= devide;
                    UserROIGraphics.Width /= devide;
                    UserROIGraphics.Height /= devide;*/

                    NormalizeRect(UserROIGraphics2, true);
                    if (!ROISeted && ChBVisualiseROI.Checked && (CBMResolution.SelectedIndex == 0))
                    {
                        TBROIHeight.Text = (UserROIGraphics.Height - UserROIGraphics.Y).ToString();
                        TBROIWidth.Text = (UserROIGraphics.Width - UserROIGraphics.X).ToString();
                        TBROIPointX.Text = (UserROIGraphics.X).ToString();
                        TBROIPointY.Text = (UserROIGraphics.Y).ToString();
                    }
                }
            }
        }

        private void ChBVisualiseROI_CheckedChanged(object sender, EventArgs e)
        {
            if (ChBVisualiseROI.Checked)
            {
                UserROIVisualFlag = true; CbBinning.Enabled = false;
            }
            else
            {
                UserROIVisualFlag = false; CbBinning.Enabled = true;
            }
        }

        private void ICInvalidateTimer_Tick(object sender, EventArgs e)
        {
            // if(icImagingControl1.LiveVideoRunning)
            // DBInvalidate(icImagingControl1.OverlayBitmap);
        }

        private void BROIFull_Click(object sender, EventArgs e)
        {
            SetMaxValuesToROIControls();
        }

        private void BTestAll_Click(object sender, EventArgs e)
        {
            TestAvailability(true);
            TestAOF_dll();
        }

        private void ChBAutoSetWL_CheckedChanged(object sender, EventArgs e)
        {
            AO_WL_Controlled_byslider = ChB_AutoSetWL.Checked;
        }

        private void ChBActivateAOFSimulator_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void CBoxPixelFormat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BSnSq_Click(object sender, EventArgs e)
        {
            SnapSequence2img();
        }

        private void TBEx1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && (e.KeyChar != Convert.ToChar(8)) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }


        private void ChkBLoadedExpCurve_CheckedChanged(object sender, EventArgs e)
        {

            if (ChkBLoadedExpCurve.Checked)
            {
                WayToCurv_exp = OpenExpcfgSearcher();
                if (WayToCurv_exp == "") { ChkBLoadedExpCurve.Text = "Перестройка по кривой"; }
                else
                {
                    ChkBLoadedExpCurve.Text = "Кривая: " + WayToCurv_exp;

                    List<int> wls = new List<int>();
                    List<double> exps = new List<double>();
                    wlming = Convert.ToInt32(TBStartL.Text);
                    wlmaxg = Convert.ToInt32(TBFinishL.Text);
                    double Gain = 0, FPS = 0;
                    ExpCurve.Get_andWrite_NiceCurveFromDirectory(WayToCurv_exp, MinimumWL, MaximumWL, (int)wlming, (int)wlmaxg, (int)wlstepg, ref wls, ref exps, ref Gain, ref FPS);

                    LogMessage("Перестройка по кривой включена.");
                }
            }
            else
            {
                ChkBLoadedExpCurve.Text = "Перестройка по кривой";
                WayToCurv_exp = "";
                LogMessage("Перестройка по кривой отключена.");
            }


        }

        /*  delegate void DCreation(ref TIS.Imaging.ICImagingControl IC,
              ref TIS.Imaging.VCDHelpers.VCDSimpleProperty VSExp, ref TIS.Imaging.VCDAbsoluteValueProperty pAbsVal,
              int pWlRealMin, int pWlRealMax, int pStWL, int pFinWL, int pStep);*/

        private void BCreateAutoCurve_Click(object sender, EventArgs e)
        {
            if (BCreateAutoCurve.Text == "Создать кривую по автоэкспозиции")
            {
                BCreateAutoCurve.Text = "Прервать создание кривой";
                StartL = Convert.ToInt32(TBStartL.Text);
                EndL = Convert.ToInt32(TBFinishL.Text);
                wlstepg = Convert.ToInt16(TBStepL.Text);
                BkGrWorker_forExpCurveBuilding.RunWorkerAsync();
            }
            else
            {
                BCreateAutoCurve.Text = "Создать кривую по автоэкспозиции";
                BkGrWorker_forExpCurveBuilding.CancelAsync();
            }
            // DCreation DelegateForCurv = new DCreation(ExpCurve.CreateCurve);
        }

        private void BkGrWorker_forExpCurveBuilding_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            bool wasAutomation = false;
            string ChangeVCDID = TIS.Imaging.VCDIDs.VCDID_Exposure;

            if (worker.CancellationPending == true)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    ShowStringDelegate MessageDelegate = new ShowStringDelegate(LogMessage);
                    var ptrExp = AbsValExp;
                    double CurFPS = icImagingControl1.DeviceFrameRate;
                    int CurGain = vcdProp.RangeValue[VCDIDs.VCDID_Gain];

                    wasAutomation = vcdProp.Automation[ChangeVCDID];

                    ExpCurve.CreateCurve(ref worker, ref e, ref icImagingControl1, ref vcdProp, ref ptrExp,
                           MinimumWL, MaximumWL, (int)StartL, (int)EndL, (int)wlstepg, CurGain, CurFPS, MessageDelegate, wasAutomation,Filter);
                    vcdProp.Automation[ChangeVCDID] = wasAutomation;
                }
                catch (Exception exc)
                {
                    LogError(exc.Message);
                    vcdProp.Automation[ChangeVCDID] = wasAutomation;
                }
            }
        }

        private void BkGrWorker_forExpCurveBuilding_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string message2 = "Подобрана экспозиция для длины волны " + e.ProgressPercentage;
            LogMessage(message2);
        }

        private void BkGrWorker_forExpCurveBuilding_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowStringDelegate MessageDelegate = new ShowStringDelegate(LogMessage);
            if (e.Cancelled == true)
            {
                MessageDelegate.Invoke("Операция отменена!");
                BCreateAutoCurve.Text = "Создать кривую по автоэкспозиции";
            }
            else if (e.Error != null)
            {
                MessageDelegate.Invoke("Ошибка: " + e.Error.Message);
                BCreateAutoCurve.Text = "Создать кривую по автоэкспозиции";
            }
            else
            {
                MessageDelegate.Invoke("Подстройка окончена!");
                BCreateAutoCurve.Text = "Создать кривую по автоэкспозиции";
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void GPCamFeat_Enter(object sender, EventArgs e)
        {

        }

        private void viaMSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ChB_LoadWLCurve_CheckedChanged(object sender, EventArgs e)
        {

            if (ChB_LoadWLCurve.Checked)
            {
                WayToCurv_wl = Files.OpenFiles("Choose your tune file", true, false, ".txt")[0];
                if (WayToCurv_wl == "") { ChB_LoadWLCurve.Text = "Перестройка по кривой"; }
                else
                {
                    ChB_LoadWLCurve.Text = "Кривая: " + Path.GetFileName(WayToCurv_wl);
                    var allstrings = Files.Read_txt(WayToCurv_wl);
                    float[] mass = null, mass2 = null;
                    Files.Get_WLData_byKnownCountofNumbers(1, allstrings.ToArray(), out mass, out WLs_toTune, out mass2);
                    List<float> data = new List<float>(WLs_toTune);
                    data.Reverse();
                    for (int i = 0; i < data.Count(); i++)
                    {


                        if ((data[i] < MinimumWL) || (data[i] > MaximumWL))
                        {
                            LogMessage(String.Format("Обнаруженная в списке длина волны {0} не принадлежит диапазону {1}-{2}. Съемка на этой длине волны производиться не будет.",
                              data[i], MinimumWL, MaximumWL));
                            data.RemoveAt(i);
                            i--;
                        }
                    }
                    WLs_toTune = data.ToArray();
                    LogMessage("Перестройка по кривой длин волн включена.");
                }
            }
            else
            {
                ChB_LoadWLCurve.Text = "Перестройка по кривой ДВ";
                WayToCurv_wl = "";
                LogMessage("Перестройка по кривой длин волн отключена.");
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            try { FormatAdaptation(); } catch { }
            CreateAttachmentFactor(ref AttachmentFactor, LBConsole);

        }

        private void ChB_Power_CheckedChanged(object sender, EventArgs e)
        {

            bool newAOFPowerStatus = ChB_Power.Checked;
            if (newAOFPowerStatus)
            {
                try
                {
                    var state = Filter.PowerOn();
                    if (state == 0)
                    {
                        Log.Message("Активация АОФ успешна!");
                        GrBAOFWlSet.Enabled = true;
                    }
                    else throw new Exception(Filter.Implement_Error(state));
                }
                catch (Exception exc)
                {
                    Log.Message("Возникла проблема при активации АОФ.");
                    Log.Error(exc.Message);
                }
            }
            else
            {
                GrBAOFWlSet.Enabled = false;
                Filter.PowerOff();
            }
        }

        private void CurrentWL_Change()
        {
            float data_CurrentWL = (float)(TrB_CurrentWL.Value / AO_WL_precision);
            if (AO_WL_Controlled_byslider)
            {
                if (AO_Sweep_Needed)
                {
                    /* if (!timer_for_sweep.IsRunning || timer_for_sweep.ElapsedMilliseconds > 500)
                     {
                         timer_for_sweep.Restart();
                         ReSweep(data_CurrentWL);
                     }*/
                }
                else
                {
                    try
                    {
                        var state = Filter.Set_Wl(data_CurrentWL);
                        if (state != 0) throw new Exception(Filter.Implement_Error(state));
                        Log.Message("Перестройка на длину волны " + data_CurrentWL.ToString() + " нм прошла успешно!");
                    }
                    catch (Exception exc)
                    {
                        Log.Error(exc.Message);
                    }
                }
            }
        }

        private void NUD_CurWL_ValueChanged(object sender, EventArgs e)
        {
            TrB_CurrentWL.Value = (int)(NUD_CurrentWL.Value * (decimal)AO_WL_precision);
            CurrentWL_Change();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void icImagingControl1_OverlayUpdate(object sender, ICImagingControl.OverlayUpdateEventArgs e)
        {
            var arg = e.overlay;
            if (icImagingControl1.LiveVideoRunning) DBInvalidate(arg);
        }

        private void CBFinalPixelFormat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FlipUpDownBut_Click(object sender, EventArgs e)//функция отзеркаливания live изображения сверху вниз
        {
            if (FlipFilter.GetBoolParameter("Flip V")) FlipFilter.SetBoolParameter("Flip V", false);
            else FlipFilter.SetBoolParameter("Flip V", true);
            /*   if (FlipFilterFHS.GetBoolParameter("Flip V")) FlipFilterFHS.SetBoolParameter("Flip V", false);
               else FlipFilterFHS.SetBoolParameter("Flip V", true);*/
        }
        private void FlipRightLeftBut_Click(object sender, EventArgs e)//функция отзеркаливания live изображения слева направо
        {
            if (FlipFilter.GetBoolParameter("Flip H")) FlipFilter.SetBoolParameter("Flip H", false);
            else FlipFilter.SetBoolParameter("Flip H", true);
            /* if (FlipFilterFHS.GetBoolParameter("Flip H")) FlipFilterFHS.SetBoolParameter("Flip H", false);
             else FlipFilterFHS.SetBoolParameter("Flip H", true);*/
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Q) && e.Alt)
            {
                Application.Exit(); return;// RemovePointsInRect();
            }
            /*     else if ((e.KeyCode == Keys.D) && e.Control)
                 {
                     RemovePointsInRect();
                 }
                 else if ((e.KeyCode == Keys.F) && e.Alt)
                 {
                     if (FullScrin) { MinimizeWindow(); FullScrin = false; }
                     else { MaximizeWindow(); FullScrin = true; }
                 }*/

        }

        private void NUD_CurrentWN_ValueChanged(object sender, EventArgs e)
        {
            if (DependenceTBWN && !LoadingAOFValues) { SetInactiveDependence(2); TBWN_onValueChanged(); SetInactiveDependence(0); }
        }

        private void tests()
        {

            Filter.Read_dev_file("ampl_avm1-011-3.dev");
            Filter.PowerOn();
            Filter.Set_Wl(Filter.WL_Max);
            Filter.Set_Wl((Filter.WL_Max + Filter.WL_Min) / 2);
            Filter.Set_Wl(Filter.WL_Min);
            Filter.Set_Hz((Filter.HZ_Min + Filter.HZ_Max) / 2);
            float delta = 5;
            Filter.Set_Sweep_on((Filter.HZ_Max + Filter.HZ_Min) / 2 - delta, 2 * delta, 1, true);
            System.Threading.Thread.Sleep(2000);
            Filter.Set_Sweep_off();
            //  Filter.PowerOff();
        }
        private void InitializeComponents_byVariables()
        {
            try
            {
                ChB_Power.Checked = false;

                ChB_AutoSetWL.Checked = AO_WL_Controlled_byslider;
                L_ReqDevName.Text = Filter.Ask_required_dev_file();
                L_RealDevName.Text = Filter.Ask_loaded_dev_file();
                float data_CurWL = (Filter.WL_Max + Filter.WL_Min) / 2;
                Filter.Set_Wl(data_CurWL);

                NUD_CurrentWL.Minimum = (decimal)Filter.WL_Min;
                TrB_CurrentWL.Minimum = (int)(Filter.WL_Min * AO_WL_precision);
                NUD_CurrentWL.Maximum = (decimal)Filter.WL_Max;
                TrB_CurrentWL.Maximum = (int)(Filter.WL_Max * AO_WL_precision);
                NUD_CurrentWL.Value = (decimal)data_CurWL;
                TrB_CurrentWL.Value = (int)(data_CurWL * AO_WL_precision);

                /*   ChB_SweepEnabled.Checked = Filter.is_inSweepMode;
                   Pan_SweepControls.Enabled = Filter.is_inSweepMode;

                   var AOFWind_FreqDeviation_bkp = AO_FreqDeviation; // ибо AO_FreqDeviation изменяется, если изменяются максимумы
                   //NUD_FreqDeviation.Minimum = (decimal)Filter.AO_FreqDeviation_Min;
                   //NUD_FreqDeviation.Maximum = (decimal)
                   //    (AO_FreqDeviation_Max_byTime < Filter.AO_FreqDeviation_Max ? AO_FreqDeviation_Max_byTime : Filter.AO_FreqDeviation_Max);

                   var AOFWind_TimeDeviation_bkp = AO_TimeDeviation; // ибо AOFWind_TimeDeviation изменяется, если изменяются максимумы
                   //NUD_TimeFdev.Minimum = (decimal)Filter.AO_TimeDeviation_Min;
                   //NUD_TimeFdev.Maximum = (decimal)Filter.AO_TimeDeviation_Max;


                   NUD_TimeFdev.Value = (decimal)AOFWind_TimeDeviation_bkp;
                   NUD_FreqDeviation.Value = (decimal)AOFWind_FreqDeviation_bkp > NUD_FreqDeviation.Maximum ? NUD_FreqDeviation.Maximum : (decimal)AO_FreqDeviation;*/

                ChB_Power.Enabled = true;

                Log.Message("Инициализация элементов управления прошла успешно!");
            }
            catch (Exception exc)
            {
                Log.Error("Инициализация элементов управления завершилась с ошибкой.");
            }
        }

        private void SetWL_everywhere(int pwl)
        {

            NUD_CurrentWL.Value = pwl;
            TrB_CurrentWL.Value = pwl;
        }
        private void ReSweep(float p_data_CurrentWL)
        {
            Filter.Set_Sweep_off();
            float HZ_toset = Filter.Get_HZ_via_WL(p_data_CurrentWL);
            System.Drawing.PointF data_for_sweep = Filter.Sweep_Recalculate_borders(HZ_toset, (float)AO_FreqDeviation);

            Log.Message(String.Format("ЛЧМ Параметры: ДВ:{0} / Частота:{1} / Девиация частоты:{2}", p_data_CurrentWL, HZ_toset, AO_FreqDeviation));
            Log.Message(String.Format("Доступные для установки ЛЧМ параметры:  ДВ: {0} / Частота:{1} / Девиация частоты: {2} ",
                p_data_CurrentWL, HZ_toset, data_for_sweep.Y / 2));
            Log.Message(String.Format("Пересчет:  {0}+{1}", data_for_sweep.X, data_for_sweep.Y));



            var state = Filter.Set_Sweep_on(data_for_sweep.X, data_for_sweep.Y, AO_TimeDeviation, true);
            if (state != 0) throw new Exception(Filter.Implement_Error(state));
            Log.Message("Режим ЛЧМ около длины волны " + p_data_CurrentWL.ToString() + " нм запущен!");
        }
        private DialogResult OpenDevSearcher(ref string CfgToLoad, ref string CfgToLoad_fullPath)
        {

            OpenFileDialog OPF = new OpenFileDialog();
            OPF.InitialDirectory = Application.StartupPath;
            OPF.Filter = "DEV config files (*.dev)|*.dev|All files (*.*)|*.*";
            OPF.FilterIndex = 0;
            OPF.RestoreDirectory = true;

            if (OPF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int k = 1 + OPF.FileName.LastIndexOf('\\');
                    CfgToLoad_fullPath = OPF.FileName;
                    CfgToLoad = OPF.FileName.Substring(k, OPF.FileName.Length - k);
                }
                catch (Exception ex)
                {
                    Log.Error("Не удалось считать файл с диска. Оригинал ошибки: " + ex.Message);
                }
                return DialogResult.OK;
            }
            else return DialogResult.Cancel;
        }




    }

}
