using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetYourCepApp.Models
{
    public class CepData
    {
        public CepData()
        {

        }
        public string Cep { get; set; } 
        public string Logradouro { get; set; } 
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public int Ibge { get; set; }
        public int Gia { get; set; }
        public int Ddd { get; set; }
        public int Siafi { get; set; }
    }
}
