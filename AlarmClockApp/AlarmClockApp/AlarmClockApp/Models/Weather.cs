using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmClockApp.Models
{
    public class Weather
    {
         
        public Weather()
        {
                
        }

        public string Description { get; set; }
        public string Icon { get; set; }
        public decimal Temp { get; set; }
    }
}
