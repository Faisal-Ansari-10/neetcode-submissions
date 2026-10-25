public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int maxArea = 0;

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == 1) {
                    maxArea = Math.Max(maxArea, Dfs(grid, i, j));
                }
            }
        }

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[i].Length; j++) {
                if (grid[i][j] == -1)
                    grid[i][j] = 1;
            }
        }

        return maxArea;
    }

    private int Dfs(int[][] grid, int row, int col) {
        if (row < 0 || col < 0 || row >= grid.Length || col >= grid[row].Length ||
            grid[row][col] != 1)
            return 0;

        int area = grid[row][col];
        grid[row][col] = -1;

        area += Dfs(grid, row + 1, col);
        area += Dfs(grid, row - 1, col);
        area += Dfs(grid, row, col + 1);
        area += Dfs(grid, row, col - 1);

        return area;
    }
}
