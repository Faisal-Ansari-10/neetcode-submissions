public class Solution {
    private bool[] _cols;
    private bool[] _diag1;
    private bool[] _diag2;
    private int[] _queens;
    private int _n;
    private List<List<string>> _result;

    public List<List<string>> SolveNQueens(int n) {
        _n = n;
        _cols = new bool[n];
        _diag1 = new bool[2 * n];
        _diag2 = new bool[2 * n];
        _queens = new int[n];
        _result = [];

        Solve(0);

        return _result;
    }

    private void Solve(int row) {
        if (row == _n) {
            _result.Add(BuildBoard());
            return;
        }

        for (int col = 0; col < _n; col++) {
            int d1 = row - col + _n;
            int d2 = row + col;

            if (_cols[col] || _diag1[d1] || _diag2[d2])
                continue;

            _cols[col] = _diag1[d1] = _diag2[d2] = true;
            _queens[row] = col;
            Solve(row + 1);
            _cols[col] = _diag1[d1] = _diag2[d2] = false;
        }
    }

    private List<string> BuildBoard() {
        var board = new List<string>();
        for (int r = 0; r < _n; r++) {
            char[] line = new char[_n];
            Array.Fill(line, '.');
            line[_queens[r]] = 'Q';
            board.Add(new string(line));
        }
        return board;
    }
}
