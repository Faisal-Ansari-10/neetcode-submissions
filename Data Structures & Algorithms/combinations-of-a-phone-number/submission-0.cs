public class Solution {
    private readonly Dictionary<char, string> _map =
        new() { { '2', "abc" }, { '3', "def" },  { '4', "ghi" }, { '5', "jkl" },
                { '6', "mno" }, { '7', "pqrs" }, { '8', "tuv" }, { '9', "wxyz" } };

    public List<string> LetterCombinations(string digits) {
        List<string> result = new();
        if (digits.Length == 0)
            return result;

        StringBuilder sb = new();

        LetterCombinations(digits, 0, sb, result);
        return result;
    }

    private void LetterCombinations(string digits, int ind, StringBuilder sb, List<string> result) {
        if (ind >= digits.Length) {
            result.Add(sb.ToString());
            return;
        }

        foreach (var c in _map[digits[ind]]) {
            sb.Append(c);
            LetterCombinations(digits, ind + 1, sb, result);
            sb.Length--;
        }
    }
}