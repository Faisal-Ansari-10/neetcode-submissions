public class Solution {
    public bool IsValid(string s) {
        Stack<char> st = new();

        for (int i = 0; i < s.Length; i++) {
            var c = s[i];
            if (c == '(' || c == '[' || c == '{') {
                st.Push(c);
            } else {
                if (st.Count == 0)
                    return false;
                var peek = st.Peek();
                if ((c == ')' && peek == '(') || (c == ']' && peek == '[') ||
                    (c == '}' && peek == '{'))
                    st.Pop();
                else
                    return false;
            }
        }

        return st.Count == 0;
    }
}
