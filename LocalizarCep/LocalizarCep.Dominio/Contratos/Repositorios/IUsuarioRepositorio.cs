using LocalizarCep.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizarCep.Dominio.Contratos.Repositorios
{
    public interface IUsuarioRepositorio
    {
        public List<Usuario> ListarUsuarios();
        Usuario SelecionarUsuarioPorLogin(string login, string senha);
    }
}
