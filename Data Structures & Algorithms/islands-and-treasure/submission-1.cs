public class Solution {
    public void islandsAndTreasure(int[][] grid) {
        Queue<(int row, int col, int d)> q = new();

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == 0)
                    q.Enqueue((i, j, 0));
            }
        }

        while (q.Count > 0) {
            var (row, col, d) = q.Dequeue();
            if (row - 1 >= 0 && grid[row - 1][col] > 1 + d) {
                grid[row - 1][col] = 1 + d;
                q.Enqueue((row - 1, col, 1 + d));
            }
            if (row + 1 < grid.Length && grid[row + 1][col] > 1 + d) {
                grid[row + 1][col] = 1 + d;
                q.Enqueue((row + 1, col, 1 + d));
            }

            if (col - 1 >= 0 && grid[row][col - 1] > 1 + d) {
                grid[row][col - 1] = 1 + d;
                q.Enqueue((row, col - 1, 1 + d));
            }

            if (col + 1 < grid[row].Length && grid[row][col + 1] > 1 + d) {
                grid[row][col + 1] = 1 + d;
                q.Enqueue((row, col + 1, 1 + d));
            }
        }
    }
}
