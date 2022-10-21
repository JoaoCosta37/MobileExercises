using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmClockApp.Models
{
    public class AlarmData
    {
        public AlarmData()
        {
            DaysToRepeat = new List<DayOfWeek>();
        }
        public TimeSpan Time { get; set; }

        [TextBlob("daysOfWeekBlobbed")]
        public List<DayOfWeek> DaysToRepeat {get;set;}

        public string daysOfWeekBlobbed { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
