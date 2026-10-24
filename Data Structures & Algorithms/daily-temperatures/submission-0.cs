public class Solution {
    public int[] DailyTemperatures(int[] temperatures) {
        Stack<int> st = new();
        int[] result = new int[temperatures.Length];

        for (int i = temperatures.Length - 1; i >= 0; i--) {
            while (st.Count > 0 && temperatures[st.Peek()] <= temperatures[i]) st.Pop();
            result[i] = st.Count > 0 ? st.Peek() - i : 0;
            st.Push(i);
        }

        return result;
    }
}
