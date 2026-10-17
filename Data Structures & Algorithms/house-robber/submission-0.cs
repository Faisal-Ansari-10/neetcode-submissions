public class Solution {
    private readonly Dictionary<(int ind, int prevInd), int> _cache = [];
    public int Rob(int[] nums) {
        return Rob(nums, 0, -1);
    }

    private int Rob(int[] nums, int ind, int prevInd) {
        if (ind >= nums.Length)
            return 0;

        var key = (ind, prevInd);
        if (_cache.TryGetValue(key, out var amt))
            return amt;

        if (prevInd >= 0 && ind - prevInd == 1)
            amt = Rob(nums, ind + 1, prevInd);
        else
            amt = Math.Max(Rob(nums, ind + 1, prevInd), Rob(nums, ind + 1, ind) + nums[ind]);

        _cache[key] = amt;
        return amt;
    }
}
