using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trabalho2.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace Trabalho2.Services
{
    class ConsultaCepService
    {
        public ConsultaCepService()
        {
        }

        private static string UrlBase = "https://viacep.com.br/ws/{0}/json/";

        public async static Task<Cep> BuscaCep(string cep)
        {
            string URL = string.Format(UrlBase, cep);
            HttpClient http = new HttpClient();
            string Json = await http.GetStringAsync(URL);
            Cep objetoCep = JsonConvert.DeserializeObject<Cep>(Json);
            return objetoCep;
        }
    }
}
