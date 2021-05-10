using System;
using System.Collections.Generic;
namespace Delete_occurrences_of_element_more_than_n_times
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ans1 = DeleteNth(new int[] { 20, 37, 20, 21 }, 1);
            Console.WriteLine("Output: ");
            for(int i = 0; i < ans1.Length; i++)
            {
                Console.WriteLine(ans1[i]);
            }
            int[] ans2 = DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);
            Console.WriteLine("Output: ");
            for (int i = 0; i < ans2.Length; i++)
            {
                Console.WriteLine(ans2[i]);
            }

        }
        public static int[] DeleteNth(int[] arr, int x)
        {
            List<int> temp = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int count = getCount(arr, arr[i]);
                if (count > x)
                {
                    int n = count - x;
                    int j = arr.Length - 1;
                    while (n > 0 && j > 0)
                    {
                        if (arr[j] == arr[i])
                        {
                            arr[j] = -1;
                            n--;
                        }
                        j--;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != -1)
                {
                    temp.Add(arr[i]);
                }
            }
            return temp.ToArray();
        }

        public static int getCount(int[] arr, int num)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == num)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
