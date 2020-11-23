using System.Collections.Generic;
using GraduationTracker.Application.UnitTests.Enums;
using GraduationTracker.Domain.Entities;
using GraduationTracker.Persistence;

namespace GraduationTracker.Application.UnitTests.Setup
{
    public class HardCodedDataBase : IDatabase
    {
        public List<IStudent> Students { get; }
        private List<ICourse> Courses { get; }
        public List<IDiploma> Diplomas { get; }

        public HardCodedDataBase()
        {
            Courses = new List<ICourse>
            {
                new Course {Id = (int)CourseId.Math, Name = "Math", Credits =  1},
                new Course {Id = (int)CourseId.Science, Name = "Science", Credits =  1},
                new Course {Id = (int)CourseId.Literature, Name = "Literature", Credits =  1},
                new Course {Id = (int)CourseId.Physichal, Name = "Physichal Education", Credits =  1},
            };

            Diplomas = new List<IDiploma>
            {
                new Diploma
                {
                    Id = (int)DiplomaId.Total4CreditsDiploma,
                    Credits = 4,
                    Requirements = new List<IRequirement>
                    {
                        new Requirement
                            {Id = 100, Name = "Math", MinimumMark = 50, Course = GetCourse(CourseId.Math), Credits = 1},
                        new Requirement
                            {Id = 102, Name = "Science", MinimumMark = 50, Course = GetCourse(CourseId.Science), Credits = 1},
                        new Requirement
                            {Id = 103, Name = "Literature", MinimumMark = 50, Course = GetCourse(CourseId.Literature), Credits = 1},
                        new Requirement
                            {Id = 104, Name = "Physichal Education", MinimumMark = 50, Course = GetCourse(CourseId.Physichal), Credits = 1}
                    }
                },
                new Diploma
                {
                    Id = (int)DiplomaId.Total8CreditsDiploma,
                    Credits = 8,
                    Requirements = new List<IRequirement>
                    {
                        new Requirement
                            {Id = 100, Name = "Math", MinimumMark = 50, Course = GetCourse(CourseId.Math), Credits = 2},
                        new Requirement
                            {Id = 102, Name = "Science", MinimumMark = 50, Course = GetCourse(CourseId.Science), Credits = 2},
                        new Requirement
                            {Id = 103, Name = "Literature", MinimumMark = 50, Course = GetCourse(CourseId.Literature), Credits = 2},
                        new Requirement
                            {Id = 104, Name = "Physichal Education", MinimumMark = 50, Course = GetCourse(CourseId.Physichal), Credits = 2}
                    }
                }
            };

            Students = new List<IStudent>
            {
                new Student
                {
                    Id = (int)StudentId.SumaCumLaudeStudent, // Suma Cum Laude Student
                    Courses = new List<IStudentCourse>
                    {
                        new StudentCourse {Course = GetCourse(CourseId.Math), Mark = 95},
                        new StudentCourse {Course = GetCourse(CourseId.Science), Mark = 95},
                        new StudentCourse {Course = GetCourse(CourseId.Literature), Mark = 95},
                        new StudentCourse {Course = GetCourse(CourseId.Physichal), Mark = 95}
                    }
                },
                new Student
                {
                    Id = (int)StudentId.MagnaCumLaudeStudent, // Magna Cum Laude Student
                    Courses = new List<IStudentCourse>
                    {
                        new StudentCourse {Course = GetCourse(CourseId.Math), Mark = 80},
                        new StudentCourse {Course = GetCourse(CourseId.Science), Mark = 80},
                        new StudentCourse {Course = GetCourse(CourseId.Literature), Mark = 80},
                        new StudentCourse {Course = GetCourse(CourseId.Physichal), Mark = 80}
                    }
                },
                new Student
                {
                    Id = (int)StudentId.AverageStudent, // Average Student
                    Courses = new List<IStudentCourse>
                    {
                        new StudentCourse {Course = GetCourse(CourseId.Math), Mark = 50},
                        new StudentCourse {Course = GetCourse(CourseId.Science), Mark = 50},
                        new StudentCourse {Course = GetCourse(CourseId.Literature), Mark = 50},
                        new StudentCourse {Course = GetCourse(CourseId.Physichal), Mark = 50}
                    }
                },
                new Student
                {
                    Id = (int)StudentId.RemedialStudent, // Remedial Student
                    Courses = new List<IStudentCourse>
                    {
                        new StudentCourse {Course = GetCourse(CourseId.Math), Mark = 40},
                        new StudentCourse {Course = GetCourse(CourseId.Science), Mark = 40},
                        new StudentCourse {Course = GetCourse(CourseId.Literature), Mark = 40},
                        new StudentCourse {Course = GetCourse(CourseId.Physichal), Mark = 40}
                    }
                },
                new Student
                {
                    Id = (int)StudentId.MissingOneCourseStudent, // Missing One Course
                    Courses = new List<IStudentCourse>
                    {
                        new StudentCourse {Course = GetCourse(CourseId.Math), Mark = 80},
                        new StudentCourse {Course = GetCourse(CourseId.Science), Mark = 80},
                        new StudentCourse {Course = GetCourse(CourseId.Physichal), Mark = 80}
                    }
                },
                new Student
                {
                    Id = (int)StudentId.ReTakingOneCourseStudent, // Re-Taking One Course
                    Courses = new List<IStudentCourse>
                    {
                        new StudentCourse {Course = GetCourse(CourseId.Math), Mark = 80},
                        new StudentCourse {Course = GetCourse(CourseId.Science), Mark = 80},
                        new StudentCourse {Course = GetCourse(CourseId.Literature), Mark = 40},
                        new StudentCourse {Course = GetCourse(CourseId.Literature), Mark = 80},
                        new StudentCourse {Course = GetCourse(CourseId.Physichal), Mark = 80}
                    }
                }
            };
        }

        private ICourse GetCourse(CourseId id) => Courses.Find(p => p.Id == (int)id);
    }
}