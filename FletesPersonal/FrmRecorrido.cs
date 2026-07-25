using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using Microsoft.VisualBasic.Devices;
using System.IO;



namespace FletesPersonal
{
    public partial class FrmRecorrido : Form
    {
        SqlConnection ThisConnection = new SqlConnection(Utilerias.Class1.ConnectionString);
        string query = "";
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        DataTable Personal = new DataTable();

        //GMarkerGoogle marker;
        //GMapOverlay markerOverlay;
        double latitud = 20.6586337;
        double longitud = -101.2942987;
        public string Prov = "", Ruta = "", IdFlete="", Tipo="", TipoFle= "";


        public FrmRecorrido()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnRuta_Click(object sender, EventArgs e)
        {
            CrearDireccionTrazarRuta();
            return;

            GMapOverlay Ruta = new GMapOverlay("Rutas");
            
            List<PointLatLng> puntos = new List<PointLatLng>();
            // variable para almacenar los datos
            double lng, lat;

            for (int i = 0; i<= DgDatos.Rows.Count - 1; i++)
            {
                lat = Convert.ToDouble(DgDatos.Rows[i].Cells["FlePer_Latitud"].Value.ToString().Trim().Replace(",", "."));
                lng = Convert.ToDouble(DgDatos.Rows[i].Cells["FlePer_Longitud"].Value.ToString().Trim().Replace(",", "."));
                puntos.Add(new PointLatLng(lat, lng));
            }

            GMapRoute PuntosRuta = new GMapRoute(puntos, "Ruta");
            Ruta.Routes.Add(PuntosRuta);
            gMap.Overlays.Add(Ruta);
            gMap.Zoom = gMap.Zoom + 1;
            gMap.Zoom = gMap.Zoom - 1;

        }

        private void FrmRecorrido_Load(object sender, EventArgs e)
        {
            LblInfo.Text = "Prov: " + Prov.Trim() + "  Ruta: " + Ruta;
            LblNoFle.Text = "Flete: " + IdFlete + "  " + Tipo + "  Tipo Viaje: " + TipoFle;
            //Gmaps configuracion e inicializacion
            //MessageBox.Show("Antes de gMap");
            gMap.DragButton = MouseButtons.Left;
            gMap.CanDragMap = true;
            gMap.MapProvider = GMapProviders.GoogleHybridMap;
            gMap.Position = new PointLatLng(latitud, longitud);
            gMap.MinZoom = 0;
            gMap.MaxZoom = 25;
            TrackZoom.Value = 13;
            LblZoom.Text = TrackZoom.Value.ToString();
            gMap.Zoom = 13;
            gMap.AutoScroll = true;
            gMap.ShowCenter = false;
            //MessageBox.Show("Despues de gMap");

            ThisConnection.Open();
            query = "Select (rtrim(b.emp_nombre) + ' ' + rtrim(b.emp_paterno) + ' ' + rtrim(b.emp_materno)) AS Nombre,  FlePer_Fecha as Fecha, FlePer_Nombre as Nom,IdFletePer, FlePer_CveNomina, FlePer_Latitud, FlePer_Longitud,  FlePer_Depto From Tb_FlePer_DetFlete a " +
                    "LEFT JOIN tb_cat_empleados b ON a.FlePer_CveNomina = b.emp_clave " +
                    "Where IdFletePer = '" + IdFlete + "' Order by Fecha";
            da = new SqlDataAdapter(query, ThisConnection);
            ds = new DataSet();
            da.Fill(ds, "Personal");
            Personal = ds.Tables["Personal"];
            query = "Select RutaCupo From Tb_FlePer_Ruta Where NomDestFlete = '" + Ruta + "'";
            cmd = new SqlCommand(query, ThisConnection);
            string Cupo = Convert.ToString(cmd.ExecuteScalar());
            ThisConnection.Close();
            string HI="", HF="";
            Int32 Tot = 0;
            foreach(DataRow row in Personal.Rows)
            {
                if (row["Nombre"].ToString().Trim().Length == 0)
                    row["Nombre"] = row["Nom"];
                if (row["Nom"].ToString().Trim().Contains("INICIO"))
                    HI = row["Fecha"].ToString();
                if (row["Nom"].ToString().Trim().Contains("FIN"))
                    HF = row["Fecha"].ToString();
                Int32 Cve = Convert.ToInt32(row["FlePer_CveNomina"]);
                if (Cve != 0 && Cve != 9999)
                    Tot++;
            }
            if (HI.Trim().Length > 0 && HF.Trim().Length > 0) // TIENE HORA DE INICIO Y FIN
            {
                TimeSpan Tiempo = Convert.ToDateTime(HF) - Convert.ToDateTime(HI);
                LblDet.Text = "Tiempo de Recorrido: " + Tiempo.Hours + ":" + Tiempo.Minutes ;
            }
            LblDet.Text = LblDet.Text + "     Total de Personas: " + Tot.ToString("#,###") + "  Cupo: " + Cupo +"    "+ ((Convert.ToDecimal(Tot) / Convert.ToDecimal(Cupo)) * 100).ToString("###") + " %  de Capacidad";

            DgDatos.DataSource = Personal;
            for (int i = 2; i <= 6; i++)
                DgDatos.Columns[i].Visible = false;
            DgDatos.Columns[0].Width = 150;
            DgDatos.Columns[1].Width = 90;
            DgDatos.Columns[7].Width = 40;
            DgDatos.Columns[0].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DgDatos.Columns[0].DefaultCellStyle.Font = new Font("Tahoma", 7);
            DgDatos.Columns[1].DefaultCellStyle.Font = new Font("Tahoma", 7);
            DgDatos.Columns[7].DefaultCellStyle.Font = new Font("Tahoma", 7);
            DgDatos.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            Double Lat = 0;
            Double lon = 0;
            int ubicaciones = 0;
            double lat_ant = 0;
            double long_ant = 0;
            foreach (DataRow row in Personal.Rows)
            {
                latitud = Convert.ToDouble(row["FlePer_Latitud"].ToString().Trim().Replace(",", "."));
                lon = Convert.ToDouble(row["FlePer_Longitud"].ToString().Trim().Replace(",", "."));

                PuntosYRuta(Lat, lon, ubicaciones, lat_ant, long_ant, row["Nombre"].ToString().Trim());
                lat_ant = latitud;
                long_ant = lon;
                ubicaciones++;
            }
            gMap.Zoom = gMap.Zoom + 1;
            gMap.Zoom = gMap.Zoom - 1; 


        }

        private void TrackZoom_ValueChanged(object sender, EventArgs e)
        {
            gMap.Zoom = TrackZoom.Value;
            LblZoom.Text = TrackZoom.Value.ToString();
        }

        public void PuntosYRuta(Double Latitud, Double longitud, int ubicaciones, double lat_ant, double long_ant, string ubicacionactual)
        {

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMapMarker marker;
            if (ubicacionactual == "INICIO")
                marker = new GMarkerGoogle(new PointLatLng(latitud, longitud), GMarkerGoogleType.arrow);
            else if (ubicacionactual == "FIN")
                marker = new GMarkerGoogle(new PointLatLng(latitud, longitud), GMarkerGoogleType.green_big_go);
            else
                marker = new GMarkerGoogle(new PointLatLng(latitud, longitud), GMarkerGoogleType.red_pushpin);
            //GMarkerGoogleType.red_pushpin);
            markersOverlay.Markers.Add(marker);
            gMap.Overlays.Add(markersOverlay);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = "Ubicacion: " + ubicacionactual;
            //Trazado de la ruta de la camioneta
            //if (ubicaciones > 0)
            //{
            //    PointLatLng start = new PointLatLng(lat_ant, long_ant);
            //    PointLatLng end = new PointLatLng(latitud, longitud);

            //    MapRoute route = BingMapProvider.Instance.GetRoute(start, end, false, false, 15);
            //    GMapRoute r = new GMapRoute(route.Points, "Myroutes");
            //    GMapOverlay routesOverlay = new GMapOverlay("Myroutes");
            //    routesOverlay.Routes.Add(r);
            //    gMap.Overlays.Add(routesOverlay);
            //    r.Stroke.Width = 2;
            //    r.Stroke.Color = Color.SeaGreen;


                
            //    GDirections ss = new GDirections();
            //    //GDirections ss;
            //    bool direccion = false;
            //    int intentos = 0;

            //    while (direccion == false) {
            //        var xx = GMapProviders.BingMap.GetRoute(start, end, true, false, 15);

            //        if (xx.ToString() == "OK") {
            //            direccion = true;
            //        }
            //        else if (xx.ToString() == "NOT_FOUND") {
            //            MessageBox.Show("Una ruta no puede ser encontrada");
            //            direccion = true;
            //        }
            //        else if (xx.ToString() == "REQUEST_DENIED")
            //        {
            //            MessageBox.Show("El servicio ha sido negado para Camionetas");
            //            direccion = true;
            //        }
            //        else if (xx.ToString() == "ZERO_RESULTS")
            //        {
            //            MessageBox.Show("No se encontraron resultados");
            //            direccion = true;
            //        }
            //        else if (intentos == 5) {
            //            direccion = true;
            //        }
            //    }

            //    //if (ss != null ){
            //    //    GMapRoute r = new GMapRoute(ss.Route, "My route");
            //    //    r.Stroke = new Pen(randomColor(), 3);
            //    //    r.Stroke.Width = 4;
            //    //    GMapOverlay routesOverlay = new GMapOverlay("routes");
            //    //    routesOverlay.Routes.Add(r);
            //    //    gmap.Overlays.Add(routesOverlay);
            //    //}
            //}
        }

        private void CrearDireccionTrazarRuta()
        {
            GDirections direccion;

            double lng=0, lat=0, lngAnt, latAnt ;
            PointLatLng Inicio, Final;
            Inicio = new PointLatLng(lat, lng);

            for (int i = 0; i <= DgDatos.Rows.Count - 1; i++)
            {
                if (i==0)
                {
                    latAnt = Convert.ToDouble(DgDatos.Rows[i].Cells["FlePer_Latitud"].Value.ToString().Trim().Replace(",", "."));
                    lngAnt = Convert.ToDouble(DgDatos.Rows[i].Cells["FlePer_Longitud"].Value.ToString().Trim().Replace(",", "."));
                    Inicio = new PointLatLng(latAnt, lngAnt);
                    continue;
                }
                lat = Convert.ToDouble(DgDatos.Rows[i].Cells["FlePer_Latitud"].Value.ToString().Trim().Replace(",", "."));
                lng = Convert.ToDouble(DgDatos.Rows[i].Cells["FlePer_Longitud"].Value.ToString().Trim().Replace(",", "."));
                Final = new PointLatLng(lat, lng);

                var RutasDireccion = GMapProviders.GoogleMap.GetDirections(out direccion, Inicio, Final, false, false, false, false, false);
                GMapRoute RutaObtenida = new GMapRoute(direccion.Route, "Ruta Ubicacion");
                GMapOverlay CapaRutas = new GMapOverlay("Capa de la Ruta");
                CapaRutas.Routes.Add(RutaObtenida);
                gMap.Overlays.Add(CapaRutas);
                latAnt = Convert.ToDouble(DgDatos.Rows[i].Cells["FlePer_Latitud"].Value.ToString().Trim().Replace(",", "."));
                lngAnt = Convert.ToDouble(DgDatos.Rows[i].Cells["FlePer_Longitud"].Value.ToString().Trim().Replace(",", "."));
                Inicio = new PointLatLng(latAnt, lngAnt);
            }

            
            gMap.Zoom = gMap.Zoom + 1;
            gMap.Zoom = gMap.Zoom - 1;

        }
    }
}
