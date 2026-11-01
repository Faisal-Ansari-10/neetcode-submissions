public class Solution {
    private HashSet<int> _visited = new();

    public int CountComponents(int n, int[][] edges) {
        var graph = BuildGraph(n, edges);

        var components = 0;
        for (int i = 0; i < n; i++) {
            if (!_visited.Contains(i)) {
                Dfs(-1, i, graph);
                components++;
            }
        }

        return components;
    }

    private void Dfs(int parent, int node, List<int>[] graph) {
        if (_visited.Contains(node))
            return;

        _visited.Add(node);

        foreach (var neighbor in graph[node]) {
            if (neighbor == parent)
                continue;

            Dfs(node, neighbor, graph);
        }
    }

    private List<int>[] BuildGraph(int n, int[][] edges) {
        var graph = new List<int>[n];

        for (int i = 0; i < n; i++) graph[i] = new List<int>();

        foreach (var edge in edges) {
            int a = edge[0], b = edge[1];
            graph[a].Add(b);
            graph[b].Add(a);
        }

        return graph;
    }
}
