public class Solution {
    private readonly List<int> _combination = [];
    private readonly List<List<int>> _combinations = [];

    public List<List<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        CombinationSum2(candidates, 0, target);

        return _combinations;
    }

    private void CombinationSum2(int[] nums, int index, int target) {
        if (target == 0) {
            _combinations.Add(new List<int>(_combination));
            return;
        }

        if (target < 0 || index >= nums.Length || target - nums[index] < 0)
            return;

        _combination.Add(nums[index]);
        CombinationSum2(nums, index + 1, target - nums[index]);
        _combination.RemoveAt(_combination.Count - 1);

        while (index + 1 < nums.Length && nums[index] == nums[index + 1]) index++;
        CombinationSum2(nums, index + 1, target);
    }
}
