public class Solution {
    public int Trap(int[] height) {
        int left = 0, leftMax = 0, right = height.Length - 1, rightMax = 0;
        int water = 0;

        while (left < right) {
            leftMax = Math.Max(leftMax, height[left]);
            rightMax = Math.Max(rightMax, height[right]);

            if (leftMax < rightMax) {
                water += leftMax - height[left];
                left++;
            } else {
                water += rightMax - height[right];
                right--;
            }
        }

        return water;
    }
}
