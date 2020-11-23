using System;
using GraduationTracker.Domain.Enums;

namespace GraduationTracker.Application.Models
{
    public interface IStudentIndicator
    {
        int Average { get; set; }
        int ApprovedCourses { get; set; }
        int NoApprovedCourses { get; set; }
        int Credits { get; set; }
        bool IsGraduated { get; set; }
        STANDING Standing { get; set; }
        Tuple<bool, STANDING> GetHasGraduated();
        void SetDefaultValues();
    }
}