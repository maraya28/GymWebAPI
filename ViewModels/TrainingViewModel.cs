using GymWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.ViewModels
{
    public class TrainingViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ScheduleViewModel> Schedules { get; set; }
    }
}
