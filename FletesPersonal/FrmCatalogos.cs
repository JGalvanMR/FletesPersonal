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
    public partial class FrmCatalogos : Form
    {
        SqlConnection thisConeccion = new SqlConnection(Utilerias.Class1.ConnectionString);
        SqlDataAdapter da;
        DataSet ds;
        string query;
        DataTable Rutas = new DataTable();
        DataTable ProvRuta = new DataTable();
        DataTable Prov = new DataTable();

        string OpRuta = "", OpRP = "";
        Int32 IdRuta = 0;

        public FrmCatalogos()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCatalogos_Load(object sender, EventArgs e)
        {
            CargaRutas();
            CargaRutasProv();
            CargaProv();
        }

        private void CargaRutas()
        {
            thisConeccion.Open();
            string Cadena = "Select IdDestFlete, NomDestFlete, FleteCant, FleteCosto, DestStatus,RutaCupo, RutaVehiculo from tb_Fleper_Ruta order by IdDestFlete";
            da = new SqlDataAdapter(Cadena, thisConeccion);
            ds = new DataSet();
            da.Fill(ds, "Rutas");
            Rutas = ds.Tables["Rutas"];
            DgRutas.DataSource = Rutas;
            CmbRuta.DisplayMember = "NomDestFlete";
            CmbRuta.ValueMember = "IdDestFlete";
            CmbRuta.DataSource = Rutas;
            thisConeccion.Close();
            FormatoRutas();
        }

        private void FormatoRutas()
        {
            DgRutas.Columns[0].Width = 60;
            DgRutas.Columns[1].Width = 250;
            DgRutas.Columns[2].Width = 50;
            DgRutas.Columns[3].Width = 80;
            DgRutas.Columns[4].Width = 40;
            DgRutas.Columns[5].Width = 60;
            DgRutas.Columns[6].Width = 100;
            DgRutas.Columns[0].HeaderText = "Id Ruta";
            DgRutas.Columns[1].HeaderText = "Nombre";
            DgRutas.Columns[2].HeaderText = "Viajes x Dia";
            DgRutas.Columns[3].HeaderText = "Costo";
            DgRutas.Columns[4].HeaderText = "Sts";
            DgRutas.Columns[5].HeaderText = "Cupo";
            DgRutas.Columns[6].HeaderText = "Vehículo";
            DgRutas.Columns[3].DefaultCellStyle.Format = "#,###.#0";
            DgRutas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgRutas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgRutas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgRutas.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgRutas.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        private void CargaRutasProv()
        {
            thisConeccion.Open();
            string Cadena = "Select A.IdRutaProv, A.Prov_Clave, B.prov_nombre, A.IdDestFlete, C.NomDestFlete, A.FechaAlta, A.Costo, A.RutaStatus " +
                            "from Tb_FlePer_ProvRuta A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
                            "WHERE A.Prov_Clave = B.prov_clave AND A.IdDestFlete = C.IdDestFlete order by B.prov_nombre";
            da = new SqlDataAdapter(Cadena, thisConeccion);
            ds = new DataSet();
            da.Fill(ds, "RutaProv");
            ProvRuta = ds.Tables["RutaProv"];
            DgProvRuta.DataSource = ProvRuta;
            thisConeccion.Close();
            FormatoRutasProv();
        }

        private void FormatoRutasProv()
        {
            DgProvRuta.Columns[0].Width = 40;
            DgProvRuta.Columns[1].Visible = false;
            DgProvRuta.Columns[2].Width = 300;
            DgProvRuta.Columns[3].Visible = false;
            DgProvRuta.Columns[4].Width = 150;
            DgProvRuta.Columns[5].Visible = false;
            DgProvRuta.Columns[6].Width = 50;
            DgProvRuta.Columns[7].Width = 25;
            DgProvRuta.Columns[0].HeaderText = "Id Ruta";
            DgProvRuta.Columns[2].HeaderText = "Proveedor";
            DgProvRuta.Columns[4].HeaderText = "Ruta";
            DgProvRuta.Columns[6].HeaderText = "Costo";
            DgProvRuta.Columns[7].HeaderText = "Sts";
            DgProvRuta.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgProvRuta.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter ;
        }

        private void CargaProv()
        {
            thisConeccion.Open();
            string Cadena = "Select Prov_Clave, prov_nombre from tb_cat_proveedor where prov_FletePer = 'S' order by prov_nombre";
            da = new SqlDataAdapter(Cadena, thisConeccion);
            ds = new DataSet();
            da.Fill(ds, "Prov");
            Prov = ds.Tables["Prov"];
            CmbProv.DisplayMember = "prov_nombre";
            CmbProv.ValueMember = "prov_clave";
            CmbProv.DataSource = Prov;
            CmbTrans.DisplayMember = "prov_nombre";
            CmbTrans.ValueMember = "prov_clave";
            CmbTrans.DataSource = Prov;
            thisConeccion.Close();
        }

        private void TabConCata_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (TabConCata.SelectedIndex == 1)
            //{
            //    MessageBox.Show("Entre!!!");
            //}
        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            CamposRuta(true);
            OpRuta = "A";
        }

        private void CamposRuta(Boolean Tipo)
        {
            LblNom.Visible = Tipo;
            LblCos.Visible = Tipo;
            LblVia.Visible = Tipo;
            TxtCosto.Visible = Tipo;
            TxtNom.Visible = Tipo;
            TxtViajes.Visible = Tipo;
            BtnCancel.Enabled = Tipo;
            BtnSave.Enabled = Tipo;
            BtnBaja.Enabled = (Tipo) ? false : true;
            BtnAlta.Enabled = (Tipo) ? false : true;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CamposRuta(false);
            OpRuta = "";
            TxtCosto.Enabled = true;
            TxtNom.Enabled = true;
            TxtViajes.Enabled = true;
            TxtNom.Text = "";
            TxtViajes.Text = "";
            TxtCosto.Text = "";
            IdRuta = 0;
        }

        private void TxtViajes_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar); // && !char.IsControl(e.KeyChar);
        }

        private void TxtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && !Char.IsControl(e.KeyChar);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region AltaRutas
            if (OpRuta == "A")
            {
                if (TxtNom.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se ha Capturado el Nombre de la Ruta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtNom.Focus();
                    return;
                }
                if (TxtViajes.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se ha Capturado el Numero de Viajes  x Dia", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtViajes.Focus();
                    return;
                }
                if (TxtCosto.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se ha Capturado el Costo de la Ruta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtCosto.Focus();
                    return;
                }
                thisConeccion.Open();
                string Cadena = "Select Max(idDestFlete) from tb_FlePer_Ruta";
                SqlCommand cmd = new SqlCommand(Cadena, thisConeccion);
                Int32 Conse = Convert.ToInt32(cmd.ExecuteScalar());
                Conse++;
                Cadena = "Insert into tb_FlePer_Ruta(IdDestFlete, NomDestFlete, FleteCant, FleteCosto, DestStatus) " +
                         "Values('" + Conse.ToString() + "','" + TxtNom.Text.Trim() + "','" + TxtViajes.Text.Trim() + "','" + TxtCosto.Text.Trim() + "','A')";
                cmd = new SqlCommand(Cadena, thisConeccion);
                cmd.ExecuteNonQuery();
                thisConeccion.Close();
                MessageBox.Show("Ruta Agregada Correctamente!!!", "Alta de Rutas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CamposRuta(false);
                CargaRutas();
            }
            #endregion
            #region BajaRutas
            if (OpRuta == "B")
            {
                if (MessageBox.Show("Esta Seguro de Cambiar el Estatus de Baja a la Ruta?", "Baja Ruta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    BtnCancel_Click(sender, e);
                    IdRuta = 0;
                    return;
                }
                thisConeccion.Open();
                string Cadena = "Update tb_FlePer_Ruta set DestStatus = 'B' where idDestFlete = '" + IdRuta.ToString() + "'";
                SqlCommand cmd = new SqlCommand(Cadena, thisConeccion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("La Ruta se dio se Baja Correctamente!!", "Baja Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                thisConeccion.Close();
                BtnCancel_Click(sender, e);
                IdRuta = 0;
                CargaRutas();
            }
            #endregion
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            // Para el control de la Tecla Suprimir en el Grid
            //private void DgRutas_KeyDown(object sender, KeyEventArgs e)
            //{
            //    if (e.KeyCode == Keys.Delete)
            //    {
            //        MessageBox.Show("delete pressed");
            //        e.Handled = true;
            //    }
            //}
            if (MessageBox.Show("Desea dar de Baja la Ruta? "+ DgRutas.Rows[DgRutas.CurrentRow.Index].Cells["NomDestFlete"].Value.ToString() + System.Environment.NewLine + " Se Van a Visualizar los Datos para que Acepte la Cancelación "  , "Baja Ruta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CamposRuta(true);
                TxtCosto.Enabled = false;
                TxtNom.Enabled = false;
                TxtViajes.Enabled = false;
                TxtNom.Text = DgRutas.Rows[DgRutas.CurrentRow.Index].Cells["NomDestFlete"].Value.ToString();
                TxtViajes.Text = DgRutas.Rows[DgRutas.CurrentRow.Index].Cells["FleteCant"].Value.ToString();
                TxtCosto.Text = DgRutas.Rows[DgRutas.CurrentRow.Index].Cells["FleteCosto"].Value.ToString();
                IdRuta = Convert.ToInt32(DgRutas.Rows[DgRutas.CurrentRow.Index].Cells["IdDestFlete"].Value);
                OpRP = "B";
            }
        }

        private void TabConCata_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = TabConCata.TabPages[e.Index];

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            // Este sera el rectangulo que se dibujara sobre el titutlo del tab 
            RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);

            // Este sera el color por defecto del tab no seleccionado 
            SolidBrush sb = new SolidBrush(Color.AntiqueWhite);

            // color del tab que se selecciona
            if (TabConCata.SelectedIndex == e.Index)
                sb.Color = Color.Aqua;

            // aplica el color sobre el tabpage actual 
            g.FillRectangle(sb, e.Bounds);

            //escribe el texto que tenia el tab 
            g.DrawString(tp.Text, TabConCata.Font, new SolidBrush(Color.Black), headerRect, sf);
        }

        private void BtnAltaRP_Click(object sender, EventArgs e)
        {
            CamposRutaProv(true);
            OpRP = "A";
            CmbProv.SelectedIndex = -1;
            CmbRuta.SelectedIndex = -1;
        }

        private void CmbRuta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (DataRow row in Rutas.Select("IdDestFlete = '" + CmbRuta.SelectedValue.ToString() + "'"))
                TxtCosPro.Text = row["FleteCosto"].ToString();
        }

        private void TxtCosPro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && !Char.IsControl(e.KeyChar);
        }

        private void BtnCancelRP_Click(object sender, EventArgs e)
        {
            CamposRutaProv(false);
            OpRuta = "";
            TxtCosPro.Enabled = true;
            CmbProv.Enabled = true;
            CmbRuta.Enabled = true;
            TxtCosPro.Text = "";
            IdRuta = 0;
        }

        private void BtnSaveRP_Click(object sender, EventArgs e)
        {

            #region AltaRutasProv
            if (OpRP == "A")
            {
                if (CmbProv.SelectedIndex < 0)
                {
                    MessageBox.Show("No se ha Capturado el Nombre del Proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CmbProv.Focus();
                    return;
                }
                if (CmbRuta.SelectedIndex < 0)
                {
                    MessageBox.Show("No se ha Capturado La Ruta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CmbRuta.Focus();
                    return;
                }
                if (TxtCosPro.Text.Trim().Length == 0)
                {
                    MessageBox.Show("No se ha Capturado el Costo de la Ruta x Proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtCosPro.Focus();
                    return;
                }
                thisConeccion.Open();
                string Cadena = "Insert into tb_FlePer_ProvRuta(Prov_Clave, IdDestFlete, FechaAlta, Costo, RutaStatus) " +
                         "Values('" + CmbProv.SelectedValue.ToString() + "','" + CmbRuta.SelectedValue.ToString() + "','" + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "','" + TxtCosPro.Text.Trim() + "','A')";
                SqlCommand cmd = new SqlCommand(Cadena, thisConeccion);
                cmd.ExecuteNonQuery();
                thisConeccion.Close();
                MessageBox.Show("Ruta Agregada al Proveedor Correctamente!!!", "Alta de Rutas x Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CamposRutaProv(false);
                CargaRutasProv();
            }
            #endregion
            #region BajaRutasProv
            if (OpRP == "B")
            {
                if (MessageBox.Show("Esta Seguro de Cambiar el Estatus de Baja a la Ruta?", "Baja Ruta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    BtnCancelRP_Click(sender, e);
                    IdRuta = 0;
                    return;
                }
                thisConeccion.Open();
                string Cadena = "Update tb_FlePer_ProvRuta set RutaStatus = 'B' where IdRutaProv = '" + IdRuta.ToString() + "'";
                SqlCommand cmd = new SqlCommand(Cadena, thisConeccion);
                cmd.ExecuteNonQuery();
                MessageBox.Show("La Ruta se dio de Baja Correctamente!!", "Baja Ruta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                thisConeccion.Close();
                BtnCancelRP_Click(sender, e);
                IdRuta = 0;
                CargaRutasProv();
            }
            #endregion
        }

        private void BtnBajaRP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea dar de Baja la Ruta? " + DgProvRuta.Rows[DgProvRuta.CurrentRow.Index].Cells["NomDestFlete"].Value.ToString() + System.Environment.NewLine + " Se Van a Visualizar los Datos para que Acepte la Cancelación ", "Baja Ruta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CamposRutaProv(true);
                TxtCosPro.Enabled = false;
                CmbProv.Enabled = false;
                CmbRuta.Enabled = false; //, A.IdDestFlete, C.
                CmbProv.Text = DgProvRuta.Rows[DgProvRuta.CurrentRow.Index].Cells["prov_nombre"].Value.ToString();
                CmbRuta.Text = DgProvRuta.Rows[DgProvRuta.CurrentRow.Index].Cells["NomDestFlete"].Value.ToString();
                TxtCosPro.Text = DgProvRuta.Rows[DgProvRuta.CurrentRow.Index].Cells["Costo"].Value.ToString();
                IdRuta = Convert.ToInt32(DgProvRuta.Rows[DgProvRuta.CurrentRow.Index].Cells["IdRutaProv"].Value);
                OpRP = "B";
            }
        }

        private void CmbTrans_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string Cvepro = CmbTrans.SelectedValue.ToString();
            thisConeccion.Open();
            string query = "Select A.IdDestFlete, A.NomDestFlete, A.FleteCant, A.FleteCosto from tb_FlePer_Ruta A, tb_FlePer_ProvRuta B Where b.prov_clave = '" + Cvepro + "' " +
                    "and a.IdDestFlete = b.IdDestFlete Order by a.NomDestFlete";
            da = new SqlDataAdapter(query, thisConeccion);
            ds = new DataSet();
            da.Fill(ds, "Rutas");
            Rutas = ds.Tables["Rutas"];
            CmbRutEsp.DataSource = null;
            CmbRutEsp.DisplayMember = "NomDestFlete";
            CmbRutEsp.ValueMember = "IdDestFlete";
            CmbRutEsp.DataSource = Rutas;
            CmbRutEsp.SelectedIndex = -1;
            CmbRutEsp.Enabled = true;
            thisConeccion.Close();
        }

        
        private void BtnCancelEsp_Click(object sender, EventArgs e)
        {
            DtFec.Enabled = false;
            CmbTrans.Enabled = false;
            CmbRutEsp.Enabled = false;
            CmbTipoFle.Enabled = false;
            TxtCostoEsp.Enabled = false;
            TxtMoti.Enabled = false;
            CmbTrans.SelectedIndex = -1;
            CmbTipoFle.SelectedIndex = -1;
            CmbRutEsp.SelectedIndex = -1;
            TxtCostoEsp.Text = "0";
            TxtMoti.Text = "";
            BtnAltaEsp.Enabled = true;
            BtnCancelEsp.Enabled = false;
            BtnSaveEsp.Enabled = false;
        }

        private void BtnAltaEsp_Click(object sender, EventArgs e)
        {
            DtFec.Enabled = true;
            CmbTrans.Enabled = true;
            CmbTipoFle.Enabled = true;
            TxtCostoEsp.Enabled = true;
            TxtMoti.Enabled = true;
            BtnAltaEsp.Enabled = false;
            BtnCancelEsp.Enabled = true;
            BtnSaveEsp.Enabled = true;
            CmbTrans.SelectedIndex = -1;
            CmbTrans.Focus();
        }

        private void CmbRutEsp_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (DataRow row in Rutas.Select("IdDestFlete = '" + CmbRutEsp.SelectedValue.ToString() + "'"))
                TxtCostoEsp.Text = row["FleteCosto"].ToString();
        }

        private void TxtCostoEsp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && !Char.IsControl(e.KeyChar);
        }

        private void BtnSaveEsp_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta Seguro de Guardar la Información?", "Alta Flete Especial", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            if (CmbTrans.SelectedIndex < 0)
            {
                MessageBox.Show("No se ha Capturado en Transportista", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                CmbTrans.Focus();
                return;
            }
            if (CmbRutEsp.SelectedIndex < 0)
            {
                MessageBox.Show("No se ha Capturado La Ruta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                CmbRutEsp.Focus();
                return;
            }
            if (CmbTipoFle.SelectedIndex < 0)
            {
                MessageBox.Show("No se ha Capturado el Tipo de Flete", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                CmbTipoFle.Focus();
                return;
            }
            if (TxtCostoEsp.Text.Trim().Length == 0 )
            {
                MessageBox.Show("No se ha Capturado el Costo del Flete", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TxtCostoEsp.Focus();
                return;
            }
            if (TxtMoti.Text.Trim().Length < 10)
            {
                MessageBox.Show("No se ha Capturado el Motivo del Flete", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TxtMoti.Focus();
                return;
            }
            thisConeccion.Open();
            string Query = "Insert into tb_FlePer_FleEspecial(FleEsp_Fecha, FleEsp_Prov, FleEsp_Ruta, FleEsp_Tipo, FleEsp_Costo, FleEsp_Motivo, FleEsp_Estatus, FleEsp_FechaCap, FleEsp_Registrado) " +
                           "Values('" + DtFec.Value.ToShortDateString() + "','" + CmbTrans.SelectedValue.ToString() + "','" + CmbRutEsp.SelectedValue.ToString() + "','" +
                           CmbTipoFle.Text + "','" + TxtCostoEsp.Text.ToString() + "','" + TxtMoti.Text.Trim() + "','A','" + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "','N')";
            SqlCommand cmd = new SqlCommand(Query, thisConeccion);
            cmd.ExecuteNonQuery();
            thisConeccion.Close();
            MessageBox.Show("Flete Dado de Alta Correctamente!!!", "Alta Flete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnCancelEsp_Click(sender, e);
        }

        private void IcnBtnRefresh_Click(object sender, EventArgs e)
        {
            thisConeccion.Open();
            query = "SELECT a.FleEsp_Fecha as Fecha, c.prov_nombre as Proveedor, b.NomDestFlete as Ruta, a.FleEsp_Tipo as Tipo, a.FleEsp_Motivo as Observaciones, a.FleEsp_Registrado as Registrado  " +
                    "FROM Tb_FlePer_FleEspecial a, Tb_FlePer_Ruta b, tb_cat_proveedor c " +
                    "WHERE a.FleEsp_Prov = c.prov_clave AND a.FleEsp_Ruta = b.IdDestFlete AND a.FleEsp_Fecha BETWEEN '"+ DtFI.Value.ToShortDateString() +"' AND '"+ DtFF.Value.ToShortDateString() +"' " +
                    "ORDER BY A.FleEsp_Fecha";
            da = new SqlDataAdapter(query, thisConeccion);
            ds = new DataSet();
            da.Fill(ds, "FleEsp");
            thisConeccion.Close();
            DataTable FleEsp = ds.Tables["FleEsp"];
            DGFleEsp.DataSource = FleEsp;
            DGFleEsp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells ;
        }

        

        private void CamposRutaProv(Boolean Tipo)
        {
            LblProv.Visible = Tipo;
            LblCost.Visible = Tipo;
            LblRuta.Visible = Tipo;
            CmbProv.Visible = Tipo;
            CmbRuta.Visible = Tipo;
            TxtCosPro.Visible = Tipo;
            BtnCancelRP.Enabled = Tipo;
            BtnSaveRP.Enabled = Tipo;
            BtnBajaRP.Enabled = (Tipo) ? false : true;
            BtnAltaRP.Enabled = (Tipo) ? false : true;
        }

        private void DtFecRep_ValueChanged(object sender, EventArgs e)
        {
            thisConeccion.Open();
            query = "SELECT a.IdRutaProv, a.Prov_Clave, c.prov_nombre as Proveedor, a.IdDestFlete, b.NomDestFlete as Ruta, b.FleteCant, b.FleteCant as FletesPen  " +
                    "FROM Tb_FlePer_ProvRuta a " +
                    "LEFT JOIN Tb_FlePer_Ruta b ON a.IdDestFlete = b.IdDestFlete " +
                    "LEFT JOIN tb_cat_proveedor c ON a.Prov_Clave = c.prov_clave " +
                    "WHERE a.RutaStatus = 'A' Order by c.prov_nombre,  b.NomDestFlete ";
            da = new SqlDataAdapter(query, thisConeccion);
            ds = new DataSet();
            da.Fill(ds, "TotXRut");
            DataTable TotxRut = ds.Tables["TotXRut"];
            query = "SELECT Prov_Clave, IdDestFlete, count(IdFletePer) as Tot " +
                    "FROM Tb_FlePer_FletePersonal " +
                    "WHERE ((FlePer_Fecha = '"+ DtFecRep.Value.ToShortDateString() +"' AND FlePer_Hora >= '03:00:00') or (FlePer_Fecha = '"+ DtFecRep.Value.AddDays(1).ToShortDateString() +"' AND FlePer_Hora <= '03:00:00')) " +
                    "AND FlePer_Chofer IS NOT NULL GROUP BY Prov_Clave, IdDestFlete ORDER BY Prov_Clave, IdDestFlete ";
            da = new SqlDataAdapter(query, thisConeccion);
            ds = new DataSet();
            da.Fill(ds,"Fletes");
            DataTable Fletes = ds.Tables["Fletes"];
            thisConeccion.Close();
            foreach (DataRow row in Fletes.Rows)
            {
                string CvePro = row["Prov_Clave"].ToString();
                string CveRut = row["IdDestFlete"].ToString();
                int Tot = Convert.ToInt32(row["Tot"]);
                foreach (DataRow Row in TotxRut.Select("Prov_Clave = '" + CvePro + "' and IdDestFlete = '" + CveRut + "'"))
                    Row["FletesPen"] = Convert.ToInt32(Row["FletesPen"]) - Tot;
            }
            DataTable Pend = TotxRut.Clone();
            DataRow[] rows = TotxRut.Select("FletesPen > 0");
            foreach (DataRow row in rows)
                Pend.ImportRow(row);
            DataView dv = Pend.DefaultView;
            dv.Sort = "Proveedor,ruta";
            Pend = dv.ToTable();

            DgDatos.DataSource = Pend;
            DgDatos.Columns[0].Visible = false;
            DgDatos.Columns[1].Visible = false;
            DgDatos.Columns[3].Visible = false;
            DgDatos.Columns[2].Width = 350;
            DgDatos.Columns[4].Width = 200;
            DgDatos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgDatos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgDatos.Columns[5].HeaderText = "Fletes x Dia";
            DgDatos.Columns[6].HeaderText = "Fletes Pendiente X Capturar";
            
        }
    }
    
}
    
