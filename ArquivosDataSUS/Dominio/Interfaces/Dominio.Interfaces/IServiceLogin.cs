using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IServiceLogin
    {
        Usuario GetUsuarioAcesso(string username, string senha);
        Usuario GetUsuario(string username);
        Usuario GetUsuario(long codigo);
        List<Usuario> GetUsuariosAll(string login, string nome, int? Perfilid, string status);
        //List<Perfil> GetPerfis();
        //Perfil GetPerfil(int id);
        bool AtivarUsuario(long codigo);
        bool DesativarUsuario(long codigo);
        //void SavarLocalizacao(Localizacao localizacao);
    }
}
