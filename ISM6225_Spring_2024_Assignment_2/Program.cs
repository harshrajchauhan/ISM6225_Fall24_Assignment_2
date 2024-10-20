using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                List<int> missing = new List<int>();
                HashSet<int> set = new HashSet<int>(nums); // Using a HashSet to store unique numbers in the array.
                
                // Iterate through the numbers from 1 to n, checking if each is present in the HashSet.
                for (int i = 1; i <= nums.Length; i++)
                {
                    if (!set.Contains(i)) // If the number is not found, it's missing.
                        missing.Add(i);
                }
                return missing; // Return the list of missing numbers.
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Order by even numbers first (nums % 2 == 0) and odd numbers later.
                return nums.OrderBy(x => x % 2).ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> map = new Dictionary<int, int>(); // Create a dictionary to store the index of each number.
                
                // Traverse the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i]; // Calculate the complement that, when added to nums[i], equals the target.
                    
                    // If the complement is in the dictionary, return its index and the current index.
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }
                    map[nums[i]] = i; // Otherwise, store the current number and its index in the dictionary.
                }
                return new int[0]; // Return an empty array if no solution is found.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums); // Sort the array to make it easier to calculate the largest product.
                int n = nums.Length;
                
                // The maximum product could be either the product of the three largest numbers
                // or the product of the two smallest numbers (which could be negative) and the largest number.
                return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3],
                                nums[0] * nums[1] * nums[n - 1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Use the built-in Convert.ToString method to convert a decimal number to binary.
                return Convert.ToString(decimalNumber, 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;

                // Perform binary search to find the minimum element.
                while (left < right)
                {
                    int mid = left + (right - left) / 2; // Calculate mid to avoid overflow.

                    // If the middle element is greater than the rightmost element, the minimum is to the right.
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid; // Otherwise, the minimum is to the left.
                    }
                }

                return nums[left]; // Return the minimum element.
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0) return false; // Negative numbers are not palindromes.
                
                int reversed = 0, original = x;

                // Reverse the number.
                while (x != 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit; // Add the current digit to the reversed number.
                    x /= 10; // Remove the last digit from x.
                }

                // Check if the original number is equal to the reversed number.
                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                if (n <= 1) return n; // Base cases: Fib(0) = 0 and Fib(1) = 1.

                int a = 0, b = 1;

                // Calculate Fibonacci numbers iteratively.
                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b; // Fib(n) = Fib(n-1) + Fib(n-2).
                    a = b;
                    b = temp;
                }

                return b; // Return the nth Fibonacci number.
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
