using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Models
{
    public class MemberEntity : BusinessEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int Seniority { get; set; }
    }
}
