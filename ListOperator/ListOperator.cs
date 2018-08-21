using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOperator
{
    public class ListOperator<T>
    {
        private List<T> list;

        public ListOperator(List<T> list)
        {
            this.list = list;
        }

        public List<T> SubList(int beginIndex, int endIndex) => SubList(list, beginIndex, endIndex);
        public static List<T> SubList(List<T> originalList, int beginIndex, int endIndex, int step = 1)
        {
            if (originalList == null) return null;
            if (originalList.Count == 0) return new List<T>();
            if (beginIndex > endIndex || beginIndex < 0 || endIndex < 0 || beginIndex >= originalList.Count) throw new Exception("下标值传递错误");
            if(step <= 0) throw new Exception("step值应该为正整数");

            List<T> subList = new List<T>();
            endIndex = Math.Min(endIndex, originalList.Count - 1);

            for(; beginIndex <= endIndex; beginIndex += step)
            {
                subList.Add(originalList[beginIndex]);
            }

            return subList;
        }
        public bool ValueEqual(List<T> ls) => ValueEqual(list, ls);
        public static bool ValueEqual(List<T> firstList, List<T> secondList)
        {
            if (firstList == null && secondList != null || firstList != null && secondList == null) return false;
            if (firstList == null && secondList == null) throw new Exception("两个List全为null");
            if (firstList.Count != secondList.Count) return false;
            if (firstList.Count == 0 && secondList.Count == 0) return true;
            if (!(firstList[0] is IComparable)) throw new Exception(typeof(T).ToString() + "类型不是IComparable");

            for(int idx = 0; idx < firstList.Count; idx++)
            {
                IComparable firstValue = (IComparable)firstList[idx];
                IComparable secondValue = (IComparable)secondList[idx];
                if (firstValue.CompareTo(secondValue) != 0)
                    return false;
            }
            return true;
        }
    }
}
