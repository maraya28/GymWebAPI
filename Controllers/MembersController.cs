using GymWebAPI.Data;
using GymWebAPI.Models;
using GymWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        protected IRepository<MemberEntity> _members;
        protected IMemberService _service;

        public MembersController(IRepository<MemberEntity> members , IMemberService service)
        {
            _members = members;
            _service = service;
        }
        
        public IActionResult Get()
        {
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
