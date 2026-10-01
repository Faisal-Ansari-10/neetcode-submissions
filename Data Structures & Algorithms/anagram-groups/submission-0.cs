public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, List<string>> map = [];

        foreach (var s in strs) {
            var key = GetKey(s);
            if (!map.TryGetValue(key, out var list))
                map[key] = list = new List<string>();
            list.Add(s);
        }

        return map.Values.ToList();
    }

    private static string GetKey(string s) {
        int[] freq = new int[26];

        for (int i = 0; i < s.Length; i++) {
            freq[s[i] - 'a']++;
        }

        var sb = new StringBuilder();
        for (int i = 0; i < 26; i++) {
            if (freq[i] > 0) {
                sb.Append((char)(i + 'a'));
                sb.Append(freq[i]);
            }
        }

        return sb.ToString();
    }
}
