using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FletesPersonal
{
    public partial class FrmDetalle : Form
    {
        SqlConnection ThisConnection = new SqlConnection(Utilerias.Class1.ConnectionString);
        //SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        string query = "";
        DataTable Fletes = new DataTable();
        public string CvePro = "", CveDes = "", FI = "", FF = "", CvPro="", CvDes="";

        private void DgDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmRecorrido FrmRut = new FrmRecorrido();
            FrmRut.Prov = CvePro;
            FrmRut.Ruta = (CveDes.Trim().Length > 0) ? CveDes : DgDatos.CurrentRow.Cells["NomDestFlete"].Value.ToString(); ;
            FrmRut.IdFlete = DgDatos.CurrentRow.Cells["IdFlete"].Value.ToString();
            FrmRut.Tipo = DgDatos.CurrentRow.Cells["TipoViaje"].Value.ToString();
            FrmRut.TipoFle = DgDatos.CurrentRow.Cells["TipoFlete"].Value.ToString();
            FrmRut.ShowDialog(this);
            //FrmMapa frmMap = new FrmMapa();
            //frmMap.ShowDialog(this);
        }

        public FrmDetalle()
        {
            InitializeComponent();
        }

        private void FrmDetalle_Load(object sender, EventArgs e)
        {
            label1.Text = "Prov: " + CvePro;
            string Cad = "", ruta = "c.NomDestFlete,";  
            if (CvePro.Trim().Length > 0) 
                Cad = "AND b.Prov_Nombre = '"+ CvePro+"' ";
            if (CveDes.Trim().Length > 0)
            {
                Cad = Cad + "AND c.NomDestFlete = '" + CveDes + "' ";
                ruta = "";
                label1.Text += "   Ruta: " + CveDes;
            }
            ThisConnection.Open();
            //query = "SELECT  IdFletePer, FlePer_Fecha, FlePer_Hora, Prov_Clave, IdDestFlete, FlePer_Area, FlePer_Turno, FlePer_TipoFlete, " +
            query = "SELECT a.IdFletePer as IdFlete, " + ruta + "  a.FlePer_Fecha as Fecha, a.FlePer_Fecha as Fecha, a.FlePer_Hora as Hora,a.FlePer_Area as Area, a.FlePer_Turno as Turno, a.FlePer_TipoFlete as TipoFlete, a.FlePer_TipoViaje as TipoViaje, " +
                    "a.FlePer_Cantidad as Cantidad, a.FlePer_Costo as Costo, a.FlePer_Status as Estatus, a.FlePer_Captura as Capturo, a.FlePer_Semana as Semana, A.FlePer_Chofer as Chofer " +
                    "FROM Tb_FlePer_FletePersonal A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
                    "WHERE FlePer_Fecha BETWEEN '"+ FI +"' AND '"+ FF +"' AND FlePer_Status = 'A' AND A.Prov_Clave = b.prov_clave AND a.IdDestFlete = c.IdDestFlete " + Cad +
                    "ORDER BY "+ ruta +"FlePer_Fecha, a.FlePer_Hora ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "Fletes");
            Fletes = ds.Tables["Fletes"];
            DgDatos.DataSource = Fletes;
            ThisConnection.Close();
            formato();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnPer_Click(object sender, EventArgs e)
        {
            Int32 TotFle = 0;
            foreach (DataRow row in Fletes.Rows)
                if (row["Chofer"].ToString().Trim().Length > 0)
                    TotFle++;
            FrmAnalisisPersonal FrmPer = new FrmAnalisisPersonal();
            FrmPer.CveDes = CveDes;
            FrmPer.CvePro = CvePro;
            FrmPer.CvDes = CvDes;
            FrmPer.CvPro = CvPro;
            FrmPer.FI = FI;
            FrmPer.FF = FF;
            FrmPer.NoFle = TotFle.ToString(); //Fletes.Rows.Count.ToString();  
            FrmPer.ShowDialog(this);
        }

        private void formato()
        {
            Int32 j = 0;
            foreach (DataGridViewRow row in DgDatos.Rows)
            {
                //string Pve = DgDatos.Rows[j].Cells["Prov_Clave"].Value.ToString();
                //string Dve = DgDatos.Rows[j].Cells["IdDestFlete"].Value.ToString();
                //foreach (DataRow Row in FleXIng.Select("Prov_Clave = '" + Pve + "' and IdDestFlete = '" + Dve + "'"))
                //{
                if (DgDatos.Rows[j].Cells["Capturo"].Value.ToString().Trim() == "")
                {
                    //DgRutas.Rows[j].Cells[3].Style.BackColor = System.Drawing.Color.Red;
                    DgDatos[0, j].Style.BackColor = System.Drawing.Color.Red;
                    DgDatos.Rows[j].Cells["IdFlete"].Style.ForeColor = System.Drawing.Color.White;
                    //DgRutas[3, j].ToolTipText = "Ruta Con Fletes Pendientes x Ingresar";
                    //DgRutas.Rows[j].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
                //}
                j++;
            }
        }

        
    }
}
