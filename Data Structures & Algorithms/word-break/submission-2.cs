public class Solution {
    private string _s;
    private HashSet<string> _dict;
    private Dictionary<int, bool> _cache = [];

    public bool WordBreak(string s, List<string> wordDict) {
        _s = s;
        _dict = new(wordDict);

        return WordBreak(0);
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
