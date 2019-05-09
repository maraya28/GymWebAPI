using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Models
{
    public class TrainingEntity : BusinessEntity
    {
        public string Name { get; set; }
        public int Schedules { get; set; }
        public string Instructor { get; set; }
    }
}
