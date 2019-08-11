using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Models
{
    public class TrainingEntity : BusinessEntity
    {
        public TrainingEntity()
        {
           
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
