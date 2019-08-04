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
        private IRepository<ScheduleEntity> _schedules;

        public TrainingsController(IRepository<TrainingEntity> trainings, IRepository<ScheduleEntity> schedules)
        {
            _trainings = trainings;
            _schedules = schedules;
        }

        public IActionResult Get()
        {
            try
            {
                var schedules = _schedules.GetAll().ToList();
                var result = _trainings.GetAll().Select(_ => new
                {
                    name = _.Name,
                    instructor = _.Instructor,
                    schedules = schedules.Where(s => s.TrainingId == _.Id)
                });
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  e.Message);
            }

        }

    }
}