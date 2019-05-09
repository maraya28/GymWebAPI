using GymWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using GymWebAPI.Data;

namespace GymWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TrainingsController : ControllerBase
    {
        private IRepository<TrainingEntity> _repository;

        public TrainingsController(IRepository<TrainingEntity> repository)
        {
            _repository = repository;       
        }

       
        public object Get()
        {

            _repository.Add(new TrainingEntity());

            return new { Name = "Test" };
        }
    }
}