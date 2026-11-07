public class Solution {
    public List<string> FindItinerary(List<List<string>> tickets) {
        var graph = new Dictionary<string, List<string>>();

        foreach (var t in tickets) {
            if (!graph.TryGetValue(t[0], out var list))
                graph[t[0]] = list = new List<string>();
            list.Add(t[1]);
        }

        foreach (var list in graph.Values) list.Sort((a, b) => string.CompareOrdinal(b, a));

        var result = new List<string>();
        Dfs("JFK", graph, result);
        result.Reverse();
        return result;
    }

    private void Dfs(string airport, Dictionary<string, List<string>> graph, List<string> result) {
        if (graph.TryGetValue(airport, out var dests)) {
            while (dests.Count > 0) {
                var next = dests[^1];
                dests.RemoveAt(dests.Count - 1);
                Dfs(next, graph, result);
            }
        }

        result.Add(airport);
    }
}
