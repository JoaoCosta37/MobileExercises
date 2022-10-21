using GetYourCepApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetYourCepApp.Services
{
    public interface ICepService
    {
        Task<CepData> GetCepAzync(string cepNumber);
    }
}
