public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int[] result = new int[2];

        int left = 0, right = numbers.Length - 1;

        while (left < right) {
            int sum = numbers[left] + numbers[right];

            if (sum == target)
                return new int[] { left + 1, right + 1 };

            if (sum > target)
                right--;
            else
                left++;
        }
        return result;
    }
}
