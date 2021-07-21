using LocalizarCep.Dominio.Entidade;
using System;
using System.Collections.Generic;

namespace LocalizarCep.Dominio.Contratos.Servicos
{
    public interface IUsuarioServico
    {
        public List<Usuario> ListarUsuarios();
        Usuario Autenticar(string login, string senha);
    }
}
