using System.Collections.Generic;
using GraduationTracker.Domain.Enums;

namespace GraduationTracker.Domain.Entities
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public List<IStudentCourse> Courses { get; set; }
    }
}
