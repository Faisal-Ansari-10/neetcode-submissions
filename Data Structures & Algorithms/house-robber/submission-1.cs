public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        int[] dp = new int[n + 2];

        for (int i = n - 1; i >= 0; i--) {
            dp[i] = Math.Max(dp[i + 1], dp[i + 2] + nums[i]);
        }

        return dp[0];
    }

    private int Rob(int[] nums, int ind) {
        if (ind >= nums.Length)
            return 0;

        return Math.Max(Rob(nums, ind + 1), nums[ind] + Rob(nums, ind + 2));
    }
}
