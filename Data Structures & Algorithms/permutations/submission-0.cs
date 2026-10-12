public class Solution {
    private readonly List<List<int>> _permutations = [];

    public List<List<int>> Permute(int[] nums) {
        Permute(nums, 0);
        return _permutations;
    }

    private void Permute(int[] nums, int index) {
        if (index >= nums.Length) {
            _permutations.Add(new List<int>(nums));
        }

        for (int i = index; i < nums.Length; i++) {
            Swap(nums, index, i);
            Permute(nums, index + 1);
            Swap(nums, index, i);
        }
    }

    private void Swap(int[] nums, int i, int j) {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
}
