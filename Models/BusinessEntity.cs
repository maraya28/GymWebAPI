using System;

namespace GymWebAPI.Models
{
    public abstract class BusinessEntity
    {
        protected BusinessEntity()
        {

        }

        public Guid Id { get; protected set; }

    }
}
