public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        int n1 = s1.Length;
        int n2 = s2.Length;

        if (n1 > n2)
            return false;

        int[] s1Freq = new int[26];
        int[] s2Freq = new int[26];

        for (int i = 0; i < n1; i++) {
            s1Freq[s1[i] - 'a']++;
        }

        int left = 0;

        for (int right = 0; right < n2; right++) {
            s2Freq[s2[right] - 'a']++;

            if (right - left + 1 > n1) {
                s2Freq[s2[left] - 'a']--;
                left++;
            }

            if (right - left + 1 == n1) {
                bool match = true;
                for (int i = 0; i < 26; i++) {
                    if (s1Freq[i] != s2Freq[i]) {
                        match = false;
                        break;
                    }
                }
                if (match)
                    return true;
            }
        }

        return false;
    }
}