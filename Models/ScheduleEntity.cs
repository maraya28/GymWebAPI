using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Models
{
    public class ScheduleEntity 
    {
        public ScheduleEntity(DayOfWeek day, int hours, int minutes)
        {
            Day = day;
            Hour = new TimeSpan(hours, minutes, 0);
        }

        public DayOfWeek Day { get; private set; }
        public TimeSpan Hour { get; private set; }
        public string HourFormat => $"{Hour.Hours.ToString("00")}:{Hour.Minutes.ToString("00")} Hs";
    }
}
