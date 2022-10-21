using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AlarmClockApp.Services
{
    public interface ILocationService
    {
        Task<Location> GetLocation();
    }
}