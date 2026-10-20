public class Solution {
    private readonly Dictionary<int, int> _cache = [];

    public int NumDecodings(string s) {
        return NumDecodings(s, 0);
    }

    private int NumDecodings(string s, int ind) {
        if (ind == s.Length)
            return 1;
        if (ind > s.Length || s[ind] == '0')
            return 0;

        if (_cache.TryGetValue(ind, out var count))
            return count;

        count = NumDecodings(s, ind + 1);
        if (ind + 1 < s.Length && (s[ind] == '1' || (s[ind] == '2' && s[ind + 1] <= '6')))
            count += NumDecodings(s, ind + 2);

        _cache[ind] = count;
        return count;
    }
}
