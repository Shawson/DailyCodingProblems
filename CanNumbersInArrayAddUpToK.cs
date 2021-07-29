//This problem was recently asked by Google.
//Given a list of numbers and a number [k]. Return whether any two
//numbers from the list add up to k
//For example given [10, 15, 3, 7] and k of 17, return true since 10+7 is 17.
//Bonus- can you do it in one pass?

using System;
using System.Collections;

namespace ArrayWithK
{
    class Program
    {
	public static bool rememberMe(int[] arrValues, int k)
        {
			var register = new bool[k + 1];
			
			var totalLength = arrValues.Length - 1;
			
			for(var i = 0; i <= totalLength; i++) {
				if (arrValues[i] > k)
					continue;
					
				if (arrValues[i] <= k)
					register[arrValues[i]]=true;
					
				if (register[k - arrValues[i]] == true)
					return true;
			}
			
			return false;
        }
	    
        public static bool doubleLoop(int[] arrValues, int k)
        {
			var totalLength = arrValues.Length - 1;
			
			for(var i = 0; i <= totalLength; i++) {
				for (var j = i +1; j <= totalLength; j++)
				{
					if (arrValues[i] + arrValues[j] == k)
						return true;
				}
			}
			
			return false;
        }
		
	public static bool thePincer(int[] arrValues, int k)
        {
			Array.Sort(arrValues);
			
			var min = 0;
			var max = arrValues.Length -1;
			
			while(min < max) {
				if (arrValues[min]+ arrValues[max] == k)
					return true;	
				else if (arrValues[min] + arrValues[max] > k)
					max --;
				else if (arrValues[min]+ arrValues[max] < k)
					min ++;
					
			}
			
			return false;
        }
			
        static void Main(string[] args)
        {
            var testCases = new List<(int[] values, int result, bool expectedOutcome)> {
				(new int[]{10,15,3,7}, 17, true),
				(new int[]{20,6,9,5}, 25, true),
				(new int[]{13,14,2,18}, 32, true),
				(new int[]{10,15,5,3,7}, 10, true),
				(new int[]{1,2,9,12}, 10, true),
				(new int[]{12,9,2,1}, 10, true),
				(new int[]{1,2,12,9}, 10, true),
				(new int[]{4,2,12,9}, 10, false),
				(new int[]{0,20,12,16}, 10, false),
			};

            foreach(var testCase in testCases)
	    {
                Console.WriteLine($"Test Result : {rememberMe(testCase.values, testCase.result) == testCase.expectedOutcome}");
            }
        }
    }
}
