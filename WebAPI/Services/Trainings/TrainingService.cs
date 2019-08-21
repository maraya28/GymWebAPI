
using GymWebAPI.Data;
using Models;
using GymWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GymWebAPI.Services
{
    public class TrainingService : ITrainingService
    {
        private IRepository<TrainingEntity> _trainings;
        private IRepository<ScheduleEntity> _schedules;

        public TrainingService(IRepository<TrainingEntity> trainings,
                               IRepository<ScheduleEntity> schedules)
        {
            _trainings = trainings;
            _schedules = schedules;
        }

        public List<TrainingViewModel> GetAll()
        {
            var result = new List<TrainingViewModel>();
            var schedules = _schedules.GetAll();
            _trainings.GetAll().ToList().ForEach(t =>
            {
                var vm = new TrainingViewModel
                {
                    Name = t.Name,
                    Description = t.Description,
                    Schedules = new List<ScheduleViewModel>()
                };
                schedules.Where(s => s.TrainingId == t.Id).ToList().ForEach(_ =>
                {
                    vm.Schedules.Add(new ScheduleViewModel(Enum.GetName(typeof(DayOfWeek),
                                                           _.Day),
                                                           _.HourFormat));
                });
                result.Add(vm);
            });
            return result;
        }
    }
}
