using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace FletesPersonal
{
    /// <summary>
    /// Envía correos desde un buzón fijo mediante Microsoft Graph (POST /users/{buzón}/sendMail).
    /// Autenticación de aplicación (credenciales de cliente), sin inicio de sesión de usuario.
    /// El secreto va embebido en el ejecutable (recurso GraphSecret.txt, fuera de git).
    /// Sin dependencias externas: el proyecto es .NET 4.0, por eso se usa HttpWebRequest y JSON manual.
    /// </summary>
    public sealed class GraphMailService
    {
        private const string ClientId = "c982ac22-b59a-441c-905a-9eb273ade26b";
        private const string TenantId = "d20460dd-675d-4b51-87cc-9d10f9175633";
        private const string RecursoSecreto = "FletesPersonal.GraphSecret.txt";

        private readonly string _buzonRemitente;
        private string _token;
        private DateTime _tokenVence = DateTime.MinValue;

        public GraphMailService(string buzonRemitente)
        {
            _buzonRemitente = buzonRemitente;
        }

        public void Enviar(IEnumerable<string> para, IEnumerable<string> cc, string asunto, string cuerpoHtml)
        {
            var json = "{\"message\":{" +
                       "\"subject\":" + Cadena(asunto) + "," +
                       "\"body\":{\"contentType\":\"HTML\",\"content\":" + Cadena(cuerpoHtml) + "}," +
                       "\"toRecipients\":" + Destinatarios(para) + "," +
                       "\"ccRecipients\":" + Destinatarios(cc) +
                       "},\"saveToSentItems\":true}";

            var url = "https://graph.microsoft.com/v1.0/users/" + Uri.EscapeDataString(_buzonRemitente) + "/sendMail";
            Post(url, json, "application/json", ObtenerToken());
        }

        private string ObtenerToken()
        {
            if (_token != null && DateTime.UtcNow < _tokenVence) return _token;

            var form = "client_id=" + Uri.EscapeDataString(ClientId) +
                       "&client_secret=" + Uri.EscapeDataString(LeerSecreto()) +
                       "&scope=" + Uri.EscapeDataString("https://graph.microsoft.com/.default") +
                       "&grant_type=client_credentials";

            var resp = Post("https://login.microsoftonline.com/" + TenantId + "/oauth2/v2.0/token",
                            form, "application/x-www-form-urlencoded", null);

            var token = Regex.Match(resp, "\"access_token\"\\s*:\\s*\"([^\"]+)\"");
            var segundos = Regex.Match(resp, "\"expires_in\"\\s*:\\s*(\\d+)");
            if (!token.Success)
                throw new InvalidOperationException("Respuesta de token inesperada: " + resp);

            _token = token.Groups[1].Value;
            // Margen de 5 minutos antes del vencimiento real.
            _tokenVence = DateTime.UtcNow.AddSeconds((segundos.Success ? int.Parse(segundos.Groups[1].Value) : 3600) - 300);
            return _token;
        }

        private static string LeerSecreto()
        {
            using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream(RecursoSecreto))
            {
                if (s == null)
                    throw new InvalidOperationException("El ejecutable no contiene el recurso " + RecursoSecreto + ".");
                using (var r = new StreamReader(s, Encoding.UTF8))
                    return r.ReadToEnd().Trim();
            }
        }

        private static string Post(string url, string cuerpo, string contentType, string bearer)
        {
            // Microsoft exige TLS 1.2; en .NET 4.0 no es el valor por defecto (3072 = Tls12).
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = contentType;
            if (bearer != null) req.Headers[HttpRequestHeader.Authorization] = "Bearer " + bearer;

            var bytes = Encoding.UTF8.GetBytes(cuerpo);
            req.ContentLength = bytes.Length;
            using (var o = req.GetRequestStream())
                o.Write(bytes, 0, bytes.Length);

            try
            {
                using (var resp = (HttpWebResponse)req.GetResponse())
                using (var r = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                    return r.ReadToEnd();
            }
            catch (WebException ex)
            {
                var detalle = ex.Message;
                if (ex.Response != null)
                {
                    var http = (HttpWebResponse)ex.Response;
                    using (var r = new StreamReader(http.GetResponseStream(), Encoding.UTF8))
                        detalle = "Graph respondió " + (int)http.StatusCode + ": " + r.ReadToEnd();
                }
                throw new InvalidOperationException(detalle, ex);
            }
        }

        private static string Destinatarios(IEnumerable<string> direcciones)
        {
            var items = new List<string>();
            foreach (var d in direcciones)
                if (!string.IsNullOrWhiteSpace(d))
                    items.Add("{\"emailAddress\":{\"address\":" + Cadena(d.Trim()) + "}}");
            return "[" + string.Join(",", items.ToArray()) + "]";
        }

        private static string Cadena(string texto)
        {
            var sb = new StringBuilder("\"");
            foreach (var c in texto ?? "")
            {
                switch (c)
                {
                    case '"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        if (c < ' ') sb.Append("\\u").Append(((int)c).ToString("x4"));
                        else sb.Append(c);
                        break;
                }
            }
            return sb.Append('"').ToString();
        }
    }
}
