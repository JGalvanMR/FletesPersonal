using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace FletesPersonal
{
    public partial class Form1 : Form
    {
        SqlConnection ThisConection = new SqlConnection(Utilerias.Class1.ConnectionString);

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        string Ocultar = "F";
        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            PanelMenu.Controls.Add(leftBorderBtn);
            //form
            this.Text = "";
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                // Boton
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon current Child Form
                IconCurrentChildForm.IconChar = currentBtn.IconChar;
                IconCurrentChildForm.IconColor = currentBtn.IconColor;
                LblTitleChildForm.Text = currentBtn.Text;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.MediumBlue;
                currentBtn.ForeColor = Color.LimeGreen;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.LimeGreen; ;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwind, int wMsg, int wParam, int lParam);

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            //Icon current Child Form
            IconCurrentChildForm.IconChar = IconChar.Home;
            IconCurrentChildForm.IconColor = Color.MediumPurple;
            LblTitleChildForm.Text = "Home";
        }
        

        private void OpenChildForm(Form childForm)
        {
            //if (currentChildForm != null)
            //{
            // abrir solamente 1 forma
            //currentChildForm.Close();
            //PanelMenu.Enabled = true;
            //}
            if (this.PanelDesktop.Controls.Count == 0)
            {
                currentChildForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                PanelDesktop.Controls.Add(childForm);
                PanelDesktop.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
                LblTitleChildForm.Text = childForm.Text;
            }
            //PanelMenu.Enabled = false;
        }

        private void BtnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        

        private void BtnHome_Click(object sender, EventArgs e)
        {
            //currentChildForm.Close();
            Reset();
        }

        private void BtnCata_Click(object sender, EventArgs e)
        {
            if(this.PanelDesktop.Controls.Count == 0)
            {
                ActivateButton(sender, Color.LightBlue);
                OpenChildForm(new FrmCatalogos());
                //FrmCatalogos FrmCata = new FrmCatalogos();
                //FrmCata.ShowDialog(this);
            }
        }

        private void BtnFlete_Click(object sender, EventArgs e)
        {
            if (this.PanelDesktop.Controls.Count == 0)
            {
                ActivateButton(sender, Color.LightBlue);
                OpenChildForm(new FrmFlete());
            }
        }

        private void BtnRepor_Click(object sender, EventArgs e)
        {
            if (this.PanelDesktop.Controls.Count == 0)
            {
                ActivateButton(sender, Color.LightBlue);
                OpenChildForm(new FrmReporte());
            }
        }


        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            if (this.PanelDesktop.Controls.Count == 0)
            {
                Reset();
                if (Ocultar == "F")
                {
                    PanelMenu.Size = new Size(50, this.Size.Height);
                    BtnCata.Text = "";
                    BtnFlete.Text = "";
                    BtnRepor.Text = "";
                    BtnSalir.Text = "";
                    BtnCos.Text = "";
                    BtnUser.Text = "";
                    Ocultar = "T";
                }
                else
                {
                    PanelMenu.Size = new Size(150, this.Size.Height);
                    BtnCata.Text = "Catalogos";
                    BtnFlete.Text = "Captura de Flete de Personal";
                    BtnRepor.Text = "Reportes";
                    BtnSalir.Text = "S A L I R";
                    BtnCos.Text = "Costos";
                    BtnUser.Text = Traeuser(Utilerias.Class1.Usu_login);
                    Ocultar = "F";
                }
            }
        }

        private void BtnCos_Click(object sender, EventArgs e)
        {
            if (this.PanelDesktop.Controls.Count == 0)
            {
                ActivateButton(sender, Color.LightBlue);
                //OpenChildForm(new FrmImportarExcel());
                FrmCostos FrmCost = new FrmCostos();
                FrmCost.ShowDialog(this);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BtnCata.Enabled = false;
            BtnCos.Enabled = false;
            BtnRepor.Enabled = false;
            BtnFlete.Enabled = false;
            BtnUser.Text = Traeuser(Utilerias.Class1.Usu_login); 
            if (Utilerias.Class1.Usu_login.Trim() == "RH" || Utilerias.Class1.Usu_login.Trim() == "N" || Utilerias.Class1.Usu_login.Trim() == "JOSE" ||
               Utilerias.Class1.Usu_login.Trim() == "C" || Utilerias.Class1.Usu_login.Trim() == "ADMINISTRA" || Utilerias.Class1.Usu_login.Trim() == "MDELRIO" ||
               Utilerias.Class1.Usu_login.Trim() == "DENISE")
            {
                if (Utilerias.Class1.Usu_login.Trim() == "RH" || Utilerias.Class1.Usu_login.Trim() == "N" || Utilerias.Class1.Usu_login.Trim() == "ADMINISTRA")
                    BtnCata.Enabled = true;
                BtnCos.Enabled = true;
                BtnRepor.Enabled = true;
                BtnFlete.Enabled = true;
            }
            if (Utilerias.Class1.Usu_login.Trim() == "PRIMA")
            {
                BtnFlete.Enabled = true;
            }
        }

        private string  Traeuser(string Login)
        {
            string Nom = "";
            ThisConection.Open();
            string Cadena = "SELECT usu_nombre FROM tb_cat_usuarios WHERE usu_login = '"+ Login.Trim() + "'";
            SqlCommand cmd = new SqlCommand(Cadena, ThisConection);
            Nom = cmd.ExecuteScalar().ToString();
            ThisConection.Close();
            return Nom.Trim(); 
        }
    }
}
