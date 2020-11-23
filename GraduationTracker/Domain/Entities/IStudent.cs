using System.Collections.Generic;
using GraduationTracker.Domain.Enums;

namespace GraduationTracker.Domain.Entities
{
    public interface IStudent
    {
        int Id { get; set; }
        List<IStudentCourse> Courses { get; set; }
    }
}