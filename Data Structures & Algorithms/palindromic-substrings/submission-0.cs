public class Solution {
    public int CountSubstrings(string s) {
        int count = 0;
        int n = s.Length;
        int l, r;

        for (int i = 0; i < n; i++) {
            l = i;
            r = i;

            while (l >= 0 && r < n && s[l] == s[r]) {
                count++;
                l--;
                r++;
            }

            l = i - 1;
            r = i;
            while (l >= 0 && r < n && s[l] == s[r]) {
                count++;
                l--;
                r++;
            }
        }

        return count;
    }
}
