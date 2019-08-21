using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.ViewModels
{
    public class ScheduleViewModel
    {
        public string Day { get; set; }
        public string Hours { get; set; }

        public ScheduleViewModel(string day, string hours)
        {
            Day = day;
            Hours = hours;
        }
    }
}
