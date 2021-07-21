using AutoMapper;
using LocalizarCep.Aplicacao.Contrato;
using LocalizarCep.Aplicacao.DTO;
using LocalizarCep.Dominio.Contratos.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizarCep.Aplicacao.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IUsuarioServico usuarioServico;
        private readonly IMapper mapper;

        public UsuarioAplicacao(IUsuarioServico usuarioServico, IMapper mapper)
        {
            this.usuarioServico = usuarioServico;
            this.mapper = mapper;
        }

        public List<UsuarioDTO> ListarUsuarios()
        {
            var usuario = new List<UsuarioDTO>();
            try
            {
                var retornoUsuarios = usuarioServico.ListarUsuarios();
                if (retornoUsuarios == null)
                    return null;

                usuario = mapper.Map<List<UsuarioDTO>>(retornoUsuarios);
            }
            catch (Exception ex)
            {
                //TODO
                return null;
            }

            return usuario;
        }

        public UsuarioDTO Autenticar(UsuarioDTO usuarioDTO)
        {
            var user = new UsuarioDTO();
            try
            {
               var usuario = usuarioServico.Autenticar(usuarioDTO.Login, usuarioDTO.Senha);
                if (usuario == null)
                {
                    return null;
                }
                user = mapper.Map<UsuarioDTO>(usuario);
            }
            catch (Exception ex)
            {
                return null;
            }

            return user;
        }
    }
}
