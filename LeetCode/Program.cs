using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 136 Single Number
            /*var numbers = new int[] {1, 2, 2, 3, 3, 4, 4, 5, 5};

            SingleNumber(numbers);
            */
            #endregion

            #region 191 Number of 1 Bits
            //Console.WriteLine("191: " + HammingWeight(00000000000000000000000000001011));
            //Console.WriteLine("191: " + HammingWeight(0x00000000000000000000000000000010));
            #endregion

            Console.WriteLine("");
            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }

        #region 136
        /*
         * Given an array of integers, every element appears twice except for one. Find that single one.
         * 
         * Note: Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?
         */
        static public int SingleNumber(int[] A)
        {
            int value = 0;
            for (int i = 0; i < A.Length; i++)
            {
                value = value ^ A[i]; //^ is XOR, see https://msdn.microsoft.com/en-us/library/zkacc7k1.aspx
            }
            return value;

            //use following if numbers do not appear exactly twice or if you are looking for more than one number with only 1 occurrence
            var numberCount = new Dictionary<int, int>();

            foreach (int number in A)
            {
                if (!numberCount.Remove(number))
                {
                    numberCount.Add(number, 1);
                }
            }

            var min = numberCount.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

            return min;
        }
        #endregion

        #region 191
        /* 
         * Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).
         * 
         * For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3.
         */
        static public int HammingWeight(uint n)
        {
            //from http://stackoverflow.com/a/109915/1233435
            int count = 0;
            while (n > 0) {           // until all bits are zero
                if ((n & 0x01) == 1)     // check lower bit
                    count++;
                n = n>>1;              // shift right bits, removing lower bit - see https://en.wikipedia.org/wiki/Bitwise_operation#Logical_shift
            }
            return count;

            //lazy solution - convert to string
            String strn = n.ToString();

            int count2 = 0;
            foreach (var c in strn)
            {
                if (c.Equals('1'))
                {
                    count2++;
                }
            }

            return count2;
        }
        #endregion
    }
}
