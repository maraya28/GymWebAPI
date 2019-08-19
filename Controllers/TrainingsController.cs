using GymWebAPI.Data;
using GymWebAPI.Models;
using GymWebAPI.Services;
using GymWebAPI.ViewModels;
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
        protected ITrainingService _service;

        public TrainingsController(IRepository<TrainingEntity> trainings, IRepository<ScheduleEntity> schedules, ITrainingService service)
        {
            _trainings = trainings;
            _schedules = schedules;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _service.GetAll();
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

        [HttpPost]
        public IActionResult Post([FromBody] TrainingViewModel training)
        {
            try
            {
                var entity = training.ToEnity();
                _trainings.Add(entity);
                return Ok(new
                {
                    name = entity.Name,
                    description = entity.Description
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                                  e.Message);
            }
        }

        [HttpPost]
        [Route("api/trainings/addSchedules")]
        public IActionResult AddSchedules()
        {
            return default;
        }
    }
}