using LocalizarCep.Dominio;
using LocalizarCep.Servicos.API.Contratos;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace LocalizarCep.Servicos.API
{
    public class ApiServico : IApiServico
    {
       
        public CEP ObeterCEP(string cep)
        {
          
            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://viacep.com.br/ws/");

            var result = httpClient.GetAsync($"{cep}/json")
                .Result.Content.ReadAsStringAsync()
                .Result;

            if (result != null)
                return JsonConvert.DeserializeObject<CEP>(result);
            return null;
        }
    }
}
