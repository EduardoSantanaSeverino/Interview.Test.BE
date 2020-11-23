using System;
using GraduationTracker.Application.Models;
using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Enums;

namespace GraduationTracker.Application
{
    public interface IGraduationTracker
    {
        Tuple<bool, STANDING> HasGraduated(IDiploma diploma, IStudent student);
        IStudentIndicator GetStudentIndicator(IDiploma diploma, IStudent student);
    }
}