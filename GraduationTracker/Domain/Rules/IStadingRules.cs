using GraduationTracker.Domain.Enums;

namespace GraduationTracker.Domain.Rules
{
    public interface IStadingRules
    {
        STANDING GetStandingByAverage(int average);
        STANDING DefaultStanding();
    }
}