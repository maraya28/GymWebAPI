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
                    description = _.Description,
                    schedules = schedules.Where(s => s.TrainingId == _.Id).Select(d => new
                    {
                        Day = Enum.GetName(typeof(DayOfWeek), d.Day),
                        Hour = d.HourFormat
                    })
                });
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                  e.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var schedules = _schedules.GetAll().ToList();
                var training = _trainings.GetAll().Single(_ => _.Id == id);
                var result = new 
                {
                    name = training.Name,
                    description = training.Description,
                    schedules = schedules.Where(s => s.TrainingId == training.Id).Select(d => new
                    {
                        Day = Enum.GetName(typeof(DayOfWeek), d.Day),
                        Hour = d.HourFormat
                    })
                };
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                  "The entered Training ID does't exist.");
            }
        }


    }
}