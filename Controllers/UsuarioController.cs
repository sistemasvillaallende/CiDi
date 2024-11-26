using Cidi.Model;
using Microsoft.AspNetCore.Mvc;
using Cidi.Services;


namespace Cidi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuarioController : Controller
    {
        private IUsuarioServices _UsuarioServices;
        public UsuarioController(IUsuarioServices UsuarioServices)
        {
            this._UsuarioServices = UsuarioServices;
        }
        [HttpGet]
        public IActionResult GetUsuarioLogueado(string hash)
        {
            Entities.UsuarioLoginCIDI usuario = _UsuarioServices.GetUsuarioLogueado(hash);

            return usuario == null ? BadRequest(new
            {
                message = "Error al obtener los datos"
            }) : Ok(usuario);
        }
        [HttpGet]
        public IActionResult GetUsuarioCidi(string hash)
        {
            Model.UsuarioCidiModel usuario = _UsuarioServices.GetUsuarioCiDi(hash);

            return usuario == null ? BadRequest(new
            {
                message = "Error al obtener los datos"
            }) : Ok(usuario);
        }
    }
}
