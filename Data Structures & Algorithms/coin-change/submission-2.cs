public class Solution {
    private readonly Dictionary<(int ind, int amount), int> _cache = [];

    public int CoinChange(int[] coins, int amount) {
        Array.Sort(coins);
        var result = CoinChange(coins, amount, 0);
        return result == int.MaxValue ? -1 : result;
    }

    private int CoinChange(int[] coins, int amount, int ind) {
        if (amount == 0)
            return 0;

        if (ind == coins.Length || coins[ind] > amount)
            return int.MaxValue;

        var key = (ind, amount);
        if (_cache.TryGetValue(key, out var count))
            return count;

        var use = CoinChange(coins, amount - coins[ind], ind);
        if (use != int.MaxValue)
            use++;
        var skip = CoinChange(coins, amount, ind + 1);

        count = Math.Min(use, skip);
        _cache[key] = count;
        return count;
    }
}
