namespace ICSpec
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.icImagingControl1 = new TIS.Imaging.ICImagingControl();
            this.SaveImgParBut = new System.Windows.Forms.Button();
            this.PropBut = new System.Windows.Forms.Button();
            this.ExitBut = new System.Windows.Forms.Button();
            this.SnapshotBut = new System.Windows.Forms.Button();
            this.ChBExposureAuto = new System.Windows.Forms.CheckBox();
            this.TrBZoomOfImage = new System.Windows.Forms.TrackBar();
            this.L_Zoom = new System.Windows.Forms.Label();
            this.ContTransAfterSnapshot = new System.Windows.Forms.Button();
            this.TimerForRenew = new System.Windows.Forms.Timer(this.components);
            this.SaveImageBut = new System.Windows.Forms.Button();
            this.LBConsole = new System.Windows.Forms.ListBox();
            this.GPCamFeat = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TrBExposureVal = new System.Windows.Forms.TrackBar();
            this.TBROIPointX = new System.Windows.Forms.TextBox();
            this.ChBROIAutoCent = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TBROIWidth = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TrBGainVal = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.LFPS = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CBMResolution = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.BSetROI = new System.Windows.Forms.Button();
            this.BROIFull = new System.Windows.Forms.Button();
            this.BSelectUserResolution = new System.Windows.Forms.Button();
            this.CBoxPixelFormat = new System.Windows.Forms.ComboBox();
            this.CBSignalFormats = new System.Windows.Forms.ComboBox();
            this.CBSavingPixelFormat = new System.Windows.Forms.ComboBox();
            this.CBAvFPS = new System.Windows.Forms.ComboBox();
            this.ChBVisualiseROI = new System.Windows.Forms.CheckBox();
            this.TBROIHeight = new System.Windows.Forms.TextBox();
            this.TBROIPointY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.BAdapt = new System.Windows.Forms.Button();
            this.TBExposureVal = new System.Windows.Forms.TextBox();
            this.TBGainVal = new System.Windows.Forms.TextBox();
            this.ChBGainAuto = new System.Windows.Forms.CheckBox();
            this.CbBinning = new System.Windows.Forms.ComboBox();
            this.LBinning = new System.Windows.Forms.Label();
            this.BTestAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.ChB_Power = new System.Windows.Forms.CheckBox();
            this.L_RealDevName = new System.Windows.Forms.Label();
            this.L_ReqDevName = new System.Windows.Forms.Label();
            this.BDevOpen = new System.Windows.Forms.Button();
            this.BConnect = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.TBNamePrefix = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.LLiveFpsLab = new System.Windows.Forms.Label();
            this.LFPSCurrent = new System.Windows.Forms.Label();
            this.FPSTimer = new System.Windows.Forms.Timer(this.components);
            this.ICInvalidateTimer = new System.Windows.Forms.Timer(this.components);
            this.TrBCurrentWL = new System.Windows.Forms.TrackBar();
            this.TBFinishL = new System.Windows.Forms.TextBox();
            this.TBStepL = new System.Windows.Forms.TextBox();
            this.TBStartL = new System.Windows.Forms.TextBox();
            this.BStartS = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TBwl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BSetWL = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.TrBWLNumber = new System.Windows.Forms.TrackBar();
            this.TBStartN = new System.Windows.Forms.TextBox();
            this.TBFinishN = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.GrBAOFWlSet = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.ChkBLoadedExpCurve = new System.Windows.Forms.CheckBox();
            this.BCreateAutoCurve = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.ChB_AutoSetWL = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ChB_CircleTune = new System.Windows.Forms.CheckBox();
            this.ChB_LoadWLCurve = new System.Windows.Forms.CheckBox();
<<<<<<< HEAD
            this.NUD_CurrentWL = new System.Windows.Forms.NumericUpDown();
            this.NUD_CurrentWN = new System.Windows.Forms.NumericUpDown();
=======
            this.NUD_CurWL = new System.Windows.Forms.NumericUpDown();
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.GrBImageSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.CBFinalPixelFormat = new System.Windows.Forms.ComboBox();
            this.FlipUpDownBut = new System.Windows.Forms.Button();
            this.FlipRightLeftBut = new System.Windows.Forms.Button();
            this.BkGrWorker_forExpCurveBuilding = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Pan_FPS = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialSeriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAutoexposureCurveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viaCameraAutoexposureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viaMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBZoomOfImage)).BeginInit();
            this.GPCamFeat.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrBExposureVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBGainVal)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrBCurrentWL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBWLNumber)).BeginInit();
            this.GrBAOFWlSet.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
<<<<<<< HEAD
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurrentWL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurrentWN)).BeginInit();
=======
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurWL)).BeginInit();
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.GrBImageSettings.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.Pan_FPS.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // icImagingControl1
            // 
            this.icImagingControl1.BackColor = System.Drawing.Color.Maroon;
            this.icImagingControl1.DeviceListChangedExecutionMode = TIS.Imaging.EventExecutionMode.Invoke;
            this.icImagingControl1.DeviceLostExecutionMode = TIS.Imaging.EventExecutionMode.AsyncInvoke;
            this.icImagingControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icImagingControl1.ImageAvailableExecutionMode = TIS.Imaging.EventExecutionMode.MultiThreaded;
            this.icImagingControl1.LiveDisplayPosition = new System.Drawing.Point(0, 0);
            this.icImagingControl1.Location = new System.Drawing.Point(4, 1);
            this.icImagingControl1.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.icImagingControl1.Name = "icImagingControl1";
            this.tableLayoutPanel1.SetRowSpan(this.icImagingControl1, 2);
            this.icImagingControl1.Size = new System.Drawing.Size(913, 654);
            this.icImagingControl1.TabIndex = 0;
            this.icImagingControl1.OverlayUpdate += new System.EventHandler<TIS.Imaging.ICImagingControl.OverlayUpdateEventArgs>(this.icImagingControl1_OverlayUpdate);
            this.icImagingControl1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.icImagingControl1_Scroll);
            this.icImagingControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.icImagingControl1_MouseDown);
            this.icImagingControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.icImagingControl1_MouseMove);
            this.icImagingControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.icImagingControl1_MouseUp);
            // 
            // SaveImgParBut
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.SaveImgParBut, 2);
            this.SaveImgParBut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveImgParBut.Location = new System.Drawing.Point(4, 118);
            this.SaveImgParBut.Margin = new System.Windows.Forms.Padding(4);
            this.SaveImgParBut.Name = "SaveImgParBut";
            this.SaveImgParBut.Size = new System.Drawing.Size(376, 32);
            this.SaveImgParBut.TabIndex = 1;
            this.SaveImgParBut.Text = "Image saving parameters";
            this.SaveImgParBut.UseVisualStyleBackColor = true;
            this.SaveImgParBut.Click += new System.EventHandler(this.SaveImgParBut_Click);
            // 
            // PropBut
            // 
            this.tableLayoutPanel6.SetColumnSpan(this.PropBut, 7);
            this.PropBut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropBut.Location = new System.Drawing.Point(4, 455);
            this.PropBut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PropBut.Name = "PropBut";
            this.PropBut.Size = new System.Drawing.Size(376, 35);
            this.PropBut.TabIndex = 3;
            this.PropBut.Text = "Advanced properties...";
            this.PropBut.UseVisualStyleBackColor = true;
            this.PropBut.Click += new System.EventHandler(this.PropBut_Click);
            // 
            // ExitBut
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ExitBut, 3);
            this.ExitBut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExitBut.Location = new System.Drawing.Point(4, 781);
            this.ExitBut.Margin = new System.Windows.Forms.Padding(4);
            this.ExitBut.Name = "ExitBut";
            this.ExitBut.Size = new System.Drawing.Size(1393, 29);
            this.ExitBut.TabIndex = 7;
            this.ExitBut.Text = "Выход";
            this.ExitBut.UseVisualStyleBackColor = true;
            this.ExitBut.Click += new System.EventHandler(this.ExitBut_Click);
            // 
            // SnapshotBut
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.SnapshotBut, 2);
            this.SnapshotBut.Dock = System.Windows.Forms.DockStyle.Fill;
<<<<<<< HEAD
            this.SnapshotBut.Location = new System.Drawing.Point(4, 296);
            this.SnapshotBut.Margin = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.SnapshotBut.Name = "SnapshotBut";
            this.SnapshotBut.Size = new System.Drawing.Size(95, 57);
=======
            this.SnapshotBut.Location = new System.Drawing.Point(4, 176);
            this.SnapshotBut.Margin = new System.Windows.Forms.Padding(4, 1, 1, 1);
            this.SnapshotBut.Name = "SnapshotBut";
            this.SnapshotBut.Size = new System.Drawing.Size(77, 33);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.SnapshotBut.TabIndex = 8;
            this.SnapshotBut.Text = "Снимок";
            this.SnapshotBut.UseVisualStyleBackColor = true;
            this.SnapshotBut.Click += new System.EventHandler(this.SnapshotBut_Click);
            // 
            // ChBExposureAuto
            // 
            this.ChBExposureAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ChBExposureAuto.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.ChBExposureAuto, 2);
            this.ChBExposureAuto.Location = new System.Drawing.Point(258, 7);
            this.ChBExposureAuto.Margin = new System.Windows.Forms.Padding(4);
            this.ChBExposureAuto.Name = "ChBExposureAuto";
            this.ChBExposureAuto.Size = new System.Drawing.Size(122, 21);
            this.ChBExposureAuto.TabIndex = 26;
            this.ChBExposureAuto.Text = "Auto";
            this.ChBExposureAuto.UseVisualStyleBackColor = true;
            this.ChBExposureAuto.CheckedChanged += new System.EventHandler(this.ChBExposureAuto_CheckedChanged);
            // 
            // TrBZoomOfImage
            // 
            this.TrBZoomOfImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel2.SetColumnSpan(this.TrBZoomOfImage, 2);
            this.TrBZoomOfImage.Location = new System.Drawing.Point(4, 4);
            this.TrBZoomOfImage.Margin = new System.Windows.Forms.Padding(4);
            this.TrBZoomOfImage.Maximum = 1000;
            this.TrBZoomOfImage.Minimum = 5;
            this.TrBZoomOfImage.Name = "TrBZoomOfImage";
            this.TrBZoomOfImage.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.TrBZoomOfImage.Size = new System.Drawing.Size(56, 568);
            this.TrBZoomOfImage.TabIndex = 28;
            this.TrBZoomOfImage.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBZoomOfImage.Value = 100;
            this.TrBZoomOfImage.Scroll += new System.EventHandler(this.ZoomOfImage_Scroll);
            // 
            // L_Zoom
            // 
            this.L_Zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Zoom.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.L_Zoom, 2);
            this.L_Zoom.Location = new System.Drawing.Point(4, 586);
            this.L_Zoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_Zoom.Name = "L_Zoom";
            this.L_Zoom.Size = new System.Drawing.Size(72, 17);
            this.L_Zoom.TabIndex = 29;
            this.L_Zoom.Text = "label2";
            // 
            // ContTransAfterSnapshot
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.ContTransAfterSnapshot, 3);
            this.ContTransAfterSnapshot.Dock = System.Windows.Forms.DockStyle.Fill;
<<<<<<< HEAD
            this.ContTransAfterSnapshot.Location = new System.Drawing.Point(201, 296);
            this.ContTransAfterSnapshot.Margin = new System.Windows.Forms.Padding(1, 1, 4, 1);
            this.ContTransAfterSnapshot.Name = "ContTransAfterSnapshot";
            this.ContTransAfterSnapshot.Size = new System.Drawing.Size(229, 57);
=======
            this.ContTransAfterSnapshot.Location = new System.Drawing.Point(165, 176);
            this.ContTransAfterSnapshot.Margin = new System.Windows.Forms.Padding(1, 1, 4, 1);
            this.ContTransAfterSnapshot.Name = "ContTransAfterSnapshot";
            this.ContTransAfterSnapshot.Size = new System.Drawing.Size(215, 33);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.ContTransAfterSnapshot.TabIndex = 32;
            this.ContTransAfterSnapshot.Text = "Продолжить";
            this.ContTransAfterSnapshot.UseVisualStyleBackColor = true;
            this.ContTransAfterSnapshot.Click += new System.EventHandler(this.ContTransAfterSnapshot_Click);
            // 
            // TimerForRenew
            // 
            this.TimerForRenew.Tick += new System.EventHandler(this.TimerForRenew_Tick);
            // 
            // SaveImageBut
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.SaveImageBut, 2);
            this.SaveImageBut.Dock = System.Windows.Forms.DockStyle.Fill;
<<<<<<< HEAD
            this.SaveImageBut.Location = new System.Drawing.Point(101, 296);
            this.SaveImageBut.Margin = new System.Windows.Forms.Padding(1);
            this.SaveImageBut.Name = "SaveImageBut";
            this.SaveImageBut.Size = new System.Drawing.Size(98, 57);
=======
            this.SaveImageBut.Location = new System.Drawing.Point(83, 176);
            this.SaveImageBut.Margin = new System.Windows.Forms.Padding(1);
            this.SaveImageBut.Name = "SaveImageBut";
            this.SaveImageBut.Size = new System.Drawing.Size(80, 33);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.SaveImageBut.TabIndex = 48;
            this.SaveImageBut.Text = "Сохранить";
            this.SaveImageBut.UseVisualStyleBackColor = true;
            this.SaveImageBut.Visible = false;
            this.SaveImageBut.Click += new System.EventHandler(this.SaveImageBut_Click);
            // 
            // LBConsole
            // 
            this.LBConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LBConsole.FormattingEnabled = true;
            this.LBConsole.ItemHeight = 16;
            this.LBConsole.Location = new System.Drawing.Point(4, 660);
            this.LBConsole.Margin = new System.Windows.Forms.Padding(4);
            this.LBConsole.Name = "LBConsole";
            this.LBConsole.Size = new System.Drawing.Size(913, 113);
            this.LBConsole.TabIndex = 51;
            // 
            // GPCamFeat
            // 
            this.GPCamFeat.Controls.Add(this.tableLayoutPanel6);
            this.GPCamFeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GPCamFeat.Location = new System.Drawing.Point(1005, 189);
            this.GPCamFeat.Margin = new System.Windows.Forms.Padding(4);
            this.GPCamFeat.Name = "GPCamFeat";
            this.GPCamFeat.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.SetRowSpan(this.GPCamFeat, 2);
            this.GPCamFeat.Size = new System.Drawing.Size(392, 584);
            this.GPCamFeat.TabIndex = 52;
            this.GPCamFeat.TabStop = false;
            this.GPCamFeat.Text = "Camera Features:";
            this.GPCamFeat.Enter += new System.EventHandler(this.GPCamFeat_Enter);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 7;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label11, 0, 11);
            this.tableLayoutPanel6.Controls.Add(this.TrBExposureVal, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.TBROIPointX, 1, 11);
            this.tableLayoutPanel6.Controls.Add(this.ChBROIAutoCent, 1, 9);
            this.tableLayoutPanel6.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.TBROIWidth, 1, 10);
            this.tableLayoutPanel6.Controls.Add(this.label9, 0, 10);
            this.tableLayoutPanel6.Controls.Add(this.TrBGainVal, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.label16, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.LFPS, 0, 8);
            this.tableLayoutPanel6.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.label8, 0, 9);
            this.tableLayoutPanel6.Controls.Add(this.CBMResolution, 3, 5);
            this.tableLayoutPanel6.Controls.Add(this.label27, 0, 6);
            this.tableLayoutPanel6.Controls.Add(this.label15, 0, 7);
            this.tableLayoutPanel6.Controls.Add(this.BSetROI, 0, 12);
            this.tableLayoutPanel6.Controls.Add(this.BROIFull, 2, 12);
            this.tableLayoutPanel6.Controls.Add(this.PropBut, 0, 13);
            this.tableLayoutPanel6.Controls.Add(this.BSelectUserResolution, 2, 5);
            this.tableLayoutPanel6.Controls.Add(this.CBoxPixelFormat, 3, 6);
            this.tableLayoutPanel6.Controls.Add(this.CBSignalFormats, 3, 4);
            this.tableLayoutPanel6.Controls.Add(this.CBSavingPixelFormat, 3, 7);
            this.tableLayoutPanel6.Controls.Add(this.CBAvFPS, 3, 8);
            this.tableLayoutPanel6.Controls.Add(this.ChBVisualiseROI, 6, 9);
            this.tableLayoutPanel6.Controls.Add(this.TBROIHeight, 5, 10);
            this.tableLayoutPanel6.Controls.Add(this.TBROIPointY, 5, 11);
            this.tableLayoutPanel6.Controls.Add(this.label10, 4, 10);
            this.tableLayoutPanel6.Controls.Add(this.label12, 4, 11);
            this.tableLayoutPanel6.Controls.Add(this.BAdapt, 5, 12);
            this.tableLayoutPanel6.Controls.Add(this.TBExposureVal, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.TBGainVal, 2, 2);
            this.tableLayoutPanel6.Controls.Add(this.ChBGainAuto, 5, 2);
            this.tableLayoutPanel6.Controls.Add(this.ChBExposureAuto, 5, 0);
            this.tableLayoutPanel6.Controls.Add(this.CbBinning, 5, 9);
            this.tableLayoutPanel6.Controls.Add(this.LBinning, 3, 9);
            this.tableLayoutPanel6.Controls.Add(this.BTestAll, 0, 15);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 16;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.140868F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143011F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(384, 561);
            this.tableLayoutPanel6.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Exposure:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 394);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 30;
            this.label11.Text = "Point X:";
            // 
            // TrBExposureVal
            // 
            this.TrBExposureVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.TrBExposureVal, 7);
            this.TrBExposureVal.Location = new System.Drawing.Point(4, 39);
            this.TrBExposureVal.Margin = new System.Windows.Forms.Padding(4);
            this.TrBExposureVal.Name = "TrBExposureVal";
            this.TrBExposureVal.Size = new System.Drawing.Size(376, 27);
            this.TrBExposureVal.TabIndex = 19;
            this.TrBExposureVal.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBExposureVal.Scroll += new System.EventHandler(this.TrBExposureVal_Scroll);
            // 
            // TBROIPointX
            // 
            this.TBROIPointX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.TBROIPointX, 3);
            this.TBROIPointX.Location = new System.Drawing.Point(68, 391);
            this.TBROIPointX.Margin = new System.Windows.Forms.Padding(4);
            this.TBROIPointX.Name = "TBROIPointX";
            this.TBROIPointX.Size = new System.Drawing.Size(118, 22);
            this.TBROIPointX.TabIndex = 31;
            // 
            // ChBROIAutoCent
            // 
            this.ChBROIAutoCent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ChBROIAutoCent.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.ChBROIAutoCent, 2);
            this.ChBROIAutoCent.Location = new System.Drawing.Point(68, 322);
            this.ChBROIAutoCent.Margin = new System.Windows.Forms.Padding(4);
            this.ChBROIAutoCent.Name = "ChBROIAutoCent";
            this.ChBROIAutoCent.Size = new System.Drawing.Size(87, 21);
            this.ChBROIAutoCent.TabIndex = 72;
            this.ChBROIAutoCent.Text = "Auto Center";
            this.ChBROIAutoCent.UseVisualStyleBackColor = true;
            this.ChBROIAutoCent.CheckedChanged += new System.EventHandler(this.ChBROIAutoCent_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Gain:";
            // 
            // TBROIWidth
            // 
            this.TBROIWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.TBROIWidth, 3);
            this.TBROIWidth.Location = new System.Drawing.Point(68, 356);
            this.TBROIWidth.Margin = new System.Windows.Forms.Padding(4);
            this.TBROIWidth.Name = "TBROIWidth";
            this.TBROIWidth.Size = new System.Drawing.Size(118, 22);
            this.TBROIWidth.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 359);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Width:";
            // 
            // TrBGainVal
            // 
            this.TrBGainVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.TrBGainVal, 7);
            this.TrBGainVal.Location = new System.Drawing.Point(4, 109);
            this.TrBGainVal.Margin = new System.Windows.Forms.Padding(4);
            this.TrBGainVal.Name = "TrBGainVal";
            this.TrBGainVal.Size = new System.Drawing.Size(376, 27);
            this.TrBGainVal.TabIndex = 22;
            this.TrBGainVal.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBGainVal.Scroll += new System.EventHandler(this.TrBGainVal_Scroll);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.label16, 2);
            this.label16.Location = new System.Drawing.Point(4, 149);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 17);
            this.label16.TabIndex = 71;
            this.label16.Text = "Signal format:";
            // 
            // LFPS
            // 
            this.LFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LFPS.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.LFPS, 2);
            this.LFPS.Location = new System.Drawing.Point(4, 289);
            this.LFPS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LFPS.Name = "LFPS";
            this.LFPS.Size = new System.Drawing.Size(120, 17);
            this.LFPS.TabIndex = 74;
            this.LFPS.Text = "Available FPS:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.label2, 2);
            this.label2.Location = new System.Drawing.Point(4, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 65;
            this.label2.Text = "Resolution:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 324);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "ROI:";
            // 
            // CBMResolution
            // 
            this.CBMResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.CBMResolution, 4);
            this.CBMResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBMResolution.FormattingEnabled = true;
            this.CBMResolution.Items.AddRange(new object[] {
            "User"});
            this.CBMResolution.Location = new System.Drawing.Point(163, 180);
            this.CBMResolution.Margin = new System.Windows.Forms.Padding(4);
            this.CBMResolution.Name = "CBMResolution";
            this.CBMResolution.Size = new System.Drawing.Size(217, 24);
            this.CBMResolution.TabIndex = 64;
            this.CBMResolution.SelectedIndexChanged += new System.EventHandler(this.CBMResolution_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.label27, 3);
            this.label27.Location = new System.Drawing.Point(4, 219);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(155, 17);
            this.label27.TabIndex = 23;
            this.label27.Text = "PX Format(camera):";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.label15, 2);
            this.label15.Location = new System.Drawing.Point(4, 254);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 17);
            this.label15.TabIndex = 68;
            this.label15.Text = "PX Format:";
            // 
            // BSetROI
            // 
            this.BSetROI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.BSetROI, 2);
            this.BSetROI.Location = new System.Drawing.Point(4, 421);
            this.BSetROI.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.BSetROI.Name = "BSetROI";
            this.BSetROI.Size = new System.Drawing.Size(124, 33);
            this.BSetROI.TabIndex = 34;
            this.BSetROI.Text = "Set";
            this.BSetROI.UseVisualStyleBackColor = true;
            this.BSetROI.Click += new System.EventHandler(this.BSetROI_Click);
            // 
            // BROIFull
            // 
            this.BROIFull.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.BROIFull, 3);
            this.BROIFull.Location = new System.Drawing.Point(128, 421);
            this.BROIFull.Margin = new System.Windows.Forms.Padding(0);
            this.BROIFull.Name = "BROIFull";
            this.BROIFull.Size = new System.Drawing.Size(126, 33);
            this.BROIFull.TabIndex = 46;
            this.BROIFull.Text = "Full";
            this.BROIFull.UseVisualStyleBackColor = true;
            this.BROIFull.Click += new System.EventHandler(this.BROIFull_Click);
            // 
            // BSelectUserResolution
            // 
            this.BSelectUserResolution.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BSelectUserResolution.Location = new System.Drawing.Point(129, 179);
            this.BSelectUserResolution.Margin = new System.Windows.Forms.Padding(1, 4, 1, 4);
            this.BSelectUserResolution.Name = "BSelectUserResolution";
            this.BSelectUserResolution.Size = new System.Drawing.Size(28, 26);
            this.BSelectUserResolution.TabIndex = 73;
            this.BSelectUserResolution.Text = "U";
            this.BSelectUserResolution.UseVisualStyleBackColor = true;
            this.BSelectUserResolution.Click += new System.EventHandler(this.BSelectUserResolution_Click);
            // 
            // CBoxPixelFormat
            // 
            this.CBoxPixelFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.CBoxPixelFormat, 4);
            this.CBoxPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBoxPixelFormat.FormattingEnabled = true;
            this.CBoxPixelFormat.Location = new System.Drawing.Point(163, 215);
            this.CBoxPixelFormat.Margin = new System.Windows.Forms.Padding(4);
            this.CBoxPixelFormat.Name = "CBoxPixelFormat";
            this.CBoxPixelFormat.Size = new System.Drawing.Size(217, 24);
            this.CBoxPixelFormat.TabIndex = 19;
            this.CBoxPixelFormat.SelectedIndexChanged += new System.EventHandler(this.CBoxPixelFormat_SelectedIndexChanged);
            // 
            // CBSignalFormats
            // 
            this.CBSignalFormats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.CBSignalFormats, 4);
            this.CBSignalFormats.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSignalFormats.FormattingEnabled = true;
            this.CBSignalFormats.Location = new System.Drawing.Point(163, 145);
            this.CBSignalFormats.Margin = new System.Windows.Forms.Padding(4);
            this.CBSignalFormats.Name = "CBSignalFormats";
            this.CBSignalFormats.Size = new System.Drawing.Size(217, 24);
            this.CBSignalFormats.TabIndex = 70;
            this.CBSignalFormats.SelectedIndexChanged += new System.EventHandler(this.CBSignalFormats_SelectedIndexChanged);
            // 
            // CBSavingPixelFormat
            // 
            this.CBSavingPixelFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.CBSavingPixelFormat, 4);
            this.CBSavingPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSavingPixelFormat.FormattingEnabled = true;
            this.CBSavingPixelFormat.Location = new System.Drawing.Point(163, 250);
            this.CBSavingPixelFormat.Margin = new System.Windows.Forms.Padding(4);
            this.CBSavingPixelFormat.Name = "CBSavingPixelFormat";
            this.CBSavingPixelFormat.Size = new System.Drawing.Size(217, 24);
            this.CBSavingPixelFormat.TabIndex = 67;
            // 
            // CBAvFPS
            // 
            this.CBAvFPS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.CBAvFPS, 4);
            this.CBAvFPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBAvFPS.FormattingEnabled = true;
            this.CBAvFPS.Location = new System.Drawing.Point(163, 285);
            this.CBAvFPS.Margin = new System.Windows.Forms.Padding(4);
            this.CBAvFPS.Name = "CBAvFPS";
            this.CBAvFPS.Size = new System.Drawing.Size(217, 24);
            this.CBAvFPS.TabIndex = 75;
            this.CBAvFPS.SelectedIndexChanged += new System.EventHandler(this.CBAvFPS_SelectedIndexChanged);
            // 
            // ChBVisualiseROI
            // 
            this.ChBVisualiseROI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ChBVisualiseROI.AutoSize = true;
            this.ChBVisualiseROI.BackColor = System.Drawing.Color.Transparent;
            this.ChBVisualiseROI.Location = new System.Drawing.Point(322, 322);
            this.ChBVisualiseROI.Margin = new System.Windows.Forms.Padding(4);
            this.ChBVisualiseROI.Name = "ChBVisualiseROI";
            this.ChBVisualiseROI.Size = new System.Drawing.Size(58, 21);
            this.ChBVisualiseROI.TabIndex = 76;
            this.ChBVisualiseROI.Text = "Visual";
            this.ChBVisualiseROI.UseVisualStyleBackColor = false;
            this.ChBVisualiseROI.CheckedChanged += new System.EventHandler(this.ChBVisualiseROI_CheckedChanged);
            // 
            // TBROIHeight
            // 
            this.TBROIHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.TBROIHeight, 2);
            this.TBROIHeight.Location = new System.Drawing.Point(258, 356);
            this.TBROIHeight.Margin = new System.Windows.Forms.Padding(4);
            this.TBROIHeight.Name = "TBROIHeight";
            this.TBROIHeight.Size = new System.Drawing.Size(122, 22);
            this.TBROIHeight.TabIndex = 29;
            // 
            // TBROIPointY
            // 
            this.TBROIPointY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.TBROIPointY, 2);
            this.TBROIPointY.Location = new System.Drawing.Point(258, 391);
            this.TBROIPointY.Margin = new System.Windows.Forms.Padding(4);
            this.TBROIPointY.Name = "TBROIPointY";
            this.TBROIPointY.Size = new System.Drawing.Size(122, 22);
            this.TBROIPointY.TabIndex = 33;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(194, 359);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "Height:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(194, 394);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 32;
            this.label12.Text = "Point Y:";
            // 
            // BAdapt
            // 
            this.BAdapt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.BAdapt, 2);
            this.BAdapt.Location = new System.Drawing.Point(254, 421);
            this.BAdapt.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.BAdapt.Name = "BAdapt";
            this.BAdapt.Size = new System.Drawing.Size(126, 33);
            this.BAdapt.TabIndex = 66;
            this.BAdapt.Text = "Adapt";
            this.BAdapt.UseVisualStyleBackColor = true;
            this.BAdapt.Click += new System.EventHandler(this.BAdapt_Click);
            // 
            // TBExposureVal
            // 
            this.TBExposureVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.TBExposureVal, 3);
            this.TBExposureVal.Location = new System.Drawing.Point(132, 6);
            this.TBExposureVal.Margin = new System.Windows.Forms.Padding(4);
            this.TBExposureVal.Name = "TBExposureVal";
            this.TBExposureVal.Size = new System.Drawing.Size(118, 22);
            this.TBExposureVal.TabIndex = 21;
            this.TBExposureVal.TextChanged += new System.EventHandler(this.TBExposureVal_TextChanged);
            this.TBExposureVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBExposureVal_KeyPress);
            // 
            // TBGainVal
            // 
            this.TBGainVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.SetColumnSpan(this.TBGainVal, 3);
            this.TBGainVal.Location = new System.Drawing.Point(132, 76);
            this.TBGainVal.Margin = new System.Windows.Forms.Padding(4);
            this.TBGainVal.Name = "TBGainVal";
            this.TBGainVal.Size = new System.Drawing.Size(118, 22);
            this.TBGainVal.TabIndex = 24;
            this.TBGainVal.TextChanged += new System.EventHandler(this.TBGainVal_TextChanged);
            this.TBGainVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBGainVal_KeyPress);
            // 
            // ChBGainAuto
            // 
            this.ChBGainAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ChBGainAuto.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.ChBGainAuto, 2);
            this.ChBGainAuto.Location = new System.Drawing.Point(258, 77);
            this.ChBGainAuto.Margin = new System.Windows.Forms.Padding(4);
            this.ChBGainAuto.Name = "ChBGainAuto";
            this.ChBGainAuto.Size = new System.Drawing.Size(122, 21);
            this.ChBGainAuto.TabIndex = 63;
            this.ChBGainAuto.Text = "Auto";
            this.ChBGainAuto.UseVisualStyleBackColor = true;
            this.ChBGainAuto.CheckedChanged += new System.EventHandler(this.ChBGainAuto_CheckedChanged);
            // 
            // CbBinning
            // 
            this.CbBinning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CbBinning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbBinning.FormattingEnabled = true;
            this.CbBinning.Items.AddRange(new object[] {
            "1",
            "2",
            "4"});
            this.CbBinning.Location = new System.Drawing.Point(258, 320);
            this.CbBinning.Margin = new System.Windows.Forms.Padding(4);
            this.CbBinning.Name = "CbBinning";
            this.CbBinning.Size = new System.Drawing.Size(56, 24);
            this.CbBinning.TabIndex = 69;
            this.CbBinning.SelectedIndexChanged += new System.EventHandler(this.CbBinning_SelectedIndexChanged);
            // 
            // LBinning
            // 
            this.LBinning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LBinning.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.LBinning, 2);
            this.LBinning.Location = new System.Drawing.Point(163, 324);
            this.LBinning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBinning.Name = "LBinning";
            this.LBinning.Size = new System.Drawing.Size(87, 17);
            this.LBinning.TabIndex = 57;
            this.LBinning.Text = "Binning:";
            // 
            // BTestAll
            // 
            this.tableLayoutPanel6.SetColumnSpan(this.BTestAll, 2);
            this.BTestAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTestAll.Location = new System.Drawing.Point(4, 519);
            this.BTestAll.Margin = new System.Windows.Forms.Padding(4);
            this.BTestAll.Name = "BTestAll";
            this.BTestAll.Size = new System.Drawing.Size(120, 38);
            this.BTestAll.TabIndex = 77;
            this.BTestAll.Text = "Tests...";
            this.BTestAll.UseVisualStyleBackColor = true;
            this.BTestAll.Click += new System.EventHandler(this.BTestAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(1405, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(392, 177);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AOF Controls:";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.ChB_Power, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.L_RealDevName, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.L_ReqDevName, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.BDevOpen, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BConnect, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.label18, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label17, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
<<<<<<< HEAD
            this.tableLayoutPanel4.Size = new System.Drawing.Size(434, 192);
=======
            this.tableLayoutPanel4.Size = new System.Drawing.Size(384, 154);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.tableLayoutPanel4.TabIndex = 74;
            // 
            // ChB_Power
            // 
            this.ChB_Power.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_Power.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_Power.Location = new System.Drawing.Point(1, 115);
            this.ChB_Power.Margin = new System.Windows.Forms.Padding(1);
            this.ChB_Power.Name = "ChB_Power";
            this.ChB_Power.Size = new System.Drawing.Size(94, 38);
            this.ChB_Power.TabIndex = 84;
            this.ChB_Power.Text = "Питание";
            this.ChB_Power.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChB_Power.UseVisualStyleBackColor = true;
            // 
            // L_RealDevName
            // 
            this.L_RealDevName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_RealDevName.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.L_RealDevName, 2);
            this.L_RealDevName.Location = new System.Drawing.Point(196, 86);
            this.L_RealDevName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_RealDevName.Name = "L_RealDevName";
            this.L_RealDevName.Size = new System.Drawing.Size(184, 17);
            this.L_RealDevName.TabIndex = 80;
            this.L_RealDevName.Text = "filename.dev";
            // 
            // L_ReqDevName
            // 
            this.L_ReqDevName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.L_ReqDevName.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.L_ReqDevName, 2);
            this.L_ReqDevName.Location = new System.Drawing.Point(196, 48);
            this.L_ReqDevName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.L_ReqDevName.Name = "L_ReqDevName";
            this.L_ReqDevName.Size = new System.Drawing.Size(184, 17);
            this.L_ReqDevName.TabIndex = 13;
            this.L_ReqDevName.Text = "filename.dev";
            // 
            // BDevOpen
            // 
            this.BDevOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BDevOpen.Location = new System.Drawing.Point(4, 4);
            this.BDevOpen.Margin = new System.Windows.Forms.Padding(4);
            this.BDevOpen.Name = "BDevOpen";
            this.BDevOpen.Size = new System.Drawing.Size(88, 30);
            this.BDevOpen.TabIndex = 13;
            this.BDevOpen.Text = "Open .dev file";
            this.BDevOpen.UseVisualStyleBackColor = true;
            this.BDevOpen.Click += new System.EventHandler(this.BDevOpen_Click);
            // 
            // BConnect
            // 
            this.BConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BConnect.Location = new System.Drawing.Point(196, 4);
            this.BConnect.Margin = new System.Windows.Forms.Padding(4);
            this.BConnect.Name = "BConnect";
            this.BConnect.Size = new System.Drawing.Size(88, 30);
            this.BConnect.TabIndex = 4;
            this.BConnect.Text = "Connect";
            this.BConnect.UseVisualStyleBackColor = true;
            this.BConnect.Click += new System.EventHandler(this.BConnect_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.label18, 2);
            this.label18.Location = new System.Drawing.Point(4, 86);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(184, 17);
            this.label18.TabIndex = 79;
            this.label18.Text = "Loaded .dev file :";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.label17, 2);
            this.label17.Location = new System.Drawing.Point(4, 48);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(184, 17);
            this.label17.TabIndex = 78;
            this.label17.Text = "Required .dev file:";
            this.label17.Click += new System.EventHandler(this.label17_Click);
            // 
            // TBNamePrefix
            // 
            this.TBNamePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.TBNamePrefix, 2);
            this.TBNamePrefix.Location = new System.Drawing.Point(4, 46);
            this.TBNamePrefix.Margin = new System.Windows.Forms.Padding(4);
            this.TBNamePrefix.Name = "TBNamePrefix";
            this.TBNamePrefix.Size = new System.Drawing.Size(376, 22);
            this.TBNamePrefix.TabIndex = 22;
            this.TBNamePrefix.Text = "ScreenShot";
            this.TBNamePrefix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBNamePrefix_KeyPress);
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(4, 10);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(184, 17);
            this.label26.TabIndex = 21;
            this.label26.Text = "NamePrefix:";
            // 
            // LLiveFpsLab
            // 
            this.LLiveFpsLab.AutoSize = true;
            this.LLiveFpsLab.Location = new System.Drawing.Point(4, 4);
            this.LLiveFpsLab.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LLiveFpsLab.Name = "LLiveFpsLab";
            this.LLiveFpsLab.Size = new System.Drawing.Size(38, 17);
            this.LLiveFpsLab.TabIndex = 64;
            this.LLiveFpsLab.Text = "FPS:";
            // 
            // LFPSCurrent
            // 
            this.LFPSCurrent.AutoSize = true;
            this.LFPSCurrent.Location = new System.Drawing.Point(8, 25);
            this.LFPSCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LFPSCurrent.Name = "LFPSCurrent";
            this.LFPSCurrent.Size = new System.Drawing.Size(54, 17);
            this.LFPSCurrent.TabIndex = 65;
            this.LFPSCurrent.Text = "label17";
            // 
            // FPSTimer
            // 
            this.FPSTimer.Enabled = true;
            this.FPSTimer.Interval = 30;
            this.FPSTimer.Tick += new System.EventHandler(this.FPSTimer_Tick);
            // 
            // ICInvalidateTimer
            // 
            this.ICInvalidateTimer.Enabled = true;
            this.ICInvalidateTimer.Interval = 5;
            this.ICInvalidateTimer.Tick += new System.EventHandler(this.ICInvalidateTimer_Tick);
            // 
            // TrBCurrentWL
            // 
<<<<<<< HEAD
            this.TrB_CurrentWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.TrB_CurrentWL, 6);
            this.TrB_CurrentWL.Location = new System.Drawing.Point(4, 182);
            this.TrB_CurrentWL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TrB_CurrentWL.Name = "TrB_CurrentWL";
            this.TrB_CurrentWL.Size = new System.Drawing.Size(292, 49);
            this.TrB_CurrentWL.TabIndex = 16;
            this.TrB_CurrentWL.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrB_CurrentWL.Scroll += new System.EventHandler(this.TBCurrentWL_Scroll);
=======
            this.TrBCurrentWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.TrBCurrentWL, 6);
            this.TrBCurrentWL.Location = new System.Drawing.Point(4, 109);
            this.TrBCurrentWL.Margin = new System.Windows.Forms.Padding(4);
            this.TrBCurrentWL.Name = "TrBCurrentWL";
            this.TrBCurrentWL.Size = new System.Drawing.Size(238, 27);
            this.TrBCurrentWL.TabIndex = 16;
            this.TrBCurrentWL.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBCurrentWL.Scroll += new System.EventHandler(this.TBCurrentWL_Scroll);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            // 
            // TBFinishL
            // 
            this.TBFinishL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.TBFinishL, 2);
<<<<<<< HEAD
            this.TBFinishL.Location = new System.Drawing.Point(104, 477);
            this.TBFinishL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBFinishL.Name = "TBFinishL";
            this.TBFinishL.Size = new System.Drawing.Size(92, 26);
=======
            this.TBFinishL.Location = new System.Drawing.Point(86, 284);
            this.TBFinishL.Margin = new System.Windows.Forms.Padding(4);
            this.TBFinishL.Name = "TBFinishL";
            this.TBFinishL.Size = new System.Drawing.Size(74, 22);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.TBFinishL.TabIndex = 8;
            // 
            // TBStepL
            // 
            this.TBStepL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.TBStepL, 2);
<<<<<<< HEAD
            this.TBStepL.Location = new System.Drawing.Point(204, 477);
            this.TBStepL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TBStepL.Name = "TBStepL";
            this.TBStepL.Size = new System.Drawing.Size(92, 26);
=======
            this.TBStepL.Location = new System.Drawing.Point(168, 284);
            this.TBStepL.Margin = new System.Windows.Forms.Padding(4);
            this.TBStepL.Name = "TBStepL";
            this.TBStepL.Size = new System.Drawing.Size(74, 22);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.TBStepL.TabIndex = 7;
            // 
            // TBStartL
            // 
            this.TBStartL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.TBStartL, 2);
            this.TBStartL.Location = new System.Drawing.Point(4, 284);
            this.TBStartL.Margin = new System.Windows.Forms.Padding(4);
            this.TBStartL.Name = "TBStartL";
<<<<<<< HEAD
            this.TBStartL.Size = new System.Drawing.Size(92, 26);
=======
            this.TBStartL.Size = new System.Drawing.Size(74, 22);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.TBStartL.TabIndex = 9;
            // 
            // BStartS
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.BStartS, 7);
            this.BStartS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BStartS.Location = new System.Drawing.Point(4, 491);
            this.BStartS.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.BStartS.Name = "BStartS";
            this.BStartS.Size = new System.Drawing.Size(376, 35);
            this.BStartS.TabIndex = 1;
            this.BStartS.Text = "Start session";
            this.BStartS.UseVisualStyleBackColor = true;
            this.BStartS.Click += new System.EventHandler(this.BStartS_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.label3, 2);
            this.label3.Location = new System.Drawing.Point(4, 263);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Start L:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.label4, 2);
<<<<<<< HEAD
            this.label4.Location = new System.Drawing.Point(204, 452);
=======
            this.label4.Location = new System.Drawing.Point(168, 263);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Step:";
            // 
<<<<<<< HEAD
=======
            // TBwl
            // 
            this.TBwl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.TBwl, 2);
            this.TBwl.Location = new System.Drawing.Point(127, 41);
            this.TBwl.Margin = new System.Windows.Forms.Padding(4);
            this.TBwl.Name = "TBwl";
            this.TBwl.Size = new System.Drawing.Size(74, 22);
            this.TBwl.TabIndex = 6;
            this.TBwl.TextChanged += new System.EventHandler(this.TBwl_TextChanged);
            // 
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.label5, 2);
<<<<<<< HEAD
            this.label5.Location = new System.Drawing.Point(104, 452);
=======
            this.label5.Location = new System.Drawing.Point(86, 263);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "End L:";
            // 
            // BSetWL
            // 
            this.BSetWL.Dock = System.Windows.Forms.DockStyle.Fill;
<<<<<<< HEAD
            this.BSetWL.Location = new System.Drawing.Point(304, 5);
            this.BSetWL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BSetWL.Name = "BSetWL";
            this.tableLayoutPanel5.SetRowSpan(this.BSetWL, 2);
            this.BSetWL.Size = new System.Drawing.Size(126, 108);
=======
            this.BSetWL.Location = new System.Drawing.Point(250, 4);
            this.BSetWL.Margin = new System.Windows.Forms.Padding(4);
            this.BSetWL.Name = "BSetWL";
            this.tableLayoutPanel5.SetRowSpan(this.BSetWL, 2);
            this.BSetWL.Size = new System.Drawing.Size(130, 62);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.BSetWL.TabIndex = 5;
            this.BSetWL.Text = "Set WL";
            this.BSetWL.UseVisualStyleBackColor = true;
            this.BSetWL.Click += new System.EventHandler(this.BSetWL_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.label6, 3);
            this.label6.Location = new System.Drawing.Point(4, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
<<<<<<< HEAD
            this.label6.Size = new System.Drawing.Size(142, 40);
=======
            this.label6.Size = new System.Drawing.Size(115, 34);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label6.TabIndex = 16;
            this.label6.Text = "Current WaveLenght:";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
<<<<<<< HEAD
            this.label21.Location = new System.Drawing.Point(254, 19);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 20);
=======
            this.label21.Location = new System.Drawing.Point(209, 9);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 17);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label21.TabIndex = 17;
            this.label21.Text = "nm";
            // 
            // TrBWLNumber
            // 
            this.TrBWLNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.TrBWLNumber, 6);
<<<<<<< HEAD
            this.TrBWLNumber.Location = new System.Drawing.Point(4, 240);
            this.TrBWLNumber.Margin = new System.Windows.Forms.Padding(4);
            this.TrBWLNumber.Name = "TrBWLNumber";
            this.TrBWLNumber.Size = new System.Drawing.Size(292, 51);
=======
            this.TrBWLNumber.Location = new System.Drawing.Point(4, 144);
            this.TrBWLNumber.Margin = new System.Windows.Forms.Padding(4);
            this.TrBWLNumber.Name = "TrBWLNumber";
            this.TrBWLNumber.Size = new System.Drawing.Size(238, 27);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.TrBWLNumber.TabIndex = 18;
            this.TrBWLNumber.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrBWLNumber.Scroll += new System.EventHandler(this.TrBWLNumber_Scroll);
            // 
            // TBStartN
            // 
            this.TBStartN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.TBStartN, 2);
            this.TBStartN.Location = new System.Drawing.Point(4, 354);
            this.TBStartN.Margin = new System.Windows.Forms.Padding(4);
            this.TBStartN.Name = "TBStartN";
<<<<<<< HEAD
            this.TBStartN.Size = new System.Drawing.Size(92, 26);
=======
            this.TBStartN.Size = new System.Drawing.Size(74, 22);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.TBStartN.TabIndex = 19;
            // 
            // TBFinishN
            // 
            this.TBFinishN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.TBFinishN, 2);
<<<<<<< HEAD
            this.TBFinishN.Location = new System.Drawing.Point(104, 594);
            this.TBFinishN.Margin = new System.Windows.Forms.Padding(4);
            this.TBFinishN.Name = "TBFinishN";
            this.TBFinishN.Size = new System.Drawing.Size(92, 26);
=======
            this.TBFinishN.Location = new System.Drawing.Point(86, 354);
            this.TBFinishN.Margin = new System.Windows.Forms.Padding(4);
            this.TBFinishN.Name = "TBFinishN";
            this.TBFinishN.Size = new System.Drawing.Size(74, 22);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.TBFinishN.TabIndex = 20;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.textBox3, 2);
<<<<<<< HEAD
            this.textBox3.Location = new System.Drawing.Point(204, 594);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(92, 26);
=======
            this.textBox3.Location = new System.Drawing.Point(168, 354);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(74, 22);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.textBox3.TabIndex = 21;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.label23, 2);
            this.label23.Location = new System.Drawing.Point(4, 333);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(54, 17);
            this.label23.TabIndex = 24;
            this.label23.Text = "Start L:";
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label24.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.label24, 2);
<<<<<<< HEAD
            this.label24.Location = new System.Drawing.Point(104, 570);
=======
            this.label24.Location = new System.Drawing.Point(86, 333);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(49, 17);
            this.label24.TabIndex = 25;
            this.label24.Text = "End L:";
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label25.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.label25, 2);
<<<<<<< HEAD
            this.label25.Location = new System.Drawing.Point(204, 570);
=======
            this.label25.Location = new System.Drawing.Point(168, 333);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 17);
            this.label25.TabIndex = 26;
            this.label25.Text = "Step:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
<<<<<<< HEAD
            this.label13.Location = new System.Drawing.Point(304, 196);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(126, 20);
=======
            this.label13.Location = new System.Drawing.Point(250, 114);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(130, 17);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label13.TabIndex = 33;
            this.label13.Text = "nm";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
<<<<<<< HEAD
            this.label14.Location = new System.Drawing.Point(304, 597);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 7, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 20);
=======
            this.label14.Location = new System.Drawing.Point(250, 359);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 17);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label14.TabIndex = 34;
            this.label14.Text = "1/cm";
            // 
            // GrBAOFWlSet
            // 
            this.GrBAOFWlSet.Controls.Add(this.tableLayoutPanel5);
            this.GrBAOFWlSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrBAOFWlSet.Location = new System.Drawing.Point(1405, 189);
            this.GrBAOFWlSet.Margin = new System.Windows.Forms.Padding(4);
            this.GrBAOFWlSet.Name = "GrBAOFWlSet";
            this.GrBAOFWlSet.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.SetRowSpan(this.GrBAOFWlSet, 2);
            this.GrBAOFWlSet.Size = new System.Drawing.Size(392, 584);
            this.GrBAOFWlSet.TabIndex = 53;
            this.GrBAOFWlSet.TabStop = false;
            this.GrBAOFWlSet.Text = "WaveLength settings";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 7;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
<<<<<<< HEAD
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
=======
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.tableLayoutPanel5.Controls.Add(this.ChkBLoadedExpCurve, 0, 12);
            this.tableLayoutPanel5.Controls.Add(this.BCreateAutoCurve, 0, 11);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label14, 6, 10);
            this.tableLayoutPanel5.Controls.Add(this.textBox3, 4, 10);
            this.tableLayoutPanel5.Controls.Add(this.label25, 4, 9);
            this.tableLayoutPanel5.Controls.Add(this.label29, 5, 1);
            this.tableLayoutPanel5.Controls.Add(this.label24, 2, 9);
            this.tableLayoutPanel5.Controls.Add(this.label23, 0, 9);
            this.tableLayoutPanel5.Controls.Add(this.TBFinishN, 2, 10);
            this.tableLayoutPanel5.Controls.Add(this.label21, 5, 0);
            this.tableLayoutPanel5.Controls.Add(this.TBStartN, 0, 10);
            this.tableLayoutPanel5.Controls.Add(this.BSetWL, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this.TBStartL, 0, 8);
            this.tableLayoutPanel5.Controls.Add(this.TBStepL, 4, 8);
            this.tableLayoutPanel5.Controls.Add(this.TBFinishL, 2, 8);
            this.tableLayoutPanel5.Controls.Add(this.ChB_AutoSetWL, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.label22, 6, 8);
            this.tableLayoutPanel5.Controls.Add(this.label4, 4, 7);
            this.tableLayoutPanel5.Controls.Add(this.label5, 2, 7);
            this.tableLayoutPanel5.Controls.Add(this.SnapshotBut, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.SaveImageBut, 2, 5);
            this.tableLayoutPanel5.Controls.Add(this.ContTransAfterSnapshot, 4, 5);
            this.tableLayoutPanel5.Controls.Add(this.TrBWLNumber, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.label20, 6, 4);
<<<<<<< HEAD
            this.tableLayoutPanel5.Controls.Add(this.TrB_CurrentWL, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.ChB_CircleTune, 0, 15);
            this.tableLayoutPanel5.Controls.Add(this.BStartS, 0, 14);
            this.tableLayoutPanel5.Controls.Add(this.ChB_LoadWLCurve, 0, 13);
            this.tableLayoutPanel5.Controls.Add(this.label13, 6, 3);
            this.tableLayoutPanel5.Controls.Add(this.NUD_CurrentWL, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.NUD_CurrentWN, 3, 1);
=======
            this.tableLayoutPanel5.Controls.Add(this.TrBCurrentWL, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.ChB_CircleTune, 0, 15);
            this.tableLayoutPanel5.Controls.Add(this.BStartS, 0, 14);
            this.tableLayoutPanel5.Controls.Add(this.ChB_LoadWLCurve, 0, 13);
            this.tableLayoutPanel5.Controls.Add(this.TBwl, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.NUD_CurWL, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.label13, 0, 3);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 16;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142406F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.142406F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.140869F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.143119F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(384, 561);
            this.tableLayoutPanel5.TabIndex = 75;
            // 
            // ChkBLoadedExpCurve
            // 
            this.ChkBLoadedExpCurve.Appearance = System.Windows.Forms.Appearance.Button;
            this.tableLayoutPanel5.SetColumnSpan(this.ChkBLoadedExpCurve, 7);
            this.ChkBLoadedExpCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChkBLoadedExpCurve.Location = new System.Drawing.Point(4, 421);
            this.ChkBLoadedExpCurve.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.ChkBLoadedExpCurve.Name = "ChkBLoadedExpCurve";
            this.ChkBLoadedExpCurve.Size = new System.Drawing.Size(376, 33);
            this.ChkBLoadedExpCurve.TabIndex = 54;
            this.ChkBLoadedExpCurve.Text = "Перестройка по кривой автоэкспозиции";
            this.ChkBLoadedExpCurve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkBLoadedExpCurve.UseVisualStyleBackColor = true;
            this.ChkBLoadedExpCurve.CheckedChanged += new System.EventHandler(this.ChkBLoadedExpCurve_CheckedChanged);
            // 
            // BCreateAutoCurve
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.BCreateAutoCurve, 7);
            this.BCreateAutoCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BCreateAutoCurve.Location = new System.Drawing.Point(4, 386);
            this.BCreateAutoCurve.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.BCreateAutoCurve.Name = "BCreateAutoCurve";
            this.BCreateAutoCurve.Size = new System.Drawing.Size(376, 33);
            this.BCreateAutoCurve.TabIndex = 56;
            this.BCreateAutoCurve.Text = "Создать кривую по автоэкспозиции";
            this.BCreateAutoCurve.UseVisualStyleBackColor = true;
            this.BCreateAutoCurve.Click += new System.EventHandler(this.BCreateAutoCurve_Click);
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label29.AutoSize = true;
<<<<<<< HEAD
            this.label29.Location = new System.Drawing.Point(254, 68);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(30, 40);
=======
            this.label29.Location = new System.Drawing.Point(209, 35);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(27, 34);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label29.TabIndex = 53;
            this.label29.Text = "1/cm";
            // 
            // ChB_AutoSetWL
            // 
            this.ChB_AutoSetWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ChB_AutoSetWL.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.ChB_AutoSetWL, 3);
            this.ChB_AutoSetWL.Location = new System.Drawing.Point(4, 39);
            this.ChB_AutoSetWL.Margin = new System.Windows.Forms.Padding(4);
            this.ChB_AutoSetWL.Name = "ChB_AutoSetWL";
            this.tableLayoutPanel5.SetRowSpan(this.ChB_AutoSetWL, 2);
<<<<<<< HEAD
            this.ChB_AutoSetWL.Size = new System.Drawing.Size(142, 108);
=======
            this.ChB_AutoSetWL.Size = new System.Drawing.Size(115, 62);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.ChB_AutoSetWL.TabIndex = 35;
            this.ChB_AutoSetWL.Text = "Управление ползунком";
            this.ChB_AutoSetWL.UseVisualStyleBackColor = true;
            this.ChB_AutoSetWL.CheckedChanged += new System.EventHandler(this.ChBAutoSetWL_CheckedChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label22.AutoSize = true;
<<<<<<< HEAD
            this.label22.Location = new System.Drawing.Point(304, 479);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 7, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 20);
=======
            this.label22.Location = new System.Drawing.Point(250, 289);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(130, 17);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label22.TabIndex = 50;
            this.label22.Text = "nm";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
<<<<<<< HEAD
            this.label20.Location = new System.Drawing.Point(304, 255);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(126, 20);
=======
            this.label20.Location = new System.Drawing.Point(250, 149);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(130, 17);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.label20.TabIndex = 49;
            this.label20.Text = "1/cm";
            // 
            // ChB_CircleTune
            // 
            this.ChB_CircleTune.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_CircleTune.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tableLayoutPanel5.SetColumnSpan(this.ChB_CircleTune, 7);
            this.ChB_CircleTune.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_CircleTune.Location = new System.Drawing.Point(4, 531);
            this.ChB_CircleTune.Margin = new System.Windows.Forms.Padding(4);
            this.ChB_CircleTune.Name = "ChB_CircleTune";
            this.ChB_CircleTune.Size = new System.Drawing.Size(376, 26);
            this.ChB_CircleTune.TabIndex = 57;
            this.ChB_CircleTune.Text = "Циклическая перестройка";
            this.ChB_CircleTune.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChB_CircleTune.UseVisualStyleBackColor = true;
            // 
            // ChB_LoadWLCurve
            // 
            this.ChB_LoadWLCurve.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChB_LoadWLCurve.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tableLayoutPanel5.SetColumnSpan(this.ChB_LoadWLCurve, 7);
            this.ChB_LoadWLCurve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChB_LoadWLCurve.Location = new System.Drawing.Point(4, 456);
            this.ChB_LoadWLCurve.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.ChB_LoadWLCurve.Name = "ChB_LoadWLCurve";
            this.ChB_LoadWLCurve.Size = new System.Drawing.Size(376, 33);
            this.ChB_LoadWLCurve.TabIndex = 58;
            this.ChB_LoadWLCurve.Text = "Перестройка по кривой ДВ";
            this.ChB_LoadWLCurve.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChB_LoadWLCurve.UseVisualStyleBackColor = true;
            this.ChB_LoadWLCurve.CheckedChanged += new System.EventHandler(this.ChB_LoadWLCurve_CheckedChanged);
            // 
            // NUD_CurWL
            // 
<<<<<<< HEAD
            this.NUD_CurrentWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.NUD_CurrentWL, 2);
            this.NUD_CurrentWL.DecimalPlaces = 2;
            this.NUD_CurrentWL.Location = new System.Drawing.Point(150, 16);
            this.NUD_CurrentWL.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_CurrentWL.Maximum = new decimal(new int[] {
=======
            this.NUD_CurWL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NUD_CurWL.DecimalPlaces = 2;
            this.NUD_CurWL.Location = new System.Drawing.Point(164, 6);
            this.NUD_CurWL.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_CurWL.Maximum = new decimal(new int[] {
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            1000,
            0,
            0,
            0});
<<<<<<< HEAD
            this.NUD_CurrentWL.Name = "NUD_CurrentWL";
            this.NUD_CurrentWL.Size = new System.Drawing.Size(100, 26);
            this.NUD_CurrentWL.TabIndex = 85;
            // 
            // NUD_CurrentWN
            // 
            this.NUD_CurrentWN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.NUD_CurrentWN, 2);
            this.NUD_CurrentWN.DecimalPlaces = 5;
            this.NUD_CurrentWN.Location = new System.Drawing.Point(150, 75);
            this.NUD_CurrentWN.Margin = new System.Windows.Forms.Padding(0);
            this.NUD_CurrentWN.Name = "NUD_CurrentWN";
            this.NUD_CurrentWN.Size = new System.Drawing.Size(100, 26);
            this.NUD_CurrentWN.TabIndex = 86;
=======
            this.NUD_CurWL.Name = "NUD_CurWL";
            this.NUD_CurWL.Size = new System.Drawing.Size(41, 22);
            this.NUD_CurWL.TabIndex = 85;
            this.NUD_CurWL.ValueChanged += new System.EventHandler(this.NUD_CurWL_ValueChanged_1);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            // 
            // GrBImageSettings
            // 
            this.GrBImageSettings.Controls.Add(this.tableLayoutPanel3);
            this.GrBImageSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrBImageSettings.Location = new System.Drawing.Point(1005, 4);
            this.GrBImageSettings.Margin = new System.Windows.Forms.Padding(4);
            this.GrBImageSettings.Name = "GrBImageSettings";
            this.GrBImageSettings.Padding = new System.Windows.Forms.Padding(4);
            this.GrBImageSettings.Size = new System.Drawing.Size(392, 177);
            this.GrBImageSettings.TabIndex = 66;
            this.GrBImageSettings.TabStop = false;
            this.GrBImageSettings.Text = "Basic settings";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.SaveImgParBut, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label19, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label26, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TBNamePrefix, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.CBFinalPixelFormat, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(384, 154);
            this.tableLayoutPanel3.TabIndex = 74;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 86);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(184, 17);
            this.label19.TabIndex = 79;
            this.label19.Text = "PixelFormat(saving):";
            // 
            // CBFinalPixelFormat
            // 
            this.CBFinalPixelFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CBFinalPixelFormat.FormattingEnabled = true;
            this.CBFinalPixelFormat.Location = new System.Drawing.Point(196, 82);
            this.CBFinalPixelFormat.Margin = new System.Windows.Forms.Padding(4);
            this.CBFinalPixelFormat.Name = "CBFinalPixelFormat";
            this.CBFinalPixelFormat.Size = new System.Drawing.Size(184, 24);
            this.CBFinalPixelFormat.TabIndex = 78;
            this.CBFinalPixelFormat.SelectedIndexChanged += new System.EventHandler(this.CBFinalPixelFormat_SelectedIndexChanged);
            // 
            // FlipUpDownBut
            // 
            this.FlipUpDownBut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlipUpDownBut.Location = new System.Drawing.Point(1, 614);
            this.FlipUpDownBut.Margin = new System.Windows.Forms.Padding(1);
            this.FlipUpDownBut.Name = "FlipUpDownBut";
            this.FlipUpDownBut.Size = new System.Drawing.Size(38, 35);
            this.FlipUpDownBut.TabIndex = 72;
            this.FlipUpDownBut.UseVisualStyleBackColor = true;
            this.FlipUpDownBut.Click += new System.EventHandler(this.FlipUpDownBut_Click);
            // 
            // FlipRightLeftBut
            // 
            this.FlipRightLeftBut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlipRightLeftBut.Location = new System.Drawing.Point(41, 614);
            this.FlipRightLeftBut.Margin = new System.Windows.Forms.Padding(1);
            this.FlipRightLeftBut.Name = "FlipRightLeftBut";
            this.FlipRightLeftBut.Size = new System.Drawing.Size(38, 35);
            this.FlipRightLeftBut.TabIndex = 71;
            this.FlipRightLeftBut.UseVisualStyleBackColor = true;
            this.FlipRightLeftBut.Click += new System.EventHandler(this.FlipRightLeftBut_Click);
            // 
            // BkGrWorker_forExpCurveBuilding
            // 
            this.BkGrWorker_forExpCurveBuilding.WorkerReportsProgress = true;
            this.BkGrWorker_forExpCurveBuilding.WorkerSupportsCancellation = true;
            this.BkGrWorker_forExpCurveBuilding.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BkGrWorker_forExpCurveBuilding_DoWork);
            this.BkGrWorker_forExpCurveBuilding.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BkGrWorker_forExpCurveBuilding_ProgressChanged);
            this.BkGrWorker_forExpCurveBuilding.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BkGrWorker_forExpCurveBuilding_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.GrBAOFWlSet, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.GPCamFeat, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.GrBImageSettings, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.icImagingControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LBConsole, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ExitBut, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.Pan_FPS, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
<<<<<<< HEAD
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2778, 1271);
=======
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1801, 814);
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.tableLayoutPanel1.TabIndex = 73;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Controls.Add(this.L_Zoom, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.TrBZoomOfImage, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.FlipRightLeftBut, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.FlipUpDownBut, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(921, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel1.SetRowSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(80, 650);
            this.tableLayoutPanel2.TabIndex = 74;
            // 
            // Pan_FPS
            // 
            this.Pan_FPS.Controls.Add(this.LLiveFpsLab);
            this.Pan_FPS.Controls.Add(this.LFPSCurrent);
            this.Pan_FPS.Location = new System.Drawing.Point(921, 656);
            this.Pan_FPS.Margin = new System.Windows.Forms.Padding(0);
            this.Pan_FPS.Name = "Pan_FPS";
            this.Pan_FPS.Size = new System.Drawing.Size(80, 121);
            this.Pan_FPS.TabIndex = 75;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1801, 28);
            this.menuStrip1.TabIndex = 74;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.quitToolStripMenuItem.Text = "Exit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.specialSeriesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // specialSeriesToolStripMenuItem
            // 
            this.specialSeriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createAutoexposureCurveToolStripMenuItem});
            this.specialSeriesToolStripMenuItem.Name = "specialSeriesToolStripMenuItem";
            this.specialSeriesToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.specialSeriesToolStripMenuItem.Text = "Special series";
            // 
            // createAutoexposureCurveToolStripMenuItem
            // 
            this.createAutoexposureCurveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viaCameraAutoexposureToolStripMenuItem,
            this.viaMSToolStripMenuItem});
            this.createAutoexposureCurveToolStripMenuItem.Name = "createAutoexposureCurveToolStripMenuItem";
            this.createAutoexposureCurveToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.createAutoexposureCurveToolStripMenuItem.Text = "Create autoexposure curve";
            // 
            // viaCameraAutoexposureToolStripMenuItem
            // 
            this.viaCameraAutoexposureToolStripMenuItem.Name = "viaCameraAutoexposureToolStripMenuItem";
            this.viaCameraAutoexposureToolStripMenuItem.Size = new System.Drawing.Size(356, 26);
            this.viaCameraAutoexposureToolStripMenuItem.Text = "via Camera Autoexposure";
            // 
            // viaMSToolStripMenuItem
            // 
            this.viaMSToolStripMenuItem.Name = "viaMSToolStripMenuItem";
            this.viaMSToolStripMenuItem.Size = new System.Drawing.Size(356, 26);
            this.viaMSToolStripMenuItem.Text = "via Sandart deviation of integral intensity";
            this.viaMSToolStripMenuItem.Click += new System.EventHandler(this.viaMSToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1801, 842);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form1_WheelScrolled);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.icImagingControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBZoomOfImage)).EndInit();
            this.GPCamFeat.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrBExposureVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBGainVal)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrBCurrentWL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrBWLNumber)).EndInit();
            this.GrBAOFWlSet.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
<<<<<<< HEAD
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurrentWL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurrentWN)).EndInit();
=======
            ((System.ComponentModel.ISupportInitialize)(this.NUD_CurWL)).EndInit();
>>>>>>> parent of 05d053c... initialize filter & change AOM to AOF 2
            this.GrBImageSettings.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.Pan_FPS.ResumeLayout(false);
            this.Pan_FPS.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public TIS.Imaging.ICImagingControl icImagingControl1;
        private System.Windows.Forms.Button SaveImgParBut;
        private System.Windows.Forms.Button PropBut;
        private System.Windows.Forms.Button ExitBut;
        private System.Windows.Forms.Button SnapshotBut;
        private System.Windows.Forms.CheckBox ChBExposureAuto;
        private System.Windows.Forms.TrackBar TrBZoomOfImage;
        private System.Windows.Forms.Label L_Zoom;
        private System.Windows.Forms.Button ContTransAfterSnapshot;
        private System.Windows.Forms.Timer TimerForRenew;
        private System.Windows.Forms.Button SaveImageBut;
        private System.Windows.Forms.ListBox LBConsole;
        private System.Windows.Forms.GroupBox GPCamFeat;
        private System.Windows.Forms.Button BROIFull;
        private System.Windows.Forms.Button BSetROI;
        private System.Windows.Forms.TextBox TBROIPointY;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TBROIPointX;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBROIHeight;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBROIWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TBGainVal;
        private System.Windows.Forms.TrackBar TrBGainVal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBExposureVal;
        private System.Windows.Forms.TrackBar TrBExposureVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CBoxPixelFormat;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox TBNamePrefix;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button BDevOpen;
        private System.Windows.Forms.Button BConnect;
        private System.Windows.Forms.CheckBox ChBGainAuto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBMResolution;
        private System.Windows.Forms.Button BAdapt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox CBSavingPixelFormat;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox CBSignalFormats;
        private System.Windows.Forms.CheckBox ChBROIAutoCent;
        private System.Windows.Forms.ComboBox CbBinning;
        private System.Windows.Forms.Label LBinning;
        private System.Windows.Forms.Button BSelectUserResolution;
        private System.Windows.Forms.Label LFPS;
        private System.Windows.Forms.ComboBox CBAvFPS;
        private System.Windows.Forms.Label LLiveFpsLab;
        private System.Windows.Forms.Label LFPSCurrent;
        private System.Windows.Forms.Timer FPSTimer;
        private System.Windows.Forms.CheckBox ChBVisualiseROI;
        private System.Windows.Forms.Timer ICInvalidateTimer;
        private System.Windows.Forms.Button BTestAll;
        private System.Windows.Forms.TrackBar TrBCurrentWL;
        private System.Windows.Forms.TextBox TBFinishL;
        private System.Windows.Forms.TextBox TBStepL;
        private System.Windows.Forms.TextBox TBStartL;
        private System.Windows.Forms.Button BStartS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBwl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BSetWL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TrackBar TrBWLNumber;
        private System.Windows.Forms.TextBox TBStartN;
        private System.Windows.Forms.TextBox TBFinishN;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox GrBAOFWlSet;
        private System.Windows.Forms.CheckBox ChB_AutoSetWL;
        private System.Windows.Forms.GroupBox GrBImageSettings;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label L_RealDevName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox TBwn;
        private System.Windows.Forms.Label L_ReqDevName;
        private System.Windows.Forms.ComboBox CBFinalPixelFormat;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button FlipUpDownBut;
        private System.Windows.Forms.Button FlipRightLeftBut;
        private System.Windows.Forms.CheckBox ChkBLoadedExpCurve;
        private System.Windows.Forms.Button BCreateAutoCurve;
        private System.ComponentModel.BackgroundWorker BkGrWorker_forExpCurveBuilding;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel Pan_FPS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.CheckBox ChB_CircleTune;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specialSeriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAutoexposureCurveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viaCameraAutoexposureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viaMSToolStripMenuItem;
        private System.Windows.Forms.CheckBox ChB_LoadWLCurve;
        private System.Windows.Forms.CheckBox ChB_Power;
        private System.Windows.Forms.NumericUpDown NUD_CurWL;
    }
}

