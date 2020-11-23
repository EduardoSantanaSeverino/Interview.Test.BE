using System;
using GraduationTracker.Application.UnitTests.Enums;
using GraduationTracker.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Application.UnitTests
{
    [TestClass]
    public class GraduationTrackerTests : BaseTests
    {
        [DataRow(STANDING.SumaCumLaude, DiplomaId.Total4CreditsDiploma, StudentId.SumaCumLaudeStudent)]
        [DataRow(STANDING.MagnaCumLaude, DiplomaId.Total4CreditsDiploma, StudentId.MagnaCumLaudeStudent)]
        [DataRow(STANDING.Average, DiplomaId.Total4CreditsDiploma, StudentId.AverageStudent)]
        [DataRow(STANDING.SumaCumLaude, DiplomaId.Total8CreditsDiploma, StudentId.SumaCumLaudeStudent)]
        [DataRow(STANDING.MagnaCumLaude, DiplomaId.Total8CreditsDiploma, StudentId.MagnaCumLaudeStudent)]
        [DataRow(STANDING.Average, DiplomaId.Total8CreditsDiploma, StudentId.AverageStudent)]
        [DataRow(STANDING.Average, DiplomaId.Total8CreditsDiploma, StudentId.ReTakingOneCourseStudent)]
        [DataTestMethod]
        public void TestStudentHasGraduated(STANDING expected, DiplomaId diplomaId, StudentId studentId)
        {
            var expectedValue = new Tuple<bool, STANDING>(true, expected);
            var diploma = _diplomaRepository.Get((int) diplomaId);
            var student = _studentRepository.Get((int) studentId);
            var eval = _graduationTracker.HasGraduated(diploma, student);
            Assert.AreEqual(expectedValue, eval);
        }
        
        [DataRow(STANDING.Remedial, DiplomaId.Total4CreditsDiploma, StudentId.RemedialStudent)]
        [DataRow(STANDING.Remedial, DiplomaId.Total8CreditsDiploma, StudentId.RemedialStudent)]
        [DataRow(STANDING.MagnaCumLaude, DiplomaId.Total4CreditsDiploma, StudentId.MissingOneCourseStudent)]
        [DataRow(STANDING.MagnaCumLaude, DiplomaId.Total8CreditsDiploma, StudentId.MissingOneCourseStudent)]
        [DataTestMethod]
        public void TestStudentHasNotGraduated(STANDING expected, DiplomaId diplomaId, StudentId studentId)
        {
            var expectedValue = new Tuple<bool, STANDING>(false, expected);
            var diploma = _diplomaRepository.Get((int) diplomaId);
            var student = _studentRepository.Get((int) studentId);
            var eval = _graduationTracker.HasGraduated(diploma, student);
            Assert.AreEqual(expectedValue, eval);
        }
        
        [DataRow(DiplomaId.Total4CreditsDiploma, StudentId.SumaCumLaudeStudent)]
        [DataRow(DiplomaId.Total4CreditsDiploma, StudentId.MagnaCumLaudeStudent)]
        [DataRow(DiplomaId.Total4CreditsDiploma, StudentId.AverageStudent)]
        [DataRow(DiplomaId.Total8CreditsDiploma, StudentId.SumaCumLaudeStudent)]
        [DataRow(DiplomaId.Total8CreditsDiploma, StudentId.MagnaCumLaudeStudent)]
        [DataRow(DiplomaId.Total8CreditsDiploma, StudentId.AverageStudent)]
        [DataRow(DiplomaId.Total8CreditsDiploma, StudentId.ReTakingOneCourseStudent)]
        [DataTestMethod]
        public void TestStudentHasPassedAllCoursesForGivenDiploma(DiplomaId diplomaId, StudentId studentId)
        {
            var diploma = _diplomaRepository.Get((int) diplomaId);
            var student = _studentRepository.Get((int) studentId);
            var eval = _graduationTracker.GetStudentIndicator(diploma, student);
            Assert.AreEqual(diploma.Requirements.Count, eval.ApprovedCourses);
        }
        
        [DataRow(DiplomaId.Total4CreditsDiploma, StudentId.MissingOneCourseStudent)]
        [DataTestMethod]
        public void TestStudentMissingOneClass(DiplomaId diplomaId, StudentId studentId)
        {
            var diploma = _diplomaRepository.Get((int) diplomaId);
            var student = _studentRepository.Get((int) studentId);
            var eval = _graduationTracker.GetStudentIndicator(diploma, student);
            Assert.AreEqual(false, eval.IsGraduated);
        }
    }
}