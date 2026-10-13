public class Solution {
    public List<string> GenerateParenthesis(int n) {
        var result = new List<string>();
        GenerateParenthesis(n, 0, 0, new StringBuilder(), result);
        return result;
    }

    private void GenerateParenthesis(int n, int left, int right, StringBuilder sb,
                                     List<string> result) {
        if (left == n && left == right) {
            result.Add(sb.ToString());
            return;
        }

        if (right > left)
            return;

        if (left < n) {
            sb.Append('(');
            GenerateParenthesis(n, left + 1, right, sb, result);
            sb.Length--;
        }

        if (right < left) {
            sb.Append(')');
            GenerateParenthesis(n, left, right + 1, sb, result);
            sb.Length--;
        }
    }
}
