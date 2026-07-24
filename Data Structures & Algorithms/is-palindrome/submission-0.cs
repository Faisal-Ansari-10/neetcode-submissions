public class Solution {
    public bool IsPalindrome(string s) {
        int left = 0, right = s.Length - 1;

        while (left < right) {
            char lc = s[left];
            char rc = s[right];

            if (!IsAlphaNumeric(lc)) {
                left++;
            } else if (!IsAlphaNumeric(rc)) {
                right--;
            } else if (!Compare(lc, rc)) {
                return false;
            } else {
                left++;
                right--;
            }
        }

        return true;
    }

    private bool IsAlphaNumeric(char c) {
        return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9');
    }

    private bool Compare(char lc, char rc) {
        if (lc == rc)
            return true;
        if (char.IsDigit(lc))
            return false;
        if (char.IsDigit(rc))
            return false;

        return char.ToLower(lc) == char.ToLower(rc);
    }
}
