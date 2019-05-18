using GymWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Services
{
    public interface IMemberService
    {
        int Applydiscount(Guid memberId);
        void ValidateMember(Guid memberId);
    }
}
