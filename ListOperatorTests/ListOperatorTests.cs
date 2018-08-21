using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListOperator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOperator.Tests
{
    [TestClass()]
    public class ListOperatorTests
    {
        [TestMethod()]
        public void TestNormal()
        {
            List<int> ls1 = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            List<int> ls2 = ListOperator<int>.SubList(ls1, 3, 7);
            List<int> ls3 = new List<int>(new int[] { 4, 5, 6, 7, 8 });

            Assert.AreEqual(ListOperator<int>.ValueEqual(ls3, ls2), true);
        }

        [TestMethod()]
        public void TestLengthBiggerThanCount()
        {
            List<int> ls1 = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            List<int> ls2 = ListOperator<int>.SubList(ls1, 3, 11);
            List<int> ls3 = new List<int>(new int[] { 4, 5, 6, 7, 8, 9, 10 });

            Assert.AreEqual(ListOperator<int>.ValueEqual(ls3, ls2), true);
        }

        [TestMethod()]
        public void TestDiffLengthAreEqual()
        {
            List<int> ls1 = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            List<int> ls2 = new List<int>(new int[] { 1, 2, 3, 4, 5});

            bool expected = false;
            bool actual = ListOperator<int>.ValueEqual(ls1, ls2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestSingleNull()
        {
            List<int> ls1 = null;
            List<int> ls2 = new List<int>(new int[] { 1, 2, 3, 4, 5 });

            bool expected = false;
            bool actual = ListOperator<int>.ValueEqual(ls1, ls2);
            Assert.AreEqual(expected, actual);

            ls1 = new List<int>();
            ls2 = null;
            Assert.AreEqual(ListOperator<int>.ValueEqual(ls1, ls2), false);
        }

        [TestMethod()]
        public void TestDoubleEmpty()
        {
            List<int> ls1 = new List<int>();
            List<int> ls2 = new List<int>();

            bool expected = true;
            bool actual = ListOperator<int>.ValueEqual(ls1, ls2);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void TestDiffValueAreEqual()
        {
            List<int> ls1 = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            List<int> ls2 = new List<int>(new int[] { 1, 2, 3, 4, 5, 7 });

            bool expected = false;
            bool actual = ListOperator<int>.ValueEqual(ls1, ls2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestSameValueAreEqual()
        {
            List<int> ls1 = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            List<int> ls2 = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 });

            bool expected = true;
            bool actual = ListOperator<int>.ValueEqual(ls1, ls2);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TestDoubleSameValueAreEqual()
        {
            List<double> ls1 = new List<double>(new double[] { 1.00001, 2, 3, 4, 5, 6 });
            List<double> ls2 = new List<double>(new double[] { 1.00001, 2, 3, 4, 5, 6 });

            bool expected = true;
            bool actual = ListOperator<double>.ValueEqual(ls1, ls2);

            Assert.AreEqual(expected, actual);
        }
    }
}