using GymWebAPI.Data;
using GymWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Services
{
    public class MemberService : IMemberService
    {
        protected IRepository<MemberEntity> _members;

        public MemberService(IRepository<MemberEntity> members)
        {
            _members = members;
        }


        public void ValidateMember(Guid memberId)
        {
            try
            {
                _members.GetAll().Any(_ => _.Id == memberId);
            }
            catch
            {
                throw new KeyNotFoundException("The member to update does't exist.");
            }
        }



        public int Applydiscount(Guid memberId)
        {
            var member = _members.GetAll().Single(_ => _.Id == memberId);
            return 0;
        }

       
    }
}
