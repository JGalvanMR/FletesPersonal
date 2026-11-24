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
using Excel = Microsoft.Office.Interop.Excel;

namespace FletesPersonal
{
    public partial class FrmCostos : Form
    {
        SqlConnection ThisConnection = new SqlConnection(Utilerias.Class1.ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        string query = "";
        DataTable Fletes = new DataTable();

        public FrmCostos()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCostos_Load(object sender, EventArgs e)
        {
            int dia2 = (int)System.DateTime.Now.DayOfWeek;
            DtFI.Value = System.DateTime.Now.AddDays((dia2 - 1) * (-1));
        }

        private void IcnBtnRefresh_Click(object sender, EventArgs e)
        {
            BtnExcel.Visible = false;
            ThisConnection.Open();
            query = "SELECT COUNT(IdFletePer)   FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + DtFI.Value.ToShortDateString() + "' AND '" + DtFF.Value.ToShortDateString() + "' and FlePer_Status = 'A' ";
            cmd = new SqlCommand(query, ThisConnection);
            LblTotFle.Text = Convert.ToString(cmd.ExecuteScalar());
            query = "SELECT SUM(FlePer_Costo) AS Costo FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + DtFI.Value.ToShortDateString() + "' AND '" + DtFF.Value.ToShortDateString() + "' and FlePer_Status = 'A '";
            cmd = new SqlCommand(query, ThisConnection);
            string TotC = Convert.ToString(cmd.ExecuteScalar());
            LblTotCos.Text = (TotC.Trim().Length > 0) ? Convert.ToDecimal(cmd.ExecuteScalar()).ToString("#,###.00") : "0";
            query = "SELECT CAST(FlePer_Fecha AS DATE) as FlePer_Fecha, COUNT(IdFletePer) AS total FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + DtFI.Value.ToShortDateString() + "' AND '" + DtFF.Value.ToShortDateString() + "' and FlePer_Status = 'A' " +
                    "GROUP BY CAST(FlePer_Fecha AS DATE) ";
            query = "SELECT ISNULL(sum(FleteCant), 0)   FROM Tb_FlePer_Ruta WHERE ISNULL(DestStatus, 'A') <> 'B'";
            cmd = new SqlCommand(query, ThisConnection);
            Int32 ViaxDia = Convert.ToInt32(cmd.ExecuteScalar());
            LblXdia.Text = ViaxDia.ToString();
            query = "SELECT count(FlePer_Fecha) AS TotalDias " +
                    "FROM " +
                    "( " +
                    "SELECT CAST(FlePer_Fecha AS DATE) as FlePer_Fecha, COUNT(IdFletePer) AS total FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha BETWEEN '" + DtFI.Value.ToShortDateString() + "' AND '" + DtFF.Value.ToShortDateString() + "' and FlePer_Status = 'A' " +
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
            query = "Select NomDestFlete, FleteCant, RutaCupo frOm Tb_FlePer_Ruta ORDER BY IDDestFlete ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "Rutas");
            DataTable Rutas = ds.Tables["Rutas"];
            query = "SELECT b.prov_nombre as Proveedor, c.NomDestFlete as Ruta, sum(a.FlePer_Cantidad) AS Personas, count(a.IdFletePer) AS Viajes, '' as Tope, (sum(a.Fleper_Cantidad) / count(a.IdFletePer)) as PromXPersona, " +
                    "'' as Cupo, sum(a.FlePer_Costo) as CostoTotal, (sum(a.Fleper_Costo) / count(a.IdFletePer)) as CostoXFlete, (sum(a.Fleper_Costo) / sum(a.FlePer_Cantidad)) as CostoXPersona " +
                    "FROM Tb_FlePer_FletePersonal A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
                    "WHERE FlePer_Fecha BETWEEN '" + DtFI.Value.ToShortDateString() + "' AND '" +  DtFF.Value.ToShortDateString() + "' AND FlePer_Status = 'A' AND A.Prov_Clave = b.prov_clave AND a.IdDestFlete = c.IdDestFlete " +
                    "GROUP BY b.prov_nombre, C.NomDestFlete Order by b.prov_nombre, C.NomDestFlete";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "Fletes");
            DataTable Fletes = ds.Tables["Fletes"];
            query = "SELECT b.prov_nombre as Proveedor, sum(a.FlePer_Cantidad) AS Personas, count(a.IdFletePer) AS Viajes, '' as Tope, (sum(a.Fleper_Cantidad) / count(a.IdFletePer)) as PromXPersona, " +
                   "'' as Cupo, sum(a.FlePer_Costo) as CostoTotal, (sum(a.Fleper_Costo) / count(a.IdFletePer)) as CostoXFlete, (sum(a.Fleper_Costo) / sum(a.FlePer_Cantidad)) as CostoXPersona " +
                   "FROM Tb_FlePer_FletePersonal A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
                   "WHERE FlePer_Fecha BETWEEN '" + DtFI.Value.ToShortDateString() + "' AND '" + DtFF.Value.ToShortDateString() + "' AND FlePer_Status = 'A' AND A.Prov_Clave = b.prov_clave AND a.IdDestFlete = c.IdDestFlete " +
                   "GROUP BY b.prov_nombre"; //, C.NomDestFlete ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "FletesC");
            DataTable FletesC = ds.Tables["FletesC"];
            query = "SELECT FlePer_Semana, Sum(FlePer_Costo) AS total FROM Tb_FlePer_FletePersonal " +
                    //"WHERE FlePer_Fecha BETWEEN '01/08/2024' AND '31/12/2024' and FlePer_Status = 'A' and FlePer_Semana is Not null " +
                    "WHERE year(FlePer_Fecha) = year(getdate()) and FlePer_Status = 'A' and FlePer_Semana is Not null " +
                    "GROUP BY FlePer_Semana ";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "FleSem");
            DataTable FleSem = ds.Tables["FleSem"];
            //query = "SELECT FlePer_Semana, COUNT(IdFletePer) AS total FROM Tb_FlePer_FletePersonal " +
            //        "WHERE FlePer_Fecha BETWEEN '01/08/2024' AND '31/12/2024' and FlePer_Status = 'A' and FlePer_Semana is Not null " +
            //        "GROUP BY FlePer_Semana ";
            //da = new SqlDataAdapter(query, ThisConnection);
            //ds = new DataSet();
            //da.Fill(ds, "FleXSem");
            //DataTable FleXSem = ds.Tables["FleXSem"];
            ThisConnection.Close();
            if (Fletes.Rows.Count > 0)
                BtnExcel.Visible = true;
            foreach (DataRow row in Fletes.Rows)
            {
                foreach (DataRow Row in Rutas.Select("NomDestFlete = '" + row["Ruta"].ToString().Replace("'", "''") + "'"))
                {
                    int fleteCant = (Row["FleteCant"] == DBNull.Value) ? 0 : Convert.ToInt32(Row["FleteCant"]);
                    decimal rutaCupo = (Row["RutaCupo"] == DBNull.Value) ? 0m : Convert.ToDecimal(Row["RutaCupo"]);
                    row["Tope"] = (fleteCant * dias).ToString();
                    row["Cupo"] = rutaCupo;
                }
            }
            DgDatos.DataSource = Fletes;
            DgDatosC.DataSource = FletesC;
            for (int i = 2; i <= 9; i++)
            {
                DgDatos.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DgDatosC.Columns[i-1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            for (int i = 5; i <= 9; i++)
            {
                DgDatos.Columns[i].DefaultCellStyle.Format = ("#,###.#0");
                DgDatosC.Columns[i-1].DefaultCellStyle.Format = ("#,###.#0");
            }
            DgDatos.Columns[1].Width = 100;
            ChartSem.Series[0].Points.Clear();
            ChartSem.Series[1].Points.Clear();
            foreach (DataRow row in FleSem.Rows)
            {
                //string dia = Convert.ToDateTime(row["FlePer_Fecha"]).ToString("ddd").Substring(0, 2);
                //Int32 TotXSem = Convert.ToInt32(LblXdia.Text) * 6;
                //if (Convert.ToInt32(row["FlePer_Semana"]) == 34) // Semana Inicial sin Ramiro
                //    TotXSem = TotXSem - (6 * 6);
                ChartSem.Series[0].Points.AddXY(row["FlePer_Semana"], row["total"]);
                //ChartSem.Series[1].Points.AddXY(row["FlePer_Semana"], row["total"]);
            }
            //foreach (DataRow row in FleXSem.Rows)
            //{
            //    //string dia = Convert.ToDateTime(row["FlePer_Fecha"]).ToString("ddd").Substring(0, 2);
            //    //Int32 TotXSem = Convert.ToInt32(LblXdia.Text) * 6;
            //    //if (Convert.ToInt32(row["FlePer_Semana"]) == 34) // Semana Inicial sin Ramiro
            //    //    TotXSem = TotXSem - (6 * 6);
            //    //ChartSem.Series[0].Points.AddXY(row["FlePer_Semana"], row["total"]);
            //    ChartSem.Series[1].Points.AddXY(row["FlePer_Semana"], row["total"]);
            //}
        }

        private void DgDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1 || e.ColumnIndex == 3)
            {
                FrmDetalle FrmDet = new FrmDetalle();
                FrmDet.CvePro = DgDatos.CurrentRow.Cells["proveedor"].Value.ToString().Trim();
                FrmDet.CveDes = "";
                FrmDet.FI = DtFI.Value.ToShortDateString();
                FrmDet.FF = DtFF.Value.ToShortDateString();
                if (e.ColumnIndex == 1 || e.ColumnIndex == 3) // clic en Ruta
                {
                    FrmDet.CveDes = DgDatos.CurrentRow.Cells["Ruta"].Value.ToString().Trim();
                }
                FrmDet.ShowDialog(this);
            }
        }

        private void BtnRep_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (DtFF.Value < DtFI.Value)
            {
                MessageBox.Show("Error en el Rango de las Fechas ", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            LblInfo.Visible = true;
            LblInfo.Refresh();

            ThisConnection.Open();
            query = "SELECT a.IdFletePer AS NoFlete, a.FlePer_Fecha AS Fecha, a.FlePer_Hora AS Hora, a.Prov_Clave AS CveProv, B.prov_nombre AS NombreProveedor, a.IdDestFlete AS CveFlete, " +
                    "C.NomDestFlete AS NombreRuta, a.FlePer_Area AS Area, a.FlePer_Turno AS Turno, a.FlePer_TipoFlete AS TipoFlete, a.FlePer_TipoViaje AS TipoViaje, a.FlePer_Cantidad AS Personas, " +
                    "a.FlePer_Costo AS Costo, a.FlePer_Status AS Estatus, a.FlePer_Captura AS Capturo, a.FlePer_Semana AS Semana, DATENAME(\"MM\", A.FlePer_Fecha) AS MES, " +
                    "year(A.FlePer_Fecha ) AS AÑO " +
                    "FROM Tb_FlePer_FletePersonal A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
                    "WHERE FlePer_Fecha BETWEEN '" + DtFI.Value.ToShortDateString() + "' AND '" + DtFF.Value.ToShortDateString() + "' AND FlePer_Status = 'A' AND A.Prov_Clave = b.prov_clave AND a.IdDestFlete = c.IdDestFlete " +
                    "ORDER BY a.IdFletePer";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "RepFlete");
            DgExcel.DataSource = ds.Tables["RepFlete"];
            ThisConnection.Close();

            //DgExcel.DataSource = INFO;
            //Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Add();
            //Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelBook.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add();
            Excel.Worksheet excelWorksheet = excel.Worksheets.get_Item(1);


            //DgExcel
            int Tope = 20000;
            Int32 ii = 0; Int32 jj = DgExcel.Rows.Count, xx = 0;
            if (DgExcel.Rows.Count > Tope)
            {
                do
                {
                    if (ii + Tope > jj)
                        ii = jj;
                    else
                        ii += Tope;
                    for (int ini = xx; ini < ii; ini++)
                        DgExcel.Rows[ini].Selected = true;
                    DgExcel.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                    Clipboard.SetDataObject(DgExcel.GetClipboardContent().GetText());
                    excelWorksheet.Cells[xx + 2, 1].Select();
                    excelWorksheet.Paste();
                    //for (int ini = xx; ini < ii; ini++)
                    //    dataGridView1.Rows[ini].Selected = false;
                    DgExcel.ClearSelection();
                    xx += Tope;
                } while (ii < jj);
            }
            else
            {
                DgExcel.SelectAll();
                DgExcel.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                Clipboard.SetDataObject(DgExcel.GetClipboardContent().GetText());
                excelWorksheet.Cells[2, 1].Select();
                excelWorksheet.Paste();
            }
            //MessageBox.Show("worksheet");
            excelWorksheet.Name = "Datos";
            for (int i = 0; i < DgExcel.ColumnCount; i++)
                excelWorksheet.Cells[1, i + 1] = DgExcel.Columns[i].HeaderText.ToString();
            excel.Columns.AutoFit();
            int fila_ultima = DgExcel.Rows.Count;
            int columna_ultima = DgExcel.ColumnCount;
            //if (fila_ultima > 65000)
            //    fila_ultima = 65000;
            Excel.Range oRange = excelWorksheet.Range[excelWorksheet.Cells[1, 1], excelWorksheet.Cells[fila_ultima + 1, columna_ultima]];
            //MessageBox.Show("rangos");
            //if (excelApp.Application.Sheets.Count < 2)
            //    excelWorksheet = (Excel.Worksheet)excelBook.Worksheets.Add();
            //else
            //    excelWorksheet = excelApp.Worksheets[2];

            //excelWorksheet.Name = "Tabla dinamica";
            ////MessageBox.Show("Tabla Dinamica");

            //Excel.Range oRange2 = excelWorksheet.Cells[1, 1];
            //Excel.PivotCache oPivotCache = (Excel.PivotCache)excelBook.PivotCaches().Add(Excel.XlPivotTableSourceType.xlDatabase, oRange);
            //Excel.PivotTable oPivotTable = (Excel.PivotTable)excelWorksheet.PivotTables().Add(PivotCache: oPivotCache, TableDestination: oRange2, TableName: "Ventas");

            //Excel.PivotField oPivotField = (Excel.PivotField)oPivotTable.PivotFields("Cliente");//nombre
            //Excel.PivotField oPivotField1 = (Excel.PivotField)oPivotTable.PivotFields("Producto");//nombre
            //Excel.PivotField oPivotField2 = (Excel.PivotField)oPivotTable.PivotFields("Cantidad");//cajas
            //Excel.PivotField oPivotField5 = (Excel.PivotField)oPivotTable.PivotFields("Total");
            //Excel.PivotField oPivotField6 = (Excel.PivotField)oPivotTable.PivotFields("Semana");
            //Excel.PivotField oPivotField7 = (Excel.PivotField)oPivotTable.PivotFields("Precio");
            ////Excel.PivotField oPivotField2 = (Excel.PivotField)oPivotTable.PivotFields("pesou");//peso_neto
            //oPivotField.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
            //oPivotField.Name = " cliente";
            //oPivotField1.Orientation = Excel.XlPivotFieldOrientation.xlRowField;
            //oPivotField1.Name = " Producto";
            //oPivotField2.Orientation = Excel.XlPivotFieldOrientation.xlDataField;
            //oPivotField2.Function = Excel.XlConsolidationFunction.xlSum;
            //oPivotField2.Name = " Cantidad";
            //oPivotField5.Orientation = Excel.XlPivotFieldOrientation.xlDataField;
            //oPivotField5.Function = Excel.XlConsolidationFunction.xlSum;
            //oPivotField5.Name = " Total";
            //oPivotField6.Orientation = Excel.XlPivotFieldOrientation.xlColumnField;
            //oPivotField6.Name = " Semana";
            //oPivotField7.Orientation = Excel.XlPivotFieldOrientation.xlDataField;
            //oPivotField7.Function = Excel.XlConsolidationFunction.xlAverage;
            //oPivotField7.Name = " Precio";

            //MessageBox.Show("Tabla Dinamica 2");

            //Excel.PivotField oPivotField3 = (Excel.PivotField)oPivotTable.PivotFields("fecha");//fecha
            //oPivotField3.Orientation = Excel.XlPivotFieldOrientation.xlPageField;
            //oPivotField3.Name = " Fecha";

            //Excel.PivotField oPivotField3 = (Excel.PivotField)oPivotTable.PivotFields("nomtabla");//variedad
            //oPivotField3.Orientation = Excel.XlPivotFieldOrientation.xlPageField;
            //oPivotField3.Name = "nomtabla";

            //Excel.PivotField oPivotField3 = (Excel.PivotField)oPivotTable.PivotFields("Linea");//Rancho
            //oPivotField3.Orientation = Excel.XlPivotFieldOrientation.xlPageField;
            //oPivotField3.Name = "Linea";

            //Excel.PivotField oPivotField4 = (Excel.PivotField)oPivotTable.PivotFields("Subcliente");//Proveedor
            //oPivotField4.Orientation = Excel.XlPivotFieldOrientation.xlPageField;
            //oPivotField4.Name = "Subcliente";
            //Excel.PivotField oPivotField8 = (Excel.PivotField)oPivotTable.PivotFields("TIPO");//Proveedor
            //oPivotField8.Orientation = Excel.XlPivotFieldOrientation.xlPageField;
            //oPivotField8.Name = "TIPO";

            //MessageBox.Show("Antesexcellapp");

            excel.Visible = true;
            //if (BD.Rows.Count > 65000)
            //{
            //excelWorksheet.Cells[1, 7] = "NOTA: MODIFICAR EL RANGO DE DATOS DE LA TABLA DINAMICA A " + fila_ultima.ToString();
            //    MessageBox.Show("NOTA: MODIFICAR EL RANGO DE DATOS DE LA TABLA DINAMICA A " + fila_ultima.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            //}
            // label7.Text = "Generando reporte . . . ";
            LblInfo.Visible = false;
            //excel.Columns.AutoFit();
            //excel.Rows.AutoFit();
            MessageBox.Show("Archivo Generado Con Exito!!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //excel.Visible = true;
            LblInfo.Visible = false;
        }
    }
}
