using System;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Domain.Entities;
using GraduationTracker.Persistence;

namespace GraduationTracker.Repositories
{
    public class StudentRepository : IRepository<IStudent> 
    {
        private readonly IDatabase _database;
        public StudentRepository(IDatabase database) => _database = database;
        public IStudent Get(int id) => GetAll().FirstOrDefault(p => p.Id == id);
        public IEnumerable<IStudent> Find(Func<IStudent, bool> predicate) => GetAll().Where(predicate);
        public IEnumerable<IStudent> GetAll() => _database.Students;
    }
}