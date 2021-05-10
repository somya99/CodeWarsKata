using System;
using System.Collections.Generic;
namespace Sum_consecutives
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> i1 = new List<int> { 1, 4, 4, 4, 0, 4, 3, 3, 1 };
            Console.WriteLine("Input: {1,4,4,4,0,4,3,3,1}");
            List<int> o1 = SumConsecutives(i1);
            Console.WriteLine("Output: ");
            for (int i = 0; i < o1.Count; i++)
            {
                Console.WriteLine(o1[i]);

            }

            List<int> i2 = new List<int> { -5, -5, 7, 7, 12, 0 };           
            Console.WriteLine("Input: {-5,-5,7,7,12,0}");
            List<int> o2 = SumConsecutives(i2);
            Console.WriteLine("Output: ");
            for (int i = 0; i < o2.Count; i++)
            {
                Console.WriteLine(o2[i]);

            }

        }
        public static List<int> SumConsecutives(List<int> s)
        {
            List<int> ans = new List<int>();
            int sum = 0;
            int i = 0;
            int count = 0;
            while (i < s.Count - 1)
            {
                if (s[i] != s[i + 1])
                {
                    ans.Add(s[i]);
                    i++;
                    count++;
                }
                else
                {
                    int temp = s[i];
                    sum = s[i];
                    while (temp == s[i + 1])
                    {
                        sum += temp;
                        i++;
                        count++;
                    }
                    ans.Add(sum);
                    i++;
                    count++;
                }
            }
            if (count < s.Count)
            {
                ans.Add(s[s.Count - 1]);
            }
            return ans;
        }
    }
}
