namespace ComputerGraphicsAssignment
{
    partial class frmPolygonFilling
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPolygonFilling));
            this.lblMainTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblSubTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClosePolygon = new Guna.UI2.WinForms.Guna2Button();
            this.btnSeedPoint = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnDrawPolygon = new Guna.UI2.WinForms.Guna2Button();
            this.grpAlgorithms = new System.Windows.Forms.GroupBox();
            this.rbFloodFill = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbBoundaryFill = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbScanLine = new Guna.UI2.WinForms.Guna2RadioButton();
            this.grpFillColor = new System.Windows.Forms.GroupBox();
            this.btnChooseColor = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFillColor = new Guna.UI2.WinForms.Guna2Panel();
            this.grpConnectivity = new System.Windows.Forms.GroupBox();
            this.rb8Connected = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rb4Connected = new Guna.UI2.WinForms.Guna2RadioButton();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.grpHowToUse = new System.Windows.Forms.GroupBox();
            this.guna2HtmlLabel6 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblInstructions = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFilledAreaLegend = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel9 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblEdgeLegend = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblVertexLegend = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.grpExtraTools = new System.Windows.Forms.GroupBox();
            this.btnZoomOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnRandomPolygon = new Guna.UI2.WinForms.Guna2Button();
            this.btnZoomIn = new Guna.UI2.WinForms.Guna2Button();
            this.btnShowVertices = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveImage = new Guna.UI2.WinForms.Guna2Button();
            this.btnFillPolygon = new Guna.UI2.WinForms.Guna2Button();
            this.picCanvas = new Guna.UI2.WinForms.Guna2PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grpTranslation = new System.Windows.Forms.GroupBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.numTx = new Guna.UI2.WinForms.Guna2TextBox();
            this.numTy = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnTranslate = new Guna.UI2.WinForms.Guna2Button();
            this.Rotation = new System.Windows.Forms.GroupBox();
            this.guna2HtmlLabel7 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnRotate = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1.SuspendLayout();
            this.grpAlgorithms.SuspendLayout();
            this.grpFillColor.SuspendLayout();
            this.grpConnectivity.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.grpHowToUse.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpExtraTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grpTranslation.SuspendLayout();
            this.Rotation.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.AutoSize = false;
            this.lblMainTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblMainTitle.Location = new System.Drawing.Point(182, 12);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(580, 26);
            this.lblMainTitle.TabIndex = 0;
            this.lblMainTitle.Text = "COMPUTER GRAPHICS POLYGON FILLING SYSTEM";
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = false;
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSubTitle.Location = new System.Drawing.Point(201, 44);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(543, 26);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Using Scan Line, Boundary Fill and Flood Fill Algorithms";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClosePolygon);
            this.groupBox1.Controls.Add(this.btnSeedPoint);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDrawPolygon);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox1.Location = new System.Drawing.Point(677, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 109);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Polygon Controls";
            // 
            // btnClosePolygon
            // 
            this.btnClosePolygon.Animated = true;
            this.btnClosePolygon.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClosePolygon.BorderRadius = 6;
            this.btnClosePolygon.BorderThickness = 2;
            this.btnClosePolygon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClosePolygon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClosePolygon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClosePolygon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClosePolygon.FillColor = System.Drawing.Color.White;
            this.btnClosePolygon.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnClosePolygon.ForeColor = System.Drawing.Color.Black;
            this.btnClosePolygon.Image = global::ComputerGraphicsAssignment.Properties.Resources.bin__1_;
            this.btnClosePolygon.Location = new System.Drawing.Point(12, 70);
            this.btnClosePolygon.Name = "btnClosePolygon";
            this.btnClosePolygon.Size = new System.Drawing.Size(145, 36);
            this.btnClosePolygon.TabIndex = 4;
            this.btnClosePolygon.Text = "close";
            this.btnClosePolygon.Click += new System.EventHandler(this.btnClosePolygon_Click);
            // 
            // btnSeedPoint
            // 
            this.btnSeedPoint.Animated = true;
            this.btnSeedPoint.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSeedPoint.BorderRadius = 6;
            this.btnSeedPoint.BorderThickness = 2;
            this.btnSeedPoint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSeedPoint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSeedPoint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSeedPoint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSeedPoint.FillColor = System.Drawing.Color.White;
            this.btnSeedPoint.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnSeedPoint.ForeColor = System.Drawing.Color.Black;
            this.btnSeedPoint.Image = global::ComputerGraphicsAssignment.Properties.Resources.pencil__1_;
            this.btnSeedPoint.Location = new System.Drawing.Point(170, 28);
            this.btnSeedPoint.Name = "btnSeedPoint";
            this.btnSeedPoint.Size = new System.Drawing.Size(125, 36);
            this.btnSeedPoint.TabIndex = 3;
            this.btnSeedPoint.Text = "Seed Point";
            this.btnSeedPoint.Click += new System.EventHandler(this.btnSeedPoint_Click);
            // 
            // btnClear
            // 
            this.btnClear.Animated = true;
            this.btnClear.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnClear.BorderRadius = 6;
            this.btnClear.BorderThickness = 2;
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.White;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Image = global::ComputerGraphicsAssignment.Properties.Resources.bin__1_;
            this.btnClear.Location = new System.Drawing.Point(308, 28);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(145, 36);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDrawPolygon
            // 
            this.btnDrawPolygon.Animated = true;
            this.btnDrawPolygon.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnDrawPolygon.BorderRadius = 6;
            this.btnDrawPolygon.BorderThickness = 2;
            this.btnDrawPolygon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDrawPolygon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDrawPolygon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDrawPolygon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDrawPolygon.FillColor = System.Drawing.Color.White;
            this.btnDrawPolygon.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnDrawPolygon.ForeColor = System.Drawing.Color.Black;
            this.btnDrawPolygon.Image = global::ComputerGraphicsAssignment.Properties.Resources.pencil__1_;
            this.btnDrawPolygon.Location = new System.Drawing.Point(12, 28);
            this.btnDrawPolygon.Name = "btnDrawPolygon";
            this.btnDrawPolygon.Size = new System.Drawing.Size(147, 36);
            this.btnDrawPolygon.TabIndex = 0;
            this.btnDrawPolygon.Text = "Draw Polygon";
            this.btnDrawPolygon.Click += new System.EventHandler(this.btnDrawPolygon_Click);
            // 
            // grpAlgorithms
            // 
            this.grpAlgorithms.Controls.Add(this.rbFloodFill);
            this.grpAlgorithms.Controls.Add(this.rbBoundaryFill);
            this.grpAlgorithms.Controls.Add(this.rbScanLine);
            this.grpAlgorithms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAlgorithms.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpAlgorithms.Location = new System.Drawing.Point(677, 191);
            this.grpAlgorithms.Name = "grpAlgorithms";
            this.grpAlgorithms.Size = new System.Drawing.Size(253, 118);
            this.grpAlgorithms.TabIndex = 4;
            this.grpAlgorithms.TabStop = false;
            this.grpAlgorithms.Text = "Filling Algorithms";
            // 
            // rbFloodFill
            // 
            this.rbFloodFill.AutoSize = true;
            this.rbFloodFill.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbFloodFill.CheckedState.BorderThickness = 0;
            this.rbFloodFill.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbFloodFill.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbFloodFill.CheckedState.InnerOffset = -4;
            this.rbFloodFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.rbFloodFill.ForeColor = System.Drawing.Color.Black;
            this.rbFloodFill.Location = new System.Drawing.Point(12, 80);
            this.rbFloodFill.Name = "rbFloodFill";
            this.rbFloodFill.Size = new System.Drawing.Size(156, 19);
            this.rbFloodFill.TabIndex = 2;
            this.rbFloodFill.Text = "Flood Fill (Seed Fill)";
            this.rbFloodFill.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbFloodFill.UncheckedState.BorderThickness = 2;
            this.rbFloodFill.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbFloodFill.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbBoundaryFill
            // 
            this.rbBoundaryFill.AutoSize = true;
            this.rbBoundaryFill.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbBoundaryFill.CheckedState.BorderThickness = 0;
            this.rbBoundaryFill.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbBoundaryFill.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbBoundaryFill.CheckedState.InnerOffset = -4;
            this.rbBoundaryFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.rbBoundaryFill.ForeColor = System.Drawing.Color.Black;
            this.rbBoundaryFill.Location = new System.Drawing.Point(12, 54);
            this.rbBoundaryFill.Name = "rbBoundaryFill";
            this.rbBoundaryFill.Size = new System.Drawing.Size(179, 19);
            this.rbBoundaryFill.TabIndex = 1;
            this.rbBoundaryFill.Text = "Boundary Fill (edge Fill)";
            this.rbBoundaryFill.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbBoundaryFill.UncheckedState.BorderThickness = 2;
            this.rbBoundaryFill.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbBoundaryFill.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rbScanLine
            // 
            this.rbScanLine.AutoSize = true;
            this.rbScanLine.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbScanLine.CheckedState.BorderThickness = 0;
            this.rbScanLine.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbScanLine.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbScanLine.CheckedState.InnerOffset = -4;
            this.rbScanLine.ForeColor = System.Drawing.Color.Black;
            this.rbScanLine.Location = new System.Drawing.Point(12, 29);
            this.rbScanLine.Name = "rbScanLine";
            this.rbScanLine.Size = new System.Drawing.Size(113, 19);
            this.rbScanLine.TabIndex = 0;
            this.rbScanLine.Text = "Scan Line Fill";
            this.rbScanLine.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbScanLine.UncheckedState.BorderThickness = 2;
            this.rbScanLine.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbScanLine.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // grpFillColor
            // 
            this.grpFillColor.Controls.Add(this.btnChooseColor);
            this.grpFillColor.Controls.Add(this.pnlFillColor);
            this.grpFillColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFillColor.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpFillColor.Location = new System.Drawing.Point(953, 190);
            this.grpFillColor.Name = "grpFillColor";
            this.grpFillColor.Size = new System.Drawing.Size(182, 118);
            this.grpFillColor.TabIndex = 5;
            this.grpFillColor.TabStop = false;
            this.grpFillColor.Text = "Fill Color";
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.Animated = true;
            this.btnChooseColor.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnChooseColor.BorderRadius = 6;
            this.btnChooseColor.BorderThickness = 2;
            this.btnChooseColor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChooseColor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChooseColor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChooseColor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChooseColor.FillColor = System.Drawing.Color.White;
            this.btnChooseColor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnChooseColor.ForeColor = System.Drawing.Color.Black;
            this.btnChooseColor.Image = global::ComputerGraphicsAssignment.Properties.Resources.color_palette;
            this.btnChooseColor.Location = new System.Drawing.Point(6, 73);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(171, 36);
            this.btnChooseColor.TabIndex = 7;
            this.btnChooseColor.Text = "Choose Color";
            this.btnChooseColor.Click += new System.EventHandler(this.btnChooseColor_Click);
            // 
            // pnlFillColor
            // 
            this.pnlFillColor.Location = new System.Drawing.Point(6, 21);
            this.pnlFillColor.Name = "pnlFillColor";
            this.pnlFillColor.Size = new System.Drawing.Size(171, 36);
            this.pnlFillColor.TabIndex = 0;
            // 
            // grpConnectivity
            // 
            this.grpConnectivity.Controls.Add(this.rb8Connected);
            this.grpConnectivity.Controls.Add(this.rb4Connected);
            this.grpConnectivity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConnectivity.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpConnectivity.Location = new System.Drawing.Point(677, 315);
            this.grpConnectivity.Name = "grpConnectivity";
            this.grpConnectivity.Size = new System.Drawing.Size(253, 89);
            this.grpConnectivity.TabIndex = 5;
            this.grpConnectivity.TabStop = false;
            this.grpConnectivity.Text = "Connectivity (For Seed Fill)";
            // 
            // rb8Connected
            // 
            this.rb8Connected.AutoSize = true;
            this.rb8Connected.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rb8Connected.CheckedState.BorderThickness = 0;
            this.rb8Connected.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rb8Connected.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rb8Connected.CheckedState.InnerOffset = -4;
            this.rb8Connected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.rb8Connected.ForeColor = System.Drawing.Color.Black;
            this.rb8Connected.Location = new System.Drawing.Point(12, 54);
            this.rb8Connected.Name = "rb8Connected";
            this.rb8Connected.Size = new System.Drawing.Size(105, 19);
            this.rb8Connected.TabIndex = 1;
            this.rb8Connected.Text = "8 Connected";
            this.rb8Connected.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rb8Connected.UncheckedState.BorderThickness = 2;
            this.rb8Connected.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rb8Connected.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rb4Connected
            // 
            this.rb4Connected.AutoSize = true;
            this.rb4Connected.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rb4Connected.CheckedState.BorderThickness = 0;
            this.rb4Connected.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rb4Connected.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rb4Connected.CheckedState.InnerOffset = -4;
            this.rb4Connected.ForeColor = System.Drawing.Color.Black;
            this.rb4Connected.Location = new System.Drawing.Point(12, 29);
            this.rb4Connected.Name = "rb4Connected";
            this.rb4Connected.Size = new System.Drawing.Size(105, 19);
            this.rb4Connected.TabIndex = 0;
            this.rb4Connected.Text = "4 Connected";
            this.rb4Connected.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rb4Connected.UncheckedState.BorderThickness = 2;
            this.rb4Connected.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rb4Connected.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.lblStatus);
            this.grpStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStatus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpStatus.Location = new System.Drawing.Point(12, 515);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(659, 89);
            this.grpStatus.TabIndex = 6;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = false;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblStatus.Location = new System.Drawing.Point(6, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(647, 63);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Polygon Created. Select an algorithm and click \"Fill Polygon\".";
            // 
            // grpHowToUse
            // 
            this.grpHowToUse.Controls.Add(this.guna2HtmlLabel6);
            this.grpHowToUse.Controls.Add(this.guna2HtmlLabel5);
            this.grpHowToUse.Controls.Add(this.guna2HtmlLabel4);
            this.grpHowToUse.Controls.Add(this.lblInstructions);
            this.grpHowToUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpHowToUse.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpHowToUse.Location = new System.Drawing.Point(12, 627);
            this.grpHowToUse.Name = "grpHowToUse";
            this.grpHowToUse.Size = new System.Drawing.Size(545, 142);
            this.grpHowToUse.TabIndex = 6;
            this.grpHowToUse.TabStop = false;
            this.grpHowToUse.Text = "How to Use";
            // 
            // guna2HtmlLabel6
            // 
            this.guna2HtmlLabel6.AutoSize = false;
            this.guna2HtmlLabel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel6.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel6.Location = new System.Drawing.Point(6, 109);
            this.guna2HtmlLabel6.Name = "guna2HtmlLabel6";
            this.guna2HtmlLabel6.Size = new System.Drawing.Size(537, 21);
            this.guna2HtmlLabel6.TabIndex = 14;
            this.guna2HtmlLabel6.Text = "4. Choose fill color and click \"Fill Polygon\".";
            // 
            // guna2HtmlLabel5
            // 
            this.guna2HtmlLabel5.AutoSize = false;
            this.guna2HtmlLabel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel5.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel5.Location = new System.Drawing.Point(6, 82);
            this.guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            this.guna2HtmlLabel5.Size = new System.Drawing.Size(537, 21);
            this.guna2HtmlLabel5.TabIndex = 13;
            this.guna2HtmlLabel5.Text = "3. For Boundary Fill and Flood Fill, choose connectivity (4 or 8 connected).";
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.AutoSize = false;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel4.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(6, 55);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(537, 21);
            this.guna2HtmlLabel4.TabIndex = 12;
            this.guna2HtmlLabel4.Text = "2. Select a filling algorithm.";
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = false;
            this.lblInstructions.BackColor = System.Drawing.Color.Transparent;
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.Color.Black;
            this.lblInstructions.Location = new System.Drawing.Point(6, 28);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(537, 21);
            this.lblInstructions.TabIndex = 11;
            this.lblInstructions.Text = "1. Click \"Draw Polygon\" and click on the canvas to create polygon vertices.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblFilledAreaLegend);
            this.groupBox3.Controls.Add(this.guna2Panel1);
            this.groupBox3.Controls.Add(this.guna2HtmlLabel9);
            this.groupBox3.Controls.Add(this.lblEdgeLegend);
            this.groupBox3.Controls.Add(this.guna2CircleButton1);
            this.groupBox3.Controls.Add(this.lblVertexLegend);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupBox3.Location = new System.Drawing.Point(563, 629);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 140);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Legend";
            // 
            // lblFilledAreaLegend
            // 
            this.lblFilledAreaLegend.AutoSize = false;
            this.lblFilledAreaLegend.BackColor = System.Drawing.Color.Transparent;
            this.lblFilledAreaLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilledAreaLegend.ForeColor = System.Drawing.Color.Black;
            this.lblFilledAreaLegend.Location = new System.Drawing.Point(57, 99);
            this.lblFilledAreaLegend.Name = "lblFilledAreaLegend";
            this.lblFilledAreaLegend.Size = new System.Drawing.Size(187, 21);
            this.lblFilledAreaLegend.TabIndex = 16;
            this.lblFilledAreaLegend.Text = "FIled Area (After Fill)";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Blue;
            this.guna2Panel1.Location = new System.Drawing.Point(5, 95);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(46, 25);
            this.guna2Panel1.TabIndex = 1;
            // 
            // guna2HtmlLabel9
            // 
            this.guna2HtmlLabel9.AutoSize = false;
            this.guna2HtmlLabel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel9.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel9.Location = new System.Drawing.Point(6, 63);
            this.guna2HtmlLabel9.Name = "guna2HtmlLabel9";
            this.guna2HtmlLabel9.Size = new System.Drawing.Size(52, 26);
            this.guna2HtmlLabel9.TabIndex = 15;
            this.guna2HtmlLabel9.Text = "___";
            this.guna2HtmlLabel9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEdgeLegend
            // 
            this.lblEdgeLegend.AutoSize = false;
            this.lblEdgeLegend.BackColor = System.Drawing.Color.Transparent;
            this.lblEdgeLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEdgeLegend.ForeColor = System.Drawing.Color.Black;
            this.lblEdgeLegend.Location = new System.Drawing.Point(64, 63);
            this.lblEdgeLegend.Name = "lblEdgeLegend";
            this.lblEdgeLegend.Size = new System.Drawing.Size(119, 21);
            this.lblEdgeLegend.TabIndex = 14;
            this.lblEdgeLegend.Text = "Edge";
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Red;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Location = new System.Drawing.Point(5, 31);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(22, 22);
            this.guna2CircleButton1.TabIndex = 13;
            // 
            // lblVertexLegend
            // 
            this.lblVertexLegend.AutoSize = false;
            this.lblVertexLegend.BackColor = System.Drawing.Color.Transparent;
            this.lblVertexLegend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVertexLegend.ForeColor = System.Drawing.Color.Black;
            this.lblVertexLegend.Location = new System.Drawing.Point(33, 31);
            this.lblVertexLegend.Name = "lblVertexLegend";
            this.lblVertexLegend.Size = new System.Drawing.Size(211, 21);
            this.lblVertexLegend.TabIndex = 12;
            this.lblVertexLegend.Text = "Vertex (Click on canvas)";
            // 
            // grpExtraTools
            // 
            this.grpExtraTools.Controls.Add(this.btnZoomOut);
            this.grpExtraTools.Controls.Add(this.btnRandomPolygon);
            this.grpExtraTools.Controls.Add(this.btnZoomIn);
            this.grpExtraTools.Controls.Add(this.btnShowVertices);
            this.grpExtraTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpExtraTools.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpExtraTools.Location = new System.Drawing.Point(814, 629);
            this.grpExtraTools.Name = "grpExtraTools";
            this.grpExtraTools.Size = new System.Drawing.Size(325, 140);
            this.grpExtraTools.TabIndex = 17;
            this.grpExtraTools.TabStop = false;
            this.grpExtraTools.Text = "Extra Tools";
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Animated = true;
            this.btnZoomOut.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnZoomOut.BorderRadius = 6;
            this.btnZoomOut.BorderThickness = 2;
            this.btnZoomOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnZoomOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnZoomOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnZoomOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnZoomOut.FillColor = System.Drawing.Color.White;
            this.btnZoomOut.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnZoomOut.ForeColor = System.Drawing.Color.Black;
            this.btnZoomOut.Image = global::ComputerGraphicsAssignment.Properties.Resources.zoom_in;
            this.btnZoomOut.Location = new System.Drawing.Point(153, 84);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(164, 36);
            this.btnZoomOut.TabIndex = 21;
            this.btnZoomOut.Text = "Zoom out";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnRandomPolygon
            // 
            this.btnRandomPolygon.Animated = true;
            this.btnRandomPolygon.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnRandomPolygon.BorderRadius = 6;
            this.btnRandomPolygon.BorderThickness = 2;
            this.btnRandomPolygon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomPolygon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRandomPolygon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRandomPolygon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRandomPolygon.FillColor = System.Drawing.Color.White;
            this.btnRandomPolygon.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnRandomPolygon.ForeColor = System.Drawing.Color.Black;
            this.btnRandomPolygon.Image = global::ComputerGraphicsAssignment.Properties.Resources.dice;
            this.btnRandomPolygon.Location = new System.Drawing.Point(153, 31);
            this.btnRandomPolygon.Name = "btnRandomPolygon";
            this.btnRandomPolygon.Size = new System.Drawing.Size(164, 36);
            this.btnRandomPolygon.TabIndex = 20;
            this.btnRandomPolygon.Text = "Random Polygon";
            this.btnRandomPolygon.Click += new System.EventHandler(this.btnRandomPolygon_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Animated = true;
            this.btnZoomIn.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnZoomIn.BorderRadius = 6;
            this.btnZoomIn.BorderThickness = 2;
            this.btnZoomIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnZoomIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnZoomIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnZoomIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnZoomIn.FillColor = System.Drawing.Color.White;
            this.btnZoomIn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnZoomIn.ForeColor = System.Drawing.Color.Black;
            this.btnZoomIn.Image = global::ComputerGraphicsAssignment.Properties.Resources.zoom_in__1_;
            this.btnZoomIn.Location = new System.Drawing.Point(6, 84);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(141, 36);
            this.btnZoomIn.TabIndex = 19;
            this.btnZoomIn.Text = "Zoom in";
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnShowVertices
            // 
            this.btnShowVertices.Animated = true;
            this.btnShowVertices.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnShowVertices.BorderRadius = 6;
            this.btnShowVertices.BorderThickness = 2;
            this.btnShowVertices.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowVertices.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowVertices.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowVertices.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowVertices.FillColor = System.Drawing.Color.White;
            this.btnShowVertices.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnShowVertices.ForeColor = System.Drawing.Color.Black;
            this.btnShowVertices.Image = ((System.Drawing.Image)(resources.GetObject("btnShowVertices.Image")));
            this.btnShowVertices.Location = new System.Drawing.Point(6, 31);
            this.btnShowVertices.Name = "btnShowVertices";
            this.btnShowVertices.Size = new System.Drawing.Size(141, 36);
            this.btnShowVertices.TabIndex = 18;
            this.btnShowVertices.Text = "show Vertices";
            this.btnShowVertices.Click += new System.EventHandler(this.btnShowVertices_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Animated = true;
            this.btnSaveImage.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveImage.BorderRadius = 6;
            this.btnSaveImage.BorderThickness = 2;
            this.btnSaveImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveImage.FillColor = System.Drawing.Color.White;
            this.btnSaveImage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveImage.ForeColor = System.Drawing.Color.Black;
            this.btnSaveImage.Image = global::ComputerGraphicsAssignment.Properties.Resources.disk;
            this.btnSaveImage.Location = new System.Drawing.Point(959, 379);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(171, 36);
            this.btnSaveImage.TabIndex = 9;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnFillPolygon
            // 
            this.btnFillPolygon.Animated = true;
            this.btnFillPolygon.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnFillPolygon.BorderRadius = 6;
            this.btnFillPolygon.BorderThickness = 2;
            this.btnFillPolygon.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFillPolygon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFillPolygon.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFillPolygon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFillPolygon.FillColor = System.Drawing.Color.White;
            this.btnFillPolygon.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnFillPolygon.ForeColor = System.Drawing.Color.Black;
            this.btnFillPolygon.Image = global::ComputerGraphicsAssignment.Properties.Resources.paint_roller;
            this.btnFillPolygon.Location = new System.Drawing.Point(959, 337);
            this.btnFillPolygon.Name = "btnFillPolygon";
            this.btnFillPolygon.Size = new System.Drawing.Size(171, 36);
            this.btnFillPolygon.TabIndex = 8;
            this.btnFillPolygon.Text = "Fill Polygon";
            this.btnFillPolygon.Click += new System.EventHandler(this.btnFillPolygon_Click);
            // 
            // picCanvas
            // 
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCanvas.ImageRotate = 0F;
            this.picCanvas.Location = new System.Drawing.Point(12, 86);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(659, 423);
            this.picCanvas.TabIndex = 2;
            this.picCanvas.TabStop = false;
            // 
            // grpTranslation
            // 
            this.grpTranslation.Controls.Add(this.guna2HtmlLabel2);
            this.grpTranslation.Controls.Add(this.guna2HtmlLabel1);
            this.grpTranslation.Controls.Add(this.numTx);
            this.grpTranslation.Controls.Add(this.numTy);
            this.grpTranslation.Controls.Add(this.btnTranslate);
            this.grpTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTranslation.ForeColor = System.Drawing.Color.RoyalBlue;
            this.grpTranslation.Location = new System.Drawing.Point(677, 421);
            this.grpTranslation.Name = "grpTranslation";
            this.grpTranslation.Size = new System.Drawing.Size(438, 88);
            this.grpTranslation.TabIndex = 6;
            this.grpTranslation.TabStop = false;
            this.grpTranslation.Text = "Translation";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(12, 53);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(33, 27);
            this.guna2HtmlLabel2.TabIndex = 22;
            this.guna2HtmlLabel2.Text = "ty:";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 20);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(33, 27);
            this.guna2HtmlLabel1.TabIndex = 17;
            this.guna2HtmlLabel1.Text = "tx:";
            // 
            // numTx
            // 
            this.numTx.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numTx.DefaultText = "";
            this.numTx.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numTx.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numTx.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numTx.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numTx.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numTx.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numTx.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numTx.Location = new System.Drawing.Point(53, 20);
            this.numTx.Name = "numTx";
            this.numTx.PlaceholderText = "";
            this.numTx.SelectedText = "";
            this.numTx.Size = new System.Drawing.Size(200, 27);
            this.numTx.TabIndex = 21;
            // 
            // numTy
            // 
            this.numTy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numTy.DefaultText = "";
            this.numTy.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.numTy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.numTy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numTy.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.numTy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numTy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numTy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.numTy.Location = new System.Drawing.Point(53, 53);
            this.numTy.Name = "numTy";
            this.numTy.PlaceholderText = "";
            this.numTy.SelectedText = "";
            this.numTy.Size = new System.Drawing.Size(200, 27);
            this.numTy.TabIndex = 20;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Animated = true;
            this.btnTranslate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnTranslate.BorderRadius = 6;
            this.btnTranslate.BorderThickness = 2;
            this.btnTranslate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTranslate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTranslate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTranslate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTranslate.FillColor = System.Drawing.Color.White;
            this.btnTranslate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnTranslate.ForeColor = System.Drawing.Color.Black;
            this.btnTranslate.Location = new System.Drawing.Point(259, 30);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(173, 36);
            this.btnTranslate.TabIndex = 18;
            this.btnTranslate.Text = "Translate";
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // Rotation
            // 
            this.Rotation.Controls.Add(this.guna2HtmlLabel7);
            this.Rotation.Controls.Add(this.guna2TextBox1);
            this.Rotation.Controls.Add(this.btnRotate);
            this.Rotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rotation.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Rotation.Location = new System.Drawing.Point(677, 516);
            this.Rotation.Name = "Rotation";
            this.Rotation.Size = new System.Drawing.Size(438, 60);
            this.Rotation.TabIndex = 23;
            this.Rotation.TabStop = false;
            this.Rotation.Text = "Rotation";
            // 
            // guna2HtmlLabel7
            // 
            this.guna2HtmlLabel7.AutoSize = false;
            this.guna2HtmlLabel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel7.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel7.Location = new System.Drawing.Point(12, 20);
            this.guna2HtmlLabel7.Name = "guna2HtmlLabel7";
            this.guna2HtmlLabel7.Size = new System.Drawing.Size(33, 27);
            this.guna2HtmlLabel7.TabIndex = 17;
            this.guna2HtmlLabel7.Text = " θ°: ";
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(39, 20);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(200, 27);
            this.guna2TextBox1.TabIndex = 21;
            // 
            // btnRotate
            // 
            this.btnRotate.Animated = true;
            this.btnRotate.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnRotate.BorderRadius = 6;
            this.btnRotate.BorderThickness = 2;
            this.btnRotate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRotate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRotate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRotate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRotate.FillColor = System.Drawing.Color.White;
            this.btnRotate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnRotate.ForeColor = System.Drawing.Color.Black;
            this.btnRotate.Location = new System.Drawing.Point(259, 20);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(173, 29);
            this.btnRotate.TabIndex = 18;
            this.btnRotate.Text = "Rotation";
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // frmPolygonFilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 771);
            this.Controls.Add(this.Rotation);
            this.Controls.Add(this.grpTranslation);
            this.Controls.Add(this.grpExtraTools);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpHowToUse);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnFillPolygon);
            this.Controls.Add(this.grpConnectivity);
            this.Controls.Add(this.grpFillColor);
            this.Controls.Add(this.grpAlgorithms);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblMainTitle);
            this.Name = "frmPolygonFilling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Computer Graphics - Filling Algorithms Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.grpAlgorithms.ResumeLayout(false);
            this.grpAlgorithms.PerformLayout();
            this.grpFillColor.ResumeLayout(false);
            this.grpConnectivity.ResumeLayout(false);
            this.grpConnectivity.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpHowToUse.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.grpExtraTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grpTranslation.ResumeLayout(false);
            this.Rotation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblMainTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSubTitle;
        private Guna.UI2.WinForms.Guna2PictureBox picCanvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpAlgorithms;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnDrawPolygon;
        private Guna.UI2.WinForms.Guna2RadioButton rbFloodFill;
        private Guna.UI2.WinForms.Guna2RadioButton rbBoundaryFill;
        private Guna.UI2.WinForms.Guna2RadioButton rbScanLine;
        private System.Windows.Forms.GroupBox grpFillColor;
        private Guna.UI2.WinForms.Guna2Button btnChooseColor;
        private Guna.UI2.WinForms.Guna2Panel pnlFillColor;
        private System.Windows.Forms.GroupBox grpConnectivity;
        private Guna.UI2.WinForms.Guna2RadioButton rb8Connected;
        private Guna.UI2.WinForms.Guna2RadioButton rb4Connected;
        private Guna.UI2.WinForms.Guna2Button btnFillPolygon;
        private Guna.UI2.WinForms.Guna2Button btnSaveImage;
        private System.Windows.Forms.GroupBox grpStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private System.Windows.Forms.GroupBox grpHowToUse;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblInstructions;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblVertexLegend;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblEdgeLegend;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFilledAreaLegend;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.GroupBox grpExtraTools;
        private Guna.UI2.WinForms.Guna2Button btnZoomIn;
        private Guna.UI2.WinForms.Guna2Button btnShowVertices;
        private Guna.UI2.WinForms.Guna2Button btnZoomOut;
        private Guna.UI2.WinForms.Guna2Button btnRandomPolygon;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Guna.UI2.WinForms.Guna2Button btnSeedPoint;
        private Guna.UI2.WinForms.Guna2Button btnClosePolygon;
        private System.Windows.Forms.GroupBox grpTranslation;
        private Guna.UI2.WinForms.Guna2TextBox numTy;
        private Guna.UI2.WinForms.Guna2Button btnTranslate;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox numTx;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private System.Windows.Forms.GroupBox Rotation;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel7;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Guna.UI2.WinForms.Guna2Button btnRotate;
    }
}

