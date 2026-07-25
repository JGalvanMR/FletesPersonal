namespace FletesPersonal
{
    partial class FrmMapa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblInfo = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.TrackZoom = new System.Windows.Forms.TrackBar();
            this.PnlDgDatos = new System.Windows.Forms.Panel();
            this.DgDatos = new System.Windows.Forms.DataGridView();
            this.LblZoom = new System.Windows.Forms.Label();
            this.BtnRuta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.PnlMaps = new System.Windows.Forms.Panel();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackZoom)).BeginInit();
            this.PnlDgDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgDatos)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PnlMaps.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblInfo);
            this.panel1.Controls.Add(this.iconPictureBox1);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1302, 74);
            this.panel1.TabIndex = 1;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.ForeColor = System.Drawing.Color.Navy;
            this.LblInfo.Location = new System.Drawing.Point(91, 28);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(217, 20);
            this.LblInfo.TabIndex = 30;
            this.LblInfo.Text = "Detalle de Fletes de Personal";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Red;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.MapMarkedAlt;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Red;
            this.iconPictureBox1.IconSize = 57;
            this.iconPictureBox1.Location = new System.Drawing.Point(11, 10);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(67, 57);
            this.iconPictureBox1.TabIndex = 29;
            this.iconPictureBox1.TabStop = false;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.ForeColor = System.Drawing.Color.Transparent;
            this.BtnSalir.Image = global::FletesPersonal.Properties.Resources.BtnSalir_Mini;
            this.BtnSalir.Location = new System.Drawing.Point(1255, 12);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(35, 37);
            this.BtnSalir.TabIndex = 27;
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // TrackZoom
            // 
            this.TrackZoom.Location = new System.Drawing.Point(152, 5);
            this.TrackZoom.Maximum = 25;
            this.TrackZoom.Name = "TrackZoom";
            this.TrackZoom.Size = new System.Drawing.Size(121, 45);
            this.TrackZoom.TabIndex = 1;
            this.TrackZoom.Value = 25;
            // 
            // PnlDgDatos
            // 
            this.PnlDgDatos.Controls.Add(this.DgDatos);
            this.PnlDgDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlDgDatos.Location = new System.Drawing.Point(0, 55);
            this.PnlDgDatos.Name = "PnlDgDatos";
            this.PnlDgDatos.Size = new System.Drawing.Size(333, 526);
            this.PnlDgDatos.TabIndex = 2;
            // 
            // DgDatos
            // 
            this.DgDatos.AllowUserToAddRows = false;
            this.DgDatos.AllowUserToDeleteRows = false;
            this.DgDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgDatos.Location = new System.Drawing.Point(0, 0);
            this.DgDatos.Name = "DgDatos";
            this.DgDatos.ReadOnly = true;
            this.DgDatos.Size = new System.Drawing.Size(333, 526);
            this.DgDatos.TabIndex = 1;
            // 
            // LblZoom
            // 
            this.LblZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblZoom.ForeColor = System.Drawing.Color.Green;
            this.LblZoom.Location = new System.Drawing.Point(282, 29);
            this.LblZoom.Name = "LblZoom";
            this.LblZoom.Size = new System.Drawing.Size(33, 14);
            this.LblZoom.TabIndex = 2;
            this.LblZoom.Text = "0";
            this.LblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnRuta
            // 
            this.BtnRuta.Location = new System.Drawing.Point(9, 27);
            this.BtnRuta.Name = "BtnRuta";
            this.BtnRuta.Size = new System.Drawing.Size(75, 23);
            this.BtnRuta.TabIndex = 0;
            this.BtnRuta.Text = "Ruta";
            this.BtnRuta.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(282, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zoom";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PnlDgDatos);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 581);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.LblZoom);
            this.panel3.Controls.Add(this.TrackZoom);
            this.panel3.Controls.Add(this.BtnRuta);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(333, 55);
            this.panel3.TabIndex = 1;
            // 
            // PnlMaps
            // 
            this.PnlMaps.Controls.Add(this.gMap);
            this.PnlMaps.Location = new System.Drawing.Point(339, 79);
            this.PnlMaps.Name = "PnlMaps";
            this.PnlMaps.Size = new System.Drawing.Size(951, 575);
            this.PnlMaps.TabIndex = 4;
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(0, 0);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = true;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(951, 575);
            this.gMap.TabIndex = 3;
            this.gMap.Zoom = 0D;
            // 
            // FrmMapa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 655);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PnlMaps);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMapa";
            this.Text = "FrmMapa";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackZoom)).EndInit();
            this.PnlDgDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgDatos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.PnlMaps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblInfo;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TrackBar TrackZoom;
        private System.Windows.Forms.Panel PnlDgDatos;
        private System.Windows.Forms.DataGridView DgDatos;
        private System.Windows.Forms.Label LblZoom;
        private System.Windows.Forms.Button BtnRuta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel PnlMaps;
        private GMap.NET.WindowsForms.GMapControl gMap;

    }
}