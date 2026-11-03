public class Solution {
    private class DSU {
        private int[] _parent;
        private int[] _size;

        public DSU(int n) {
            _parent = new int[n];
            _size = new int[n];

            for (int i = 0; i < n; i++) {
                _parent[i] = i;
                _size[i] = 1;
            }
        }

        public int Find(int node) {
            if (_parent[node] == node)
                return node;

            _parent[node] = Find(_parent[node]);
            return _parent[node];
        }

        public bool Union(int u, int v) {
            int rootU = Find(u);
            int rootV = Find(v);

            if (rootU == rootV)
                return false;

            if (_size[rootU] < _size[rootV])
                (rootU, rootV) = (rootV, rootU);

            _parent[rootV] = rootU;
            _size[rootU] += _size[rootV];

            return true;
        }
    }

    public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.SelectMany(edge => edge).Max() + 1;
        var dsu = new DSU(n);

        foreach (var edge in edges) {
            int u = edge[0], v = edge[1];
            if (!dsu.Union(u, v))
                return new int[] { u, v };
        }

        return new int[2];
    }
}
