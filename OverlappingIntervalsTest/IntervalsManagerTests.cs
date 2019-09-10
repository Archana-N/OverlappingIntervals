using System;
using System.Collections.Generic;
using OverlappingIntervalsService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OverlappingIntervalsTest
{
    [TestClass]
    public class IntervalsManagerTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestThat_IntervalsList_Is_Empty()
        {
            IList<Interval> intervalList = new List<Interval>();

            IIntervalsManager intervalsManager = new IntervalsManager();
            var intervalStack = intervalsManager.GetFinalIntervals(intervalList);
        }


        [TestMethod]
        public void TestThat_Intervals_Are_Merged()
        {
            IList<Interval> intervalList = new List<Interval>();
            intervalList.Add(new Interval(25, 30));
            intervalList.Add(new Interval(2, 19));
            intervalList.Add(new Interval(14, 23));
            intervalList.Add(new Interval(4, 8));


            IIntervalsManager intervalsManager = new IntervalsManager();
            var intervalStack = intervalsManager.GetFinalIntervals(intervalList);

            Assert.AreEqual(2, intervalStack.Count, "The Intervals list is not appropriate");
        }
    }
}
