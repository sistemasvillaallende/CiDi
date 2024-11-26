namespace Cidi.Model
{
    public class UsuarioLogueadoRequest
    {
        public int IdAplicacion { get; set; }
        public string Contrasenia { get; set; }
        public string HashCookie { get; set; }
        public string TokenValue { get; set; }
        public string TimeStamp { get; set; }
        public string CUIL { get; set; }

        public UsuarioLogueadoRequest()
        {
            IdAplicacion = 0;
            Contrasenia = string.Empty;
            HashCookie = string.Empty;
            TokenValue = string.Empty;
            TimeStamp = string.Empty;
            CUIL = string.Empty;
        }
    }
}
