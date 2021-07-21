using LocalizarCep.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizarCep.Aplicacao.Contrato
{
    public interface ICEPAplicacao
    {
       public CEP ObeterCEP(string cep);
    }
}
