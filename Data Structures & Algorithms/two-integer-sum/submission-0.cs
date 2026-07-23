public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new Dictionary<int,int>();

        for(int i = 0; i < nums.Length; i++) {
            int remaining = target - nums[i];

            if(map.ContainsKey(remaining)) {
                return new int[]{map[remaining], i};
            }

            map[nums[i]] = i;
        }

        return new int[]{-1,-1};
    }
}
