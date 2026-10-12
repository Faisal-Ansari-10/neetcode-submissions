public class Solution {
    private readonly List<int> _combination = [];
    private readonly List<List<int>> _combinations = [];

    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        CombinationSum2(candidates, 0, target);

        return _combinations;
    }

    private void CombinationSum2(int[] nums, int start, int target) {
        if (target == 0) {
            _combinations.Add(new List<int>(_combination));
            return;
        }

        for (int i = start; i < nums.Length; i++) {
            if (i > start && nums[i] == nums[i - 1])
                continue;
            if (target - nums[i] < 0)
                return;

            _combination.Add(nums[i]);
            CombinationSum2(nums, i + 1, target - nums[i]);
            _combination.RemoveAt(_combination.Count - 1);

        }
    }
}
