public class Solution {
    public string MinWindow(string s, string t) {
        int lenS = s.Length;
        int lenT = t.Length;
        (int start, int length) result = (int.MaxValue, int.MaxValue);

        if (lenT == 0 || lenS < lenT)
            return "";

        Dictionary<char, int> freqT = new();
        Dictionary<char, int> freqS = new();

        for (int i = 0; i < lenT; i++) {
            freqT[t[i]] = freqT.GetValueOrDefault(t[i], 0) + 1;
        }

        int have = 0, need = freqT.Count;
        int left = 0;
        for (int right = 0; right < lenS; right++) {
            char cRight = s[right];
            freqS[cRight] = freqS.GetValueOrDefault(cRight, 0) + 1;
            if (freqT.ContainsKey(cRight) && freqS[cRight] == freqT[cRight]) {
                have++;
            }

            while (have == need) {
                if ((right - left + 1) < result.length) {
                    result = (left, right - left + 1);
                }
                char c = s[left++];
                freqS[c]--;
                if (freqT.ContainsKey(c) && freqS[c] < freqT[c]) {
                    have--;
                }
            }
        }

        return result.length == int.MaxValue
                ? ""
                : s.Substring(result.start, result.length);
    }
}