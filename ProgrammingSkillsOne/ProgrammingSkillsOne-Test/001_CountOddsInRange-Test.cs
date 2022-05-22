using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProgrammingSkillsOne;
using System;


namespace ProgrammingSkillsOne_Test
{

    [TestClass]
    public class _001_CountOddsInRange_Test
    {
        [TestMethod]
        public void CountOdds()
        {
            var solution = new _001_CountOddsInRange();
            int low = 0;
            int high = 10;

            int expected = 5;
            int actual = solution.CountOddsInRange(low, high);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountOddsWrong()
        {
            var solution = new _001_CountOddsInRange();
            int low = 3;
            int high = 7;

            int expected = 3;
            int actual = solution.CountOddsInRange(low, high);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "low can not be higher than high.")]
        public void InvalidRange()
        {
            var solution = new _001_CountOddsInRange();
            int low = 7;
            int high = 3;

            int actual = solution.CountOddsInRange(low, high);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void SingleNumberOdd()
        {
            var solution = new _001_CountOddsInRange();
            int low = 3;
            int high = 3;

            int expected = 1;
            int actual = solution.CountOddsInRange(low, high);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SingleNumberEven()
        {
            var solution = new _001_CountOddsInRange();
            int low = 2;
            int high = 2;

            int expected = 0;
            int actual = solution.CountOddsInRange(low, high);

            Assert.AreEqual(expected, actual);
        }
    }
}
