using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services
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
            var exists = false;
            var members = _members.GetAll();
            if (members != default)
                exists = members.Any(_ => _.Id == memberId);
            if (exists) return;
            throw new KeyNotFoundException("The member does't exist.");
        }

        public int Applydiscount(Guid memberId)
        {
            var member = _members.GetAll().Single(_ => _.Id == memberId);
            return 0;
        }


    }
}
