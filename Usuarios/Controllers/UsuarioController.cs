using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;


namespace Usuarios.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IConfiguration Configuration;
        private string Id;
        public UsuarioController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        [Route("RegistrarUsuario")]
        public IActionResult Registrar(Entities.Body.RegistrarUsuario Usu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Bussiness.Consult.RegistrarUsuario registrar = new Bussiness.Consult.RegistrarUsuario(this.Configuration);
                    Entities.Answer.Response response = registrar.Usu(Usu);
                    if (response != null)
                    {
                        return RedirectToAction("Privacy", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(message);
            }
        }


        [HttpPost]
        [Route("Login/Privacy")]
        public IActionResult Login(Entities.Body.Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Bussiness.Consult.Login Auth = new Bussiness.Consult.Login(this.Configuration);
                    Entities.Answer.Login response = Auth.Auth(login);
                    if (response.Codigo == 1)
                    {
                        TempData["Identificacion"] = response.NumeroIdentificacion;
                        return RedirectToAction("Consulta", "Usuario");
                    }
                    else
                    {
                        return Ok(RedirectToPage("Privacy"));
                    }
                }
                catch
                {
                    return BadRequest(null);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(message);
            }
        }

        public IActionResult Consulta(string Identificacion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Identificacion = TempData["Identificacion"].ToString();
                    Bussiness.Consult.ConsultaPersonas registrar = new Bussiness.Consult.ConsultaPersonas(this.Configuration);
                    Entities.Answer.ConsultaUsuario response = registrar.Usu(Identificacion);
                    if (response != null)
                    {
                        return View(response);
                    }
                    else
                    {
                        TempData["Identificacion"] = response.NumeroIdentificacion;
                        return RedirectToAction("Consulta", "Usuario");
                    }
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                                    .SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return View(message);
            }
        }
    }
}
