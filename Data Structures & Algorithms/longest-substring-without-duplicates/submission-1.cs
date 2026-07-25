public class Solution {
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char, int> map = new();
        int max = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++) {
            char c = s[right];

            if (map.ContainsKey(c)) {
                left = Math.Max(map[c] + 1, left);
            }

            map[c] = right;
            max = Math.Max(max, right - left + 1);
        }

        return max;
    }
}
