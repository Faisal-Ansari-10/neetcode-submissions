public class Solution {
    public int Trap(int[] height) {
        int n = height.Length;
        int[] leftWall = new int[n];
        int[] rightWall = new int[n];

        leftWall[0] = height[0];
        rightWall[n - 1] = height[n - 1];

        for (int i = 1; i < n; i++) {
            leftWall[i] = Math.Max(height[i], leftWall[i - 1]);

            int rightIndex = n - 1 - i;
            rightWall[rightIndex] = Math.Max(height[rightIndex], rightWall[rightIndex + 1]);
        }

        // for (int i = n - 2; i >= 0; i--) {
        //     rightWall[i] = Math.Max(height[i], rightWall[i + 1]);
        // }

        int water = 0;

        for (int i = 0; i < n; i++) {
            water += Math.Max(Math.Min(leftWall[i], rightWall[i]) - height[i], 0);
        }

        return water;
    }
}
