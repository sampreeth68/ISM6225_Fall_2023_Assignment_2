/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        /*
        FindMissingRanges function takes in a sorted integer array (nums), a lower bound (lower), and an upper bound (upper).
        It returns a list of lists representing the missing ranges within the inclusive range [lower, upper].

        The function works by iterating through the array "nums" and finding the missing ranges between "lower" and the first element of "nums," 
        and between the last element of "nums" and "upper."

        If the input array "nums" is empty, it simply adds the entire range [lower, upper] as a missing range.

        Time complexity: O(n), where n is the length of the "nums" array.
        Space complexity: O(1), as the output list "missingRanges" does not grow with the input size.
        */

        // Keep track of current number we are checking
        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)

        {

            try

            {

                // Initialize list to store missing ranges

                List<IList<int>> missingRanges = new List<IList<int>>();

                // keep track of Current number we are checking

                int current = lower;

                // Go through given nums array

                foreach (int num in nums)

                {

                    // check if gap between current and num is more than 1

                    if (num > current + 1)

                    {

                        // Calculate start and end of missing range

                        int start = current + 1;

                        int end = num - 1;

                        // Add missing range to list

                        missingRanges.Add(new List<int> { start, end });

                    }

                    // Update current number

                    current = num;

                }

                // Check for missing range after final number

                if (upper > current + 1)

                {

                    // Calculate for missing range after final number

                    int start = current + 1;

                    int end = upper;

                    // Add missing range

                    missingRanges.Add(new List<int> { start, end });

                }

                // Return list of missing ranges

                return missingRanges;

            }

            catch (Exception)

            {

                throw;

            }

        }

        /*

        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.

        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                Stack<char> st = new Stack<char>();

                foreach (char c in s)
                {
                    if (c == '(' || c == '[' || c == '{')
                    {
                        st.Push(c);
                    }
                    else
                    {
                        if (st.Count == 0)
                        {
                            return false; // Closing brackets Don't Match
                        }

                        char openBracket = st.Pop();

                        if (c == ')' && openBracket != '(')
                        {
                            return false; // Parentheses Don't Match
                        }
                        else if (c == ']' && openBracket != '[')
                        {
                            return false; // Square brackets Don't Match
                        }
                        else if (c == '}' && openBracket != '{')
                        {
                            return false; // Curly braces Don't Match
                        }
                    }
                }

                return st.Count == 0; // Check if any open brackets in st remain Unmatched
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
                return false; // If exception, Invalid Input
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Check if the input array is null or has fewer than 2 elements
                if (prices == null || prices.Length < 2)
                {
                    // return 0, If not enough days to make profits
                    return 0;
                }

                // Declare variables to track min Price and max Profit
                int min = prices[0];
                int max = 0;

                // Go through prices array, Update min and max values when needed
                for (int i = 1; i < prices.Length; i++)
                {
                    int current = prices[i];
                    max = Math.Max(max, current - min);
                    min = Math.Min(min, current);
                }

                // Return Max profit
                return max;
            }
            catch (Exception)
            {
                // Catch Exceptions and Throw again
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Create Dictionaries for storing Valid Strobogrammatic pairs
                Dictionary<char, char> strpair = new Dictionary<char, char>
            {
                {'0', '0'},
                {'1', '1'},
                {'6', '9'},
                {'8', '8'},
                {'9', '6'}
            };

                int left = 0;
                int right = s.Length - 1;

                while (left <= right)
                {
                    // Check if current characters form valid pair
                    if (!strpair.ContainsKey(s[left]) || strpair[s[left]] != s[right])
                    {
                        return false;
                    }

                    // Move left and right pointers inwards
                    left++;
                    right--;
                }

                return true;
            }
            // Catch any exceptions and throw again
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Create Dictionary for storing count occurences of each number
                Dictionary<int, int> countMap = new Dictionary<int, int>();
                int NiceP = 0;

                foreach (int no in nums)
                {
                    // If number already exists in dictionary, increment pairs counter
                    if (countMap.ContainsKey(no))
                    {
                        NiceP += countMap[no];
                        countMap[no]++;
                    }
                    else
                    {
                        // If there is new number then add it to dictionary with count 1
                        countMap[no] = 1;
                    }
                }
                // Return total pairs found
                return NiceP;
            }
            // Catch any exceptions and throw again
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Initialize variables to track top 3 numbers
                long fst = long.MinValue;
                long sec = long.MinValue;
                long thi = long.MinValue;

                foreach (int num in nums)
                {
                    // Update first if num is greater
                    if (num > fst)
                    {
                        thi = sec;
                        sec = fst;
                        fst = num;
                    }
                    // Update second if num is between first and second
                    else if (num < fst && num > sec)
                    {
                        thi = sec;
                        sec = num;
                    }
                    // Update third if num is between second and third
                    else if (num < sec && num > thi)
                    {
                        thi = num;
                    }
                }

                // Check if third highest value is found
                if (thi == long.MinValue)
                {
                    // If not, retuen first value
                    return (int)fst;
                }
                // Return third highest value
                return (int)thi;
            }
            // Catch any Exceptions and throw again
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Create list to store possible next moves
                List<string> psbst = new List<string>();

                // Loop through current state string
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // check if adjacent chars are '+'
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Make a copy of state as char array
                        char[] newState = currentState.ToCharArray();
                        newState[i] = '-';
                        newState[i + 1] = '-';
                        // add new state to list
                        psbst.Add(new string(newState));
                    }
                }

                // Return list of possible next moves
                return psbst;
            }
            // handle exception and throw again
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            try
            {
                // Create StringBuilder to generate the output string
                StringBuilder result = new StringBuilder();

                foreach (char c in s)
                {
                    // Check if character is not a vowel
                    if (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u')
                    {
                        // Append non-vowel char to result
                        result.Append(c);
                    }
                }
                // Return string without vowels
                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */

        // Function to convert nested integer list to string
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                // Add inner list to string
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add comma if not last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add closing square bracket for outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // add double quotes around each string
            }

            // Concatenate the strings in strArray delimited by commas and enclosed in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}