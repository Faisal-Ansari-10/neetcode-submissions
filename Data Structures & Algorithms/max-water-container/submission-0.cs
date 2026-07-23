public class Solution {
    public int MaxArea(int[] heights) {
        int maxWater = 0;
        int n = heights.Length;

        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                int area = Math.Min(heights[i], heights[j]) * (j - i);
                maxWater = Math.Max(maxWater, area);
            }
        }

        return maxWater;
    }
}
