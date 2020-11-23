using System.Collections.Generic;

namespace GraduationTracker.Domain.Entities
{
    public class Diploma : IDiploma
    {
        public int Id { get; set; }
        public int Credits { get; set; }
        public List<IRequirement> Requirements { get; set; }
    }
}
