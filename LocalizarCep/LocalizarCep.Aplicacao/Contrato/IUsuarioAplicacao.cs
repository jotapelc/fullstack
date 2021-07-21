using LocalizarCep.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizarCep.Aplicacao.Contrato
{
    public interface IUsuarioAplicacao
    {
        List<UsuarioDTO> ListarUsuarios();
        UsuarioDTO Autenticar(UsuarioDTO usuarioDTO);
    }
}
