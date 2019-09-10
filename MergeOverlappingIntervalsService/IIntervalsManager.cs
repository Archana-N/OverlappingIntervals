

using System.Collections.Generic;

namespace OverlappingIntervalsService
{
    public interface IIntervalsManager
    {
        Stack<Interval> GetFinalIntervals(IList<Interval> intervalList);

        void PrintFinalIntervals(Stack<Interval> intervalStack);
    }
}
