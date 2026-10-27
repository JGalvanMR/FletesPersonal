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
using System.Net.Mail;

namespace FletesPersonal
{
    public partial class FrmFlete : Form
    {

        SqlConnection thisConnection = new SqlConnection(Utilerias.Class1.ConnectionString);
        DateTime FechaHoySer;
        DataTable Prov = new DataTable();
        DataTable Rutas = new DataTable();
        DataTable Info = new DataTable();
        DataTable FlePen = new DataTable();
        DataTable Emple = new DataTable();
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        string query = "", OpFle = "", Query2 = "", XCombo = "N";
        string UsuMail = "mprima@mrlucky.com.mx", BuzonGraph = "embarques@mrlucky.com.mx";
        DateTime FechaIni;
        Int32 FolioFle = 0;

        public FrmFlete()
        {
            InitializeComponent();
        }

        private void FrmFlete_Load(object sender, EventArgs e)
        {

            //panel2.Size = new Size(920, 800);
            thisConnection.Open();
            query = "Select Getdate()";
            cmd = new SqlCommand(query, thisConnection);
            FechaHoySer = Convert.ToDateTime(cmd.ExecuteScalar());
            query = "Select Prov_Clave, prov_nombre,prov_email from tb_cat_proveedor where prov_FletePer = 'S' order by prov_nombre";
            da = new SqlDataAdapter(query, thisConnection);
            ds = new DataSet();
            da.Fill(ds, "Prov");
            Prov = ds.Tables["Prov"];
            CmbProv.DisplayMember = "prov_nombre";
            CmbProv.ValueMember = "prov_clave";
            CmbProv.DataSource = Prov;
            thisConnection.Close();
            CmbProv.SelectedIndex = -1;
            DtFec.MaxDate = FechaHoySer.Date;
            DtFec.MinDate = FechaHoySer.AddDays(-9).Date;
            CamposFlete(false);
            FechaIni = DtFec.Value;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CamposFlete(Boolean Tipo)
        {
            DtFec.Enabled = Tipo;
            DtHr.Enabled = Tipo;
            CmbProv.Enabled = Tipo;
            CmbRuta.Enabled = Tipo;
            CmbArea.Enabled = Tipo;
            CmbTurno.Enabled = Tipo;
            CmbTipoFle.Enabled = Tipo;
            CmbTipoViaje.Enabled = Tipo;
            TxtCant.Enabled = Tipo;
            CmbProv.SelectedIndex = -1;
            CmbRuta.SelectedIndex = -1;
            CmbArea.SelectedIndex = -1;
            CmbTurno.SelectedIndex = -1;
            CmbTipoFle.SelectedIndex = -1;
            CmbTipoViaje.SelectedIndex = -1;
            CmbProv.Text = "";
            CmbRuta.Text = "";
            CmbTurno.Text = "";
            TxtCant.Text = "";
            BtnAlta.Enabled = (Tipo) ? false : true;
            TxtElabora.Enabled = Tipo;

        }

        private void BtnAlta_Click(object sender, EventArgs e)
        {
            thisConnection.Open();
            query = "SELECT max(IdFletePer) FROM Tb_FlePer_FletePersonal";
            cmd = new SqlCommand(query, thisConnection);
            string Folio = Convert.ToString(cmd.ExecuteScalar());
            Folio = (Folio.Trim().Length == 0) ? "1" : (Folio.Trim() == "-1") ? "1" : (Convert.ToInt32(Folio) + 1).ToString();
            query = "SELECT (cast(A.IdFletePer as varchar(8)) + ' ' + cast(A.FlePer_Fecha as varchar (11)) + ' ' +d.NomDestFlete) as Flete,  A.IdFletePer, A.FlePer_Fecha, a.FlePer_Hora, A.Prov_Clave, b.prov_nombre, a.IdDestFlete, d.NomDestFlete, c.Costo, FlePer_Cantidad, FlePer_TipoFlete, FlePer_TipoViaje " +
                    "FROM Tb_FlePer_FletePersonal A " +
                    "LEFT JOIN tb_cat_proveedor b ON A.Prov_Clave = b.prov_clave " +
                    "LEFT JOIN Tb_FlePer_ProvRuta c ON A.Prov_Clave = c.Prov_Clave AND A.IdDestFlete = c.IdDestFlete " +
                    "LEFT JOIN Tb_FlePer_Ruta d ON A.IdDestFlete = d.IdDestFlete " +
                    "WHERE a.Prov_Clave != '' AND a.IdDestFlete != 0 AND FlePer_Captura IS NULL AND FlePer_Status != 'C' " +
                    "Order by A.IdFletePer";
            da = new SqlDataAdapter(query, thisConnection);
            ds = new DataSet();
            da.Fill(ds, "FlePen");
            FlePen = ds.Tables["FlePen"];

            thisConnection.Close();
            TxtNoFle.Text = Folio;
            CamposFlete(true);
            BtnAlta.Enabled = false;
            BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            BtnConsul.Enabled = false;
            if (FlePen.Rows.Count > 0)
            {
                CmbFle.ValueMember = "IdFletePer";
                CmbFle.DisplayMember = "Flete";
                CmbFle.DataSource = FlePen;
                CmbFle.Enabled = true;
                CmbFle.SelectedIndex = -1;
                MessageBox.Show("Hay Fletes Pendientes x Ingresar!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            OpFle = "A";
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (OpFle == "A" || OpFle == "M") // Alta
            {
                CamposFlete(false);
                LblMotivo.Visible = false;
                XCombo = "N";
            }
            if (OpFle == "C") // Consulta
            {
                PnlFle.Visible = true;
                PnlCons.Visible = false;
                BtnBaja.Visible = false;
            }
            if (OpFle == "B")
            {
                DgDatos.CurrentRow.Selected = false;
                LblFleSel.Text = "";
                LblFleSel.Visible = false;
                BtnSave.Enabled = false;
                OpFle = "C";
                return;
            }
            BtnAlta.Enabled = true;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnConsul.Enabled = true;
            LblFleSel.Visible = true;
            CmbFle.DataSource = null;
            CmbFle.Enabled = false;
        }

        private void TxtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar);
        }

        private void CmbProv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string Cvepro = CmbProv.SelectedValue.ToString();
            thisConnection.Open();
            query = "Select A.IdDestFlete, A.NomDestFlete, A.FleteCant, A.FleteCosto from tb_FlePer_Ruta A, tb_FlePer_ProvRuta B Where b.prov_clave = '" + Cvepro + "' and a.DestStatus = 'A' " +
                    "and a.IdDestFlete = b.IdDestFlete Order by a.NomDestFlete";
            da = new SqlDataAdapter(query, thisConnection);
            ds = new DataSet();
            da.Fill(ds, "Rutas");
            Rutas = ds.Tables["Rutas"];
            CmbRuta.DataSource = null;
            CmbRuta.DisplayMember = "NomDestFlete";
            CmbRuta.ValueMember = "IdDestFlete";
            CmbRuta.DataSource = Rutas;
            CmbRuta.SelectedIndex = -1;
            thisConnection.Close();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            #region Guardar los Datos del Flete
            if (OpFle == "A" || OpFle == "M")
            {
                if (CmbProv.SelectedIndex < 0)
                {
                    MessageBox.Show("Falta Seleccionar el Proveedor!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CmbProv.Focus();
                    return;
                }
                if (CmbRuta.SelectedIndex < 0)
                {
                    MessageBox.Show("Falta Seleccionar la Ruta!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CmbRuta.Focus();
                    return;
                }
                if (CmbArea.SelectedIndex < 0)
                {
                    MessageBox.Show("Falta Seleccionar el Area!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CmbArea.Focus();
                    return;
                }
                if (CmbTurno.SelectedIndex < 0)
                {
                    MessageBox.Show("Falta Seleccionar el Turno!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CmbTurno.Focus();
                    return;
                }
                if (CmbTipoFle.SelectedIndex < 0)
                {
                    MessageBox.Show("Falta Seleccionar el Tipo de Flete!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CmbTipoFle.Focus();
                    return;
                }
                if (CmbTipoViaje.SelectedIndex < 0)
                {
                    MessageBox.Show("Falta Seleccionar el Tipo de Viaje!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    CmbTipoViaje.Focus();
                    return;
                }
                if (TxtCant.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Falta Capturar la Cantidad de Personal!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtCant.Focus();
                    return;
                }
                if (TxtElabora.Text.Trim().Length < 3)
                {
                    MessageBox.Show("Falta Capturar la Personal que Elabora el Ticket!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    TxtElabora.Focus();
                    return;
                }
                //SendMail(UsuMail.Trim(), "ricardo.cortes@mrlucky.com.mx");
                //return;
                thisConnection.Open();
                if (OpFle == "A")
                {
                    query = "Insert Into Tb_FlePer_FletePersonal(FlePer_Fecha, FlePer_Hora, Prov_Clave, IdDestFlete, FlePer_Area, FlePer_Turno, FlePer_TipoFlete, FlePer_TipoViaje, FlePer_Cantidad, " +
                            "FlePer_Costo,FlePer_Status,FlePer_Captura, FlePer_Semana) " +
                            "Values('" + DtFec.Value.ToString("dd/MM/yyyy") + "','" + DtHr.Value.ToString("HH:mm:ss") + "','" + CmbProv.SelectedValue.ToString() + "','" + CmbRuta.SelectedValue.ToString() + "','" +
                            CmbArea.Text + "','" + CmbTurno.Text + "','" + CmbTipoFle.Text + "','" + CmbTipoViaje.Text + "','" + TxtCant.Text + "','" + LblCosto.Text + "','A'," +
                            "'" + TxtElabora.Text.Trim() + "','" + TraeSemana(DtFec.Value.ToString("dd/MM/yyyy")).ToString() + "') SELECT SCOPE_IDENTITY()";
                    cmd = new SqlCommand(query, thisConnection);
                    FolioFle = Convert.ToInt32(cmd.ExecuteScalar());
                    if (LblMotivo.Text.Length > 0) // SE ESTA CAPTUANDO UN FLETE ESPECIAL
                    {
                        query = "Update tb_FlePer_FleEspecial set FleEsp_Registrado = 'S' where FleEsp_Fecha = '" + DtFec.Value.ToShortDateString() + "' AND FleEsp_Ruta = '" + CmbRuta.SelectedValue.ToString() + "'";
                        cmd = new SqlCommand(query, thisConnection);
                        cmd.ExecuteNonQuery();
                    }
                }
                if (OpFle == "M") // Se Actualizan los Datos del Flete
                {
                    query = "Update Tb_FlePer_FletePersonal Set FlePer_Area = '" + CmbArea.Text + "', FlePer_Turno = '" + CmbTurno.Text + "', FlePer_TipoFlete = '" + CmbTipoFle.Text + "', " +
                            "FlePer_TipoViaje = '" + CmbTipoViaje.Text + "', FlePer_Cantidad = '" + TxtCant.Text + "',FlePer_Costo = '" + LblCosto.Text + "',FlePer_Captura = '" + TxtElabora.Text.Trim() + "', " +
                            "FlePer_Semana = '" + TraeSemana(DtFec.Value.ToString("dd/MM/yyyy")).ToString() + "' Where IdFletePer = '" + TxtNoFle.Text + "'";
                    cmd = new SqlCommand(query, thisConnection);
                    cmd.ExecuteNonQuery();
                    FolioFle = Convert.ToInt32(TxtNoFle.Text);
                }
                query = "Select Email_dest from tb_mstr_email where cnte_clave = 'FLEPER' AND EMAIL_MOV = 'FLE'";
                cmd = new SqlCommand(query, thisConnection);
                string Dest = Convert.ToString(cmd.ExecuteScalar());
                thisConnection.Close();
                foreach (DataRow row in Prov.Select("Prov_Clave = '" + CmbProv.SelectedValue.ToString() + "'"))
                    Dest += ";" + row["prov_email"].ToString().Trim();
                MessageBox.Show("El Flete " + FolioFle.ToString() + " fue guardado con Exito!!!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SendMail(UsuMail.Trim(), Dest);
                TxtCant.Text = "";
                TxtNoFle.Text = "";
                BtnCancel_Click(sender, e);
            }
            #endregion
            #region Guardar la Cancelacion del Flete en Consultas
            if (OpFle == "B")
            {
                if (MessageBox.Show("Esta Seguro de Cancelar el No. de Flete " + DgDatos.Rows[DgDatos.CurrentRow.Index].Cells["IdFletePer"].Value.ToString(), "Cancelación de Flete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    DgDatos.CurrentRow.Selected = false;
                    LblFleSel.Text = "0";
                    LblFleSel.Visible = false;
                    BtnSave.Enabled = false;
                    OpFle = "C";
                    return;
                }
                thisConnection.Open();
                string Cadena = "Update tb_FlePer_FletePersonal set FlePer_Status = 'C' where IdFleteper = '" + LblFleSel.Text + "'";
                SqlCommand cmd = new SqlCommand(Cadena, thisConnection);
                cmd.ExecuteNonQuery();
                thisConnection.Close();
                MessageBox.Show("El Flete " + LblFleSel.Text + " Fue Cancelado con Exito!!", "Cancelar Flete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DgDatos.CurrentRow.Selected = false;
                LblFleSel.Text = "0";
                LblFleSel.Visible = false;
                BtnSave.Enabled = false;
                OpFle = "C";
                ActuInfo(Query2);
            }
            #endregion
        }

        private void CmbRuta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BtnSave.Enabled = true; ;
            thisConnection.Open();
            if (OpFle == "A")
                query = "SELECT count(IdDestFlete) AS Totaldeldia FROM Tb_FlePer_FletePersonal " +
                      "WHERE FlePer_Fecha = '" + DtFec.Value.ToShortDateString() + "' AND IdDestFlete = '" + CmbRuta.SelectedValue.ToString() + "' and FlePer_Status = 'A'";
            if (OpFle == "M")
                query = "SELECT count(IdDestFlete) AS Totaldeldia FROM Tb_FlePer_FletePersonal " +
                    "WHERE FlePer_Fecha = '" + DtFec.Value.ToShortDateString() + "' AND IdDestFlete = '" + CmbRuta.SelectedValue.ToString() + "' and FlePer_Status = 'A' and FlePer_Captura IS NOT NULL";
            cmd = new SqlCommand(query, thisConnection);
            Int32 FleDia = Convert.ToInt32(cmd.ExecuteScalar());
            query = "Select FleEsp_Motivo, FleEsp_Tipo from tb_FlePer_FleEspecial where FleEsp_Fecha = '" + DtFec.Value.ToShortDateString() + "' AND FleEsp_Ruta = '" + CmbRuta.SelectedValue.ToString() + "' " +
                    "and FleEsp_Registrado = 'N'";
            da = new SqlDataAdapter(query, thisConnection);
            ds = new DataSet();
            da.Fill(ds, "FleEsp");
            DataTable FleEsp = ds.Tables["FleEsp"];
            string Moti = "", Tipo = "";
            Int32 SemEsp = 0; // Esta Variable va a traer los Fletes de la Semana Anterior para la Ruta San Cayetano - Apatzingan de Acosta una semana 2 y otra 4
            Int32 FleXdia = 0;
            if (CmbRuta.GetItemText(CmbRuta.SelectedItem).ToString().Trim() == "San Cayetano - Apatzingan")
            {
                query = "SELECT count(IdDestFlete) AS Totaldeldia FROM Tb_FlePer_FletePersonal " +
                        "WHERE FlePer_Fecha = '" + DtFec.Value.AddDays(-7).ToShortDateString() + "' AND IdDestFlete = '" + CmbRuta.SelectedValue.ToString() + "' and FlePer_Status = 'A'";
                cmd = new SqlCommand(query, thisConnection);
                SemEsp = Convert.ToInt32(cmd.ExecuteScalar());
            }
            thisConnection.Close();
            LblCosto.Text = "0";
            CmbTipoFle.Enabled = true;
            LblMotivo.Visible = false;
            string Nom = "";
            foreach (DataRow row in Rutas.Select("IdDestFlete = '" + CmbRuta.SelectedValue.ToString() + "'"))
            {
                FleXdia = Convert.ToInt32(row["FleteCant"]);
                LblCosto.Text = row["FleteCosto"].ToString();
                Nom = row["NomDestFlete"].ToString().Trim();
            }
            if (SemEsp > 0 && SemEsp < 4)
                FleXdia += 2;
            foreach (DataRow row in FleEsp.Rows)
            {
                Tipo = row["FleEsp_Tipo"].ToString();
                Moti = row["FleEsp_Motivo"].ToString();
                FleXdia++;
            }
            if (FleDia >= FleXdia)
            {
                MessageBox.Show("Ya se Llego al Tope de Fletes x dia que son de " + FleXdia + System.Environment.NewLine + "  " + Nom + " Ya no se pueden hacer mas Fletes para este destino Verifique la Informacion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                BtnSave.Enabled = false;
            }
            string HayFletePen = "N";
            if (XCombo == "N")
                foreach (DataRow row in FlePen.Rows)
                {
                    if (row["IdDestFlete"].ToString().Trim() == CmbRuta.SelectedValue.ToString().Trim() && Convert.ToDateTime(row["FlePer_Fecha"]).ToShortDateString() == DtFec.Value.ToShortDateString())
                    {
                        MessageBox.Show("Hay Fletes Pendientes por Ingresar Para Este Proveedor y Ruta " + row["NomDestFlete"].ToString().Trim() + System.Environment.NewLine + " Primero Hay que Ingresar los pendientes para Poder Capturar Nuevos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        BtnSave.Enabled = false;
                        HayFletePen = "S";
                    }
                    //SELECT (cast(A.IdFletePer as varchar(8)) + ' ' + cast(A.FlePer_Fecha as varchar (11)) + ' ' +d.NomDestFlete) as Flete,  A.IdFletePer, A.FlePer_Fecha, a.FlePer_Hora, A.Prov_Clave, b.prov_nombre, a.IdDestFlete, d.NomDestFlete, c.Costo, FlePer_Cantidad, FlePer_TipoFlete, FlePer_TipoViaje)
                }
            if (Tipo.Trim().Length > 0)
            {
                MessageBox.Show("Tiene Fletes Pendientes Especiales de " + Tipo + " Para esta ruta Selecctione el Motivo para Capturar el Flete Especial", "Flete Especial Pendiente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CmbTipoFle.SelectedIndex = (Tipo.Trim() == "T.E.") ? 2 : 3;
                CmbTipoFle.Enabled = false;
                LblMotivo.Visible = true;
                LblMotivo.Text = Moti;
            }
            else
                if (FleDia >= FleXdia || HayFletePen == "S")
                BtnCancel_Click(sender, e);
        }

        private void IcnBtnRefresh_Click(object sender, EventArgs e)
        {
            if (DtFecIni.Value.Date > DtFecFin.Value.Date)
            {
                MessageBox.Show("Error en el Rango de Fechas, verifique las fechas ", "Error en el Rango de Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            thisConnection.Open();
            query = "SELECT A.IdFletePer, A.FlePer_Fecha, A.FlePer_Hora, B.prov_nombre, C.NomDestFlete, A.FlePer_Area, " +
                    "A.FlePer_Turno, A.FlePer_TipoFlete, A.FlePer_TipoViaje, A.FlePer_Cantidad, A.FlePer_Status " +
                    "FROM Tb_FlePer_FletePersonal A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
                    "WHERE A.Prov_Clave = B.prov_clave AND A.IdDestFlete = C.IdDestFlete AND " +
                    "A.FlePer_Fecha BETWEEN '" + DtFecIni.Value.ToShortDateString() + "' AND '" + DtFecFin.Value.ToShortDateString() + "' ORDER BY A.IdFletePer ";
            Query2 = query;
            da = new SqlDataAdapter(query, thisConnection);
            ds = new DataSet();
            da.Fill(ds, "Info");
            Info = ds.Tables["Info"];
            DgDatos.DataSource = Info;
            thisConnection.Close();
            if (Info.Rows.Count > 0)
                BtnBaja.Visible = true;
            FormatoRep();
            BtnSave.Enabled = false;
            LblFleSel.Visible = false;
        }

        private void ActuInfo(string Consulta)
        {
            thisConnection.Open();
            da = new SqlDataAdapter(Consulta, thisConnection);
            ds = new DataSet();
            da.Fill(ds, "Info");
            Info = ds.Tables["Info"];
            DgDatos.DataSource = Info;
            thisConnection.Close();
        }
        private void FormatoRep()
        {
            DgDatos.Columns[0].Width = 60;
            DgDatos.Columns[1].Width = 70;
            DgDatos.Columns[2].Width = 50;
            DgDatos.Columns[3].Width = 300;
            DgDatos.Columns[4].Width = 200;
            DgDatos.Columns[5].Width = 80;
            DgDatos.Columns[6].Width = 80;
            DgDatos.Columns[7].Width = 100;
            DgDatos.Columns[8].Width = 100;
            DgDatos.Columns[9].Width = 50;
            DgDatos.Columns[10].Width = 40;
            DgDatos.Columns[0].HeaderText = "No. Flete";
            DgDatos.Columns[1].HeaderText = "Fecha";
            DgDatos.Columns[2].HeaderText = "Hora";
            DgDatos.Columns[3].HeaderText = "Proveedor";
            DgDatos.Columns[4].HeaderText = "Ruta";
            DgDatos.Columns[5].HeaderText = "Area";
            DgDatos.Columns[6].HeaderText = "Turno";
            DgDatos.Columns[7].HeaderText = "Tipo";
            DgDatos.Columns[8].HeaderText = "Viaje";
            DgDatos.Columns[9].HeaderText = "No. Personal";
            DgDatos.Columns[10].HeaderText = "Sts";
            DgDatos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgDatos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgDatos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgDatos.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DgDatos.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void TxtFle_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void IcnBtnFle_Click(object sender, EventArgs e)
        {
            if (TxtFle.Text.Trim().Length == 0)
            {
                MessageBox.Show("No se ha Capturado el No. de Flete", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            thisConnection.Open();
            query = "SELECT A.IdFletePer, A.FlePer_Fecha, A.FlePer_Hora, B.prov_nombre, C.NomDestFlete, A.FlePer_Area, " +
                    "A.FlePer_Turno, A.FlePer_TipoFlete, A.FlePer_TipoViaje, A.FlePer_Cantidad, A.FlePer_Status " +
                    "FROM Tb_FlePer_FletePersonal A, tb_cat_proveedor B, Tb_FlePer_Ruta C " +
                    "WHERE A.Prov_Clave = B.prov_clave AND A.IdDestFlete = C.IdDestFlete AND A.IdFletePer = '" + TxtFle.Text + "' ORDER BY A.IdFletePer ";
            Query2 = query;
            da = new SqlDataAdapter(query, thisConnection);
            ds = new DataSet();
            da.Fill(ds, "Info");
            Info = ds.Tables["Info"];
            DgDatos.DataSource = Info;
            thisConnection.Close();
            if (Info.Rows.Count > 0)
                BtnBaja.Visible = true;
            FormatoRep();
            BtnSave.Enabled = false;
            LblFleSel.Visible = false;
        }

        private void BtnBaja_Click(object sender, EventArgs e)
        {
            BtnSave.Enabled = false;
            if (DgDatos.Rows[DgDatos.CurrentRow.Index].Cells["FlePer_Status"].Value.ToString().Trim() != "B")
            {
                if (MessageBox.Show("Desea dar de Baja el Flete? " + DgDatos.Rows[DgDatos.CurrentRow.Index].Cells["IdFletePer"].Value.ToString() + " De la Ruta: " +
                    DgDatos.Rows[DgDatos.CurrentRow.Index].Cells["NomDestFlete"].Value.ToString() + System.Environment.NewLine + " Se Va Seleccionar el Renglon, Tiene que guardar el Movimientos para que Acepte la Cancelación ", "Baja Ruta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LblFleSel.Text = DgDatos.Rows[DgDatos.CurrentRow.Index].Cells["IdFletePer"].Value.ToString();
                    LblFleSel.Visible = true;
                    OpFle = "B";
                    DgDatos.CurrentRow.Selected = true;  //DgDatos.Rows[DgDatos.CurrentRow.Index].Selected;
                    BtnSave.Enabled = true;
                }
            }
        }

        private void DtFec_ValueChanged(object sender, EventArgs e)
        {
            if (DtFec.Value.Date != FechaIni.Date) // Cambio de Fecha se Vuelve a pedir El proveedor y Ruta
            {
                CmbProv.SelectedIndex = -1;
                CmbRuta.SelectedIndex = -1;
                CmbProv.Focus();
            }
        }

        private void CmbTipoFle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LblMotivo.Visible = false;
            BtnSave.Enabled = true;
            // SE HACE UNA VALIDACION DE QUE EXISTA LA CAPTURA DE UN FLETE ESPECIAL EN ESE DIA
            //if (CmbTipoFle.Text.Trim() == "T.E." || CmbTipoFle.Text.Trim() == "EXTRAORDINARIO")
            if (CmbTipoFle.SelectedIndex >= 2) // 2->"T.E."   3->"EXTRAORDINARIO"
            {
                thisConnection.Open();
                query = "Select FleEsp_Motivo from tb_FlePer_FleEspecial where FleEsp_Fecha = '" + DtFec.Value.ToShortDateString() +
                        "' and FleEsp_Tipo = '" + CmbTipoFle.Text.Trim() + "'";
                cmd = new SqlCommand(query, thisConnection);
                string Moti = Convert.ToString(cmd.ExecuteScalar());
                thisConnection.Close();
                if (Moti.Trim().Length == 0)
                {
                    MessageBox.Show("No Existe Ningun Flete Especial, Reviselo con Rosa Isela", "Flete Especial", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    BtnSave.Enabled = false;
                    return;
                }
                LblMotivo.Visible = true;
            }
        }

        private void CmbFle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            foreach (DataRow row in FlePen.Select("IdFletePer = '" + CmbFle.SelectedValue.ToString() + "'"))
            {

                if (BtnAlta.Enabled == true)
                    return;
                TxtNoFle.Text = CmbFle.SelectedValue.ToString();
                DateTime FecFle = Convert.ToDateTime(row["FlePer_Fecha"]);
                if (FecFle < DtFec.MinDate.Date)
                {
                    MessageBox.Show("La Fecha del Flete '" + FecFle.ToShortDateString() + "'es menor a la Fecha Minima que es de " + DtFec.MinDate.ToShortDateString(), "Fecha Fuera de Rango", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    BtnCancel_Click(sender, e);
                    return;
                }
                DtFec.Value = Convert.ToDateTime(row["FlePer_Fecha"]);
                CmbProv.SelectedValue = row["Prov_Clave"];
                CmbProv_SelectionChangeCommitted(sender, e);
                CmbRuta.SelectedValue = row["IdDestFlete"];
                OpFle = "M"; // voy a tomar la M ya que el registro ya existe!!
                XCombo = "S";
                CmbRuta_SelectionChangeCommitted(sender, e);
                if (BtnSave.Enabled == false)
                {
                    BtnCancel_Click(sender, e);
                    return;
                }
                TxtCant.Text = row["FlePer_Cantidad"].ToString();
                TxtCant.Enabled = false;
                string Hr = row["FlePer_Hora"].ToString();
                string Fec = Convert.ToDateTime(row["FlePer_Fecha"]).ToShortDateString() + " " + row["FlePer_Hora"];
                DtHr.Value = Convert.ToDateTime(Fec);
                DtFec.Enabled = false;
                DtHr.Enabled = false;
                string TipFle = row["FlePer_TipoFlete"].ToString().Trim();
                Int32 IdxTF = (TipFle.Contains("NORMAL")) ? 0 : (TipFle.Contains("MIXTO")) ? 1 : (TipFle.Contains("T.E.")) ? 2 : 3;
                CmbTipoFle.SelectedIndex = IdxTF;
                CmbTipoFle.Enabled = false;
                CmbTipoViaje.SelectedIndex = (row["FlePer_TipoViaje"].ToString().Trim().Contains("TRAER")) ? 0 : 1;
                if (Convert.ToInt32(Hr.Substring(0, 2)) < 7)
                    CmbTurno.SelectedIndex = 0; // Mautino
                else
                    if (Convert.ToInt32(Hr.Substring(0, 2)) > 13 && Convert.ToInt32(Hr.Substring(0, 2)) < 22)
                    CmbTurno.SelectedIndex = 1; // Vestpertino 
                else
                    CmbTurno.SelectedIndex = 2;

                thisConnection.Open();
                query = "Select(rtrim(b.emp_nombre) + ' ' + rtrim(b.emp_paterno) + ' ' + rtrim(b.emp_materno)) AS Nom, FlePer_Nombre as Nombre, FlePer_Fecha as Fecha, " +
                        "IdFletePer, FlePer_CveNomina, FlePer_Latitud, FlePer_Longitud,  FlePer_Depto, c.depto_clave, c.depto_nombre, C.DEPTO_AREA AS AREA " +
                        "From Tb_FlePer_DetFlete a " +
                        "LEFT JOIN tb_cat_empleados b ON a.FlePer_CveNomina = b.emp_clave " +
                        "LEFT JOIN Tb_Cat_Deptos c ON b.emp_depto = c.depto_clave " +
                        "Where IdFletePer = '" + CmbFle.SelectedValue.ToString() + "' Order by FlePer_Fecha ";
                da = new SqlDataAdapter(query, thisConnection);
                ds = new DataSet();
                da.Fill(ds, "Emple");
                Emple = ds.Tables["Emple"];
                Int32 TotEns = 0, TotFre = 0;
                foreach (DataRow Row in Emple.Rows)
                {
                    if (Convert.ToString(Row["Nombre"]).Trim().Length == 0)
                    {
                        query = "Update Tb_FlePer_DetFlete set FlePer_Nombre = '" + Row["Nom"].ToString().Trim() + "', FlePer_Depto = '" + Row["depto_nombre"].ToString().Trim() + "' " +
                                "Where IdFletePer = '" + CmbFle.SelectedValue.ToString() + "' and FlePer_CveNomina = '" + Row["FlePer_CveNomina"] + "'";
                        cmd = new SqlCommand(query, thisConnection);
                        cmd.ExecuteNonQuery();
                    }
                    if (Row["Area"].ToString().Contains("FRESCO"))
                        TotFre++;
                    if (Row["Area"].ToString().Contains("ENSALADAS"))
                        TotEns++;
                }
                thisConnection.Close();
                if (TotFre > 0 && TotEns == 0)
                    CmbArea.SelectedIndex = 1;
                else
                    if (TotFre == 0 && TotEns > 0)
                    CmbArea.SelectedIndex = 0;
                else
                    CmbArea.SelectedIndex = 2;
                TxtElabora.Focus();
            }
        }

        private void PnlFle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnConsul_Click(object sender, EventArgs e)
        {
            //SendMailCtaAgui("enviaipo@aguilares.com.mx", "enviaipo@aguilares.com.mx", "-mZVoPT0&=g&", "ricardo.cortes@mrlucky.com.mx;jlenriquez@grupou.mx", 1);
            //return;

            BtnAlta.Enabled = false;
            PnlFle.Visible = false;
            PnlCons.Visible = true;
            //BtnSave.Enabled = true;
            BtnCancel.Enabled = true;
            //BtnBaja.Visible = true;
            PnlCons.Dock = DockStyle.Fill;
            OpFle = "C";
        }

        private Int32 TraeSemana(string Fec)
        {
            Int32 Sem = 0;
            //thisConnection.Open();
            query = "SELECT semana FROM tb_cat_semanas WHERE fecha1 <= '" + Fec + "' AND fecha2 >= '" + Fec + "'";
            cmd = new SqlCommand(query, thisConnection);
            Sem = Convert.ToInt32(cmd.ExecuteScalar());
            //thisConnection.Close();
            return Sem;
        }

        public void SendMailCtaAgui(string mail, string usuario, string password, string Dest, Int16 Opcion)
        {
            MailMessage msg = new MailMessage();
            MailMessage email = new MailMessage();
            string[] destinatarios = Dest.Split(';');
            string InfoCorreo = "";
            foreach (string destinos in destinatarios)
            {
                email.To.Add(new MailAddress(destinos));
                //email.Bcc.Add("andrea@mrlucky.com.mx");
            }
            email.CC.Add(mail);
            //if (Opcion == 1) // Autorizados
            //{
            //    email.Bcc.Add("musabiaga@mrlucky.com.mx"); //  PARA MANDAR LA COPIA OCULTA 
            //}
            //email.To.Add(new MailAddress(mail));
            //email.To.Add(new MailAddress("gcamacho@mrlucky.com.mx"));
            //string correos = "ricardo.cortes@mrlucky.com.mx; jbravo@mrlucky.com.mx";

            //cap = "";
            //foreach (DataRow fila in captura.Rows)
            //    cap = cap + Convert.ToString(fila["cantidad"].ToString()).Trim() + " - " + Convert.ToString(fila["producto"].ToString()).Trim() + " - " + Convert.ToString(fila["nombre"].ToString()).Trim() + " <br> ";

            // se busca la Informacion del Inventario de Cajones x Proveedor
            string Cad = string.Format(
                            "<H3>Hola Buen día" + "</H3>"
                            );

            email.From = new MailAddress(mail); //
            email.Subject = "Mensaje de Prueba";  //"Flete "+ FolioFle.ToString() + " de FLETES DE PERSONAL";//mAsunto; //"Mensaje de Prueba";
            email.Body = Cad;//mBody;  //"Información de la factura";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            InfoCorreo = Cad.Replace("'", "");
            //string archivo = @"C:\Reportes\factura_informativa.txt";
            //if (Archivo.Trim().Length > 0)
            //    if (File.Exists(Archivo))
            //        email.Attachments.Add(new Attachment(Archivo));            
            SmtpClient smtp = new SmtpClient();
            smtp.Host = " mail.aguilares.com.mx"; //-mZVoPT0&=g&
            smtp.Port = 587;
            //smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(usuario, password);
            smtp.EnableSsl = true;
            //smtp.Credentials = new NetworkCredential("ricardo.cortes", "rcedillo");
            //smtp.Credentials = new NetworkCredential(usuario, password);

            try
            {
                smtp.Send(email);
                email.Dispose();
                //MessageBox.Show("correo enviado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login.Trim(), "A", "2.19", FolioFle.ToString(), "Captura Flete de Personal Folio: " + FolioFle.ToString(), "SIPGAB", "", "" + InfoCorreo + "");

            }
            catch (Exception ex)
            {
                MessageBox.Show("correo no enviado\r\n" + ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SendMail(string cc, string Dest)
        {
            string InfoCorreo = "";
            string Cad = string.Format(
                            "<H3>Hola Buen día" + "</H3>" +
                            "<H3><p style='color: blue'>Envio Información Del Flete de Personal " + FolioFle.ToString() + " </p></H3>" +
                            "<H3><p style='color: blue'>Del Día " + DtFec.Value.ToShortDateString() + "</p></H3>" +
                            "<H4>Transportita: " + CmbProv.Text + "</H4>" +
                            "<H4>Ruta:: " + CmbRuta.Text.ToUpper() + "</H4>" +
                            "<H4>Area: " + CmbArea.Text + "</H4>" +
                            "<H4>Turno: " + CmbTurno.Text + "</H4>" +
                            "<H4>Tipo de Flete:  " + CmbTipoFle.Text + "</H4>" +
                            "<H4>Medio Viaje: " + CmbTipoViaje.Text + "</H4>" +
                            "<H4>Cantidad: " + TxtCant.Text + "</H4><br>" +
                            "Atentamente, " + "<br><br>" +
                            "Comercializadora GAB S.A. de C.V." + "<br>" +
                            "www.mrlucky.com.mx" + "<br><br>" +
                            "" + TxtElabora.Text.Trim());

            InfoCorreo = Cad.Replace("'", "");

            try
            {
                new GraphMailService(BuzonGraph).Enviar(Dest.Split(';'), new[] { cc },
                    "Flete " + FolioFle.ToString() + " de FLETES DE PERSONAL", Cad);
                Utilerias.Class1.registrar_movimiento3(DateTime.Now, Environment.MachineName, Utilerias.Class1.Usu_login.Trim(), "A", "2.19", FolioFle.ToString(), "Captura Flete de Personal Folio: " + FolioFle.ToString(), "SIPGAB", "", "" + InfoCorreo + "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("correo no enviado\r\n" + ex.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
