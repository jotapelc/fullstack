using LocalizarCep.Dominio.Contratos.Repositorios;
using LocalizarCep.Dominio.Contratos.Servicos;
using LocalizarCep.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizarCep.Dominio.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public List<Usuario> ListarUsuarios()
        {
            return usuarioRepositorio.ListarUsuarios();
        }

        public Usuario Autenticar(string login, string senha)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
                return null;

            if (login.Length < 2 || login.Length > 10)
                return null;

            if (string.IsNullOrEmpty(senha) || string.IsNullOrWhiteSpace(senha))
                return null;

            if (senha.Length < 2)
                return null;

            var user = usuarioRepositorio.SelecionarUsuarioPorLogin(login, senha);

            if (user == null)
                return null;        

            return user;
        }
    }
}
