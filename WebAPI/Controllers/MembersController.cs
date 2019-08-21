using GymWebAPI.Data;
using Models;
using GymWebAPI.Services;
using GymWebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
                    seniority = Enum.GetName(typeof(SeniorityType), _.Seniority)
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
                                  "The entered member ID does't exist.");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MemberViewModel member)
        {
            try
            {
                var entity = member.ToEnity();
                _members.Add(entity);
                return Ok(entity);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                  e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] MemberViewModel member)
        {
            try
            {
                _service.ValidateMember(id);
                var entity = _members.GetAll().Single(_ => _.Id == id);
                var updated = member.ToEnity(entity);
                _members.Update(updated);
                _members.Save();
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
