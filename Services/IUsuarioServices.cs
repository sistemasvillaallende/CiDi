using Cidi.Entities;
using Cidi.Model;

namespace Cidi.Services
{
    public interface IUsuarioServices
    {
        public UsuarioLoginCIDI GetUsuarioLogueado(string hash);
        public UsuarioCidiModel GetUsuarioCiDi(string hash);

    }
}
