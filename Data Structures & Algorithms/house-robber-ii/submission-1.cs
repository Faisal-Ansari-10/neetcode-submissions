public class Solution {
    public int Rob(int[] nums) {
        int n = nums.Length;
        if(n == 0) return 0;
        if(n == 1) return nums[0];
        
        int[] dp1 = new int[n + 1];
        int[] dp2 = new int[n + 2];

        for (int i = n - 2; i >= 0; i--) {
            dp1[i] = Math.Max(dp1[i + 1], nums[i] + dp1[i + 2]);
        }

        for (int i = n - 1; i > 0; i--) {
            dp2[i] = Math.Max(dp2[i + 1], nums[i] + dp2[i + 2]);
        }

        return Math.Max(dp1[0], dp2[1]);
    }
}
