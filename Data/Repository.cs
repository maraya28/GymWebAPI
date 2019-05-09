using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymWebAPI.Models;

namespace GymWebAPI.Data
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly GymContext _context;
       
        public Repository(GymContext context)
        {
            _context = context;
        }
                            
        public void Add(T entity)
        {
            _context.Add(entity);
        }
          
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
