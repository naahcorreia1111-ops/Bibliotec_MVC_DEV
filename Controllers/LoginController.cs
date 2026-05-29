
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bibliotec_MVC_DEV.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(string email, string senha)
        {
            Usuario? usuario = await _usuarioService.AutenticarUsuario(email, senha);

            if (usuario != null)
            {
                HttpContext.Session.SetString("UsuarioId", usuario.Id.ToString());
                HttpContext.Session.SetString("Admin", usuario.TipoBib.ToString());

                return RedirectToAction("Index", "Livro");
            }

            ViewBag.Erro = "Usuário ou senha inválidos";
            return View("Index");

        }

        [HttpPost]

        public IActionResult Deslogar()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Index");

        }


    }
}