public class Solution {
    private HashSet<int> _visited = new();

    public bool ValidTree(int n, int[][] edges) {
        if (edges.Length != n - 1)
            return false;

        var graph = BuildGraph(n, edges);

        if (!Dfs(0, -1, graph))
            return false;

        return _visited.Count == n;
    }

    private bool Dfs(int node, int parent, List<int>[] graph) {
        if (_visited.Contains(node))
            return false;

        _visited.Add(node);

        foreach (var neighbor in graph[node]) {
            if (neighbor == parent)
                continue;

            if (!Dfs(neighbor, node, graph))
                return false;
        }

        return true;
    }

    private List<int>[] BuildGraph(int n, int[][] edges) {
        var graph = new List<int>[n];

        for (int i = 0; i < n; i++) {
            graph[i] = new List<int>();
        }

        foreach (var edge in edges) {
            int a = edge[0], b = edge[1];
            graph[a].Add(b);
            graph[b].Add(a);
        }

        return graph;
    }
}