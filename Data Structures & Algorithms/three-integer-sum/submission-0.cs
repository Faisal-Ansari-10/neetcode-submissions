public class Solution {
    public List<List<int>> ThreeSum(int[] nums) {
        List<List<int>> result = new();

        Array.Sort(nums);
        int n = nums.Length;

        for (int i = 0; i < n; i++) {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            int target = 0 - nums[i];
            int left = i + 1;
            int right = n - 1;

            while (left < right) {
                int sum = nums[left] + nums[right];

                if (sum > target) {
                    right--;
                } else if (sum < target) {
                    left++;
                } else {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    left++;
                    right--;

                    while (left < right && nums[left] == nums[left - 1]) left++;

                    while (left < right && nums[right] == nums[right + 1]) right--;
                }
            }
        }

        return result;
    }
}