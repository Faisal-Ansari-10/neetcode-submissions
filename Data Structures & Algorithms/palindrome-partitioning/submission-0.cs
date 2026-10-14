public class Solution {
    private List<string> _partitions = [];
    private List<List<string>> _validPartitions = [];

    public List<List<string>> Partition(string s) {
        Partition(s, 0);
        return _validPartitions;
    }

    private void Partition(string s, int start) {
        if (start >= s.Length) {
            _validPartitions.Add(new List<string>(_partitions));
            return;
        }

        for (int end = start + 1; end <= s.Length; end++) {
            var partition = s.Substring(start, end - start);
            if (!IsPalindrome(partition))
                continue;
            _partitions.Add(partition);
            Partition(s, end);
            _partitions.RemoveAt(_partitions.Count - 1);
        }
    }

    private bool IsPalindrome(string s) {
        for (int i = 0; i < s.Length; i++) {
            if (s[i] != s[s.Length - 1 - i])
                return false;
        }

        return true;
    }
}
