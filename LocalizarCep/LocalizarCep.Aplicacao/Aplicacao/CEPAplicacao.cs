using LocalizarCep.Aplicacao.Contrato;
using LocalizarCep.Dominio;
using LocalizarCep.Servicos.API.Contratos;
using System;
using System.Text;

namespace LocalizarCep.Aplicacao.Aplicacao
{
    public class CEPAplicacao : ICEPAplicacao
    {
        private readonly IApiServico api;
        
        public CEPAplicacao(IApiServico api)
        {
            this.api = api;
        }
    
        public CEP ObeterCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || string.IsNullOrEmpty(cep))
                return null;

            if (cep.Length < 8 || cep.Length > 8)
                return null;

            var cepRetorno = api.ObeterCEP(cep);
            if (cepRetorno == null)
            {
                //TODO:LOG 
                return null;
            }

            return cepRetorno;
        }
    }
}
