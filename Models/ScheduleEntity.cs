using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ScheduleEntity : BusinessEntity
    {
        public ScheduleEntity(Guid trainingId, DayOfWeek day, int hours, int minutes)
        {
            TrainingId = trainingId;
            Day = day;
            Hours = hours;
            Minutes = minutes;
        }

        public Guid TrainingId { get; set; }
        public DayOfWeek Day { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public string HourFormat => $"{Hours.ToString("00")}:{Minutes.ToString("00")} Hs";
    }
}
