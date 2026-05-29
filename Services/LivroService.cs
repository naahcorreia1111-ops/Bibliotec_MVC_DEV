using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec_MVC.Repositories;
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;


namespace Bibliotec_MVC_DEV.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }


        public async Task<IEnumerable<Livro>>  BuscarLivrosComCatAsync()
        {
            return await _livroRepository.BuscarLivrosAsync();
                }
    }

}