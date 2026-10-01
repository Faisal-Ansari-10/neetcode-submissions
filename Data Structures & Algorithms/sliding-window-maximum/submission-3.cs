public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        int[] result = new int[n - k + 1];

        var dq = new LinkedList<int>();

        for(int i = 0; i < n; i++)
        {
            if(dq.Count > 0 && dq.First.Value <= i - k)
                dq.RemoveFirst();

            while(dq.Count > 0 && nums[dq.Last.Value] <= nums[i])
                dq.RemoveLast();
            
            dq.AddLast(i);

            if(i >= k - 1)
                result[i - k + 1] = nums[dq.First.Value];
        }

        return result;
    }
}
