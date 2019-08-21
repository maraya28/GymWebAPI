using GymWebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Services
{
    public interface ITrainingService
    {
        List<TrainingViewModel> GetAll();
    }
}
