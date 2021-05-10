using System;


namespace Sum_of_differences_between_products_and_LCMs
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = SumDifferencesBetweenProductsAndLCMs(new int[][] { new int[] { 15, 18 }, new int[] { 4, 5 }, new int[] { 12, 60 } });
            int b = SumDifferencesBetweenProductsAndLCMs(new int[][] { new int[] { 1, 1 }, new int[] { 0, 0 }, new int[] { 13, 91 } });
            int c = SumDifferencesBetweenProductsAndLCMs(new int[][] { new int[] { 15, 7 }, new int[] { 4, 5 }, new int[] { 19, 60 } });
            int d = SumDifferencesBetweenProductsAndLCMs(new int[][] { new int[] { 20, 50 }, new int[] { 10, 10 }, new int[] { 50, 20 } });
            int e = SumDifferencesBetweenProductsAndLCMs(new int[][] { });

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
        }
        public static int SumDifferencesBetweenProductsAndLCMs(int[][] pairs)
        {

            int[] prod = ProductOfPair(pairs);

            int[] lcm = LcmOfPairs(pairs);

            int sub = 0;
            int sum = 0;
            for (int i = 0; i < pairs.GetLength(0); i++)
            {
                sub = prod[i] - lcm[i];
                sum += sub;
            }
            return sum;
        }

        public static int[] ProductOfPair(int[][] pairs)
        {
            int[] prod = new int[pairs.GetLength(0)];


            for (int i = 0; i < pairs.GetLength(0); i++)
            {

                prod[i] = pairs[i][0] * pairs[i][1];
            }
            return prod;
        }

        public static int[] LcmOfPairs(int[][] pairs)
        {
            int[] lcm = new int[pairs.GetLength(0)];

            for (int i = 0; i < pairs.GetLength(0); i++)
            {
                int n1 = pairs[i][0];
                int n2 = pairs[i][1];
                int ans = Lcm(n1, n2);
                lcm[i] = ans;
            }
            return lcm;
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
