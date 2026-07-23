public class Solution {
    public int MaxArea(int[] heights) {
        int maxWater = 0;
        int left = 0, right = heights.Length - 1;

        while (left < right) {
            int water = Math.Min(heights[left], heights[right]) * (right - left);
            maxWater = Math.Max(maxWater, water);

            if (heights[left] < heights[right])
                left++;
            else
                right--;
        }

        return maxWater;
    }
}
