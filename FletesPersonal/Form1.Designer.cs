namespace FletesPersonal
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.BtnSalir = new FontAwesome.Sharp.IconButton();
            this.BtnUser = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCos = new FontAwesome.Sharp.IconButton();
            this.BtnRepor = new FontAwesome.Sharp.IconButton();
            this.BtnFlete = new FontAwesome.Sharp.IconButton();
            this.BtnCata = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.BtnHome = new System.Windows.Forms.PictureBox();
            this.PnlTitleBar = new System.Windows.Forms.Panel();
            this.IconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.BtnMaxi = new FontAwesome.Sharp.IconButton();
            this.BtnMini = new FontAwesome.Sharp.IconButton();
            this.LblTitleChildForm = new System.Windows.Forms.Label();
            this.PnlShadow = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PanelDesktop = new System.Windows.Forms.Panel();
            this.PanelMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).BeginInit();
            this.PnlTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.MediumBlue;
            this.PanelMenu.Controls.Add(this.BtnSalir);
            this.PanelMenu.Controls.Add(this.BtnUser);
            this.PanelMenu.Controls.Add(this.label1);
            this.PanelMenu.Controls.Add(this.BtnCos);
            this.PanelMenu.Controls.Add(this.BtnRepor);
            this.PanelMenu.Controls.Add(this.BtnFlete);
            this.PanelMenu.Controls.Add(this.BtnCata);
            this.PanelMenu.Controls.Add(this.panel2);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(150, 633);
            this.PanelMenu.TabIndex = 1;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnSalir.FlatAppearance.BorderSize = 0;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalir.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnSalir.ForeColor = System.Drawing.Color.LimeGreen;
            this.BtnSalir.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.BtnSalir.IconColor = System.Drawing.Color.Lime;
            this.BtnSalir.IconSize = 32;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(0, 514);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnSalir.Rotation = 0D;
            this.BtnSalir.Size = new System.Drawing.Size(150, 51);
            this.BtnSalir.TabIndex = 17;
            this.BtnSalir.Text = "  S A L I R";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnUser
            // 
            this.BtnUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnUser.FlatAppearance.BorderSize = 0;
            this.BtnUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUser.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnUser.ForeColor = System.Drawing.Color.Aqua;
            this.BtnUser.IconChar = FontAwesome.Sharp.IconChar.User;
            this.BtnUser.IconColor = System.Drawing.Color.Lime;
            this.BtnUser.IconSize = 25;
            this.BtnUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.Location = new System.Drawing.Point(0, 565);
            this.BtnUser.Name = "BtnUser";
            this.BtnUser.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnUser.Rotation = 0D;
            this.BtnUser.Size = new System.Drawing.Size(150, 45);
            this.BtnUser.TabIndex = 16;
            this.BtnUser.Text = "  User";
            this.BtnUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUser.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("Verdana", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.PaleGreen;
            this.label1.Location = new System.Drawing.Point(0, 610);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "2.19  Ver 25.01.28";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCos
            // 
            this.BtnCos.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCos.FlatAppearance.BorderSize = 0;
            this.BtnCos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCos.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnCos.ForeColor = System.Drawing.Color.LimeGreen;
            this.BtnCos.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.BtnCos.IconColor = System.Drawing.Color.Lime;
            this.BtnCos.IconSize = 32;
            this.BtnCos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCos.Location = new System.Drawing.Point(0, 250);
            this.BtnCos.Name = "BtnCos";
            this.BtnCos.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnCos.Rotation = 0D;
            this.BtnCos.Size = new System.Drawing.Size(150, 51);
            this.BtnCos.TabIndex = 11;
            this.BtnCos.Text = "Costos";
            this.BtnCos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCos.UseVisualStyleBackColor = true;
            this.BtnCos.Click += new System.EventHandler(this.BtnCos_Click);
            // 
            // BtnRepor
            // 
            this.BtnRepor.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnRepor.FlatAppearance.BorderSize = 0;
            this.BtnRepor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRepor.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnRepor.ForeColor = System.Drawing.Color.DarkKhaki;
            this.BtnRepor.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.BtnRepor.IconColor = System.Drawing.Color.Lime;
            this.BtnRepor.IconSize = 32;
            this.BtnRepor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRepor.Location = new System.Drawing.Point(0, 199);
            this.BtnRepor.Name = "BtnRepor";
            this.BtnRepor.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnRepor.Rotation = 0D;
            this.BtnRepor.Size = new System.Drawing.Size(150, 51);
            this.BtnRepor.TabIndex = 10;
            this.BtnRepor.Text = "Reportes";
            this.BtnRepor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRepor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRepor.UseVisualStyleBackColor = true;
            this.BtnRepor.Click += new System.EventHandler(this.BtnRepor_Click);
            // 
            // BtnFlete
            // 
            this.BtnFlete.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnFlete.FlatAppearance.BorderSize = 0;
            this.BtnFlete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFlete.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnFlete.ForeColor = System.Drawing.Color.Cyan;
            this.BtnFlete.IconChar = FontAwesome.Sharp.IconChar.TruckMoving;
            this.BtnFlete.IconColor = System.Drawing.Color.Lime;
            this.BtnFlete.IconSize = 32;
            this.BtnFlete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFlete.Location = new System.Drawing.Point(0, 148);
            this.BtnFlete.Name = "BtnFlete";
            this.BtnFlete.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnFlete.Rotation = 0D;
            this.BtnFlete.Size = new System.Drawing.Size(150, 51);
            this.BtnFlete.TabIndex = 9;
            this.BtnFlete.Text = "Captura Flete de Personal";
            this.BtnFlete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFlete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnFlete.UseVisualStyleBackColor = true;
            this.BtnFlete.Click += new System.EventHandler(this.BtnFlete_Click);
            // 
            // BtnCata
            // 
            this.BtnCata.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnCata.FlatAppearance.BorderSize = 0;
            this.BtnCata.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCata.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnCata.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCata.ForeColor = System.Drawing.Color.LimeGreen;
            this.BtnCata.IconChar = FontAwesome.Sharp.IconChar.Tasks;
            this.BtnCata.IconColor = System.Drawing.Color.Lime;
            this.BtnCata.IconSize = 32;
            this.BtnCata.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCata.Location = new System.Drawing.Point(0, 96);
            this.BtnCata.Name = "BtnCata";
            this.BtnCata.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.BtnCata.Rotation = 0D;
            this.BtnCata.Size = new System.Drawing.Size(150, 52);
            this.BtnCata.TabIndex = 8;
            this.BtnCata.Text = "Catalogos";
            this.BtnCata.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCata.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnCata.UseVisualStyleBackColor = true;
            this.BtnCata.Click += new System.EventHandler(this.BtnCata_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.iconPictureBox1);
            this.panel2.Controls.Add(this.BtnHome);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 96);
            this.panel2.TabIndex = 2;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.MediumBlue;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.AlignJustify;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconSize = 27;
            this.iconPictureBox1.Location = new System.Drawing.Point(4, 63);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(27, 29);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox1.TabIndex = 10;
            this.iconPictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.iconPictureBox1, "Minimizar Menu");
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // BtnHome
            // 
            this.BtnHome.BackColor = System.Drawing.Color.Transparent;
            this.BtnHome.Image = global::FletesPersonal.Properties.Resources.logo;
            this.BtnHome.Location = new System.Drawing.Point(46, 13);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(76, 67);
            this.BtnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BtnHome.TabIndex = 3;
            this.BtnHome.TabStop = false;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // PnlTitleBar
            // 
            this.PnlTitleBar.BackColor = System.Drawing.Color.MediumBlue;
            this.PnlTitleBar.Controls.Add(this.IconCurrentChildForm);
            this.PnlTitleBar.Controls.Add(this.BtnMaxi);
            this.PnlTitleBar.Controls.Add(this.BtnMini);
            this.PnlTitleBar.Controls.Add(this.LblTitleChildForm);
            this.PnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTitleBar.Location = new System.Drawing.Point(150, 0);
            this.PnlTitleBar.Name = "PnlTitleBar";
            this.PnlTitleBar.Size = new System.Drawing.Size(886, 46);
            this.PnlTitleBar.TabIndex = 2;
            this.PnlTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PnlTitleBar_MouseDown);
            // 
            // IconCurrentChildForm
            // 
            this.IconCurrentChildForm.BackColor = System.Drawing.Color.MediumBlue;
            this.IconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.IconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.IconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.IconCurrentChildForm.IconSize = 30;
            this.IconCurrentChildForm.Location = new System.Drawing.Point(7, 9);
            this.IconCurrentChildForm.Name = "IconCurrentChildForm";
            this.IconCurrentChildForm.Size = new System.Drawing.Size(30, 31);
            this.IconCurrentChildForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconCurrentChildForm.TabIndex = 9;
            this.IconCurrentChildForm.TabStop = false;
            // 
            // BtnMaxi
            // 
            this.BtnMaxi.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMaxi.FlatAppearance.BorderSize = 0;
            this.BtnMaxi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMaxi.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnMaxi.ForeColor = System.Drawing.Color.LimeGreen;
            this.BtnMaxi.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleUp;
            this.BtnMaxi.IconColor = System.Drawing.Color.Red;
            this.BtnMaxi.IconSize = 32;
            this.BtnMaxi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMaxi.Location = new System.Drawing.Point(814, 0);
            this.BtnMaxi.Name = "BtnMaxi";
            this.BtnMaxi.Rotation = 0D;
            this.BtnMaxi.Size = new System.Drawing.Size(32, 46);
            this.BtnMaxi.TabIndex = 8;
            this.BtnMaxi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMaxi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnMaxi.UseVisualStyleBackColor = true;
            this.BtnMaxi.Visible = false;
            // 
            // BtnMini
            // 
            this.BtnMini.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnMini.FlatAppearance.BorderSize = 0;
            this.BtnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMini.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.BtnMini.ForeColor = System.Drawing.Color.LimeGreen;
            this.BtnMini.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleDown;
            this.BtnMini.IconColor = System.Drawing.Color.Red;
            this.BtnMini.IconSize = 32;
            this.BtnMini.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMini.Location = new System.Drawing.Point(846, 0);
            this.BtnMini.Name = "BtnMini";
            this.BtnMini.Rotation = 0D;
            this.BtnMini.Size = new System.Drawing.Size(40, 46);
            this.BtnMini.TabIndex = 7;
            this.BtnMini.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMini.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnMini.UseVisualStyleBackColor = true;
            this.BtnMini.Click += new System.EventHandler(this.BtnMini_Click);
            // 
            // LblTitleChildForm
            // 
            this.LblTitleChildForm.AutoSize = true;
            this.LblTitleChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitleChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.LblTitleChildForm.Location = new System.Drawing.Point(43, 16);
            this.LblTitleChildForm.Name = "LblTitleChildForm";
            this.LblTitleChildForm.Size = new System.Drawing.Size(53, 18);
            this.LblTitleChildForm.TabIndex = 1;
            this.LblTitleChildForm.Text = "Home";
            // 
            // PnlShadow
            // 
            this.PnlShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlShadow.Location = new System.Drawing.Point(150, 46);
            this.PnlShadow.Name = "PnlShadow";
            this.PnlShadow.Size = new System.Drawing.Size(886, 9);
            this.PnlShadow.TabIndex = 3;
            // 
            // PanelDesktop
            // 
            this.PanelDesktop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelDesktop.Location = new System.Drawing.Point(150, 55);
            this.PanelDesktop.Name = "PanelDesktop";
            this.PanelDesktop.Size = new System.Drawing.Size(886, 578);
            this.PanelDesktop.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 633);
            this.Controls.Add(this.PanelDesktop);
            this.Controls.Add(this.PnlShadow);
            this.Controls.Add(this.PnlTitleBar);
            this.Controls.Add(this.PanelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PanelMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnHome)).EndInit();
            this.PnlTitleBar.ResumeLayout(false);
            this.PnlTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconCurrentChildForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox BtnHome;
        private System.Windows.Forms.Panel PnlTitleBar;
        private System.Windows.Forms.Label LblTitleChildForm;
        private System.Windows.Forms.Panel PnlShadow;
        private System.Windows.Forms.Panel PanelDesktop;
        private FontAwesome.Sharp.IconButton BtnCos;
        private FontAwesome.Sharp.IconButton BtnRepor;
        private FontAwesome.Sharp.IconButton BtnFlete;
        private FontAwesome.Sharp.IconButton BtnCata;
        private FontAwesome.Sharp.IconButton BtnMaxi;
        private FontAwesome.Sharp.IconButton BtnMini;
        private FontAwesome.Sharp.IconPictureBox IconCurrentChildForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton BtnSalir;
        private FontAwesome.Sharp.IconButton BtnUser;
    }
}

