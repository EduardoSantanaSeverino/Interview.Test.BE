namespace GraduationTracker.Domain.Entities
{
    public interface IStudentCourse
    {
        ICourse Course { get; set; }
        int Mark { get; set; }
    }
}