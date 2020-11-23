using System;
using System.Linq;
using GraduationTracker.Application.Models;
using GraduationTracker.Domain.Entities;
using GraduationTracker.Domain.Enums;
using GraduationTracker.Domain.Rules;

namespace GraduationTracker.Application
{
    public class GraduationTracker : IGraduationTracker
    {
        private readonly IStadingRules _stadingRules;
        private readonly IStudentIndicator _studentIndicator;
        
        public GraduationTracker(IStadingRules stadingRules, IStudentIndicator studentIndicator)
        {
            _stadingRules = stadingRules ?? throw new ArgumentNullException(nameof(stadingRules));
            _studentIndicator = studentIndicator ?? throw new ArgumentNullException(nameof(studentIndicator));
        }

        public Tuple<bool, STANDING> HasGraduated(IDiploma diploma, IStudent student) => GetStudentIndicator(diploma, student).GetHasGraduated();

        public IStudentIndicator GetStudentIndicator(IDiploma diploma, IStudent student)
        {
            
            // Set counters to Zero and default Standing
            _studentIndicator.SetDefaultValues();
            
            // Foreach Diploma Requirement
            foreach (var requirement in diploma.Requirements)
            {
                
                var studentCourses= student
                    .Courses
                    .Where(p => p.Course.Id == requirement.Course.Id);

                foreach (var studentCourse in studentCourses)
                {
                    // Increase the Average, Passed Credits and APPROVED Courses Counters.
                    _studentIndicator.Average += studentCourse.Mark;
                    _studentIndicator.Credits += studentCourse.Course.Credits;
                    if (studentCourse.Mark < requirement.MinimumMark) _studentIndicator.NoApprovedCourses++;
                    else _studentIndicator.ApprovedCourses++; 
                }
               
            }

            // Set the is graduated, Standing and final Average.
            _studentIndicator.IsGraduated = _studentIndicator.ApprovedCourses >= diploma.Requirements.Count;

            if (_studentIndicator.Average > 0)
            {
                // Set the Average only if greater than zero.
                _studentIndicator.Average = _studentIndicator.Average / (_studentIndicator.ApprovedCourses + _studentIndicator.NoApprovedCourses);
                // Get the Standing by custom defined domain rules only if Average greater than zero.
                _studentIndicator.Standing = _stadingRules.GetStandingByAverage(_studentIndicator.Average);
            }
            
            // Return Indicators
            return _studentIndicator;

        }
    }
}