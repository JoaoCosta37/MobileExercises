using GetYourCepApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GetYourCepApp.Services
{
    public class CepService : ICepService
    {
       
        public async Task<CepData> GetCepAzync(string cepNumber)
        {
            HttpClient httpClient = new HttpClient();

            string url = $"https://viacep.com.br/ws/{cepNumber}/json/";

            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(result);

                var cep = json["cep"].ToString();
                var logradouro = json["logradouro"].ToString();
                var complemento = json["complemento"].ToString();
                var bairro = json["bairro"].ToString();
                var localidade = json["localidade"].ToString();
                var uf = json["uf"].ToString();
                var ibge = Convert.ToInt32(json["ibge"].ToString());
                var gia = Convert.ToInt32(json["gia"].ToString());
                var ddd = Convert.ToInt32(json["ddd"].ToString());
                var siafi = Convert.ToInt32(json["siafi"].ToString());

                return new CepData()
                {
                    Cep = cep,
                    Logradouro = logradouro,
                    Complemento = complemento,
                    Bairro = bairro,
                    Localidade = localidade,
                    Uf = uf,
                    Ibge = ibge,
                    Gia = gia,
                    Ddd = ddd,
                    Siafi = siafi
                };

            }
            return null;
        }
    }
}
