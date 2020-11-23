using System.Collections.Generic;
using GraduationTracker.Domain.Entities;

namespace GraduationTracker.Persistence
{
    public interface IDatabase
    {
        List<IStudent> Students { get; } 
        List<IDiploma> Diplomas { get; }
    }
}