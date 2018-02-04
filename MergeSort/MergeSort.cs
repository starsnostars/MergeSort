using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    public class MergeSort
    {
        public IEnumerable<T> Sort<T>(IList<T> list) where T : IComparable
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            var sorted = list;

            Divide(list, 0, sorted.Count() - 1);

            return sorted;
        }

        private void Divide<T>(IList<T> list, int left, int right) where T : IComparable
        {
            if (left < right)
            {
                int pivot = left + (right - left) / 2;
                Divide(list, left, pivot);
                Divide(list, pivot + 1, right);

                Merge(list, left, pivot, right);
            }
        }

        private void Merge<T>(IList<T> list, int left, int pivot, int right) where T : IComparable
        {
            int countLeft = pivot - left + 1;
            int countRight = right - pivot;

            var leftArr = new List<T>(countLeft);
            var rightArr = new List<T>(countRight);

            leftArr.AddRange(list.Skip(left).Take(countLeft));
            rightArr.AddRange(list.Skip(pivot + 1).Take(countRight));
            
            int idxLeft = 0, idxRight = 0;
            int idxList = left;
            while (idxLeft < countLeft && idxRight < countRight)
            {
                if (leftArr[idxLeft].CompareTo(rightArr[idxRight]) < 0)
                {
                    list[idxList] = leftArr[idxLeft];
                    idxLeft++;
                }
                else
                {
                    list[idxList] = rightArr[idxRight];
                    idxRight++;
                }

                idxList++;
            }
            
            // Copy remaining elements from both lists
            while (idxLeft < countLeft)
            {
                list[idxList] = leftArr[idxLeft];
                idxLeft++;
                idxList++;
            }

            while (idxRight < countRight)
            {
                list[idxList] = rightArr[idxRight];
                idxRight++;
                idxList++;
            }
        }
    }
}
