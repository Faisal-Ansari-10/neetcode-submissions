public class Solution {
    public int NumDecodings(string s) {
        int n = s.Length;
        int[] dp = new int[n + 1];
        dp[n] = 1;

        for (int i = n - 1; i >= 0; i--) {
            if (s[i] == '0') {
                dp[i] = 0;
            } else {
                dp[i] = dp[i + 1];

                if (i + 1 < n && (s[i] == '1' || (s[i] == '2' && s[i + 1] <= '6')))
                    dp[i] += dp[i + 2];
            }
        }
        return dp[0];
    }
}
