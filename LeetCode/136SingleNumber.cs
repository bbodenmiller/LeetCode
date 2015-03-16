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
            var numbers = new int[] {1, 2, 2, 3, 3, 4, 4, 5, 5};

            SingleNumber(numbers);

            Console.ReadLine();
        }

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

            foreach(int number in A){
                if (!numberCount.Remove(number))
                {
                    numberCount.Add(number, 1);
                }
            }

            var min = numberCount.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

            return min;
        }
    }
}
