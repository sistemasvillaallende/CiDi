using Cidi.Model;
using RestSharp;
using Newtonsoft;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography;
using Cidi.Entities;

namespace Cidi.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        public static String ObtenerToken_SHA1(String TimeStamp, string CiDiKeyAplicacion)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(TimeStamp + CiDiKeyAplicacion);
            SHA1 SHA1 = new SHA1Managed();
            String token = BitConverter.ToString(SHA1.ComputeHash(buffer)).Replace("-", "");

            return token;
        }
        public static string getParametrosCIDI(string hash)
        {
            try
            {

                int idApp = 521;
                string urlBaseCuenta = "https://cuentacidi.cba.gov.ar/";
                string pass = "GBHREGahcu52487";
                string keyApp = "365873517459654D49575773436C7370";


                UsuarioLogueadoRequest objReq = new UsuarioLogueadoRequest();
                objReq.Contrasenia = pass;
                objReq.CUIL = null;
                objReq.HashCookie = hash;
                objReq.IdAplicacion = idApp;
                objReq.TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                objReq.TokenValue = ObtenerToken_SHA1(objReq.TimeStamp, keyApp);

                string jsonContent =
                    Newtonsoft.Json.JsonConvert.SerializeObject(objReq);

                return jsonContent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UsuarioCidiModel GetUsuarioCiDi(string hash)
        {
            try
            {
                string req = getParametrosCIDI(hash);
                var options = new RestClientOptions("https://cuentacidi.cba.gov.ar")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/Usuario/Obtener_Usuario_Basicos_Domicilio", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                var body = req;
                request.AddStringBody(body, DataFormat.Json);
                RestResponse response = client.Execute(request);

                return JsonConvert.DeserializeObject<UsuarioCidiModel>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UsuarioLoginCIDI GetUsuarioLogueado(string hash)
        {
            UsuarioCidiModel obj = GetUsuarioCiDi(hash);
            UsuarioLoginCIDI usuario = null;
            if (obj.CUIL != null)
            {
                usuario = UsuarioLoginCIDI.getByCuit(obj.CUIL); 
                if(usuario != null)
                {
                    usuario.sessionHash = hash;
                    usuario.apellido = obj.Apellido;
                    usuario.cuit = obj.CUIL;
                    usuario.cuit_formateado = obj.CuilFormateado;
                    usuario.nombre = obj.Nombre;
                    usuario.nombre_completo = obj.NombreFormateado;
                }
            }
            return usuario;
        }
    }
}
