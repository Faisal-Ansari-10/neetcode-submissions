public class Solution {
    public string LongestPalindrome(string s) {
        (int start, int length) result = (0, 0);

        for (int i = 0; i < s.Length; i++) {
            int l = i, r = i;
            while (l >= 0 && r < s.Length && s[l] == s[r]) {
                if (r - l + 1 > result.length) {
                    result.length = r - l + 1;
                    result.start = l;
                }
                l--;
                r++;
            }

            l = i - 1;
            r = i;
            while (l >= 0 && r < s.Length && s[l] == s[r]) {
                if (r - l + 1 > result.length) {
                    result.length = r - l + 1;
                    result.start = l;
                }
                l--;
                r++;
            }
        }

        return s.Substring(result.start, result.length);
    }
}
