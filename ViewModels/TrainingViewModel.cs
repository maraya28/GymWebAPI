using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewModels
{
    public class TrainingViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ScheduleViewModel> Schedules { get; set; }

        public TrainingEntity ToEnity()
        {
            return new TrainingEntity(Name, Description);
        }
    }
}
