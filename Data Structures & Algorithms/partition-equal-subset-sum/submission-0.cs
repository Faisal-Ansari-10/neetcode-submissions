
public class Solution {
    public bool CanPartition(int[] nums) {
        int sum = nums.Sum();
        if (sum % 2 != 0)
            return false;

        sum /= 2;

        bool[] dp = new bool[sum + 1];
        dp[0] = true;

        for (int i = 0; i < nums.Length; i++) {
            for (int j = sum; j >= nums[i]; j--) {
                dp[j] = dp[j] || dp[j - nums[i]];
            }
        }

        return dp[sum];
    }
}
