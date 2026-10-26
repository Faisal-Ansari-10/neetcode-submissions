/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if (node is null)
            return null;

        Dictionary<Node, Node> clones = new();
        Queue<Node> q = new();
        clones[node] = new Node(node.val, new List<Node>());
        q.Enqueue(node);

        while (q.Count > 0) {
            Node current = q.Dequeue();
            foreach (var neighbor in current.neighbors) {
                if (!clones.TryGetValue(neighbor, out var clone)) {
                    clone = new Node(neighbor.val, new List<Node>());
                    clones[neighbor] = clone;
                    q.Enqueue(neighbor);
                }

                clones[current].neighbors.Add(clone);
            }
        }

        return clones[node];
    }
}
