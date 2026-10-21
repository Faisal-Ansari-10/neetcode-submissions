public class Solution {
    private Dictionary<(int ind, int product), int> _cache = [];

    public int MaxProduct(int[] nums) {
        return MaxProduct(nums, 0, 1);
    }

    private int MaxProduct(int[] nums, int ind, int product) {
        if (ind >= nums.Length)
            return int.MinValue;

        var key = (ind, product);
        if (_cache.TryGetValue(key, out var max))
            return max;

        // take it
        max = product * nums[ind];
        max = Math.Max(max, MaxProduct(nums, ind + 1, max));
        // skip it
        max = Math.Max(max, MaxProduct(nums, ind + 1, 1));

        _cache[key] = max;
        return max;
    }
}
