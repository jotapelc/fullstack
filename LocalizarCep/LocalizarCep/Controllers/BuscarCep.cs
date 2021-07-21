using LocalizarCep.Aplicacao.Contrato;
using LocalizarCep.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LocalizarCep.Controllers
{
    public class BuscarCep : BaseController
    {
        private readonly ICEPAplicacao cepAplicacao;

        public BuscarCep(ICEPAplicacao cepAplicacao)
        {
            this.cepAplicacao = cepAplicacao;
        }

        [HttpGet("{cep}")]
        public IActionResult Get(string cep)
        {
            try
            {  
                var resultado = cepAplicacao.ObeterCEP(cep);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Ops, houve um erro.: {ex.Message}");
            }

        }
    }
}
