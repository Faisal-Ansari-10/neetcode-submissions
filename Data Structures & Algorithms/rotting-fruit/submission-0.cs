public class Solution {
    public int OrangesRotting(int[][] grid) {
        Queue<(int row, int col, int d)> q = new();
        int[][] time = new int[grid.Length][];

        for (int i = 0; i < grid.Length; i++) {
            time[i] = new int[grid[i].Length];
            for (int j = 0; j < grid[i].Length; j++) {
                time[i][j] = int.MaxValue;
                if (grid[i][j] == 2)
                    q.Enqueue((i, j, 0));
            }
        }

        while (q.Count > 0) {
            var (row, col, d) = q.Dequeue();
            int r = row - 1, c = col;
            d += 1;
            if (r >= 0 && grid[r][c] == 1 && time[r][c] > d) {
                time[r][c] = d;
                q.Enqueue((r, c, d));
            }

            r = row + 1;
            if (r < grid.Length && grid[r][c] == 1 && time[r][c] > d) {
                time[r][c] = d;
                q.Enqueue((r, c, d));
            }

            r = row;
            c = col - 1;
            if (c >= 0 && grid[r][c] == 1 && time[r][c] > d) {
                time[r][c] = d;
                q.Enqueue((r, c, d));
            }

            c = col + 1;
            if (c < grid[r].Length && grid[r][c] == 1 && time[r][c] > d) {
                time[r][c] = d;
                q.Enqueue((r, c, d));
            }
        }

        int minutes = 0;

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == 1) {
                    if (time[i][j] == int.MaxValue)
                        return -1;
                    minutes = Math.Max(minutes, time[i][j]);
                }
            }
        }

        return minutes;
    }
}