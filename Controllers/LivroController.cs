using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec_MVC_DEV.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bibliotec_MVC_DEV.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }
        public async Task<IActionResult> Index()
        {


            string? adminSessao = HttpContext.Session.GetString("Admin");

            if (adminSessao == null)
            {
                return RedirectToAction("Index", "Login");

            }

            ViewBag.Admin = adminSessao == "True" || adminSessao == "True";

            var livros = await _livroService.BuscarLivrosComCatAsync();

            return View(livros);
        }

    }
}