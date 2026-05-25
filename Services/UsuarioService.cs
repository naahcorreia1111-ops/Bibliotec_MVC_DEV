using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bibliotec_MVC_DEV.Interfaces;
using Bibliotec_MVC_DEV.Models;

namespace Bibliotec_MVC_DEV.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRpository _usuarioRepository;

        public UsuarioService(IUsuarioRpository usuarioRpository)
        {
            _usuarioRepository = usuarioRpository;
        }

        public async Task<Usuario?> AutenticarUsuario(string email, string senha)
        {
            return await _usuarioRepository.BuscarPorEmailSenha(email, senha);
        }
    }
}