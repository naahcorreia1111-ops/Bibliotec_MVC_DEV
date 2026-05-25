

using Bibliotec_MVC_DEV.Contexts;
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;
using Microsoft.EntityFrameworkCore;

namespace Bibliotec_MVC_DEV.Repositories
{
    public class UsuarioRepository : IUsuarioRpository
    {
        private readonly BbDbContext _context;

        public UsuarioRepository(BbDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> BuscarPorEmailSenha(string email, string senha)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }
    }
}