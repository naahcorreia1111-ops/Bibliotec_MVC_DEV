using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec_MVC_DEV.Contexts;
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotec_MVC.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BbDbContext _context;

        public LivroRepository(BbDbContext context)
        {
            _context = context;
        }

        public async Task<Livro> BuscarLivroPorIdAsync(int id)
        {
            return await _context.Livro.FindAsync(id);
        }

        public async Task<IEnumerable<Livro>> BuscarLivrosAsync()
        {
            return await _context.Livro
            .Include(l => l.LivroCategorias)
            .ThenInclude(lc => lc.Categoria)
            .ToListAsync();
        }

        public async Task CadastrarCatLivroAsync(LivroCategoria lc)
        {
            await _context.LivroCategoria.AddAsync(lc);
            await _context.SaveChangesAsync();
        }

        public async Task CadastrarLivro(Livro l)
        {
            await _context.Livro.AddAsync(l);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarCatLivroAsync(int idLivro)
        {
        IEnumerable<LivroCategoria> lcs = _context.LivroCategoria.Where(lc => lc.LivroId == idLivro);
        
            _context.LivroCategoria.RemoveRange(lcs);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarLivroAsync(Livro l)
        {
            _context.Livro.Remove(l);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> ListarCategoriasAsync()
        {
            return await _context.Categoria.ToListAsync();

        }
    }
}
