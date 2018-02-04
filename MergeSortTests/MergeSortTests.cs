using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorter = MergeSort.MergeSort;

namespace MergeSortTests
{
    [TestFixture]
    public class MergeSortTests
    {
        [Test]
        public void Sort_ArrayIsNull_ThrowsArgumentNullException()
        {
            var sorter = new Sorter();

            Assert.Throws<ArgumentNullException>(() => sorter.Sort<int>(null));
        }

        [Test]
        public void Sort_ArrayHasNoElements_ReturnsTheArray()
        {
            var sorter = new Sorter();
            var arr = new int[] { };

            IEnumerable<int> actual = sorter.Sort(arr);

            Assert.AreEqual(actual, arr);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 42 }, new int[] { 42 })]
        [TestCase(new int[] { 2, 6, 5 }, new int[] { 2, 5, 6 })]
        [TestCase(new int[] { 38, 27, 43, 3, 9, 82, 10 }, new int[] { 3, 9, 10, 27, 38, 43, 82 })]
        public void Sort_Mainsuccess_SortsArrays(int[] array, int[] expected)
        {
            var sorter = new Sorter();

            IEnumerable<int> actual = sorter.Sort(array);

            Assert.AreEqual(expected, actual);
        }
    }
}
