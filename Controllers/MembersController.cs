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

        public MembersController(IRepository<MemberEntity> members, IMemberService service)
        {
            _members = members;
            _service = service;
        }

        public IActionResult Get()
        {
            try
            {
                var results = _members.GetAll().Select(_ => new
                {
                    name = _.Name,
                    birthDate = _.BirthDate,
                    seniority = _.Seniority
                });
                return Ok(results);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  e.InnerException);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var result = _members.GetAll().Single(_ => _.Id == id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                  "The member Id is incorrect.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MemberEntity member)
        {
            try
            {
                _members.Add(member);
                return Ok(member);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                  e.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var member = _members.GetAll().Single(_ => _.Id == id);
                _members.Delete(member);
                _members.Save();
                return Ok($"The {member.Name} member was deleted.");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                  e.Message);
            }
        }

    }
}
