using System.Collections.Generic;

namespace GraduationTracker.Domain.Entities
{
    public interface IDiploma
    {
        int Id { get; set; }
        int Credits { get; set; }
        List<IRequirement> Requirements { get; set; }
    }
}