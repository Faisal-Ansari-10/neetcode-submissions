public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int lo = 1, hi = piles.Max();

        while(lo <= hi){
            int perHour = lo + (hi - lo) / 2;
            int hours = piles.Sum(p => (int)Math.Ceiling(p / (double)perHour));
            if(hours > h) lo = perHour + 1;
            else hi = perHour - 1;
        }

        return lo;
    }
}
