using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Models
{
    public sealed class GymSingleton
    {
        private static readonly object _lock = new object();
        private static GymSingleton _instance = null;

        GymSingleton()
        {

        }

        public static GymSingleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new GymSingleton()
                        {
                            Name = "Gym API",
                            Address = "Mendoza 452 Rosario, Santa Fe, Argentina.",
                            PhoneNumber = "+54 (341) 000 0000 00",
                            Email = "gymapi@hotmail.com",
                            WebSite = "gymapi.com.ar"
                        };
                    return _instance;
                }
            }
        }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string WebSite { get; private set; }
    }
}
