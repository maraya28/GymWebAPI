using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Models
{
    public class MemberEntity : BusinessEntity
    {
        private MemberEntity()
        {

        }

        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int Seniority { get;  private set; }


        public class Builder
        {
            private MemberEntity _instance;

            public Builder()
            {
                _instance = new MemberEntity();
            }

            public Builder SetFields(Guid id, string name, DateTime birthDate, int seniority)
            {
                _instance.Id = id;
                _instance.Name = name;
                _instance.BirthDate = birthDate;
                _instance.Seniority = seniority;
                return this;
            }

            public MemberEntity Build()
            {
                return _instance;
            }
        }

    }
}
