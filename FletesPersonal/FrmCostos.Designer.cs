namespace FletesPersonal
{
    partial class FrmCostos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCostos));
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChartSem = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.LblXdia = new System.Windows.Forms.Label();
            this.LblProm = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LblTotCos = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.LblTotFle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnExcel = new FontAwesome.Sharp.IconButton();
            this.IcnBtnRefresh = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtFF = new System.Windows.Forms.DateTimePicker();
            this.DtFI = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DgExcel = new System.Windows.Forms.DataGridView();
            this.LblInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DgDatosC = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DgDatos = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSem)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgExcel)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgDatosC)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.ChartSem);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.BtnExcel);
            this.panel3.Controls.Add(this.IcnBtnRefresh);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.DtFF);
            this.panel3.Controls.Add(this.DtFI);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 57);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1182, 192);
            this.panel3.TabIndex = 28;
            // 
            // ChartSem
            // 
            this.ChartSem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChartSem.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisY.MajorGrid.LineWidth = 0;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Transparent;
            chartArea1.AxisY.MajorTickMark.LineWidth = 0;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.ChartSem.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Enabled = false;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.ChartSem.Legends.Add(legend1);
            this.ChartSem.Location = new System.Drawing.Point(1, 81);
            this.ChartSem.Name = "ChartSem";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            series1.IsValueShownAsLabel = true;
            series1.LabelAngle = 90;
            series1.LabelForeColor = System.Drawing.Color.DarkBlue;
            series1.LabelFormat = "#,###";
            series1.LabelToolTip = "#VALX{N0}";
            series1.Legend = "Legend1";
            series1.MarkerSize = 1;
            series1.Name = "Series1";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.SmartLabelStyle.IsMarkerOverlappingAllowed = true;
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.ChartSem.Series.Add(series1);
            this.ChartSem.Series.Add(series2);
            this.ChartSem.Size = new System.Drawing.Size(1179, 109);
            this.ChartSem.TabIndex = 57;
            this.ChartSem.Text = "Costo x Semana";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            title1.ForeColor = System.Drawing.Color.Blue;
            title1.Name = "Title1";
            title1.Text = "Costo x Semana";
            this.ChartSem.Titles.Add(title1);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.LblXdia);
            this.panel6.Controls.Add(this.LblProm);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Location = new System.Drawing.Point(683, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(155, 73);
            this.panel6.TabIndex = 56;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(115, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Tope";
            // 
            // LblXdia
            // 
            this.LblXdia.AutoSize = true;
            this.LblXdia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblXdia.ForeColor = System.Drawing.Color.DarkBlue;
            this.LblXdia.Location = new System.Drawing.Point(123, 18);
            this.LblXdia.Name = "LblXdia";
            this.LblXdia.Size = new System.Drawing.Size(16, 17);
            this.LblXdia.TabIndex = 42;
            this.LblXdia.Text = "0";
            this.LblXdia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblProm
            // 
            this.LblProm.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProm.ForeColor = System.Drawing.Color.LimeGreen;
            this.LblProm.Location = new System.Drawing.Point(3, 32);
            this.LblProm.Name = "LblProm";
            this.LblProm.Size = new System.Drawing.Size(149, 39);
            this.LblProm.TabIndex = 41;
            this.LblProm.Text = "0";
            this.LblProm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(2, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 17);
            this.label9.TabIndex = 40;
            this.label9.Text = "Promedio x Dia";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.LblTotCos);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(512, 10);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(155, 65);
            this.panel5.TabIndex = 55;
            // 
            // LblTotCos
            // 
            this.LblTotCos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotCos.ForeColor = System.Drawing.Color.Blue;
            this.LblTotCos.Location = new System.Drawing.Point(2, 24);
            this.LblTotCos.Name = "LblTotCos";
            this.LblTotCos.Size = new System.Drawing.Size(150, 39);
            this.LblTotCos.TabIndex = 41;
            this.LblTotCos.Text = "0";
            this.LblTotCos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(48, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 40;
            this.label7.Text = "Costo $";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.LblTotFle);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Location = new System.Drawing.Point(342, 10);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(155, 65);
            this.panel7.TabIndex = 54;
            // 
            // LblTotFle
            // 
            this.LblTotFle.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotFle.ForeColor = System.Drawing.Color.Blue;
            this.LblTotFle.Location = new System.Drawing.Point(3, 25);
            this.LblTotFle.Name = "LblTotFle";
            this.LblTotFle.Size = new System.Drawing.Size(149, 36);
            this.LblTotFle.TabIndex = 41;
            this.LblTotFle.Text = "0";
            this.LblTotFle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(24, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "Total de Fletes";
            // 
            // BtnExcel
            // 
            this.BtnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnExcel.BackColor = System.Drawing.Color.Transparent;
            this.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcel.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcel.ForeColor = System.Drawing.Color.Blue;
            this.BtnExcel.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.BtnExcel.IconColor = System.Drawing.Color.Green;
            this.BtnExcel.IconSize = 35;
            this.BtnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExcel.Location = new System.Drawing.Point(1042, 35);
            this.BtnExcel.Name = "BtnExcel";
            this.BtnExcel.Rotation = 0D;
            this.BtnExcel.Size = new System.Drawing.Size(41, 38);
            this.BtnExcel.TabIndex = 53;
            this.BtnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExcel.UseVisualStyleBackColor = false;
            this.BtnExcel.Visible = false;
            this.BtnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // IcnBtnRefresh
            // 
            this.IcnBtnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.IcnBtnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.IcnBtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IcnBtnRefresh.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.IcnBtnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IcnBtnRefresh.ForeColor = System.Drawing.Color.Blue;
            this.IcnBtnRefresh.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.IcnBtnRefresh.IconColor = System.Drawing.Color.Blue;
            this.IcnBtnRefresh.IconSize = 25;
            this.IcnBtnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.IcnBtnRefresh.Location = new System.Drawing.Point(258, 42);
            this.IcnBtnRefresh.Name = "IcnBtnRefresh";
            this.IcnBtnRefresh.Rotation = 0D;
            this.IcnBtnRefresh.Size = new System.Drawing.Size(36, 31);
            this.IcnBtnRefresh.TabIndex = 52;
            this.IcnBtnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IcnBtnRefresh.UseVisualStyleBackColor = false;
            this.IcnBtnRefresh.Click += new System.EventHandler(this.IcnBtnRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(136, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 40;
            this.label3.Text = "Fecha Fin: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Fecha Ini: ";
            // 
            // DtFF
            // 
            this.DtFF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFF.Location = new System.Drawing.Point(137, 52);
            this.DtFF.Name = "DtFF";
            this.DtFF.Size = new System.Drawing.Size(106, 20);
            this.DtFF.TabIndex = 1;
            // 
            // DtFI
            // 
            this.DtFI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtFI.Location = new System.Drawing.Point(12, 52);
            this.DtFI.Name = "DtFI";
            this.DtFI.Size = new System.Drawing.Size(106, 20);
            this.DtFI.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.iconPictureBox1);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1182, 57);
            this.panel1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(50, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "Reporte de Fletes de Personal";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Lime;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Lime;
            this.iconPictureBox1.Location = new System.Drawing.Point(12, 10);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 27;
            this.iconPictureBox1.TabStop = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.ForeColor = System.Drawing.Color.Transparent;
            this.BtnSalir.Image = global::FletesPersonal.Properties.Resources.BtnSalir_Mini;
            this.BtnSalir.Location = new System.Drawing.Point(1136, 10);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(35, 37);
            this.BtnSalir.TabIndex = 26;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // DgExcel
            // 
            this.DgExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgExcel.Location = new System.Drawing.Point(798, 416);
            this.DgExcel.Name = "DgExcel";
            this.DgExcel.Size = new System.Drawing.Size(240, 150);
            this.DgExcel.TabIndex = 31;
            this.DgExcel.Visible = false;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.BackColor = System.Drawing.Color.Transparent;
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.Location = new System.Drawing.Point(412, 602);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(368, 26);
            this.LblInfo.TabIndex = 32;
            this.LblInfo.Text = "Exportando la Informacion a Excel....";
            this.LblInfo.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DgDatosC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1182, 110);
            this.panel2.TabIndex = 33;
            // 
            // DgDatosC
            // 
            this.DgDatosC.AllowUserToAddRows = false;
            this.DgDatosC.AllowUserToDeleteRows = false;
            this.DgDatosC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgDatosC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgDatosC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgDatosC.Location = new System.Drawing.Point(0, 0);
            this.DgDatosC.Name = "DgDatosC";
            this.DgDatosC.ReadOnly = true;
            this.DgDatosC.Size = new System.Drawing.Size(1182, 110);
            this.DgDatosC.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DgDatos);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 359);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1182, 348);
            this.panel4.TabIndex = 34;
            // 
            // DgDatos
            // 
            this.DgDatos.AllowUserToAddRows = false;
            this.DgDatos.AllowUserToDeleteRows = false;
            this.DgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgDatos.Location = new System.Drawing.Point(0, 0);
            this.DgDatos.Name = "DgDatos";
            this.DgDatos.ReadOnly = true;
            this.DgDatos.Size = new System.Drawing.Size(1182, 348);
            this.DgDatos.TabIndex = 31;
            this.DgDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgDatos_CellDoubleClick);
            // 
            // FrmCostos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 707);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.DgExcel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCostos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Viajes y Costos de Fletes de Personal";
            this.Load += new System.EventHandler(this.FrmCostos_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSem)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgExcel)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgDatosC)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton IcnBtnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtFF;
        private System.Windows.Forms.DateTimePicker DtFI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Button BtnSalir;
        private FontAwesome.Sharp.IconButton BtnExcel;
        private System.Windows.Forms.DataGridView DgExcel;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgDatosC;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView DgDatos;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label LblXdia;
        private System.Windows.Forms.Label LblProm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label LblTotCos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label LblTotFle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartSem;
        private System.Windows.Forms.Label label5;
    }
}