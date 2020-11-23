using System;
using GraduationTracker.Domain.Enums;
using GraduationTracker.Domain.Rules;

namespace GraduationTracker.Application.Models
{
    public class StudentIndicator : IStudentIndicator
    {

        private readonly IStadingRules _stadingRules;

        public StudentIndicator(IStadingRules stadingRules) => _stadingRules = stadingRules ?? throw new ArgumentNullException(nameof(stadingRules));

        public int Average { get; set; }
        public int ApprovedCourses { get; set; }
        public int NoApprovedCourses { get; set; }
        public int Credits { get; set; }
        public bool IsGraduated { get; set; }
        public STANDING Standing { get; set; }
        public virtual Tuple<bool, STANDING> GetHasGraduated() => new Tuple<bool, STANDING>(IsGraduated, Standing);
        
        public virtual void SetDefaultValues()
        {
            Average = 0;
            ApprovedCourses = 0;
            NoApprovedCourses = 0;
            Credits = 0;
            IsGraduated = false;
            Standing = _stadingRules.DefaultStanding();
        }
    }
}