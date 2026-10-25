public class Solution {
    public int NumIslands(char[][] grid) {
        int islands = 0;

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++)
                if (grid[i][j] == '1') {
                    islands++;
                    Dfs(grid, i, j);
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
        if (row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length ||
            grid[row][col] != '1')
            return;

        grid[row][col] = 'x';
        Dfs(grid, row + 1, col);
        Dfs(grid, row - 1, col);
        Dfs(grid, row, col + 1);
        Dfs(grid, row, col - 1);
    }
}
