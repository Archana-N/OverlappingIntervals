using System;
using System.Collections.Generic;
using System.Linq;

namespace OverlappingIntervalsService
{
    public class IntervalsManager : IIntervalsManager
    {
        public Stack<Interval> GetFinalIntervals(IList<Interval> intervalList)
        {
            if (intervalList.Count <= 0)
                throw new ArgumentException("Input Intervals list cannot be empty");

            // Create an empty stack of intervals  
            Stack<Interval> intervalStack = new Stack<Interval>();

            intervalList = intervalList.OrderBy(interval => interval.Start).ToList();

            // push the first interval to stack  
            intervalStack.Push(intervalList[0]);

            // Start from the next interval and merge if necessary  
            for (int index = 1; index < intervalList.Count; index++)
            {
                // get interval from stack top  
                Interval topInterval = intervalStack.Peek();

                // if current interval is not overlapping with stack top, push it to the stack  
                if (topInterval.End < intervalList[index].Start)
                {
                    intervalStack.Push(intervalList[index]);
                }

                // Otherwise update the ending time of top if ending of current interval is more  
                else if (topInterval.End < intervalList[index].End)
                {
                    topInterval.End = intervalList[index].End;
                    intervalStack.Pop();
                    intervalStack.Push(topInterval);
                }
            }

            return intervalStack;
        }

        public void PrintFinalIntervals(Stack<Interval> intervalStack)
        {
            // Print contents of stack  
            Console.WriteLine("The final Intervals are: ");
            while (intervalStack.Any())
            {
                Interval currentInterval = intervalStack.Pop();
                Console.WriteLine("[" + currentInterval.Start + "," + currentInterval.End + "] ");
            }
        }
    }
}
