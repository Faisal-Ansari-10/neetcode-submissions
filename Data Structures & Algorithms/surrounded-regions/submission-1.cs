public class Solution {
    public void Solve(char[][] board) {
        int m = board.Length, n = board[0].Length;

        for (int i = 0; i < m; i++) {
            Dfs(board, i, 0);
            Dfs(board, i, n - 1);
        }
        for (int j = 0; j < n; j++) {
            Dfs(board, 0, j);
            Dfs(board, m - 1, j);
        }

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (board[i][j] == 'O') board[i][j] = 'X';
                else if (board[i][j] == 'S') board[i][j] = 'O';
            }
        }
    }

    private void Dfs(char[][] board, int row, int col) {
        if (row < 0 || col < 0 || row >= board.Length || col >= board[0].Length
            || board[row][col] != 'O')
            return;

        board[row][col] = 'S';
        Dfs(board, row - 1, col);
        Dfs(board, row + 1, col);
        Dfs(board, row, col - 1);
        Dfs(board, row, col + 1);
    }
}