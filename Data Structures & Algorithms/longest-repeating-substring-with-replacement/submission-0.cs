public class Solution {
    public int CharacterReplacement(string s, int k) {
        int[] frequency = new int[26];
        int maxFrequency = 0, left = 0, result = 0;

        for (int right = 0; right < s.Length; right++) {
            char c = s[right];
            frequency[c - 'A']++;
            maxFrequency = Math.Max(maxFrequency, frequency[c - 'A']);

            if ((right - left + 1) - maxFrequency > k) {
                frequency[s[left] - 'A']--;
                left++;
            }

            result = Math.Max(right - left + 1, result);
        }

        return result;
    }
}
