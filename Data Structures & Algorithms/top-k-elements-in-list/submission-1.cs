public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        int n = nums.Length;

        Dictionary<int, int> freq = [];

        for (int i = 0; i < n; i++) freq[nums[i]] = freq.GetValueOrDefault(nums[i], 0) + 1;

        var buckets = new List<int>[n + 1];

        foreach (var (num, count) in freq) {
            (buckets[count] ??= new List<int>()).Add(num);
        }

        var result = new List<int>();

        for (int f = buckets.Length - 1; f >= 1 && result.Count < k; f--) {
            if (buckets[f] is null)
                continue;
            result.AddRange(buckets[f]);
        }

        return [..result.Take(k)];
    }
}
