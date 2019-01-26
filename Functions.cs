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
using System.Diagnostics;

namespace ICSpec
{
    public partial class Form1
    {
        float wlming = 740, wlmaxg = 1000, wlstepg = 10, wlcurrentg = 0, StartL = 0, EndL = 0, Step = 0;
        bool ACenterAvailible = false;
        bool ScanXOffsetAvailible = false;
        bool ScanYOffsetAvailible = false;
        bool AOFisON = false;
        int MaxMWidth = 0; int MaxMHeight = 0;
        bool ROISeted = false; double alpha = 0, beta = 0, xenta = 0, zF = 1000000;

        int MaximumWL = 0; int MinimumWL = 0;
        //forDrawROI
       // BufferedGraphicsContext currentContext;
      //  BufferedGraphics myBuffer;
        Pen PancilForDraw2 = new Pen(Color.FromArgb(255, 50, 255, 50));
        Pen PencilForDraw = new Pen(Color.FromArgb(255, 50, 255, 50), 4);
        SolidBrush PencilPodsv = new SolidBrush(Color.FromArgb(100, 50, 255, 50));
        public delegate void ShowStringDelegate(string message);
        private void LogMessage(string message)
        {
            if (null == message)
            {
                throw new ArgumentNullException("message");
            }
            string data = string.Format("{0:yyyy-MM-dd HH:mm:ss.fff}: {1}", DateTime.Now, message);
            object index;
            if(LBConsole.InvokeRequired)
            {

                ShowStringDelegate MessageDelegate = new ShowStringDelegate(LogMessage);
                LBConsole.BeginInvoke(MessageDelegate,new object[] { message });
            }
            else
            if (data.Length <= AttachmentFactor)
            {
                index = data;
                LBConsole.Items.Insert(0, index);
            }
            else
            {
                index = data.Substring(0, AttachmentFactor) + "...";
                LBConsole.Items.Insert(0, index);
                LogAttachment(data.Substring(AttachmentFactor), 1);
            }

        }
        private void LogAttachment(string Addmessage, int level)
        {
            if (null == Addmessage)
            {
                throw new ArgumentNullException("message");
            }
            string data = Addmessage;
            object index;
            if (data.Length <= AttachmentFactor)
            {
                index = "..." + data;
                LBConsole.Items.Insert(level, index);
            }
            else
            {
                index = "..." + data.Substring(0, AttachmentFactor) + "...";
                LBConsole.Items.Insert(level, index);
                LogAttachment(data.Substring(AttachmentFactor), level + 1);
            }

        }
        private void CreateAttachmentFactor(ref int pAF, ListBox pLB)
        {
            const float widthofthesymbol = 5.5f;
            pAF = (int)((float)pLB.Width / widthofthesymbol) - 10;
        }

        /// <summary>
        /// Add an error log message and show an error message box
        /// </summary>
        /// <param name="message">The message</param>
        private void LogError(string message)
        {
            LogMessage("Ошибка: " + message);
        }

        private void SwitchOverlay(TIS.Imaging.OverlayBitmap ob, bool flag)
        {
            icImagingControl1.OverlayBitmapPosition = TIS.Imaging.PathPositions.Display;
            icImagingControl1.OverlayBitmapAtPath[PathPositions.Device].ColorMode  = OverlayColorModes.Grayscale;
            icImagingControl1.OverlayBitmapAtPath[PathPositions.Display].ColorMode = OverlayColorModes.Grayscale;
            icImagingControl1.OverlayBitmapAtPath[PathPositions.Sink].ColorMode = OverlayColorModes.Grayscale;

            ob.Enable = flag;
            ob.DropOutColor = Color.Magenta;
            ob.Fill(ob.DropOutColor);
            ob.FontTransparent = true;
        }
        private void DBInvalidate(TIS.Imaging.OverlayBitmap ob)//функция перерисовки всех элементов через двойную буферизацию
        {
            ob.Fill(ob.DropOutColor);
            ob.DrawText(Color.FromArgb(125,0,255,0), 10, 10, DateTime.Now.ToString());
            int NumOfLines = 1+(int)(1.0f/icImagingControl1.LiveDisplayZoomFactor);
            if (!ROISeted)
            {
                for (int i = 0; i < NumOfLines; i++)
                {
                    ob.DrawFrameRect(Color.FromArgb(125, 250, 250, 250), UserROIGraphics.X + i, UserROIGraphics.Y + i,
                   UserROIGraphics.Width - i, UserROIGraphics.Height - i);
                }      
                
            }
            //если потребуется отрисовать изображение
            #region Example
            /*  try
            {
                // Load the sample bitmap from the project file's directory.
                Image bmp = Bitmap.FromFile(Application.StartupPath + @"\hardware.bmp");
                // Calculate the column to display the bitmap in the
                // upper right corner of Imaging Control.
                int col = icImagingControl1.ImageWidth - 5 - bmp.Width;
                // Retrieve the Graphics object of the OverlayBitmap.
                Graphics g = ob.GetGraphics();
                // Draw the image
                g.DrawImage(bmp, col, 5);

                // Release the Graphics after drawing is finished.
               // ob.ReleaseGraphics(g);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("File not found: " + Ex.Message);
            }*/
            #endregion
            //тяжелая артиллерия
            #region Double Buffer
        /*    currentContext = BufferedGraphicsManager.Current;// Gets a reference to the current BufferedGraphicsContext
            myBuffer = currentContext.Allocate(icImagingControl1.CreateGraphics(), icImagingControl1.DisplayRectangle);//Передает буферу объект, для которого осуществляется перерисовка,и зона на этом объекте
            myBuffer.Graphics.DrawRectangle(PencilForDraw, 1, 10, 10, 10);
            Invalidate();
            myBuffer.Render();
            myBuffer.Dispose();*/
            #endregion

        }
        private void LoadFlipFilter()
        {
            FlipUpDownBut.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FUDBut.png", false);
            FlipUpDownBut.BackgroundImageLayout = ImageLayout.Stretch;
            FlipRightLeftBut.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FRLBut.png", false);
            FlipRightLeftBut.BackgroundImageLayout = ImageLayout.Stretch;

            FlipFilter = icImagingControl1.FrameFilterCreate("Rotate Flip", "");
            FlipFilterFHS = icImagingControl1.FrameFilterCreate("Rotate Flip", "");
            
            if (FlipFilter == null)
                LogError("Failed to create RotateFlipFilter");
            else
            {
                //curfhs.FrameFilters.Clear();
               // curfhs.FrameFilters.Add(FlipFilterFHS);
                icImagingControl1.DeviceFrameFilters.Clear();
                icImagingControl1.DeviceFrameFilters.Add(FlipFilter);
            }         
        }
        private void DisableFlipButtons()
        {
            FlipRightLeftBut.Enabled = false;
            FlipRightLeftBut.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FRLButCapt.png", false);
            FlipUpDownBut.Enabled = false;
            FlipUpDownBut.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FUDButCapt.png", false);
        }
        private void EnableFlipButtons()
        {
            FlipRightLeftBut.Enabled = true;
            FlipRightLeftBut.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FRLBut.png", false);
            FlipUpDownBut.Enabled = true;
            FlipUpDownBut.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FUDBut.png", false);
        }
        private void EnableOverlayBitmapAtPath(PathPositions pos, bool enabled)
        {
            bool wasLive = icImagingControl1.LiveVideoRunning;
            if (wasLive)
                icImagingControl1.LiveStop();

            PathPositions oldPos = icImagingControl1.OverlayBitmapPosition;
            if (enabled)
                icImagingControl1.OverlayBitmapPosition = pos;
            else
                icImagingControl1.OverlayBitmapPosition = PathPositions.Device;

            if (wasLive)
                icImagingControl1.LiveStart();
        }
		
        private void ReadAllSettingsFromFile(bool typeofwind)//чтение настроек записи из файла
        {
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
                {
                    sw.WriteLine("Image Settings:");
                    sw.WriteLine("      1.Directory::");
                    sw.WriteLine("      2.Extension::");
                    sw.WriteLine("      3.Quality::");
                    sw.WriteLine("Video Settings:");
                    sw.WriteLine("      1.Directory::");
                    sw.WriteLine("      1.Media Stream Container(extension)::");
                    sw.WriteLine("      1.Codec::");
                }
            }

            string[] readText = File.ReadAllLines(fileName);
            if (typeofwind)  //Video Settings
            {
                filedatename = DateTime.Now.ToString();
                filedatename = filedatename.Replace(' ', '_');
                filedatename = filedatename.Replace(':', '_');
                filedatename = filedatename.Replace('.', '_');
                m_oldSink = icImagingControl1.Sink;
                TIS.Imaging.MediaStreamSink m_Sink = new TIS.Imaging.MediaStreamSink();


                string localcontainername = readText[6].Substring(readText[6].LastIndexOf(':') + 1, readText[6].Length - (readText[6].LastIndexOf(':') + 1));
                for (int i = 0; i < icImagingControl1.MediaStreamContainers.Count(); i++)
                {
                    if (icImagingControl1.MediaStreamContainers[i].Name == localcontainername)
                    {
                        m_Sink.StreamContainer = icImagingControl1.MediaStreamContainers[i];
                    }
                }
                string temp = Application.StartupPath + "\\Видео\\" + filedatename + "." + m_Sink.StreamContainer.PreferredFileExtension;
                if (readText[5].Substring(19, readText[5].Length - 19) == "")
                {
                    if (!Directory.Exists(Application.StartupPath + "\\Видео\\"))
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Видео");
                        }
                        catch (System.IO.IOException except)
                        {
                            WarningofCapt = true;
                            WarningofCaptMessage = except.Message + "Невозможно создать директорию  " + Application.StartupPath + "\\Видео";
                        }
                    }
                    else
                        temp = Application.StartupPath + "\\Видео\\" + filedatename + "." + m_Sink.StreamContainer.PreferredFileExtension;
                    //WarningofCapt = true;
                    // WarningofCaptMessage="Введите директорию файла для записи в разделе " + SaveImgParBut.Name + "!";
                }
                else
                {
                    if (!Directory.Exists(readText[5].Substring(19, readText[5].Length - 19)))
                    {
                        //WarningofCapt = true;
                        // WarningofCaptMessage = "Введите существующую директорию файла для записи в разделе " + SaveImgParBut.Name + "!";
                        WarningofCapt = false;
                        temp = Application.StartupPath + "\\Видео\\" + filedatename + "." + m_Sink.StreamContainer.PreferredFileExtension;
                    }
                    else
                    {
                        temp = readText[5].Substring(19, readText[5].Length - 19) + filedatename + "." + m_Sink.StreamContainer.PreferredFileExtension;
                        WarningofCapt = false;
                    }
                }
                m_Sink.Filename = temp;

                string localcodecname = readText[7].Substring(readText[7].LastIndexOf(':') + 1, readText[7].Length - (readText[7].LastIndexOf(':') + 1));
                for (int i = 0; i < icImagingControl1.AviCompressors.Count(); i++)
                {
                    if (icImagingControl1.AviCompressors[i].Name == localcodecname)
                    {
                        m_Sink.Codec = icImagingControl1.AviCompressors[i];
                    }
                }
                icImagingControl1.LiveStop();
                icImagingControl1.Sink = m_Sink;
            }
            else//Image Settings
            {
                string temp = null;
                SnapImageStyle.Directory = Application.StartupPath + "\\Фото\\";
                SnapImageStyle.Extension = ".bmp";
                if (readText[1].Substring(19, readText[1].Length - 19) == "")
                {
                    if (!Directory.Exists(Application.StartupPath + "\\Фото\\"))
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Фото\\");
                        }
                        catch (System.IO.IOException except)
                        {
                            WarningofCapt = true;
                            WarningofCaptMessage = except.Message + "Невозможно создать директорию  " + Application.StartupPath + "\\Фото";
                        }
                    }
                    else
                        SnapImageStyle.Directory = Application.StartupPath + "\\Фото\\";
                    // WarningofImage = true;
                    //WarningofImgMessage = "Введите директорию файла для записи в разделе " + SaveImgParBut.Name + "!";
                }
                else WarningofCapt = false;
                if (!Directory.Exists(readText[1].Substring(19, readText[1].Length - 19)))
                {
                    SnapImageStyle.Directory = Application.StartupPath + "\\Фото\\";
                    //WarningofImage = true;
                    // WarningofImgMessage = "Введите существующую директорию файла для записи в разделе " + SaveImgParBut.Name + "!";                  
                }
                else SnapImageStyle.Directory = readText[1].Substring(19, readText[1].Length - 19);

                string alph = readText[2].Substring(19, readText[2].Length - 19) ;
                if (alph != "")
                {
                    SnapImageStyle.Extension = readText[2].Substring(readText[2].LastIndexOf(':') + 1, readText[2].Length - (readText[2].LastIndexOf(':') + 1));
                }
                temp = readText[3].Substring(readText[3].LastIndexOf(':') + 1, readText[3].Length - (readText[3].LastIndexOf(':') + 1));
                if (temp != "") SnapImageStyle.Quality = Convert.ToInt32(temp);
                else SnapImageStyle.Quality = 100;
            }
        }
        private void SnapShot()//функция создания скриншота окна
        {
            ReadAllSettingsFromFile(false);
            if (WarningofImage)
            {
                MessageBox.Show(WarningofImgMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    curfhs.SnapImage();
                    icImagingControl1.LiveStop();
                    LogMessage("Изображение захвачено. ");
                    ContTransAfterSnapshot.Visible = true;
                    SnapshotBut.Enabled = false;
                }
                catch
                { LogError("Ошибка при захвате кадра"); }
            }
        }
        private void CreateDialog(bool type)//функция создания диалового окна сохраниния видео
        {
            SaveDialog f2 = new SaveDialog();
            f2.Owner = this;
            f2.ShowDialog(type);
        }
        private void InitSliders() //функция инициализации ползунка для регулировки отдельных свойст камеры
        {
            string ChangeVCDID = VCDIDs.VCDID_Exposure;
            string ChangeVCDID2 = VCDIDs.VCDID_Gain;

            if (!vcdProp.AutoAvailable(ChangeVCDID))//если невозможна автоматическая регулировка,отключить возможность ее включения
            {
                ChBExposureAuto.Enabled = false;
            }
            else
            {
                ChBExposureAuto.Enabled = true;
                vcdProp.Automation[ChangeVCDID] = false;
            }
            if (!vcdProp.AutoAvailable(ChangeVCDID2))//если невозможна автоматическая регулировка,отключить возможность ее включения
            {
                ChBGainAuto.Enabled = false;
            }
            else
            {
                ChBGainAuto.Enabled = true;
                vcdProp.Automation[ChangeVCDID2] = false;
            }

            if (!vcdProp.Available(ChangeVCDID))
            {
                TrBExposureVal.Enabled = false;
                TBExposureVal.Enabled = false;
            }
            else
            {
                AbsValExp = (VCDAbsoluteValueProperty)icImagingControl1.VCDPropertyItems.FindInterface(ChangeVCDID +
                    ":" + VCDIDs.VCDElement_Value + ":" + VCDIDs.VCDInterface_AbsoluteValue);
                TrBExposureVal.Enabled = true;
                TBExposureVal.Enabled = true;
                int Az = TrBExposureVal.Minimum = (int)PerfectRounding((double)(AbsValExp.RangeMin * zF),0);
                int Bz = TrBExposureVal.Maximum = (int)PerfectRounding((double)(AbsValExp.RangeMax * zF),0);
                alpha = (AbsValExp.RangeMin*AbsValExp.RangeMax - 0.25*0.25) / (AbsValExp.RangeMin + AbsValExp.RangeMax - 2*0.25);
                xenta = Math.Pow((AbsValExp.RangeMax - alpha) / (AbsValExp.RangeMin - alpha), (zF / ((Bz - Az))));               
                beta = (0.25 - alpha) / Math.Pow(xenta, (Bz + Az) / (2 * zF));
                int val1slide = Az;              
                double val1real = Exposure_Slide2real(val1slide);
                int val2slide = Exposure_real2slide(val1real);
                if (val1slide == val2slide) LogMessage("Exponential Exposure test passed successfully!");
                try { TrBExposureVal.Value = Exposure_real2slide(AbsValExp.Value); }
                catch
                {
                    if (TrBExposureVal.Value < TrBExposureVal.Minimum) TrBExposureVal.Value = TrBExposureVal.Minimum;
                    else if (TrBExposureVal.Value > TrBExposureVal.Maximum) TrBExposureVal.Value = TrBExposureVal.Maximum;
                }
                TrBExposureVal.TickFrequency = (TrBExposureVal.Maximum - TrBExposureVal.Minimum) / 10;
                ChangingActivatedTextBoxExp = false;
                TBExposureVal.Text = "1/" + ((int)(1.0 / Exposure_Slide2real(TrBExposureVal.Value))).ToString();
                ChangingActivatedTextBoxExp = true;
            }
            if (!vcdProp.Available(ChangeVCDID2))
            {
                TrBGainVal.Enabled = false;
                TBGainVal.Enabled = false;
            }
            else
            {
                TrBGainVal.Enabled = true;
                TBGainVal.Enabled = true;
                TrBGainVal.Minimum = vcdProp.RangeMin(ChangeVCDID2);
                TrBGainVal.Maximum = vcdProp.RangeMax(ChangeVCDID2);
                TrBGainVal.Value = vcdProp.RangeValue[ChangeVCDID2];
                TrBGainVal.TickFrequency = (TrBGainVal.Maximum - TrBGainVal.Minimum) / 10;
                ChangingActivatedTextBoxGain = false;
                TBGainVal.Text = TrBGainVal.Value.ToString();
                ChangingActivatedTextBoxGain = true;
            }
        }
        private double Exposure_Slide2real(int arg)
        {

            double a = Math.Pow(xenta, ((double)arg)/zF);
            double b = beta * a;
            return (alpha + b);

        }
        private int Exposure_real2slide(double arg)
        {
            return (int)PerfectRounding((float)(zF*(Math.Log(((arg - alpha) / beta),xenta))),0);

        }
        private bool dots(string s)//функция,проверяющая, дробное или целое число введено в окно регулировки параметров
        {
            if ((s.IndexOf('.') + s.IndexOf('/')) != -2) return true;
            else return false;
        }
        private float NormalConvertToFloat(string s)//полное преобразования текста числа, введенного в любом дробном формате в окно регулировки параметров,в дробное число  
        {

            float returning = 0.00f;

            int i = 0;
            int zappos = s.Length;
            string prom = null;

            if (s.IndexOf('/') != -1)
            {
                zappos = s.IndexOf('/');
                double chislit = 0;
                double znam = 1;
                prom = s.Substring(0, zappos);
                if (prom != "") chislit = Convert.ToDouble(prom);
                if (zappos != s.Length)
                {
                    prom = s.Substring(zappos + 1, s.Length - (zappos + 1));
                    if (prom != "") znam = Convert.ToDouble(prom);
                }
                returning = (float)((chislit / znam));
            }
            else
            {
                s = s.Replace(",", ".");
                double celaya = 0;
                double drobnaya = 0;
                for (i = 0; i < s.Length; i++)
                {
                    if (Convert.ToInt32(s[i]) == 46) zappos = i; //если это точка                 
                }
                prom = s.Substring(0, zappos);
                if (prom != "") celaya = Convert.ToDouble((prom));
                if (zappos != s.Length)
                {
                    prom = s.Substring(zappos + 1, s.Length - (zappos + 1));
                    if (prom != "") drobnaya = (Convert.ToDouble(prom) * Math.Pow(10.00, Convert.ToDouble((-1) * (s.Length - (zappos + 1)))));
                }
                returning = (float)celaya + (float)drobnaya;
            }
            return returning;
        }
        private void ScrollOcc()//функция,инициализирующая ползунок увеличения в live режиме
        {
            TrBZoomOfImage.Visible = true;
            L_Zoom.Visible = true;
            if (icImagingControl1.LiveDisplayDefault == false)
            {

                icImagingControl1.LiveDisplayZoomFactor = (float)TrBZoomOfImage.Value / 100.0f;
                L_Zoom.Text = TrBZoomOfImage.Value.ToString() + "%";
                if (icImagingControl1.LiveDisplayZoomFactor >= 1.0) icImagingControl1.ScrollbarsEnabled = true;
                else icImagingControl1.ScrollbarsEnabled = false;
            }
            else
            {
                MessageBox.Show("The zoom factor can only be set" + "\n" + "if LiveDisplayDefault returns False!");
            }
        }
        private void CheckEmptyness(TextBox TB)
        {
            string name = null;
            if (TB.Name == TBROIHeight.Name) { name = "Height"; }
            else if (TB.Name == TBROIWidth.Name) { name = "Width"; }
            else if (TB.Name == TBROIPointX.Name) { name = "Point X"; }
            else if (TB.Name == TBROIPointY.Name) { name = "Point Y"; }
            else { name = TB.Name; }
            if ((TB.Text == "") || (TB.Text == null))
                throw new Exception("Данные в элементе " + name + " некорректны");
        }
        private Bitmap[] StartSession(int Number)
        {
            Bitmap[] Resultive = new Bitmap[Number];
            ReadAllSettingsFromFile(false);
            int codeerr = 0;
            if (WarningofImage)
            {
                LogError(WarningofImgMessage);
            }
            else
            {
                try
                {
                    codeerr = AOF.AOM_SetWL(wlming,AOFSimulatorActivated);
                    if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
                System.Threading.Thread.Sleep(200);
                for (int i = 0; i < Number; i += 1)
                {
                    wlcurrentg = wlming + i * wlstepg;
                    try
                    {
                        codeerr = AOF.AOM_SetWL(wlcurrentg, AOFSimulatorActivated);
                        if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                    }
                    catch (Exception ex)
                    {
                        LogError(ex.Message);
                    }

                    icImagingControl1.MemorySnapImage();
                    //Resultive[i] = new Bitmap(icImagingControl1.ImageBuffers[0].Bitmap);
                    Resultive[i] = new Bitmap(icImagingControl1.ImageActiveBuffer.Bitmap);
                    LogMessage(String.Format("Изображение №{0:D2} захвачено. ", i.ToString()));
                }

            }
            return Resultive;
        }
        private void New_SnapAndSaveMassive2(int pStartWL,int pFinishWL,int pSteps)
        {
            TIS.Imaging.ImageBuffer[] rval = new TIS.Imaging.ImageBuffer[pSteps+1];
            ReadAllSettingsFromFile(false);
            int codeerr = 0;
            if (WarningofImage) { LogError(WarningofImgMessage); }
            else
            {
                try
                {
                    codeerr = AOF.AOM_SetWL(wlming, AOFSimulatorActivated);
                    if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
               // System.Threading.Thread.Sleep(20);

                Stopwatch SessionDone = new Stopwatch(); SessionDone.Start();
                for (int i = 0; i < pSteps; i += 1)
                {
                    wlcurrentg = pStartWL + i * wlstepg;
                    try
                    {
                        codeerr = AOF.AOM_SetWL(wlcurrentg, AOFSimulatorActivated);
                        if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                    }
                    catch (Exception ex)
                    {
                        LogError(ex.Message);
                    }
                    curfhs.SnapImage();
                    rval[i] = curfhs.LastAcquiredBuffer;
                    //icImagingControl1.MemorySnapImage();
                    //Resultive[i] = new Bitmap(icImagingControl1.ImageActiveBuffer.Bitmap);
                  //  LogMessage(String.Format("Изображение №{0:D2} захвачено. ", i.ToString()));
                }
                try
                {
                    codeerr = AOF.AOM_SetWL(pFinishWL, AOFSimulatorActivated);
                    if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                    curfhs.SnapImage();
                    rval[pSteps] = curfhs.LastAcquiredBuffer;
                   // LogMessage(String.Format("Изображение №{0:D2} захвачено. ", pSteps.ToString()));
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
                SessionDone.Stop();
                LogMessage("Захват кадров завершен. Прошедшее время: " + SessionDone.Elapsed.ToString());
                LogMessage("Заявленное FPS: " + icImagingControl1.DeviceFrameRate);
                LogMessage("Реальное   FPS: " + (((double)(pSteps + 1)) / SessionDone.Elapsed.TotalSeconds).ToString());
            }
            string SCRName = CheckScreenShotBasicName();
            string date = GetDateString();
            string NameDirectory = DateTime.Now.ToString().Replace('.','_').Replace(' ','_').Replace(':','_')+"\\";
            Directory.CreateDirectory(SnapImageStyle.Directory + NameDirectory);
            for (int i = 0; i < pSteps; i++)
            {
                try
                {
                    wlcurrentg = pStartWL + i * wlstepg;
                    string local = SnapImageStyle.Directory + NameDirectory + SCRName + "_" + date + "_" + wlcurrentg.ToString() + SnapImageStyle.Extension;
                    rval[i].SaveAsTiff(local);
                   // LogMessage("Формат пикселей: " + Massive2Save[i].PixelFormat.ToString());
                }
                catch (Exception e3)
                {
                    LogError("Сохранение " + i.ToString() + " не произошло.");
                    LogError("ORIGINAL: " + e3.Message);
                }
            }
            try
            {
                rval[pSteps].SaveAsTiff(SnapImageStyle.Directory + NameDirectory +SCRName + "_" + date + "_" + pFinishWL.ToString() + SnapImageStyle.Extension);
                // LogMessage("Формат пикселей: " + Massive2Save[i].PixelFormat.ToString());
            }
            catch (Exception e3)
            {
                LogError("Сохранение " + pSteps.ToString() + " не произошло.");
                LogError("ORIGINAL: " + e3.Message);
            }
            SetInactiveDependence(1);
            TBwl.Text = wlcurrentg.ToString();
            SetInactiveDependence(0);
        }
        private void New_SnapAndSaveMassive(int pStartWL, int pFinishWL, int pSteps,float[] WLVals = null)
        {
            TIS.Imaging.ImageBuffer[] rval = new TIS.Imaging.ImageBuffer[pSteps + 1];
            ReadAllSettingsFromFile(false);
            int codeerr = 0;
            bool IsNeeded_ExpCurve = ChkBLoadedExpCurve.Checked;
            double Gain = 0, FPS = 0;
            List<int> wls = new List<int>();
            List<double> exps = new List<double>();
            if (IsNeeded_ExpCurve)
            {
                ExpCurve.Get_andWrite_NiceCurveFromDirectory(WayToCurv_exp, MinimumWL, MaximumWL,pStartWL, pFinishWL, (int)wlstepg, ref wls, ref exps,ref Gain,ref FPS);
            }

            List<float> allvalues = new List<float>();
            List<double> Times2SetWL = new List<double>();
            List<double> Times2SnapImage = new List<double>();
            List<double> Times2CopyImage = new List<double>();
            //List<double> Times2CopyImage = new List<double>();
            if (WLVals == null)
            {
                for (int i = 0; i < pSteps; i += 1)
                {
                    wlcurrentg = pStartWL + i * wlstepg;
                    allvalues.Add(wlcurrentg);
                }
                allvalues.Add(pFinishWL);
                if (allvalues[pSteps] == allvalues[pSteps - 1]) allvalues.RemoveAt(pSteps);
            }
            else
            {
                allvalues = new List<float>(WLVals);
            }
            int psteps2 = allvalues.Count;
            if (icImagingControl1.ImageRingBufferSize < allvalues.Count)
            {
                icImagingControl1.LiveStop();
                icImagingControl1.ImageRingBufferSize = allvalues.Count;
                icImagingControl1.LiveStart();
            }
            if (WarningofImage) { LogError(WarningofImgMessage); }
            else
            {
                try
                {
                    codeerr = AOF.AOM_SetWL(wlming, AOFSimulatorActivated);
                    if (IsNeeded_ExpCurve)
                    {
                        LoadExposure(ref AbsValExp, exps[0]);
                        LoadGain(ref vcdProp, Gain);
                    }
                    Thread.Sleep(500);
                    if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
                // System.Threading.Thread.Sleep(20);             
                Stopwatch SessionDone = new Stopwatch(); SessionDone.Start();
                for (int i = 0; i < psteps2; i++)
                {
                    /* try
                     {
                         codeerr = AOF.AOM_SetWL(allvalues[i], AOFSimulatorActivated);
                         if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                     }
                     catch (Exception ex)
                     {
                         LogError(ex.Message);
                     }*/
                    if (IsNeeded_ExpCurve)
                        LoadExposure(ref AbsValExp, exps[i]);

                    Stopwatch swl = new Stopwatch(); swl.Start();
                    AOF.AOM_SetWL(allvalues[i], AOFSimulatorActivated);
                    swl.Stop();
                    Times2SetWL.Add(swl.Elapsed.TotalMilliseconds);

                    Stopwatch swl2 = new Stopwatch(); swl2.Start();
                    curfhs.SnapImage();
                    swl2.Stop();
                    Times2SnapImage.Add(swl2.Elapsed.TotalMilliseconds);

                    Stopwatch swl3 = new Stopwatch(); swl3.Start();
                    rval[i] = curfhs.LastAcquiredBuffer;
                    swl3.Stop();
                    Times2CopyImage.Add(swl3.Elapsed.TotalMilliseconds);

                }
                SessionDone.Stop();
                double MediumTime2SWL = 0;
                double MediumTime2SI = 0;
                double MediumTime2CI = 0;
                for (int i = 0; i < Times2SetWL.Count; i++) { MediumTime2SWL += Times2SetWL[i]; }
                for (int i = 0; i < Times2SnapImage.Count; i++) { MediumTime2SI += Times2SnapImage[i]; }
                for (int i = 0; i < Times2CopyImage.Count; i++) { MediumTime2CI += Times2CopyImage[i]; }
                MediumTime2SWL /= Times2SetWL.Count;
                MediumTime2SI /= Times2SnapImage.Count;
                MediumTime2CI /= Times2CopyImage.Count;
                LogMessage("Среднее время на перестройку: " + MediumTime2SWL.ToString());
                LogMessage("Среднее время на захват: " + MediumTime2SI.ToString());
                LogMessage("Среднее время на копирование:  " + MediumTime2CI.ToString());
                LogMessage("Захват кадров завершен. Прошедшее время: " + SessionDone.Elapsed.ToString());
                LogMessage("Заявленное FPS: " + icImagingControl1.DeviceFrameRate);
                LogMessage("Реальное   FPS: " + (((double)(psteps2)) / SessionDone.Elapsed.TotalSeconds).ToString());
            }
            
            string SCRName = CheckScreenShotBasicName();
            string date = GetDateString();
            string NameDirectory = GetFullDateString() + "\\";
            Directory.CreateDirectory(SnapImageStyle.Directory + NameDirectory);
            for (int i = 0; i < psteps2; i++)
            {
                try
                {
                    string local = SnapImageStyle.Directory + NameDirectory + SCRName + "_" + date + "_" + 
                        ((int)allvalues[i]).ToString() + SnapImageStyle.Extension;
                    if(File.Exists(local))
                    {
                        int num = 1;
                        while(File.Exists(local))
                        {
                            num++;
                            local = SnapImageStyle.Directory + NameDirectory + SCRName + "_" + date + "_" +
                        ((int)allvalues[i]).ToString()+ "_"+num.ToString() + SnapImageStyle.Extension;
                        }
                    }
                    rval[i].SaveAsTiff(local);
                    // LogMessage("Формат пикселей: " + Massive2Save[i].PixelFormat.ToString());
                }
                catch (Exception e3)
                {
                    LogError("Сохранение " + i.ToString() + " не произошло.");
                    LogError("ORIGINAL: " + e3.Message);
                }
            }
            SetInactiveDependence(1);
            TBwl.Text = wlcurrentg.ToString();
            SetInactiveDependence(0);
        }
        private void SaveMassive(Bitmap[] Massive2Save)
        {
            string SCRName = CheckScreenShotBasicName();
            Bitmap /*orig,*/ clone; int curWidth, curHeight;
            System.Drawing.Imaging.ImageFormat format = null; Graphics gr;
            if (SnapImageStyle.Extension == ".bmp") { format = System.Drawing.Imaging.ImageFormat.Bmp; }
            else if (SnapImageStyle.Extension == ".jpg") { format = System.Drawing.Imaging.ImageFormat.Jpeg; }
            else { format = System.Drawing.Imaging.ImageFormat.Tiff; }
            int Number = Massive2Save.Count();
            var List2 = new List<Bitmap>();
            // Bitmap[] Mass2 = new Bitmap[Number];
            System.Drawing.Imaging.PixelFormat CurrentPXF = (System.Drawing.Imaging.PixelFormat)CBSavingPixelFormat.SelectedItem;
            try { curWidth = Massive2Save[0].Width; curHeight = Massive2Save[0].Height; }
            catch { LogError("Сохранение не произведено"); return; }
            string date = GetDateString();
            List<int> Mistakes = new List<int>();
            //конвертирование форматов
             for (int i = 0; i < Number; i++)
             {
                // orig = new Bitmap(Massive2Save[i]);
                 try
                 {
                     clone = new Bitmap(Massive2Save[i].Width, Massive2Save[i].Height, (System.Drawing.Imaging.PixelFormat)CBFinalPixelFormat.SelectedItem);
                   //  clone = new Bitmap(orig.Width, orig.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                 }
                 catch (Exception e2)
                 {
                     LogError(i.ToString() + " " + e2.Message);
                     Mistakes.Add(i);
                     clone = new Bitmap(Massive2Save[i].Width, Massive2Save[i].Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                 }
                 try
                 {
                     using (gr = Graphics.FromImage(clone))
                     {
                         gr.DrawImage(Massive2Save[i], new Rectangle(0, 0, clone.Width, clone.Height));
                     }
                     LogMessage("Формат пикселей " + clone.PixelFormat.ToString() + " установлен");
                 }
                 catch (Exception e1)
                 {
                     LogError(i.ToString()+" Формат пикселей " + clone.PixelFormat.ToString() + " не установлен");
                     LogMessage("Причина: " + e1.ToString());
                     Mistakes.Add(i);
                 }
                 Massive2Save[i] = clone;
             }
             

            for (int i = 0; i < Number; i++)
            {
                try
                {
                    wlcurrentg = wlming + i * wlstepg;
                    Massive2Save[i].Save(SnapImageStyle.Directory + SCRName + "_" + date + "_" + wlcurrentg.ToString() + SnapImageStyle.Extension, format);
                    LogMessage("Формат пикселей: " + Massive2Save[i].PixelFormat.ToString());
                }
                catch (Exception e3)
                {
                    LogError("Сохранение " + i.ToString() + " " + e3.Message);
                }
            }
            
            SetInactiveDependence(1);
            TBwl.Text = wlcurrentg.ToString();
            SetInactiveDependence(0);
        }
        private void SnapSequence2img()
        {
          /*  ReadAllSettingsFromFile(false);
            if (WarningofImage)
            {
                MessageBox.Show(WarningofImgMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            float MinEx = (float)(TrBExposureVal.Minimum)/1000000.0f;
            float MaxEx = (float)(TrBExposureVal.Maximum)/1000000.0f;
            double PrexEx = AbsValExp.Value;
            if ((Ex1 <= MinEx) || (Ex1 >= MaxEx)) { LogError(String.Format("Введите допустимое время экспонирования.Min: {0} ; Max: {1}", MinEx, MaxEx)); return; }
            if ((Ex2 <= MinEx) || (Ex2 >= MaxEx)) { LogError(String.Format("Введите допустимое время экспонирования.Min: {0} ; Max: {1}", MinEx, MaxEx)); return; }
          
            filedatename = DateTime.Now.ToString();
            filedatename = filedatename.Replace(' ', '_');
            filedatename = filedatename.Replace(':', '_');
            filedatename = filedatename.Replace('.', '_');
            AbsValExp.Value = Ex1;
            Thread.Sleep((int)PerfectRounding(Ex1 * 1000,0));           
            TIS.Imaging.ImageBuffer buf = GrabImage(TIS.Imaging.MediaSubtypes.Y16);
            NewWrite16Bit(ref buf, SnapImageStyle.Directory + "3_1st_" + filedatename);
           
            filedatename = DateTime.Now.ToString();
            filedatename = filedatename.Replace(' ', '_');
            filedatename = filedatename.Replace(':', '_');
            filedatename = filedatename.Replace('.', '_');
            AbsValExp.Value = Ex2;
            Thread.Sleep((int)PerfectRounding(Ex2 * 1000,0));
            buf = GrabImage(TIS.Imaging.MediaSubtypes.Y16);
            NewWrite16Bit(ref buf, SnapImageStyle.Directory + "3_2st_" + filedatename);
           AbsValExp.Value = PrexEx;*/
    
        }
        private TIS.Imaging.ImageBuffer GrabImage(Guid colorFormat)
        {
            bool wasLive = icImagingControl1.LiveVideoRunning;
            icImagingControl1.LiveStop();
            TIS.Imaging.BaseSink oldSink = icImagingControl1.Sink;
            TIS.Imaging.FrameHandlerSink fhs = new TIS.Imaging.FrameHandlerSink();
            fhs.FrameTypes.Add(new TIS.Imaging.FrameType(colorFormat));
            icImagingControl1.Sink = fhs;

            try
            {
                icImagingControl1.LiveStart();
            }
            catch (TIS.Imaging.ICException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            TIS.Imaging.ImageBuffer rval = null;

            try
            {
                fhs.SnapImage((int)(2000.0f));
                rval = fhs.LastAcquiredBuffer;
            }
            catch (TIS.Imaging.ICException ex)
            {
                MessageBox.Show(ex.Message);
            }

            icImagingControl1.LiveStop();

            icImagingControl1.Sink = oldSink;

            if (wasLive) icImagingControl1.LiveStart();

            return rval;
        }
        private void NewWrite16Bit(ref ImageBuffer buf,string name)
        {
            UInt32 px1 = ReadY16(buf, 0, 0);
            LogMessage("PX 0,0 is " +px1.ToString());
         /*   WriteY16(ref buf, 0, 0, 0xFFFF);
            WriteY16(ref buf, 1, 1, 0xFFFF);
            WriteY16(ref buf, 2, 2, 0xFFFF);
            WriteY16(ref buf, 3, 3, 0xFFFF);
            WriteY16(ref buf, 4, 4, 0xFFFF);*/
            buf.SaveAsTiff(name + ".tiff");
        }
        private UInt16 ReadY16(TIS.Imaging.ImageBuffer buf, int row, int col)
        {
            // Y16 is top-down, the first line has index 0
            int offset = row * buf.BytesPerLine + col * 2;

            return (UInt16)System.Runtime.InteropServices.Marshal.ReadInt16(buf.GetIntPtr(), offset);
        }
        private void WriteY16(ref TIS.Imaging.ImageBuffer buf, int row, int col, UInt16 value)
        {
            int offset = row * buf.BytesPerLine + col * 2;

            System.Runtime.InteropServices.Marshal.WriteInt16(buf.GetIntPtr(), offset, (short)value);
        }
        private string GetDateString()
        {
            string res = DateTime.Today.ToString();
            return ((res.Substring(0, res.IndexOf(' '))).Remove(res.IndexOf('.'), 1)).Remove(res.LastIndexOf('.') - 1, 1);             
        }
        public static string GetFullDateString()
        {
            return DateTime.Now.ToString().Replace('.', '_').Replace(' ', '_').Replace(':', '_');
        }
        private void OpenDevSearcher()
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
                    L_RealDevName.Text = OPF.FileName.Substring(k, OPF.FileName.Length - k);
                }
                catch (Exception ex)
                {
                    LogError("Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private string OpenExpcfgSearcher()
        {
            string result = "";
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.InitialDirectory = Application.StartupPath;
            OPF.Filter = "Exposure curve files (*.expcurv)|*.expcurv| Exposure FullCurve files (*.fexpcurv)|*.fexpcurv|All files (*.*)|*.*";
            OPF.FilterIndex = 0;
            OPF.RestoreDirectory = true;

            if (OPF.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int k = 1 + OPF.FileName.LastIndexOf('\\');
                    result = OPF.FileName.Substring(k, OPF.FileName.Length - k);
                }
                catch (Exception ex)
                {
                    LogError("Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return result;
        }
       public static double PerfectRounding(double val, int CharN)
        {
            double mnoj = (float)Math.Pow(10.0, CharN);
            val *= mnoj;
            if (Math.Abs(val - (int)val) > 0.5f) return (((int)val + 1 * Math.Sign(val - (int)val)) / mnoj);
            else return ((int)val / mnoj);
        }
        private void ConnectAOF()
        {
            try
            {
                int codeerr = 0;
                int num=-1;
                try { num = AOF.AOM_GetNumDevices(AOFSimulatorActivated);}
                catch { LogError("Ошибка в функции AOM_GetNumDevices"); }
                try
                {
                    codeerr = AOF.AOM_Init(0, AOFSimulatorActivated);
                }
                catch { LogError("Ошибка в функции AOM_Init"); }
                /*if (codeerr == 4)
                    try
                    {
                        var newpath = "aom_v2.dll";
                        AOF.basepath = newpath ;
                        codeerr = AOF.AOM_Init(0, AOFSimulatorActivated);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                */
                try
                {
                    if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                }
                catch { LogError("Ошибка в функции AOM_IntErr"); }
                StringBuilder cfgname2 = new StringBuilder(7);
                try
                {
                    codeerr = AOF.AOM_GetID(cfgname2, AOFSimulatorActivated);
                }
                catch { LogError("Ошибка в функции AOM_GetID"); }
                L_ReqDevName.Text = cfgname2.ToString()+".dev";
                if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                float wlmin = 0.0f;
                float wlmax = 0.0f;

                string cfgname = L_RealDevName.Text;// cfgname2.ToString() + ".dev";

                codeerr = AOF.AOM_LoadSettings(cfgname, ref wlmin, ref wlmax);
                if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); };
                
                wlming = wlmin; wlmaxg = wlmax; wlcurrentg = (wlmaxg + wlming) / 2;
                LoadingAOFValues = true;
                TBStepL.Text = wlstepg.ToString();
                MaximumWL = (int)wlmaxg; ; MinimumWL = (int)wlming;
                TrBCurrentWL.Maximum = (int)wlmaxg;
                TrBCurrentWL.Minimum = (int)wlming;
                TrBWLNumber.Minimum = (int)(ConvertWL2WN(wlmaxg));
                TrBWLNumber.Maximum = (int)(ConvertWL2WN(wlming));
                                       
                TBwl.Text = wlcurrentg.ToString();
                TBwn.Text = ConvertWL2WN(wlcurrentg).ToString();
                TrBCurrentWL.Value =(int) wlcurrentg;
                TrBWLNumber.Value = (int)ConvertWL2WN(wlcurrentg);
                
                TBStartL.Text = wlming.ToString();
                TBFinishL.Text = wlmaxg.ToString();   
                TBStartN.Text = ConvertWL2WN(wlming).ToString();
                TBFinishN.Text = ConvertWL2WN(wlmaxg).ToString();
                LoadingAOFValues = false;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        private static void IC_DigitalIO(ICImagingControl ctrl,bool SetActive)
        {
            if(SetActive) { }
            else { }
        }
        private void TrBWLOnScroll()
        {
            int codeerr = 0;
            float wcurrent = 0;
            wcurrent = Convert.ToInt32(TrBCurrentWL.Value);
            TBwl.Text = wcurrent.ToString();
            TBwn.Text = ConvertWL2WN(wcurrent).ToString();           
            if(AutoSetActivated)
            try
            {
                TrBWLNumber.Value = (int)ConvertWL2WN(wcurrent);
                codeerr = AOF.AOM_SetWL(wcurrent, AOFSimulatorActivated);
                if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); }
                else LogMessage(TBwl.Text + " wave lenght has been set!");
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        private void TrBWNOnScroll()
        {
            int codeerr = 0;
            float wcurrentN = 0;
            wcurrentN = Convert.ToInt32( TrBWLNumber.Value);
            TBwn.Text = wcurrentN.ToString();
            TBwl.Text = ((int)ConvertWN2WL(wcurrentN)).ToString();
            TrBCurrentWL.Value = (int)ConvertWN2WL(wcurrentN);
            if (AutoSetActivated)
                try
                {
                    codeerr = AOF.AOM_SetWL(ConvertWN2WL(wcurrentN), AOFSimulatorActivated);
                    if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); }
                    else LogMessage(TBwl.Text + " wave lenght has been set!");
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                }
        }
        private void TBWLTextChanged()
        {
            ChB_AutoSetWL.Checked = false;
            try
            { 
            int curWL = Convert.ToInt16(TBwl.Text);
            TBwn.Text = ConvertWL2WN(curWL).ToString();
            
            TrBCurrentWL.Value = curWL;
            TrBWLNumber.Value = (int)ConvertWL2WN(curWL);
            }
            catch { LogError("Указанное значение находится вне диапазона"); }

        }
        private void TBWNTextChanged()
        {
            ChB_AutoSetWL.Checked = false;
            try
            {
            int curWN = Convert.ToInt16(TBwn.Text);
            TBwl.Text = ((int)ConvertWN2WL(curWN)).ToString();
            
                TrBCurrentWL.Value = (int)ConvertWN2WL(curWN);
                TrBWLNumber.Value = curWN;
            }
            catch { LogError("Указанное значение находится вне диапазона"); }
        }
        private void BSetWLOnClick()
        {
            int codeerr = 0;
            try
            {
                codeerr = AOF.AOM_SetWL(Convert.ToInt32(TBwl.Text), AOFSimulatorActivated);
                if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); }
                else LogMessage(TBwl.Text + " wave lenght has been set!");
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        private void PowerAOF()
        {
            try
            {
                int codeerr = 0;
                codeerr = AOF.AOM_PowerOn(AOFSimulatorActivated);
                if (codeerr != 0) { throw new Exception(AOF.AOM_IntErr(codeerr)); }
                else { LogMessage(" AOF Power is ON"); AOFisON = true; GrBAOFWlSet.Enabled = true; }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        private string CheckScreenShotBasicName()
        {
            string result = "ScreenShot";
            if ((TBNamePrefix.Text != "") && (TBNamePrefix.Text != null)) result = TBNamePrefix.Text;
            return result;
        }
        private int CalculateSteps()
        {
            wlstepg = Convert.ToInt16(TBStepL.Text);
            wlcurrentg = Convert.ToInt16(TBwl.Text);
            wlming = StartL = Convert.ToInt32(TBStartL.Text);
            wlmaxg = EndL = Convert.ToInt32(TBFinishL.Text);
            int steps = (int)((EndL - StartL) / wlstepg) + 1;
            return steps;
        }
        private void DisableAlltheShit()
        {
            TBROIHeight.Enabled = false;
            TBROIWidth.Enabled = false;
            TBROIPointX.Enabled = false;
            TBROIPointY.Enabled = false;
            TBStartN.Enabled = false;
            TBFinishN.Enabled = false;
            textBox3.Enabled = false;

            CBFinalPixelFormat.Enabled = false;

            label19.Visible = false;
            CBFinalPixelFormat.Visible = false;
            CBoxPixelFormat.Enabled = false;
            CBSavingPixelFormat.Enabled = false;
        }
        private float ConvertWL2WN(float WL) {  return 10000000.0f / (WL); }
        private float ConvertWN2WL(float WN) { return 10000000.0f / (WN); }
        private void TestAvailability(bool Visual)
        {
            if(Visual) LogMessage(DateTime.Today.ToString());                
            var ic = icImagingControl1;
            try
            {
                ChBROIAutoCent.Enabled = ACenterAvailible = Is_Partial_scan_Auto_center_Available(ic);
                if (Visual) LogMessage("Существование функции центрирования ROI: " + ACenterAvailible.ToString());
                if (ACenterAvailible)
                {
                    if (Get_Partial_scan_Auto_center_Switch(ic))
                        if (Visual) LogMessage("Функция центрирования ROI включена");
                        else if (Visual) LogMessage("Функция центрирования ROI отключена");
                }
            }
            catch (Exception e) { LogError(e.Message); }
            try
            {
                Set_Partial_scan_Auto_center_Switch(icImagingControl1, true);
                if (Visual) LogMessage("Попытка включения функции центрирования ROI программно. Состояние: " +
                    Get_Partial_scan_Auto_center_Switch(ic).ToString());
                ChBROIAutoCent.Checked = Get_Partial_scan_Auto_center_Switch(ic);
            }
            catch (Exception e) { LogError(e.Message); }
            try
            {
                TBROIPointX.Enabled = ScanXOffsetAvailible = IsPartial_scanX_OffsetAvailable(ic);
                TBROIPointY.Enabled = ScanYOffsetAvailible = IsPartial_scanY_OffsetAvailable(ic);
                if (Visual) LogMessage("Доступность функций смещения ROI по осям: X: " +
                    ScanXOffsetAvailible.ToString() + "; Y: " + ScanYOffsetAvailible.ToString());
            }
            catch (Exception e) { LogError(e.Message); }
            try
            {
                int Value = GetPartial_scanX_OffsetValue(ic);
                int Minimum = GetPartial_scanX_OffsetMin(ic);
                int Maximum = PointXMax = GetPartial_scanX_OffsetMax(ic);
                TBROIPointX.Text = Value.ToString();
                if (Visual) LogMessage("Попытка получения граничных значений PointX . Состояние: Min:" +
                    Minimum.ToString() + "; Max: " + Maximum.ToString() + " . Текущее значение: " + Value.ToString());
            }
            catch (Exception e) { LogError(e.Message); }
            try
            {
                int Value = GetPartial_scanY_OffsetValue(ic);
                int Minimum = GetPartial_scanY_OffsetMin(ic);
                int Maximum = PointYMax = GetPartial_scanY_OffsetMax(ic);
                TBROIPointY.Text = Value.ToString();
                if (Visual) LogMessage("Попытка получения граничных значений PointY . Состояние: Min:" +
                    Minimum.ToString() + "; Max: " + Maximum.ToString() + " . Текущее значение: " + Value.ToString());
            }
            catch (Exception e) { LogError(e.Message); }
            try
            {
                if (Visual) LogMessage("Текущий формат захвата изображения: " + ic.MemoryCurrentGrabberColorformat.ToString());
            }
            catch (Exception e) { LogError(e.Message); }
        }
        private void TestAOF_dll()
        {
            LogMessage("Direct search of aom.dll and aom_old.dll");
            if(File.Exists("aom.dll")) LogMessage("aom.dll has been found in application directory.");
            else LogMessage("aom.dll has NOT been found in application directory!");
            if (File.Exists("aom_old.dll")) LogMessage("aom_old.dll has been found in application directory.");
            else LogMessage("aom_old.dll has NOT been found in application directory!");

            string baseapppath = Application.StartupPath+"\\";
            LogMessage("Search of "+baseapppath+" aom.dll and "+baseapppath+" aom_old.dll");
            if (File.Exists(baseapppath+"aom.dll")) LogMessage("aom.dll has been found in application directory.");
            else LogMessage("aom.dll has NOT been found in application directory!");
            if (File.Exists(baseapppath + "aom_old.dll")) LogMessage("aom_old.dll has been found in application directory.");
            else LogMessage("aom_old.dll has NOT been found in application directory!");
        }
        private void GetAllResolutionsByFormat()
        {
            var ic = icImagingControl1;
            CBMResolution.Items.Clear();
            CBMResolution.Items.Add("User");
            int real_count = ic.VideoFormats.Count();
            for (int i = 0; i < real_count; i++)
            {             
                if (ic.VideoFormats[i].ToString().Contains(CBSignalFormats.SelectedItem.ToString()))
                {
                    CBMResolution.Items.Add(ic.VideoFormats[i]);
                }//ic.VideoFormatCurrent.Name) { index = i; CBMResolution.SelectedIndex = i; Found = true; break; }
            }
        }
        private void FindCurrentFormat(bool ShowFormat)
        {
            var ic = icImagingControl1; bool Found = false;
            int index = 0;
            for (int i = 0; i < CBMResolution.Items.Count; i++)
            {
                if (CBMResolution.Items[i].ToString() == ic.VideoFormatCurrent.Name) { index = i; CBMResolution.SelectedIndex = i; Found = true; break; }
            }
            if (!Found) CBMResolution.SelectedIndex = 0;
            if (ShowFormat) LogMessage("Format: " + ic.VideoFormatCurrent.Name);
            RefreshROIControls(false);
        }
        private void AnalyseFormats()
        {
            var ic = icImagingControl1;
            string format = ic.VideoFormats[0].Name.Substring(0, ic.VideoFormats[0].Name.IndexOf(' ')); string newformat = null;
            CBSignalFormats.Items.Add(format);
            for (int i = 0; i < ic.VideoFormats.Count(); i++)
            {
                newformat = ic.VideoFormats[i].Name.Substring(0, ic.VideoFormats[i].Name.IndexOf(' '));
                if (newformat != format)
                {
                    CBSignalFormats.Items.Add(newformat);
                    format = newformat;
                }
            }
            string currentformat = ic.VideoFormatCurrent.Name.Substring(0, ic.VideoFormatCurrent.Name.IndexOf(' '));
            int j = 0;
            for (j = 0; j < CBSignalFormats.Items.Count; j++)
            {
                if (CBSignalFormats.Items[j].ToString() == currentformat) break;
            }
          //  CBSignalFormats.SelectedIndex = j; //перенесено в конец функции для последовательного срабатывания других функций по событиям*
            //getting MAX width and height
            string maxformat = ic.VideoFormats[ic.VideoFormats.Count() - 1];

            int op_pos = maxformat.IndexOf('(') + 1;
            int cl_pos = maxformat.LastIndexOf(')');
            int s_lenght = cl_pos - op_pos;
            int x_pos = maxformat.LastIndexOf('x');
            string str_MWidth = maxformat.Substring(op_pos, x_pos - op_pos);
            string str_MHeight = maxformat.Substring(x_pos+1, maxformat.Length - x_pos-2);            
            try
            {
                 MaxMWidth = Convert.ToInt16(str_MWidth);
                 MaxMHeight = Convert.ToInt16(str_MHeight);
            }
            catch
            {
                LogError("Ошибка при определении максимального размера матрицы");
            }

            CBSignalFormats.SelectedIndex = j; // перенес сюда*

        }
        private void DetectCameraPixelFormats()
        {
            var ic = icImagingControl1; string remstr;
            /*int index = 0;
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICBY8);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICRGB24);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICRGB32);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICRGB555);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICRGB565);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICUYVY);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICY16);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICY8);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICY800);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICYGB0);
            CBoxPixelFormat.Items.Add(ICImagingControlColorformats.ICYGB1);*/
            try
            {
                remstr = ic.MemoryCurrentGrabberColorformat.ToString();
            }
            catch { LogError("Формат пикселей на матрице не установлен. Скорее всего, вы используйте не IC камеру"); return; }
          /*  for (int i = 0; i < CBoxPixelFormat.Items.Count; i++)
            {
                try
                {
                    ic.MemoryCurrentGrabberColorformat = (ICImagingControlColorformats)CBoxPixelFormat.Items[i];
                }
                catch (Exception e)
                {
                    CBoxPixelFormat.Items.RemoveAt(i); i--;
                }
            }
            for (int i = 0; i < CBoxPixelFormat.Items.Count; i++)
            {
                if (remstr == CBoxPixelFormat.Items[i].ToString())
                {
                    ic.MemoryCurrentGrabberColorformat = (ICImagingControlColorformats)CBoxPixelFormat.Items[i];
                    CBoxPixelFormat.SelectedIndex = i; break;
                }
            }*/
        }
        private void GetAllPixelFormats()
        {
            var ic = icImagingControl1;
            int index = -1;
            CBSavingPixelFormat.Items.Clear();
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Alpha);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Canonical);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.DontCare);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Extended);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format16bppArgb1555);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format16bppRgb565);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format1bppIndexed);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format48bppRgb);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format4bppIndexed);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format64bppPArgb);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Gdi);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Indexed);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Max);
            CBSavingPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.PAlpha);
            if(ic.LiveVideoRunning) ic.LiveStop();
            var previous_px_format = ic.MemoryPixelFormat;
            for (int i = 0; i < CBSavingPixelFormat.Items.Count; i++)
            {
                try
                {
                    ic.MemoryPixelFormat = (System.Drawing.Imaging.PixelFormat)CBSavingPixelFormat.Items[i];
                }
                catch (Exception e)
                {
                    CBSavingPixelFormat.Items.RemoveAt(i); i--;
                }
            }
            ic.MemoryPixelFormat = previous_px_format;
            try
            {
                for (int i = 0; i < CBSavingPixelFormat.Items.Count; i++)
                {
                    if (ic.MemoryPixelFormat.ToString() == CBSavingPixelFormat.Items[i].ToString())
                    { index = i; CBSavingPixelFormat.SelectedIndex = i; break; }
                }
            }
            catch //06.06 не внес в эту ветвь правки,поправить позже
            {
                if (ic.VideoFormatCurrent.BinningFactor != 1)
                {
                    LogMessage("Задержка при загрузке программы при определении формата пикселей. ");
                    LogMessage("Причина: попытка определения формата пикселей при включенном биннинге.");
                    LogMessage("Попытка вторичного определения...");

                    var currentFormat = ic.VideoFormatCurrent;
                    ic.VideoFormat = ic.VideoFormats[ic.VideoFormats.Count() - 1];
                    ic.LiveStart(); ic.LiveStop();
                    for (int i = 0; i < CBSavingPixelFormat.Items.Count; i++)
                    {
                        if (ic.MemoryPixelFormat.ToString() == CBSavingPixelFormat.Items[i].ToString())
                        { index = i; CBSavingPixelFormat.SelectedIndex = i; break; }
                    }
                    ic.VideoFormat = currentFormat;
                    if (index != -1) LogMessage("Формат пикселей определен: " + CBSavingPixelFormat.Items[index].ToString());
                }
            }
            var PXFormatToSet = (System.Drawing.Imaging.PixelFormat)CBSavingPixelFormat.Items[index];           
            ic.MemoryPixelFormat = PXFormatToSet;
            
        }
        private void GetAllPixelFormatsForSaving()
        {
            CBFinalPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            CBFinalPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format16bppRgb565); 
            CBFinalPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            CBFinalPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format32bppArgb);  
            CBFinalPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            CBFinalPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            CBFinalPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format48bppRgb);
            CBFinalPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format64bppArgb);
            CBFinalPixelFormat.Items.Add(System.Drawing.Imaging.PixelFormat.Format64bppPArgb);
            CBFinalPixelFormat.SelectedIndex = 0;
        }
        private void GetAllAvailibleFPS()
        {
            var ic = icImagingControl1; CBAvFPS.Items.Clear();
            for (int i = 0; i < ic.DeviceFrameRates.Count(); i++)
            {
                CBAvFPS.Items.Add(ic.DeviceFrameRates[i]);
            }
        }
        private void FindCurrentFPS(bool IsFPSFreshNeeded)
        {
            bool WasFound = false;
            var FPSCur = icImagingControl1.DeviceFrameRate;
            bool a = icImagingControl1.LiveVideoRunning;
            if (!a) a = false;
            for (int i = 0; i < CBAvFPS.Items.Count; i++)
            {
                if (Convert.ToDouble(CBAvFPS.Items[i]) == FPSCur)
                {
                    CBAvFPS.SelectedIndexChanged -= new EventHandler(CBAvFPS_SelectedIndexChanged);
                    CBAvFPS.SelectedIndex = i;
                    CBAvFPS.SelectedIndexChanged += new EventHandler(CBAvFPS_SelectedIndexChanged);

                    WasFound = true; break;
                }
            }
            FPSChangeCausedByUser = IsFPSFreshNeeded;
            if (!WasFound) CBAvFPS.SelectedIndex = 0;
            FPSChangeCausedByUser = true;
        }
        private void ChangeFPS()
        {
            if (FPSChangeCausedByUser)
            {
                float SelectedRate = icImagingControl1.DeviceFrameRates[CBAvFPS.SelectedIndex];
                try { icImagingControl1.LiveStop(); }
                catch { }
                icImagingControl1.DeviceFrameRate = SelectedRate;
                try { icImagingControl1.LiveStart(); }
                catch { }
            }
        }
        private void RefreshROIControls(bool CausedByChangingFormatByUser)
        {
            RefreshROIControls(CausedByChangingFormatByUser, false);
        }

        private void SetMaxValuesToROIControls()
        {
            TBROIWidth.Text = MaxMWidth.ToString();
            TBROIHeight.Text = MaxMHeight.ToString();
            TBROIPointX.Text = "0";
            TBROIPointY.Text = "0";
        }
        private void RefreshROIControls(bool CausedByChangingFormatByUser, bool WasError)
        {
            var ic = icImagingControl1;
            if (CBMResolution.SelectedIndex == 0) CbBinning.Enabled = true; else CbBinning.Enabled = false;
            try
            {
                int Value = GetPartial_scanX_OffsetValue(ic);
                TBROIPointX.Text = Value.ToString();
            }
            catch (Exception e) { LogError(e.Message); }
            try
            {
                int Value = GetPartial_scanY_OffsetValue(ic);
                TBROIPointY.Text = Value.ToString();
            }
            catch (Exception e) { LogError(e.Message); }
            try
            {
                int ImHeight = 0; int ImWidth = 0;
                bool WasFound = false;
                TBROIWidth.Enabled = false; TBROIHeight.Enabled = false;
                for (int i = 0; i < ic.VideoFormats.Count(); i++)
                {
                    if (CBMResolution.SelectedItem.ToString() == ic.VideoFormats[i].ToString())
                    {
                        ImWidth = ic.VideoFormats[i].Width; ImHeight = ic.VideoFormats[i].Height; WasFound = true;
                        int BinningOfTheFormat = ic.VideoFormats[i].BinningFactor; break;
                    }
                }
                if (!WasFound)
                {
                    TBROIWidth.Enabled = true; TBROIHeight.Enabled = true;
                    if (ScanXOffsetAvailible && !ACenterFlag) TBROIPointX.Enabled = true; else TBROIPointX.Enabled = false;
                    if (ScanYOffsetAvailible && !ACenterFlag) TBROIPointY.Enabled = true; else TBROIPointY.Enabled = false;
                    if (ACenterAvailible) ChBROIAutoCent.Enabled = true; else ChBROIAutoCent.Enabled = false;
                    if ((CausedByChangingFormatByUser)&&(TBROIWidth.Text != "") && (TBROIHeight.Text != ""))
                    {
                        CbBinning.SelectedIndex = 0; ImWidth = Convert.ToInt16(TBROIWidth.Text); ImHeight = Convert.ToInt16(TBROIHeight.Text);
                    }
                    else { ImWidth = ic.ImageWidth; ImHeight = ic.ImageHeight; }
                }
                if (!WasError)
                {
                    TBROIWidth.Text = ImWidth.ToString();
                    TBROIHeight.Text = ImHeight.ToString();
                }
            }
            catch (Exception e) { LogError(e.Message); }
            try
            {
                int Binning = 1;
                if (!CausedByChangingFormatByUser) Binning = ic.VideoFormatCurrent.BinningFactor;
                if (Binning == 1) CbBinning.SelectedIndex = 0;
                else if (Binning == 2) CbBinning.SelectedIndex = 1;
                else if (Binning == 4) CbBinning.SelectedIndex = 2;
                else { CbBinning.Text = "?"; CbBinning.Enabled = false; }
                PrevSelectedBinning = Binning;
            }
            catch (Exception e) { LogError(e.Message); }
            if (Get_Partial_scan_Auto_center_Switch(icImagingControl1)) ChBROIAutoCent.Checked = true;
            else ChBROIAutoCent.Checked = false;
        }
        private void GetValuesAfterSet()
        {
            var ic = icImagingControl1;
            try
            {
                int Binning = 1;
                Binning = ic.VideoFormatCurrent.BinningFactor;
                if (Binning == 1) CbBinning.SelectedIndex = 0;
                else if (Binning == 2) CbBinning.SelectedIndex = 1;
                else if (Binning == 4) CbBinning.SelectedIndex = 2;
                else { CbBinning.Text = "?"; CbBinning.Enabled = false; }
                PrevSelectedBinning = Binning;
            }
            catch (Exception e) { LogError(e.Message); }
            
            TBROIHeight.Text = ic.VideoFormatCurrent.Height.ToString();
            TBROIWidth.Text = ic.VideoFormatCurrent.Width.ToString();
            if (Get_Partial_scan_Auto_center_Switch(ic)) ChBROIAutoCent.Checked = true;
            else ChBROIAutoCent.Checked = false;
            TBROIPointX.Text = (GetPartial_scanX_OffsetValue(ic) / ic.VideoFormatCurrent.BinningFactor).ToString();
            TBROIPointY.Text = (GetPartial_scanY_OffsetValue(ic) / ic.VideoFormatCurrent.BinningFactor).ToString();

        }
        private bool CheckRight()
        {
            bool ExcCatched = false;
            try { CheckEmptyness(TBROIHeight); }
            catch (Exception e1) { LogError(e1.Message); ExcCatched = true; }
            try { CheckEmptyness(TBROIWidth); }
            catch (Exception e1) { LogError(e1.Message); ExcCatched = true; }
            try { CheckEmptyness(TBROIPointX); }
            catch (Exception e1) { LogError(e1.Message); ExcCatched = true; }
            try { CheckEmptyness(TBROIPointY); }
            catch (Exception e1) { LogError(e1.Message); ExcCatched = true; }
            return ExcCatched;
        }
        private bool SetSelectedFormatAndBinning()
        {
            var ic = icImagingControl1; bool WasFound = false; int i = 0; bool WasErr = false;
            for (i = 0; i < ic.VideoFormats.Count(); i++)
            {
                if (CBMResolution.SelectedItem.ToString() == ic.VideoFormats[i].ToString())
                { WasFound = true; break; }
            }
            if (WasFound) ic.VideoFormat = ic.VideoFormats[i];
            else
            {
                int NewBinning = 1;
                try { NewBinning = (int)Math.Pow(2, CbBinning.SelectedIndex); }

                catch { WasErr = true; LogError("Ошибка преобразования биннинга"); }
                try
                {
                    string VideoStreamFormat = CBSignalFormats.SelectedItem.ToString();
                    CorrectROIValues();
                    int Width = Convert.ToInt16(TBROIWidth.Text); int Height = Convert.ToInt16(TBROIHeight.Text);
                    if (NewBinning != 1) ic.VideoFormat = String.Format(VideoStreamFormat + " ({0}x{1}) [Binning {2}x]",
                        Width, Height, NewBinning);
                    else ic.VideoFormat = String.Format(VideoStreamFormat + " ({0}x{1})", Width, Height);
                }
                catch
                {
                    LogError("Невозможно задать выбранный формат матрицы.");
                    LogError("Попробуйте задать другое значение биннинга или параметров ROI."); WasErr = true;
                }
            }
           
            if (!WasErr) LogMessage("Format has been changed to " + ic.VideoFormatCurrent.Name);
            return WasErr;
            //  ic.VideoFormatCurrent.BinningFactor = NewBinning;
        }
        private bool SetSelectedPartialScan()
        {
            bool result = true;
            if (ACenterAvailible && !ACenterFlag)
            {
                try
                {
                    int PointXN = Convert.ToInt16(TBROIPointX.Text); int PointYN = Convert.ToInt16(TBROIPointY.Text);
                    var ic = icImagingControl1;
                    int CurWidth = ic.VideoFormatCurrent.Width, CurHeight = ic.VideoFormatCurrent.Height;
                    int MaxROIX = -1, MaxROIY = -1;
                    int NeededBinning = (int)Math.Pow(2, CbBinning.SelectedIndex);

                    GetMaximumResolution(ref MaxROIX, ref MaxROIY, NeededBinning);
                    int MaxPointX = (MaxROIX - CurWidth);
                    int MaxPointY = (MaxROIY - CurHeight);
                    if (PointXN > MaxPointX) PointXN = MaxPointX - 8;
                    if (PointYN > MaxPointY) PointYN = MaxPointY - 4;
                    if (PointXN < 0) PointXN = 0;
                    if (PointYN < 0) PointYN = 0;
                    TBROIPointX.Text = PointXN.ToString();
                    TBROIPointY.Text = PointYN.ToString();

                    SetPartial_scanX_OffsetValue(ic, PointXN*NeededBinning);
                    SetPartial_scanY_OffsetValue(ic, PointYN * NeededBinning);
                }
                catch { LogError("Ошибка при смещении ROI "); result = false; }
            }
            return result;
        }
        private void CorrectROIValues()
        {
            if ((TBROIWidth.Text != "") && (TBROIHeight.Text != ""))
            {
                int Width2Set = Convert.ToInt16(TBROIWidth.Text);
                int Height2Set = Convert.ToInt16(TBROIHeight.Text);
                int NeededBinning = (int)Math.Pow(2, CbBinning.SelectedIndex);
                int DevineFact = 8;//(int)Math.Pow(2, NeededBinning);
                var ic = icImagingControl1; int CurrentBinning = ic.VideoFormatCurrent.BinningFactor;
                int RWidth = Width2Set * PrevSelectedBinning * CurrentBinning; int RHeight = Height2Set * CurrentBinning * PrevSelectedBinning;
                if (PrevSelectedBinning == CurrentBinning) { RWidth /= PrevSelectedBinning; RHeight /= PrevSelectedBinning; }
                if (RWidth % DevineFact != 0) RWidth -= RWidth % DevineFact;
                if (RHeight % DevineFact != 0) RHeight -= RHeight % DevineFact;
                if (RWidth < 96) RWidth = 96;
                if (RHeight < 96) RHeight = 96;
                else if ((RHeight == MaxMHeight) && (CbBinning.SelectedIndex != 0)) RHeight -= 8;
                if (PrevSelectedBinning != CurrentBinning)
                { RWidth = RWidth / CurrentBinning; RHeight = RHeight / CurrentBinning; }
                PrevSelectedBinning = NeededBinning;
                int trueWidth = RWidth / NeededBinning, trueHeight = RHeight / NeededBinning;
                if (trueWidth % 8 != 0) trueWidth -= trueWidth % 8;
                if (trueHeight % 4 != 0) trueHeight -= trueHeight % 4;
                TBROIWidth.Text = (trueWidth).ToString();
                TBROIHeight.Text = (trueHeight).ToString();
            }
        }
        private void GetMaximumResolution(ref int MaxX,ref int MaxY,int NeededBinning)
        {
            int DevineFactX = 8, DevineFactY = 4;
            MaxX = MaxMWidth/ NeededBinning; MaxY = MaxMHeight / NeededBinning;
            if (MaxX % DevineFactX != 0) MaxX -= MaxX % DevineFactX;
            if (MaxY % DevineFactY != 0) MaxY -= MaxY % DevineFactY;
        }

        private void SetSelectedCameraPixelFormat()
        {
            var ic = icImagingControl1;
            int index = CBoxPixelFormat.SelectedIndex;
            try
            {
                ic.MemoryCurrentGrabberColorformat = (ICImagingControlColorformats)CBoxPixelFormat.Items[index];
            }
            catch (Exception e)
            {
                LogError(e.Message);
            }
        }
        private TIS.Imaging.BaseSink New_SetSelectedCamera_SignalStream_Format() 
        {
            var ic = icImagingControl1;
            int index = CBSignalFormats.SelectedIndex;
            var name = CBSignalFormats.Items[index].ToString();
            Guid realGuid;
            if (name == "BY8") realGuid = TIS.Imaging.MediaSubtypes.BY8;
            else if (name == "RGB24") realGuid = TIS.Imaging.MediaSubtypes.RGB24;
            else if (name == "RGB32") realGuid = TIS.Imaging.MediaSubtypes.RGB32;
            else if (name == "RGB555") realGuid = TIS.Imaging.MediaSubtypes.RGB555;
            else if (name == "RGB565") realGuid = TIS.Imaging.MediaSubtypes.RGB565;
            else if (name == "RGB8") realGuid = TIS.Imaging.MediaSubtypes.RGB8;
            else if (name == "UYVY") realGuid = TIS.Imaging.MediaSubtypes.UYVY;
            else if (name == "Y16") realGuid = TIS.Imaging.MediaSubtypes.Y16;
            else if (name == "YGB1") realGuid = TIS.Imaging.MediaSubtypes.YGB1;
            else if (name == "YGB0") realGuid = TIS.Imaging.MediaSubtypes.YGB0;
            else if (name == "YUY2") realGuid = TIS.Imaging.MediaSubtypes.YUY2;
            else if (name == "Y800") realGuid = TIS.Imaging.MediaSubtypes.Y800;
            else
            {
                realGuid = TIS.Imaging.MediaSubtypes.RGB24;
            }
            if(ic.LiveVideoRunning) ic.LiveStop();

            TIS.Imaging.BaseSink oldSink = ic.Sink;

            curfhs = new TIS.Imaging.FrameHandlerSink();
            curfhs.FrameTypes.Add(new TIS.Imaging.FrameType(realGuid));
            LoadFlipFilter();
            try
            {
                LogMessage("PixelFormat of new Sink.FrameType is " + curfhs.FrameType.PixelFormat.ToString());
            }
            catch (Exception exf) { LogError("ORIGINAL: "+exf.Message); }
            try
            {
                LogMessage("Name of new Sink.FrameType is " + curfhs.FrameType.Name.ToString());
            }
            catch (Exception exf) { LogError("ORIGINAL: " + exf.Message); }
            try
            {
                LogMessage("Bits per pixel: " + curfhs.FrameType.BitsPerPixel.ToString());
            }
            catch (Exception exf) { LogError("ORIGINAL: " + exf.Message); }
            try
            {
                LogMessage("FourCC: " + curfhs.FrameType.FourCC.ToString());
            }
            catch (Exception exf) { LogError("ORIGINAL: " + exf.Message); }
            ic.Sink = curfhs;
            
            return oldSink;
        }
        private void SetSelectedPixelFormat()
        {
            var ic = icImagingControl1;
            int index = CBSavingPixelFormat.SelectedIndex;
            try
            {
                var a = (System.Drawing.Imaging.PixelFormat)CBSavingPixelFormat.Items[index];
                ic.MemoryPixelFormat = a;
            }
            catch (Exception e)
            {
                LogError(e.Message);
            }
        }
        private void FormatAdaptation()
        {
            var ic = icImagingControl1;
            int WidthOfImage = ic.ImageWidth;
            int HeightOfImage = ic.ImageHeight;
            int ControlWidth = ic.Width;
            int ControlHeight = ic.Height;
            float ZFactWidth = (float)ControlWidth / (float)WidthOfImage;
            float ZFactHeight = (float)ControlHeight / (float)HeightOfImage;
            float ZFactFinal = 100.0f;
            if (ZFactWidth >= ZFactHeight) ZFactFinal = ZFactHeight;
            else ZFactFinal = ZFactWidth;
            TrBZoomOfImage.Visible = true;
            L_Zoom.Visible = true;

            if (icImagingControl1.LiveDisplayDefault == false)
            {
                icImagingControl1.LiveDisplayZoomFactor = ZFactFinal;
                TrBZoomOfImage.Value = (int)(icImagingControl1.LiveDisplayZoomFactor * 100.00f);
                L_Zoom.Text = TrBZoomOfImage.Value.ToString() + "%";
                if (icImagingControl1.LiveDisplayZoomFactor > 1.0) icImagingControl1.ScrollbarsEnabled = true;
                else icImagingControl1.ScrollbarsEnabled = false;
            }
            else
            {
                LogError("The zoom factor can only be set" + "\n" + "if LiveDisplayDefault returns False!");
            }

        }
        private void NormalizeRect(Rectangle val, bool PTest)
        {
            int x1 = val.X, y1 = val.Y;
            int x2 = val.Width, y2 = val.Height;
            if (PTest) LogMessage("1Points:  x1=" + val.X.ToString() + " y1=" + val.Y.ToString() + " ; "
                 + " x2=" + val.Width.ToString() + " y2=" + val.Height.ToString());
            if (x1 > x2) SwapValues(ref x1, ref x2);
            if (y1 > y2) SwapValues(ref y1, ref y2);
            if (PTest) LogMessage("2Points:  x1=" + x1.ToString() + " y1=" + y1.ToString() + " ; "
                + " x2=" + x2.ToString() + " y2=" + y2.ToString());
            UserROIGraphics = new Rectangle(x1, y1, x2, y2);
        }
        private Rectangle NormalizeRect(int px1, int py1, int px2, int py2, bool ptest)
        {
            Rectangle r = new Rectangle(px1, py1, px2, py2);
            NormalizeRect(r, ptest);

            return r;
        }
        private void SwapValues(ref int pa, ref int pb)
        {
            int a = pa; pa = pb; pb = a;
        }
        private void OpenSomeFolder()
        {
            /*  if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
              {
                  TBSavingFolder.Text = folderBrowserDialog1.SelectedPath;
                  WindowsFormsApplication5.Settings.Default.Path = folderBrowserDialog1.SelectedPath;
              }*/
        }

        // ****************************************************************
        // C# functions for Partial_scan Auto_center Switch interface
        //
        // Usage:
        // bool CurrentSwitch;
        // if( Is_Partial_scan_Auto_center_Available(icImagingControl1) )
        // {
        //	CurrentSwitch =  Get_Partial_scan_Auto_center_Switch(icImagingControl1);
        //	Set_Partial_scan_Auto_center_Switch(icImagingControl1, false);
        // }

        private bool Is_Partial_scan_Auto_center_Available(TIS.Imaging.ICImagingControl IC)
        {
            if (IC.DeviceValid)
            {
                TIS.Imaging.VCDSwitchProperty SwitchItf;
                SwitchItf = (TIS.Imaging.VCDSwitchProperty)IC.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset,
                                                            TIS.Imaging.VCDIDs.VCDElement_PartialScanAutoCenter,
                                                            TIS.Imaging.VCDIDs.VCDInterface_Switch);
                if (SwitchItf != null)
                {
                    return true;
                }
            }
            return false;
        }
        private bool Get_Partial_scan_Auto_center_Switch(TIS.Imaging.ICImagingControl IC)
        {
            if (IC.DeviceValid)
            {
                TIS.Imaging.VCDSwitchProperty SwitchItf;
                SwitchItf = (TIS.Imaging.VCDSwitchProperty)IC.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset,
                                                            TIS.Imaging.VCDIDs.VCDElement_PartialScanAutoCenter,
                                                            TIS.Imaging.VCDIDs.VCDInterface_Switch);
                if (SwitchItf != null)
                {
                    return SwitchItf.Switch;
                }
            }
            return false;
        }
        private void Set_Partial_scan_Auto_center_Switch(TIS.Imaging.ICImagingControl IC, bool OnOff)
        {
            if (IC.DeviceValid)
            {
                TIS.Imaging.VCDSwitchProperty SwitchItf;
                SwitchItf = (TIS.Imaging.VCDSwitchProperty)IC.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset,
                                                            TIS.Imaging.VCDIDs.VCDElement_PartialScanAutoCenter,
                                                            TIS.Imaging.VCDIDs.VCDInterface_Switch);
                if (SwitchItf != null)
                {
                    SwitchItf.Switch = OnOff;
                }
            }
        }

        // ****************************************************************
        // C# functions for Partial_scan X_Offset Range interface
        // Usage :
        // int Value, Minimum,Maximum;
        // if( IsPartial_scanX_OffsetAvailable(icImagingControl1) )
        // {
        //  	Value = GetPartial_scanX_OffsetValue(icImagingControl1);
        //  	Minimum = GetPartial_scanX_OffsetMin(icImagingControl1);
        //  	Maximum = GetPartial_scanX_OffsetMax(icImagingControl1);
        //  	SetPartial_scanX_OffsetValue(icImagingControl1, 10);
        // } 
        bool IsPartial_scanX_OffsetAvailable(TIS.Imaging.ICImagingControl ic)
        {
            bool bResult = false;
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset,
                    TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetX,
                    TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    bResult = true;
                }
            }
            return bResult;
        }
        int GetPartial_scanX_OffsetValue(TIS.Imaging.ICImagingControl ic)
        {
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset, TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetX, TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    return Property.Value;
                }
            }

            return 0;
        }
        void SetPartial_scanX_OffsetValue(TIS.Imaging.ICImagingControl ic, int Value)
        {
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset, TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetX, TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    Property.Value = Value;
                }
            }
        }
        int GetPartial_scanX_OffsetMin(TIS.Imaging.ICImagingControl ic)
        {
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset, TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetX, TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    return Property.RangeMin;
                }
            }

            return 0;
        }
        int GetPartial_scanX_OffsetMax(TIS.Imaging.ICImagingControl ic)
        {
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset, TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetX, TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    return Property.RangeMax;
                }
            }
            return 0;
        }

        // ****************************************************************
        // C# functions for Partial_scan Y_Offset Range interface
        // Usage :
        // int Value, Minimum,Maximum;
        // if( IsPartial_scanY_OffsetAvailable(icImagingControl1) )
        // {
        //  	Value = GetPartial_scanY_OffsetValue(icImagingControl1);
        //  	Minimum = GetPartial_scanY_OffsetMin(icImagingControl1);
        //  	Maximum = GetPartial_scanY_OffsetMax(icImagingControl1);
        //  	SetPartial_scanY_OffsetValue(icImagingControl1, 10);
        // } 
        bool IsPartial_scanY_OffsetAvailable(TIS.Imaging.ICImagingControl ic)
        {
            bool bResult = false;
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset, TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetY, TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    bResult = true;
                }
            }
            return bResult;
        }
        int GetPartial_scanY_OffsetValue(TIS.Imaging.ICImagingControl ic)
        {
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset, TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetY, TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    return Property.Value;
                }
            }

            return 0;
        }
        void SetPartial_scanY_OffsetValue(TIS.Imaging.ICImagingControl ic, int Value)
        {
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset, TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetY, TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    Property.Value = Value;
                }
            }
        }
        int GetPartial_scanY_OffsetMin(TIS.Imaging.ICImagingControl ic)
        {
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset, TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetY, TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    return Property.RangeMin;
                }
            }

            return 0;
        }
        int GetPartial_scanY_OffsetMax(TIS.Imaging.ICImagingControl ic)
        {
            if (ic.DeviceValid == true)
            {
                TIS.Imaging.VCDRangeProperty Property;
                Property = (TIS.Imaging.VCDRangeProperty)ic.VCDPropertyItems.FindInterface(TIS.Imaging.VCDIDs.VCDID_PartialScanOffset, TIS.Imaging.VCDIDs.VCDElement_PartialScanOffsetY, TIS.Imaging.VCDIDs.VCDInterface_Range);
                if (Property != null)
                {
                    return Property.RangeMax;
                }
            }
            return 0;
        }
      /*  private void SnapSequence2img()
        {
            ReadAllSettingsFromFile(false);
            if (WarningofImage)
            {
                MessageBox.Show(WarningofImgMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            float MinEx = (float)(TrBExposureVal.Minimum) / 1000000.0f;
            float MaxEx = (float)(TrBExposureVal.Maximum) / 1000000.0f;
            float Ex1 = (float)Convert.ToDouble(TBEx1.Text);
            float Ex2 = (float)Convert.ToDouble(TBEx2.Text);
            double PrexEx = AbsValExp.Value;
            if ((Ex1 <= MinEx) || (Ex1 >= MaxEx)) { LogError(String.Format("Введите допустимое время экспонирования.Min: {0} ; Max: {1}", MinEx, MaxEx)); return; }
            if ((Ex2 <= MinEx) || (Ex2 >= MaxEx)) { LogError(String.Format("Введите допустимое время экспонирования.Min: {0} ; Max: {1}", MinEx, MaxEx)); return; }

            filedatename = DateTime.Now.ToString();
            filedatename = filedatename.Replace(' ', '_');
            filedatename = filedatename.Replace(':', '_');
            filedatename = filedatename.Replace('.', '_');
            TIS.Imaging.ImageBuffer[] buf = GrabImage(TIS.Imaging.MediaSubtypes.Y16, Ex1, Ex2);
            NewWrite16Bit(buf[0], SnapImageStyle.Directory + "3_1st_" + filedatename);
            NewWrite16Bit(buf[1], SnapImageStyle.Directory + "3_2st_" + filedatename);
            AbsValExp.Value = PrexEx;

        }
        private TIS.Imaging.ImageBuffer[] GrabImage(Guid colorFormat, float exposure1, float exposure2)
        {
            bool wasLive = icImagingControl1.LiveVideoRunning;
            icImagingControl1.LiveStop();
            TIS.Imaging.BaseSink oldSink = icImagingControl1.Sink;
            TIS.Imaging.FrameHandlerSink fhs = new TIS.Imaging.FrameHandlerSink();
            fhs.FrameTypes.Add(new TIS.Imaging.FrameType(colorFormat));
            icImagingControl1.Sink = fhs;

            try
            {
                icImagingControl1.LiveStart();
            }
            catch (TIS.Imaging.ICException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            TIS.Imaging.ImageBuffer[] rval = new ImageBuffer[2];

            try
            {
                int var1 = 0, var2 = 0;
                if ((var1 = ((int)(exposure1 * 1000.0f) + 200)) > 500) var1 = 500;
                if ((var2 = ((int)(exposure2 * 1000.0f) + 200)) > 1000) var2 = 1000;
                AbsValExp.Value = exposure1;
                fhs.SnapImage((int)(exposure1 * 1000.0f) + 100);//timeout - время в мс, сколько будет изображение держаться в буфере
                rval[0] = fhs.LastAcquiredBuffer;
                AbsValExp.Value = exposure2;
                fhs.SnapImage((int)(exposure2 * 1000.0f) + 100);
                rval[1] = fhs.LastAcquiredBuffer;
            }
            catch (TIS.Imaging.ICException ex)
            {
                MessageBox.Show(ex.Message);
            }

            icImagingControl1.LiveStop();
            icImagingControl1.Sink = oldSink;
            if (wasLive) icImagingControl1.LiveStart();

            return rval;
        }*/

    }
}

