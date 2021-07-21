using LocalizarCep.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalizarCep.Servicos.API.Contratos
{
    public interface IApiServico
    {
      CEP ObeterCEP(string cep);
    }
}
