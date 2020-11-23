using GraduationTracker.Domain.Enums;

namespace GraduationTracker.Domain.Rules
{
    public class StadingRules : IStadingRules
    {
        public STANDING GetStandingByAverage(int average)
        {
            if (average < 50) return STANDING.Remedial;
            if (average < 80) return STANDING.Average;
            if (average < 95) return STANDING.MagnaCumLaude;
            return STANDING.SumaCumLaude;
        }

        public STANDING DefaultStanding() => STANDING.None;
    }
}