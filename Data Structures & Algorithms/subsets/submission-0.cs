public class Solution {
    public List<List<int>> Subsets(int[] nums) {
        List<List<int>> subsets = [];
        List<int> set = [];

        Subsets(nums, 0, set, subsets);
        return subsets;
    }

    private void Subsets(int[] nums, int index, List<int> set, List<List<int>> subsets) {
        if (index >= nums.Length) {
            subsets.Add(new List<int>(set));
            return;
        }

        Subsets(nums, index + 1, set, subsets);
        set.Add(nums[index]);
        Subsets(nums, index + 1, set, subsets);
        set.RemoveAt(set.Count - 1);
    }
}
