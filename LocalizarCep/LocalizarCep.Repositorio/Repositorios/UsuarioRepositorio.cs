using LocalizarCep.Dominio.Contratos.Repositorios;
using LocalizarCep.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LocalizarCep.Repositorio.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        public List<Usuario> ListarUsuarios()
        {
            XDocument xDocument = XDocument.Load("UsuarioLogin.xml");
            List<Usuario> usuarios = xDocument.Descendants("Usuario").Select
                (p => new Usuario()
                {
                    Login = p.Element("Login").Value,
                    Senha = p.Element("Senha").Value

                }).ToList();

            return usuarios;
        }

        public Usuario SelecionarUsuarioPorLogin(string login, string senha)
        {
            XDocument xDocument = XDocument.Load("UsuarioLogin.xml");
            var usuarios = ListarUsuarios();
            var usuario = usuarios.FirstOrDefault(x => x.Login.ToUpper().Equals(login.ToUpper()) && x.Senha.ToUpper().Equals(senha.ToUpper()));

            return usuario;     
        }
    }
}
