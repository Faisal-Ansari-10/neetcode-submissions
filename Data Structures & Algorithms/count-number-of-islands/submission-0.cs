public class Solution {
    public int NumIslands(char[][] grid) {
        Queue<(int row, int col)> q = new();

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++)
                if (grid[i][j] == '1')
                    q.Enqueue((i, j));
        }

        int islands = 0;

        while (q.Count > 0) {
            var (row, col) = q.Dequeue();
            if (grid[row][col] == '1') {
                islands++;
                Dfs(grid, row, col);
            }
        }

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == 'x')
                    grid[i][j] = '1';
            }
        }

        return islands;
    }

    private void Dfs(char[][] grid, int row, int col) {
        if (!(row >= 0 && row < grid.Length) || !(col >= 0 && col < grid[row].Length) ||
            grid[row][col] != '1')
            return;

        grid[row][col] = 'x';
        Dfs(grid, row + 1, col);
        Dfs(grid, row - 1, col);
        Dfs(grid, row, col + 1);
        Dfs(grid, row, col - 1);
    }
}
