
using GymWebAPI.Data;
using GymWebAPI.Models;
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
            var trainings = _trainings.GetAll();
            var schedules = _schedules.GetAll();
            var result = new List<TrainingViewModel>();

            foreach (var t in trainings)
            {
                var vm = new TrainingViewModel
                {
                    Name = t.Name,
                    Description = t.Description,
                    Schedules = new List<ScheduleViewModel>()
                };

                foreach (var s in schedules.Where(s => s.TrainingId == t.Id))
                {
                    vm.Schedules.Add(new ScheduleViewModel(Enum.GetName(typeof(DayOfWeek), s.Day),
                                         s.HourFormat));
                }
                result.Add(vm);
            }
            return result;
        }
    }
}
