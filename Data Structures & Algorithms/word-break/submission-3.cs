public class Solution {
    private string _s;
    private HashSet<string> _dict;
    private Dictionary<int, bool> _cache = [];

    public bool WordBreak(string s, List<string> wordDict) {
        _s = s;
        _dict = new(wordDict);

        bool[] dp = new bool[s.Length + 1];
        dp[s.Length] = true;

        for(int start = s.Length - 1; start >= 0; start--)
        {
            for(int end = start + 1; end <= s.Length; end++)
            {
                if(_dict.Contains(s[start..end]) && dp[end]) dp[start] = true;
            }
        }

        return dp[0];
    }

    private bool WordBreak(int start) {
        if (start >= _s.Length)
            return true;

        if (_cache.TryGetValue(start, out var result))
            return result;

        result = false;
        for (int end = start + 1; end <= _s.Length; end++) {
            if (_dict.Contains(_s[start..end]) && WordBreak(end))
                result = true;
        }

        _cache[start] = result;
        return result;
    }
}
