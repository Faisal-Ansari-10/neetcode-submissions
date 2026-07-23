public class Solution {
    public int MaxProfit(int[] prices) {
        int maxProfit = 0, boughtPrice = int.MaxValue;

        for (int i = 0; i < prices.Length; i++) {
            if (prices[i] < boughtPrice)
                boughtPrice = prices[i];
            else
                maxProfit = Math.Max(prices[i] - boughtPrice, maxProfit);
        }

        return maxProfit;
    }
}
