using System;

namespace Amazon_JobDefficulity
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] diff = new int[] { 3, 5, 4, 6, 2, 1 };
            
            Console.WriteLine(MinDifficulty(diff,3));
        }

        static int MinDifficulty(int[] jobDifficulty, int d)
        {
            int n = jobDifficulty.Length;
            if (n < d) return -1;
            var dp = new int[d, n];
            for (int day = 0; day < d; day++)
            {
                for (int j = day; j < n; j++)
                {
                    if (day == 0)
                        dp[0, j] = j == 0 ? jobDifficulty[0] : Math.Max(dp[0, j - 1], jobDifficulty[j]);
                    else
                    {
                        int max = jobDifficulty[j];
                        dp[day, j] = int.MaxValue;
                        for (int i = j - 1; i >= day - 1; i--)
                        {
                            max = Math.Max(max, jobDifficulty[i + 1]);
                            dp[day, j] = Math.Min(dp[day, j], dp[day - 1, i] + max);
                        }
                    }
                }
            }

            return dp[d - 1, n - 1];
        }
    }
}
