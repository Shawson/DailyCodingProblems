//This problem was recently asked by Google.
//Given a list of numbers and a number [k]. Return whether any two
//numbers from the list add up to k
//For example given [10, 15, 3, 7] and k of 17, return true since 10+7 is 17.
//Bonus- can you do it in one pass?

using System;
namespace ArrayWithK
{
    class Program
    {
        public static bool combinationK(int[] arrValues, int k)
        {
            var totalLength = arrValues.Length - 1;

            for (var i = 0; i < totalLength; i++)
            {
                if (i == totalLength - i)
                    continue;

                if (arrValues[i] + arrValues[totalLength - i] == k)
                    return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            int[][] testSet = new int[][]
            {
              new int[]{10,15,3,7},
              new int[]{20,6,9,5},
              new int[]{13,14,2,18},
              new int[]{10,15,5,3,7}
            };
            int[] kSet = new int[4]
            {17, 25, 32, 10};

            for (int testIndex = 0; testIndex < kSet.Length; testIndex++)
            {
                Console.WriteLine(combinationK(testSet[testIndex], kSet[testIndex]));
            }
        }
    }
}
