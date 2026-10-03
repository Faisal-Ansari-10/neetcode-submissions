public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int lr = 0, hr = m;
        int lc = 0, hc = n;
        int mr, mc;

        while (lr < hr && lc < hc) {
            mr = lr + (hr - lr) / 2;
            mc = lc + (hc - lc) / 2;

            if (target == matrix[mr][mc]) {
                return true;
            } else if (target > matrix[mr][mc]) {
                if (target > matrix[mr][n - 1]) {
                    lr = mr + 1;
                    hc = n;
                } else {
                    hr = mr + 1;
                    lc = mc + 1;
                }
            } else {
                if (target < matrix[mr][0]) {
                    hr = mr;
                    lc = 0;
                } else {
                    lr = mr;
                    hc = mc;
                }
            }
        }

        return false;
    }
}
