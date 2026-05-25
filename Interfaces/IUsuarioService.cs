
using Bibliotec_MVC_DEV.Models;

namespace Bibliotec_MVC_DEV.Interfaces
{
    public interface IUsuarioService
    {
        
        Task<Usuario?> AutenticarUsuario(string email, string senha);
        
    }
}