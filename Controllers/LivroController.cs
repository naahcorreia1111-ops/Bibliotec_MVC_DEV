using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;
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


        [HttpGet]

        public async Task<IActionResult> Cadastro()
        {
            string? adminSessao = HttpContext.Session.GetString("Admin");
            if (adminSessao == null || (adminSessao != "true" && adminSessao != "True"))
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Admin = true;
            ViewBag.Categorias = await _livroService.ListarCategoriasAsync();

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Cadastro(Livro l, string? CategoriasSelecionadas, IFormFile arquivoImagem, string? ativo)
        {
            string? adminSessao = HttpContext.Session.GetString("Admin");
            if (adminSessao == null || (adminSessao != "true" && adminSessao != "True"))
            {
                return RedirectToAction("Index", "Login");
            }

            await _livroService.CadastrarLivroAsync(l, CategoriasSelecionadas, arquivoImagem, ativo);

            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Excluir(int id)

        {
            string? adminSessao = HttpContext.Session.GetString("Admin");
            if (adminSessao == null || (adminSessao != "true" && adminSessao != "True"))
            {
                return RedirectToAction("Index", "Login");
            }

            bool removido = await _livroService.RemoverLivroAsync(id);

            if (removido) return Ok();

            return NotFound();
        }
    }
}