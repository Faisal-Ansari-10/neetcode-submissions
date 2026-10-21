public class Solution {
    public int MaxProduct(int[] nums) {
        int curMax = nums[0];
        int curMin = nums[0];
        int best = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            int n = nums[i];

            int a = curMax * n;
            int b = curMin * n;

            curMax = Math.Max(n, Math.Max(a, b));
            curMin = Math.Min(n, Math.Min(a, b));

            best = Math.Max(best, curMax);
        }

        return best;
    }
}