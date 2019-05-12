using GymWebAPI.Data;
using GymWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GymWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TrainingsController : ControllerBase
    {
        private IRepository<TrainingEntity> _trainings;

        public TrainingsController(IRepository<TrainingEntity> trainings)
        {
            _trainings = trainings;
        }

        public IActionResult Get()
        {
            try
            {
                var result = _trainings.GetAll().Select(_ => new
                {
                    name = _.Name,
                    instructor = _.Instructor
                });
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  e.InnerException);
            }

        }

    }
}