using LocalizarCep.Aplicacao.Contrato;
using LocalizarCep.Aplicacao.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LocalizarCep.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioAplicacao usuarioAplicacao;

        public UsuarioController(IUsuarioAplicacao usuarioAplicacao)
        {
            this.usuarioAplicacao = usuarioAplicacao;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = usuarioAplicacao.ListarUsuarios();
            if (usuarios == null)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, houve um erro.:");
            }

            return Ok(usuarios);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Post(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
                return null;

            try
            {
                var user = usuarioAplicacao.Autenticar(usuarioDTO);
                if (user != null)
                    return Ok(user);
                else
                    return NotFound("Usuário e/ou senha inválido(s)");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, houve um erro.: " + ex);
            }

        }

    }
}
