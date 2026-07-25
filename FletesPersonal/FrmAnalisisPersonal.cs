using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FletesPersonal
{
    public partial class FrmAnalisisPersonal : Form
    {
        SqlConnection ThisConnection = new SqlConnection(Utilerias.Class1.ConnectionString);
        //SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        string query = "";
        DataTable Personal = new DataTable();
        public string CvePro = "", CveDes = "", FI = "", FF = "", NoFle = "", CvPro="", CvDes="" ;

        public FrmAnalisisPersonal()
        {
            InitializeComponent();
        }

        private void FrmAnalisisPersonal_Load(object sender, EventArgs e)
        {
            label1.Text = "Prov: " + CvePro + "   Ruta: " + CveDes;
            label2.Text = "No. de Viajes " + NoFle;
            query = "SELECT * FROM " +
                    "(SELECT b.FlePer_Nombre AS Nombre, a.IdFletePer AS Tot, DATENAME(weekday, a.FlePer_Fecha) AS nomdia, (rtrim(c.emp_nombre) + ' ' + rtrim(c.emp_paterno) + ' ' + rtrim(c.emp_materno)) AS Nom " +
                    "FROM Tb_FlePer_FletePersonal a, Tb_FlePer_DetFlete b " +
                    "LEFT JOIN tb_cat_empleados c ON b.FlePer_CveNomina = c.emp_clave " +
                    "WHERE a.Prov_Clave = '"+ CvPro  +"' AND a.IdDestFlete = '"+ CvDes +"' AND a.FlePer_Fecha BETWEEN '"+ FI  +"' AND '"+FF+"' AND a.FlePer_Chofer != '' " +
                    "AND b.FlePer_CveNomina != 0 AND b.FlePer_CveNomina != 9999 AND a.FlePer_Status != 'C' " +
                    "AND a.IdFletePer = b.IdFletePer) " +
                    "AS SourceTable PIVOT(count(Tot) FOR [nomdia] IN([Lunes],[Martes],[Miércoles],[Jueves],[Viernes],[Sábado],[Domingo])) AS PivotTable " +
                    "ORDER BY Nombre ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "Personal");
            Personal = ds.Tables["Personal"];
            Personal.Columns.Add("Total");
            Personal.Columns.Add("Ocupacion");
            foreach (DataRow row in Personal.Rows)
            {
                //row["Total"] = (Convert.ToInt32(row[1]) + Convert.ToInt32(row[2]) + Convert.ToInt32(row[3]) + Convert.ToInt32(row[4]) + Convert.ToInt32(row[5]) + Convert.ToInt32(row[6]) + Convert.ToInt32(row[7])).ToString();
                row["Total"] = (Convert.ToInt32(row[8]) + Convert.ToInt32(row[2]) + Convert.ToInt32(row[3]) + Convert.ToInt32(row[4]) + Convert.ToInt32(row[5]) + Convert.ToInt32(row[6]) + Convert.ToInt32(row[7])).ToString();
                row["Ocupacion"] = ((Convert.ToDecimal(row["Total"]) / Convert.ToDecimal(NoFle))*100).ToString("###.00");
            }
            DGDatos.DataSource = Personal;
            DGDatos.Columns[0].Visible = false;
            DGDatos.Columns[1].Width = 300;
            DGDatos.Columns[2].Width = 60;
            DGDatos.Columns[3].Width = 60;
            DGDatos.Columns[4].Width = 60;
            DGDatos.Columns[5].Width = 60;
            DGDatos.Columns[6].Width = 60;
            DGDatos.Columns[7].Width = 60;
            DGDatos.Columns[8].Width = 60;
            DGDatos.Columns[9].Width = 60;
            DGDatos.Columns[10].Width = 60;


        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
