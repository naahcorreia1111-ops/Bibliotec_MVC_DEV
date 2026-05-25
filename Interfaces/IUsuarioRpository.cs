using Bibliotec_MVC_DEV.Models;

namespace Bibliotec_MVC_DEV.Interfaces
{
    public interface IUsuarioRpository
    {
        
        Task<Usuario?> BuscarPorEmailSenha(string email, string senha);
        
    }
}