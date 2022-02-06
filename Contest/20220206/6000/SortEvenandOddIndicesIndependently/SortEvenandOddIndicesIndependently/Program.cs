using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortEvenandOddIndicesIndependently
{
    public class Solution
    {
        public int[] SortEvenOdd(int[] nums)
        {
            List<int> oddArray = new List<int>();
            List<int> evenArray = new List<int>();
            int tempVal = 0;

            for (int i=0; i < nums.Length;i++)
            {
                if (i % 2 != 0)
                    oddArray.Add(nums[i]);
                else
                    evenArray.Add(nums[i]);
            }

            //降序排列奇数索引数列
            for (int i=0; i < oddArray.Count;i++)
            {
                for (int j=0;j< oddArray.Count - i-1; j++)
                {
                    if (oddArray[j] < oddArray[j + 1])
                    {
                        tempVal = oddArray[j];
                        oddArray[j] = oddArray[j + 1];
                        oddArray[j + 1] = tempVal;
                    }
                }
            }

            for (int i=0;i< oddArray.Count; i++)
            {
                nums[2 * i + 1] = oddArray[i];
            }

            //升序排列偶数索引数列
            for (int i = 0; i < evenArray.Count; i++)
            {
                for (int j = 0; j < evenArray.Count - i-1; j++)
                {
                    if (evenArray[j] > evenArray[j + 1])
                    {
                        tempVal = evenArray[j];
                        evenArray[j] = evenArray[j + 1];
                        evenArray[j + 1] = tempVal;
                    }
                }
            }

            for (int i = 0; i < evenArray.Count; i++)
            {
                nums[2 * i] = evenArray[i];
            }

            return nums;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] retval= solution.SortEvenOdd(new int[4] { 4, 1, 2, 3 });

            foreach (int ret in retval)
                Console.Write(ret.ToString() + ",");

            Console.ReadLine();
        }
    }
}
