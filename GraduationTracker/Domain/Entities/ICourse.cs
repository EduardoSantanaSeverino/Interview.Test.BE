namespace GraduationTracker.Domain.Entities
{
    public interface ICourse
    {
        int Id { get; set; }
        string Name { get; set; }
        int Credits { get; set; }
    }
}