﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Scratchpad
{
    [TestFixture]
    class Tests
    {
        private int[] TestData1 => new int[] { 2, 10, 13, 14, 22, 44, 87, 115, 155, 186 };
        [Test]
        public void TestMedian()
        {

            FraudulentActivity.SpecializedQueue queue = BuildQueue(TestData1, 10);

            double expected = GetMedian(TestData1);

            double actual = queue.GetMedian();

            Assert.AreEqual(expected, actual);
        }

        private double GetMedian(int[] data)
        {
            int middle = data.Length / 2;
            bool isEven = data.Length % 2 == 0;
            Array.Sort(data);

            if (isEven)
                return (data[middle] + (data[middle - 1])) / 2.0;
            else
                return data[middle];
        }

        private FraudulentActivity.SpecializedQueue BuildQueue(int[] data, int windowSize)
        {
            var queue = new FraudulentActivity.SpecializedQueue(windowSize, 200);

            foreach (var x in data)
            {
                queue.Enqueue(x);
            }

            return queue;
        }
    }
}
