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
    public partial class FrmReporte : Form
    {
        SqlConnection ThisConnection = new SqlConnection(Utilerias.Class1.ConnectionString);
        string query = "";
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataTable FletesxDia = new DataTable();
        DataTable Fletes = new DataTable();


        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            string dia = System.DateTime.Now.ToString("ddd").Replace(".", "").ToUpper();
            int diaS = DiaSem(dia);
            int dia2 = (int)System.DateTime.Now.DayOfWeek;
            if (dia2 == 1)
                dia2 = 8;
            DtFI.Value = System.DateTime.Now.AddDays((dia2 - 1) * (-1));
            //DtFF.Value = Convert.ToDateTime("31/08/2024");
            CargaInfo(DtFI.Value.ToShortDateString(), DtFF.Value.ToShortDateString());
        }

        private int DiaSem(string DiaS)
        {
            int dia = 0;
            switch (DiaS)
            {
                case "DOM":
                    {
                        dia = 7;
                        break;
                    }
                case "LUN":
                    {
                        dia = 1;
                        break;
                    }
                case "MAR":
                    {
                        dia = 2;
                        break;
                    }
                case "MIE":
                    {
                        dia = 3;
                        break;
                    }
                case "JUE":
                    {
                        dia = 4;
                        break;
                    }
                case "VIE":
                    {
                        dia = 5;
                        break;
                    }
                case "SAB":
                    {
                        dia = 6;
                        break;
                    }
            }
            return dia;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgRutas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 3)
            {
                FrmDetalle FrmDet = new FrmDetalle();
                FrmDet.CvePro = DgRutas.CurrentRow.Cells["proveedor"].Value.ToString().Trim();
                FrmDet.CveDes = "";
                FrmDet.CvPro = DgRutas.CurrentRow.Cells["Prov_Clave"].Value.ToString().Trim();
                FrmDet.CvDes = DgRutas.CurrentRow.Cells["IdDestFlete"].Value.ToString().Trim();
                FrmDet.FI = DtFI.Value.ToShortDateString();
                FrmDet.FF = DtFF.Value.ToShortDateString();
                if (e.ColumnIndex == 1 || e.ColumnIndex == 3) // clic en Ruta
                {
                    FrmDet.CveDes = DgRutas.CurrentRow.Cells["Ruta"].Value.ToString().Trim();
                }
                FrmDet.ShowDialog(this);
            }
        }

        private void IcnBtnRefresh_Click(object sender, EventArgs e)
        {
            CargaInfo(DtFI.Value.ToShortDateString(), DtFF.Value.ToShortDateString());
        }

        private void CargaInfo(string FI, string FF)
        {
            ThisConnection.Open();
            query = "SELECT COUNT(IdFletePer)   FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' and FlePer_Status = 'A' ";
            cmd = new SqlCommand(query, ThisConnection);
            LblTotFle.Text = Convert.ToString(cmd.ExecuteScalar());
            query = "SELECT SUM(FlePer_Costo) AS Costo FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "'  AND '" + FF + "' and FlePer_Status = 'A '";
            cmd = new SqlCommand(query, ThisConnection);
            string TotC = Convert.ToString(cmd.ExecuteScalar());
            LblTotCos.Text = (TotC.Trim().Length > 0) ? Convert.ToDecimal(cmd.ExecuteScalar()).ToString("#,###.00") : "0";
            query = "SELECT CAST(FlePer_Fecha AS DATE) as FlePer_Fecha, COUNT(IdFletePer) AS total FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' and FlePer_Status = 'A' " +
                    "GROUP BY CAST(FlePer_Fecha AS DATE)";
            query = "SELECT ISNULL(sum(FleteCant), 0)   FROM Tb_FlePer_Ruta WHERE ISNULL(DestStatus, 'A') <> 'B' ";
            cmd = new SqlCommand(query, ThisConnection);
            Int32 ViaxDia = Convert.ToInt32(cmd.ExecuteScalar());
            LblXdia.Text = ViaxDia.ToString();
            query = "SELECT count(FlePer_Fecha) AS TotalDias " +
                    "FROM " +
                    "( " +
                    "SELECT CAST(FlePer_Fecha AS DATE) as FlePer_Fecha, COUNT(IdFletePer) AS total FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' and FlePer_Status = 'A' " +
                    "GROUP BY CAST(FlePer_Fecha AS DATE) " +
                    ") AS Fletes ";

            cmd = new SqlCommand(query, ThisConnection);
            Int32 dias = Convert.ToInt32(cmd.ExecuteScalar());
            LblProm.Text = "0";
            if (Convert.ToDecimal(LblTotFle.Text) > 0 && dias > 0)
                LblProm.Text = (Convert.ToDecimal(LblTotFle.Text) / dias).ToString("#,###.#0");
            if (Convert.ToDecimal(LblProm.Text) > ViaxDia)
            {
                LblProm.ForeColor = Color.Red;
            }
            query = "SELECT CAST(FlePer_Fecha AS DATE)as FlePer_Fecha, COUNT(IdFletePer) AS total FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' and FlePer_Status = 'A' " +
                    "GROUP BY CAST(FlePer_Fecha AS DATE) ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "FletesxDia");
            FletesxDia = ds.Tables["FletesxDia"];
            query = "SELECT FlePer_Area, count(FlePer_Area) AS total FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' AND FlePer_Status = 'A' " +
                    "GROUP BY FlePer_Area ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "FleArea");
            DataTable FleArea = ds.Tables["FleArea"];

            query = "SELECT FlePer_Turno , count(FlePer_Turno) AS total FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' AND FlePer_Status = 'A' " +
                    "GROUP BY FlePer_Turno ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "FleTur");
            DataTable FleTur = ds.Tables["FleTur"];

            query = "SELECT FlePer_TipoFlete , count(FlePer_TipoFlete) AS total FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' AND FlePer_Status = 'A' " +
                    "GROUP BY FlePer_TipoFlete ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "FleTip");
            DataTable FleTip = ds.Tables["FleTip"];

            query = "SELECT FlePer_TipoViaje, count(FlePer_TipoViaje) AS total FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' AND FlePer_Status = 'A' " +
                    "GROUP BY FlePer_TipoViaje";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "FleVia");
            DataTable FleVia = ds.Tables["FleVia"];

            query = "Select NomDestFlete, FleteCant, RutaCupo frOm Tb_FlePer_Ruta ORDER BY IDDestFlete ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "Rutas");
            DataTable Rutas = ds.Tables["Rutas"];
            //query = "SELECT b.prov_nombre as Proveedor, c.NomDestFlete as Ruta, sum(a.FlePer_Cantidad) AS Personas, count(a.IdFletePer) AS Viajes, '' as Tope, (sum(a.Fleper_Cantidad) / count(a.IdFletePer)) as PromXPersona, " +
            //        "'' as Cupo, sum(a.FlePer_Costo) as CostoTotal, (sum(a.Fleper_Costo) / count(a.IdFletePer)) as CostoXFlete, (sum(a.Fleper_Costo) / sum(a.FlePer_Cantidad)) as CostoXPersona, a.Prov_Clave, a.IdDestFlete  " +
            //        "FROM Tb_FlePer_FletePersonal A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
            //        "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' AND FlePer_Status = 'A' AND A.Prov_Clave = b.prov_clave AND a.IdDestFlete = c.IdDestFlete " +
            //        "GROUP BY b.prov_nombre, C.NomDestFlete,a.Prov_Clave, a.IdDestFlete Order by b.prov_nombre, C.NomDestFlete  ";
            query = "SELECT b.prov_nombre as Proveedor, c.NomDestFlete as Ruta, sum(a.FlePer_Cantidad) AS Personas, count(a.IdFletePer) AS Viajes, '' as Tope, " +
                    "(sum(a.Fleper_Cantidad) / NULLIF(count(a.IdFletePer), 0)) as PromXPersona, " +
                    "'' as Cupo, sum(a.FlePer_Costo) as CostoTotal, " +
                    "(sum(a.Fleper_Costo) / NULLIF(count(a.IdFletePer), 0)) as CostoXFlete, " +
                    "(sum(a.Fleper_Costo) / NULLIF(sum(a.FlePer_Cantidad), 0)) as CostoXPersona, " +
                    "a.Prov_Clave, a.IdDestFlete " +
                    "FROM Tb_FlePer_FletePersonal A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' " +
                    "AND FlePer_Status = 'A' AND A.Prov_Clave = b.prov_clave AND a.IdDestFlete = c.IdDestFlete " +
                    "GROUP BY b.prov_nombre, C.NomDestFlete, a.Prov_Clave, a.IdDestFlete " +
                    "ORDER BY b.prov_nombre, C.NomDestFlete";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "Fletes");
            Fletes = ds.Tables["Fletes"];
            query = "SELECT count(a.IdFletePer) AS Viajes, a.Prov_Clave, a.IdDestFlete  " +
                    "FROM Tb_FlePer_FletePersonal A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
                    "WHERE FlePer_Fecha BETWEEN '" + FI + "' AND '" + FF + "' AND FlePer_Status = 'A' AND A.Prov_Clave = b.prov_clave AND a.IdDestFlete = c.IdDestFlete and A.FlePer_Captura IS NULL " +
                    "GROUP BY b.prov_nombre, C.NomDestFlete,a.Prov_Clave, a.IdDestFlete Order by b.prov_nombre, C.NomDestFlete  ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "FleXIng");
            DataTable FleXIng = ds.Tables["FleXIng"];
            query = "SELECT FlePer_Semana, COUNT(IdFletePer) AS total FROM Tb_FlePer_FletePersonal " +
                    //"WHERE FlePer_Fecha BETWEEN '01/08/2024' AND '31/12/2024' and FlePer_Status = 'A' and FlePer_Semana is Not null " +
                    "WHERE year(FlePer_Fecha) = year(getdate()) and FlePer_Status = 'A' and FlePer_Semana is Not null " +
                    "GROUP BY FlePer_Semana Order by FlePer_Semana ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "FleSem");
            DataTable FleSem = ds.Tables["FleSem"];
            ThisConnection.Close();

            foreach (DataRow row in Fletes.Rows)
            {
                foreach (DataRow Row in Rutas.Select("NomDestFlete = '" + row["Ruta"].ToString().Replace("'", "''") + "'"))
                {
                    // FleteCant / RutaCupo pueden venir NULL (rutas nuevas sin cupo): se toman como 0
                    int fleteCant = (Row["FleteCant"] == DBNull.Value) ? 0 : Convert.ToInt32(Row["FleteCant"]);
                    decimal rutaCupo = (Row["RutaCupo"] == DBNull.Value) ? 0m : Convert.ToDecimal(Row["RutaCupo"]);
                    row["Tope"] = (fleteCant * dias).ToString();
                    row["Cupo"] = rutaCupo;
                }
            }

            //ChartFletes.DataSource = null;
            //ChartFletes.DataSource = FletesxDia;
            ChartFletes.Series[0].Points.Clear();
            ChartFletes.Series[1].Points.Clear();
            //ChartFletes.Series[0].XValueMember = "FlePer_Fecha";
            //ChartFletes.Series[0].YValueMembers = "total";
            ChartFletes.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline; // .Spline .Line  ;
            //ChartFletes.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            ChartFletes.Series[0].IsValueShownAsLabel = true;
            ChartFletes.Series[0].LabelAngle = 45;
            ChartFletes.Series[0].Font = new Font("Verdana", 8, FontStyle.Bold);
            //ChartFletes.Series[0].Color = Color..Red;
            ChartFletes.Series[0].LabelForeColor = Color.DarkBlue;
            foreach (DataRow row in FletesxDia.Rows)
            {
                string dia = Convert.ToDateTime(row["FlePer_Fecha"]).ToString("ddd").Substring(0, 2);
                ChartFletes.Series[0].Points.AddXY(dia + " " + Convert.ToDateTime(row["FlePer_Fecha"]).ToString("dd-MMM"), row["total"]);
                ChartFletes.Series[1].Points.AddXY(dia + " " + Convert.ToDateTime(row["FlePer_Fecha"]).ToString("dd-MMM"), LblXdia.Text);
            }
            ChartFletes.Series[1].Color = Color.Red;
            ChartSem.Series[0].Points.Clear();
            ChartSem.Series[1].Points.Clear();
            foreach (DataRow row in FleSem.Rows)
            {
                //string dia = Convert.ToDateTime(row["FlePer_Fecha"]).ToString("ddd").Substring(0, 2);
                Int32 TotXSem = Convert.ToInt32(LblXdia.Text) * 6;
                if (Convert.ToInt32(row["FlePer_Semana"]) == 34) // Semana Inicial sin Ramiro
                    TotXSem = TotXSem - (6 * 6);
                ChartSem.Series[0].Points.AddXY(row["FlePer_Semana"], row["total"]);
                ChartSem.Series[1].Points.AddXY(row["FlePer_Semana"], TotXSem);
            }
            ChartSem.Series[1].Color = Color.Red;
            //GraficaArea.DataSource = null;
            //GraficaArea.Series[0].XValueMember = "FlePer_Area";
            //GraficaArea.Series[0].YValueMembers = "Total";
            //GraficaArea.DataSource = FleArea;
            //GraficaArea.ChartAreas[0].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            //GraficaTurno.DataSource = null;
            //GraficaTurno.Series[0].XValueMember = "FlePer_Turno";
            //GraficaTurno.Series[0].YValueMembers = "Total";
            //GraficaTurno.DataSource = FleTur;
            //GraficaTipo.DataSource = null;
            //GraficaTipo.Series[0].XValueMember = "FlePer_TipoFlete";
            //GraficaTipo.Series[0].YValueMembers = "Total";
            //GraficaTipo.DataSource = FleTip;
            GraficaArea.Series[0].Points.Clear();
            foreach (DataRow row in FleArea.Rows)
                GraficaArea.Series[0].Points.AddXY((row["FlePer_Area"].ToString().Trim().Length == 0) ? "X Registrar" : row["FlePer_Area"].ToString(), row["total"]);
            GraficaTurno.Series[0].Points.Clear();
            foreach (DataRow row in FleTur.Rows)
                GraficaTurno.Series[0].Points.AddXY((row["FlePer_Turno"].ToString().Trim().Length == 0) ? "X Registrar" : row["FlePer_Turno"].ToString(), row["total"]);
            GraficaTipo.Series[0].Points.Clear();
            foreach (DataRow row in FleTip.Rows)
                GraficaTipo.Series[0].Points.AddXY(row["FlePer_Tipoflete"].ToString(), row["total"]);

            DgRutas.DataSource = Fletes;
            DgRutas.Columns[10].Visible = false;
            DgRutas.Columns[11].Visible = false;
            for (int i = 2; i <= 9; i++)
                DgRutas.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            for (int i = 5; i <= 9; i++)
                DgRutas.Columns[i].DefaultCellStyle.Format = ("#,###.#0");
            Formato(FleXIng);

        }

        private void Formato(DataTable FleXIng)
        {
            Int32 j = 0;
            foreach (DataGridViewRow row in DgRutas.Rows)
            {
                string Pve = DgRutas.Rows[j].Cells["Prov_Clave"].Value.ToString();
                string Dve = DgRutas.Rows[j].Cells["IdDestFlete"].Value.ToString();
                foreach (DataRow Row in FleXIng.Select("Prov_Clave = '" + Pve + "' and IdDestFlete = '" + Dve + "'"))
                {
                    //DgRutas.Rows[j].Cells[3].Style.BackColor = System.Drawing.Color.Red;
                    DgRutas[3, j].Style.BackColor = System.Drawing.Color.Red;
                    DgRutas.Rows[j].Cells["Viajes"].Style.ForeColor = System.Drawing.Color.White;
                    DgRutas[3, j].ToolTipText = "Ruta Con Fletes Pendientes x Ingresar";
                    //DgRutas.Rows[j].DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                }
                j++;
            }
        }


    }
}
