using AlarmClockApp.Models;
using System.Threading.Tasks;

namespace AlarmClockApp.Services
{
    public interface IWeatherService
    {
        Task<Weather> GetWeatherAsync();
    }
}