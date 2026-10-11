public class Solution {
    public List<List<int>> CombinationSum(int[] nums, int target) {
        List<int> path = [];
        List<List<int>> paths = [];

        CombinationSum(nums, 0, target, path, paths);

        return paths;
    }

    private void CombinationSum(int[] nums, int index, int target, List<int> path,
                                List<List<int>> paths) {
        if (target < 0)
            return;
        if (index >= nums.Length) {
            if (target == 0)
                paths.Add(new List<int>(path));

            return;
        }

        path.Add(nums[index]);
        CombinationSum(nums, index, target - nums[index], path, paths);
        path.RemoveAt(path.Count - 1);
        CombinationSum(nums, index + 1, target, path, paths);
    }
}
