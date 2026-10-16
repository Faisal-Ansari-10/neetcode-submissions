public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int n = cost.Length;
        int[] dp = new int[n + 1];
        dp[n - 1] = cost[n - 1];

        for (int i = n - 2; i >= 0; i--) {
            dp[i] = Math.Min(dp[i + 1], dp[i + 2]) + cost[i];
        }

        return Math.Min(dp[0], dp[1]);
    }
}
