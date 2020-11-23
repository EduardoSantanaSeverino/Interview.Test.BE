using System.Collections.Generic;

namespace GraduationTracker.Domain.Entities
{
    public class Requirement : IRequirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int Credits { get; set; }
        public ICourse Course { get; set; }
    }
}
