namespace GraduationTracker.Domain.Entities
{
    public interface IRequirement
    {
        int Id { get; set; }
        string Name { get; set; }
        int MinimumMark { get; set; }
        int Credits { get; set; }
        ICourse Course { get; set; }
    }
}