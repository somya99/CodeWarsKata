using System;

namespace Two_Joggers
{
    class Program
    {
        static void Main(string[] args)
        {
            Tuple<int, int> ans1 = NbrOfLaps(5, 3);
            Tuple<int, int> ans2 = NbrOfLaps(4, 6);
            Tuple<int, int> ans3 = NbrOfLaps(5, 5);
            Console.WriteLine(ans1);
            Console.WriteLine(ans2);
            Console.WriteLine(ans3);
        }
        public static Tuple<int, int> NbrOfLaps(int x, int y)
        {
            int lcm = Lcm(x, y);
            int bob = lcm / x;
            int charles = lcm / y;
            return new Tuple<int, int>(bob, charles);
        }

        public static int Lcm(int n1, int n2)
        {
            int lcm = 0;
            if (n1 == 0 || n2 == 0)
            {
                return 0;
            }
            else
            {
                int on1 = n1;
                int on2 = n2;
                while (n1 % n2 != 0)
                {
                    int rem = n1 % n2;
                    n1 = n2;
                    n2 = rem;
                }
                int gcd = n2;

                lcm = (on1 * on2) / gcd;
            }
            return lcm;

        }
    }
}
