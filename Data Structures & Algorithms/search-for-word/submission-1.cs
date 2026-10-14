public class Solution {
    private readonly List<(int row, int col)> _directions = [(0, -1), (0, 1), (1, 0), (-1, 0)];

    public bool Exist(char[][] board, string word) {
        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[i].Length; j++) {
                if (Exist(board, word, 0, i, j))
                    return true;
            }
        }

        return false;
    }

    private bool Exist(char[][] board, string word, int ind, int row, int col) {
        if (ind == word.Length)
            return true;
        if (row < 0 || row >= board.Length)
            return false;
        if (col < 0 || col >= board[0].Length)
            return false;
        if (board[row][col] != word[ind])
            return false;

        var c = board[row][col];
        board[row][col] = '#';
        var result = false;
        foreach (var dir in _directions) {
            if (Exist(board, word, ind + 1, row + dir.row, col + dir.col)) {
                result = true;
                break;
            }
        }

        board[row][col] = c;

        return result;
    }
}
