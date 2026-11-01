public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        List<int>[] graph = BuildGraph(numCourses, prerequisites);
        int[] inDegree = BuildIndegree(numCourses, prerequisites);

        Queue<int> queue = new();

        for (int i = 0; i < numCourses; i++) {
            if (inDegree[i] == 0)
                queue.Enqueue(i);
        }

        List<int> topologicalOrder = new();

        while (queue.Count > 0) {
            int current = queue.Dequeue();
            topologicalOrder.Add(current);

            foreach (var neighbor in graph[current]) {
                inDegree[neighbor]--;

                if (inDegree[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return topologicalOrder.Count == graph.Length;
    }

    private List<int>[] BuildGraph(int numNodes, int[][] edges) {
        var graph = new List<int>[numNodes];
        for (int i = 0; i < numNodes; i++) {
            graph[i] = new List<int>();
        }

        foreach (var edge in edges) {
            int a = edge[0], b = edge[1];
            graph[b].Add(a);
        }

        return graph;
    }

    private int[] BuildIndegree(int numNodes, int[][] edges) {
        int[] inDegree = new int[numNodes];

        foreach (var edge in edges) {
            int a = edge[0];
            inDegree[a]++;
        }

        return inDegree;
    }
}
