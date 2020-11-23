namespace GraduationTracker.Domain.Entities
{
    public class StudentCourse : IStudentCourse
    {
        public ICourse Course { get; set; }
        public int Mark { get; set; }
        
    }
}