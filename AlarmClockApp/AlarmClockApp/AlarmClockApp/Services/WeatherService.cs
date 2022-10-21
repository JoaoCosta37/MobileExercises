using AlarmClockApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AlarmClockApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ILocationService locationService;

        public WeatherService(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        public async Task<Weather> GetWeatherAsync()
        {
            HttpClient httpClient = new HttpClient();

            var location = await locationService.GetLocation();

            var lat = location.Latitude.ToString(CultureInfo.InvariantCulture);
            var lng = location.Longitude.ToString(CultureInfo.InvariantCulture);

            string url = $"https://api.openweathermap.org/data/2.5/onecall?lat={lat}&lon={lng}&appid=32778d2194488f1295d68287590fbc76&lang=pt_br&units=metric&exclude=minutely,daily,hourly";

            try
            {
            var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(result);


                    var temp = Convert.ToDecimal(json["current"]["temp"].ToString());
                    var description = json["current"]["weather"][0]["description"]?.ToString();
                    var icon = json["current"]["weather"][0]["icon"]?.ToString();

                    return new Weather() { Description = description, Icon = icon, Temp = temp };
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            

            return null;

        }
    }
}
