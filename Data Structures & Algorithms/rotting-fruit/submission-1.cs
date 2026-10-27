public class Solution {
    private static readonly(int dr, int dc)[] Dirs = { (-1, 0), (1, 0), (0, -1), (0, 1) };

    public int OrangesRotting(int[][] grid) {
        var q = new Queue<(int r, int c)>();
        int fresh = 0;

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == 2)
                    q.Enqueue((i, j));
                else if (grid[i][j] == 1)
                    fresh++;
            }
        }

        int minutes = 0;

        while (q.Count > 0 && fresh > 0) {
            int size = q.Count;
            for (int k = 0; k < size; k++) {
                var (r, c) = q.Dequeue();
                foreach (var (dr, dc) in Dirs) {
                    int nr = r + dr, nc = c + dc;
                    if (nr < 0 || nr >= grid.Length || nc < 0 || nc >= grid[nr].Length ||
                        grid[nr][nc] != 1)
                        continue;

                    grid[nr][nc] = 2;
                    fresh--;
                    q.Enqueue((nr, nc));
                }
            }
            minutes++;
        }

        return fresh == 0 ? minutes : -1;
    }
}