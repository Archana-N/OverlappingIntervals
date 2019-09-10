
namespace OverlappingIntervalsService
{
    public class Interval
    {
        internal int Start { get; set; }
        internal int End { get; set; }

        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }
    }    
}
