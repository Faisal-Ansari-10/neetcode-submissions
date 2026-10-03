public class Solution {
    public int FindMin(int[] nums) {
        int lo = 0, hi = nums.Length - 1;

        while(lo < hi)
        {
            int mid = lo + (hi - lo) / 2;
            if(nums[hi] < nums[mid]) lo = mid + 1;
            else hi = mid;
        }

        return nums[hi];
    }
}
