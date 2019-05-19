using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Tests
{
    public abstract class TestBaseClass<T> where T: class
    {
        public T Target { get; set; }

        public virtual void Initialize()
        {

        }
    }
}
