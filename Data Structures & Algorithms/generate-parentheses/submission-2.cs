public class Solution {
    public List<string> GenerateParenthesis(int n) {
        var result = new List<string>(Catalan(n));
        var buf = new char[2 * n];
        Backtrack(result, buf, 0, n, 0, 0);
        return result;
    }

    private static void Backtrack(List<string> result, char[] buf, int pos,
                                  int n, int open, int close) {
        if (pos == buf.Length) {
            result.Add(new string(buf));
            return;
        }

        if (open < n) {
            buf[pos] = '(';
            Backtrack(result, buf, pos + 1, n, open + 1, close);
        }

        if (close < open) {
            buf[pos] = ')';
            Backtrack(result, buf, pos + 1, n, open, close + 1);
        }
    }

    // C(n) = C(n-1) * 2(2n-1) / (n+1)
    private static int Catalan(int n) {
        long c = 1;
        for (int i = 1; i <= n; i++)
            c = c * 2 * (2 * i - 1) / (i + 1);
        return (int)c;
    }
}