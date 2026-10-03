public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length, n = matrix[0].Length;
        int lo = 0, hi = m * n - 1;
        int mid, val;

        while(lo <= hi)
        {
            mid = lo + (hi - lo) / 2;
            val = matrix[mid / n][mid % n];
            if(target == val) return true;
            else if(target > val) lo = mid + 1;
            else hi = mid - 1;
        }

        return false;
    }
}
