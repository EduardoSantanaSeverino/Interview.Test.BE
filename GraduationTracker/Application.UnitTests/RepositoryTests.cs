using System.Linq;
using GraduationTracker.Application.UnitTests.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GraduationTracker.Application.UnitTests
{
    [TestClass]
    public class RepositoryTests : BaseTests
    {
        [DataRow(DiplomaId.Total4CreditsDiploma, 100, "Math", 1)] 
        [DataRow(DiplomaId.Total4CreditsDiploma, 102, "Science", 1)] 
        [DataRow(DiplomaId.Total4CreditsDiploma, 103, "Literature", 1)] 
        [DataRow(DiplomaId.Total4CreditsDiploma, 104, "Physichal Education", 1)]
        [DataTestMethod]
        public void TestRequirementExistForGivenDiploma(DiplomaId diplomaId, int expectedId, string expectedName, int expectedCredits)
        {
            var diploma = _diplomaRepository.Get((int)diplomaId);

            var requirement = diploma
                .Requirements
                .FirstOrDefault(p =>
                    p.Id == expectedId && 
                    p.Name == expectedName && 
                    p.Credits == expectedCredits);

            Assert.IsNotNull(requirement);
        }
        
        [DataRow(DiplomaId.Total4CreditsDiploma, CourseId.Math, "Math")] 
        [DataRow(DiplomaId.Total4CreditsDiploma, CourseId.Science, "Science")] 
        [DataRow(DiplomaId.Total4CreditsDiploma, CourseId.Literature, "Literature")] 
        [DataRow(DiplomaId.Total4CreditsDiploma, CourseId.Physichal, "Physichal Education")] 
        [DataTestMethod]
        public void TestCourseExistForGivenDiploma(DiplomaId diplomaId, CourseId expectedId, string expectedName)
        {
            var diploma = _diplomaRepository.Get((int)diplomaId);

            var requirement = diploma
                .Requirements
                .FirstOrDefault(p =>
                    p.Course.Id == (int)expectedId && 
                    p.Course.Name == expectedName);

            Assert.IsNotNull(requirement);
        }
        
        [DataRow(DiplomaId.Total4CreditsDiploma)]
        [DataRow(DiplomaId.Total8CreditsDiploma)] 
        [DataTestMethod]
        public void TestFindDiplomaRepositoryMethod(DiplomaId diplomaId)
        {
            var diplomaByGet = _diplomaRepository.Get((int)diplomaId);
            var diplomaByFind = _diplomaRepository.Find(p => p.Id == (int)diplomaId).FirstOrDefault();

            Assert.AreEqual(diplomaByGet.Id , diplomaByFind.Id);
            Assert.AreEqual(diplomaByGet.Credits , diplomaByFind.Credits);
        }
        
        [DataRow(StudentId.SumaCumLaudeStudent)]
        [DataRow(StudentId.MagnaCumLaudeStudent)]
        [DataRow(StudentId.AverageStudent)]
        [DataRow(StudentId.RemedialStudent)]
        [DataRow(StudentId.MissingOneCourseStudent)]
        [DataRow(StudentId.ReTakingOneCourseStudent)]
        [DataTestMethod]
        public void TestFindStudentRepositoryMethod(StudentId studentId)
        {
            var studentByGet = _studentRepository.Get((int)studentId);
            var studentByFind = _studentRepository.Find(p => p.Id == (int)studentId).FirstOrDefault();

            Assert.AreEqual(studentByGet.Id , studentByFind.Id);
            Assert.AreEqual(studentByGet.Courses.Count , studentByFind.Courses.Count);
        }
    }
}