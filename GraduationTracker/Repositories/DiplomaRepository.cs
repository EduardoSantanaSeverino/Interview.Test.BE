using System;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Domain.Entities;
using GraduationTracker.Persistence;

namespace GraduationTracker.Repositories
{
    public class DiplomaRepository : IRepository<IDiploma>
    {
        private readonly IDatabase _database;
        public DiplomaRepository(IDatabase database) =>  _database = database;
        public IEnumerable<IDiploma> Find(Func<IDiploma, bool> predicate) => GetAll().Where(predicate).ToList();
        public IDiploma Get(int id) => GetAll().FirstOrDefault(p => p.Id == id);
        public IEnumerable<IDiploma> GetAll() => _database.Diplomas;
    }
}