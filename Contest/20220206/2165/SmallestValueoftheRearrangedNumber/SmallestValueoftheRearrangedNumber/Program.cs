using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestValueoftheRearrangedNumber
{
    class Program
    {
        public class Solution
        {
            public long SmallestNumber(long num)
            {
                List<long> separateNums = new List<long>();
                int zeroNums = 0;
                long tempVal = 0, ret = 0, numTemp = 0;

                numTemp = Math.Abs(num);

                while (numTemp != 0)
                {
                    if (numTemp % 10 == 0)
                        zeroNums++;
                    else
                        separateNums.Add(Convert.ToInt64(numTemp % 10));

                    numTemp = numTemp / 10;
                }

                for (int i = 0; i < separateNums.Count; i++)
                {
                    for (int j = 0; j < separateNums.Count - i - 1; j++)
                    {
                        if (num > 0)
                        {
                            if (separateNums[j] > separateNums[j + 1])
                            {
                                tempVal = separateNums[j];
                                separateNums[j] = separateNums[j + 1];
                                separateNums[j + 1] = tempVal;
                            }
                        }
                        else
                        {
                            if (separateNums[j] < separateNums[j + 1])
                            {
                                tempVal = separateNums[j];
                                separateNums[j] = separateNums[j + 1];
                                separateNums[j + 1] = tempVal;
                            }
                        }
                    }
                }

                for (int i = 0; i < separateNums.Count; i++)
                {
                    if (num > 0 && i == 1)
                    {
                        while(zeroNums!=0)
                        {
                            ret = ret * 10;
                            zeroNums--;
                        }
                    }

                    ret = ret * 10 + separateNums[i];

                    if (num < 0 && i == separateNums.Count - 1)
                    {
                        while (zeroNums != 0)
                        {
                            ret = ret * 10;
                            zeroNums--;
                        }
                    }
                }

                while (zeroNums != 0)
                {
                    ret = ret * 10;
                    zeroNums--;
                }

                if (num < 0)
                    ret = -ret;

                return ret;
            }
        }

        static void Main(string[] args)
        {
            Solution solution = new Solution();
            long retVal = solution.SmallestNumber(-7605);

            Console.Write(retVal.ToString());

            Console.ReadLine();
        }
    }
}
