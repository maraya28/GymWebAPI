using System;

namespace GymWebAPI.Models
{
    public abstract class BusinessEntity
    {
        public Guid Id { get; private set; }
    }
}
