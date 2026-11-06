public class Solution {
    private const int _inf = int.MaxValue;

    public int NetworkDelayTime(int[][] times, int n, int k) {
        int[] dist = new int[n];
        Array.Fill(dist, _inf);
        dist[k - 1] = 0;

        for (int i = 0; i < n - 1; i++) {
            bool changed = false;

            foreach (var e in times) {
                int u = e[0] - 1, v = e[1] - 1, c = e[2];

                if (dist[u] != _inf && dist[u] + c < dist[v]) {
                    dist[v] = dist[u] + c;
                    changed = true;
                }
            }

            if (!changed)
                break;
        }

        int max = 0;
        foreach (int d in dist) {
            if (d == _inf)
                return -1;
            max = Math.Max(max, d);
        }

        return max;
    }
}