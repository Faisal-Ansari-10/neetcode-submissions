public class Solution {
    public List<string> GenerateParenthesis(int n) {
        return GenerateParenthesis(n, 0, 0, new StringBuilder());
    }

    private List<string> GenerateParenthesis(int n, int left, int right, StringBuilder sb) {
        if (left == n && left == right) {
            return new List<string> { sb.ToString() };
        }

        if (right > left)
            return new List<string>();

        var result = new List<string>();

        if (left < n) {
            sb.Append('(');
            result.AddRange(GenerateParenthesis(n, left + 1, right, sb));
            sb.Length--;
        }

        if (right < left) {
            sb.Append(')');
            result.AddRange(GenerateParenthesis(n, left, right + 1, sb));
            sb.Length--;
        }

        return result;
    }
}
