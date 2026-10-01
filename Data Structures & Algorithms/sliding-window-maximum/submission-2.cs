public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        int[] result = new int[n - k + 1];

        var pq = new PriorityQueue<(int value, int index), (int value, int index)>(
            Comparer<(int value, int index)>.Create((a, b) => {
                int compare = b.value.CompareTo(a.value);
                if (compare != 0)
                    return compare;
                return a.index.CompareTo(b.index);
            }));

        for (int i = 0; i < n; i++) {
            if (i + 1 < k) {
                pq.Enqueue((nums[i], i), (nums[i], i));
                continue;
            }

            while (pq.Count > 0 && pq.Peek().index <= (i - k)) {
                pq.Dequeue();
            }

            pq.Enqueue((nums[i], i), (nums[i], i));
            var (max, index) = pq.Peek();
            result[i - k + 1] = max;
        }

        return result;
    }
}
