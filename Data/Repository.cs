using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GymWebAPI.Data
{
    public class Repository<T> : IRepository<T> where T : BusinessEntity
    {
        private readonly GymContext _context;

        public Repository(GymContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
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
