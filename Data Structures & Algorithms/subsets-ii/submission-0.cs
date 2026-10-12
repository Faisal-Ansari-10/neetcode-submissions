public class Solution {
    private readonly List<int> _subset = [];
    private readonly List<List<int>> _subsets = [];

    public List<List<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        _subsets.Add([]);
        Subsets(nums, 0);

        return _subsets;
    }

    private void Subsets(int[] nums, int start) {
        for (int i = start; i < nums.Length; i++) {
            if (i > start && nums[i] == nums[i - 1])
                continue;

            _subset.Add(nums[i]);
            _subsets.Add(new List<int>(_subset));
            Subsets(nums, i + 1);
            _subset.RemoveAt(_subset.Count - 1);
        }
    }
}
