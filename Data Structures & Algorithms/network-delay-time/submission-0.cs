public class Solution {
    private const int _inf = int.MaxValue;

    public int NetworkDelayTime(int[][] times, int n, int k) {
        var graph = BuildGraph(times, n);

        int[] propagationTime = new int[n];
        Array.Fill(propagationTime, _inf);
        propagationTime[k - 1] = 0;

        // (node, distance) with priority = distance
        var pq = new PriorityQueue<(int v, int d), int>();
        pq.Enqueue((k - 1, 0), 0);

        while (pq.Count > 0) {
            var (u, d) = pq.Dequeue();

            // Skip stale entries
            if (d > propagationTime[u])
                continue;

            foreach (var (v, c) in graph[u]) {
                int newTime = d + c;
                if (newTime < propagationTime[v]) {
                    propagationTime[v] = newTime;
                    pq.Enqueue((v, newTime), newTime);
                }
            }
        }

        int max = 0;
        foreach (int t in propagationTime) {
            if (t == _inf)
                return -1;
            max = Math.Max(max, t);
        }

        return max;
    }

    private List<(int v, int c)>[] BuildGraph(int[][] edges, int n) {
        var graph = new List<(int v, int c)>[n];

        for (int i = 0; i < n; i++) graph[i] = new List<(int v, int c)>();

        foreach (var edge in edges) {
            int u = edge[0] - 1, v = edge[1] - 1, c = edge[2];
            graph[u].Add((v, c));
        }

        return graph;
    }
}