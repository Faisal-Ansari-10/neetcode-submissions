/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Codec {
    // Encodes a tree to a single string.
    public string Serialize(TreeNode root) {
        StringBuilder sb = new();
        Queue<TreeNode> q = new();
        q.Enqueue(root);

        while (q.Count > 0) {
            var node = q.Dequeue();
            if (node is null) {
                sb.Append("#,");
                continue;
            }

            sb.Append(node.val);
            sb.Append(',');

            q.Enqueue(node.left);
            q.Enqueue(node.right);
        }

        return sb.ToString().Trim(",");
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data) {
        var nodes = data.Split(",");

        if (nodes[0].Equals("#"))
            return null;

        TreeNode root = new(int.Parse(nodes[0]));
        Queue<TreeNode> q = new();
        q.Enqueue(root);

        int i = 1;
        while (q.Count > 0 && i < nodes.Length) {
            var node = q.Dequeue();

            if (nodes[i] != "#") {
                node.left = new TreeNode(int.Parse(nodes[i]));
                q.Enqueue(node.left);
            }
            i++;

            if (i < nodes.Length && nodes[i] != "#") {
                node.right = new TreeNode(int.Parse(nodes[i]));
                q.Enqueue(node.right);
            }
            i++;
        }

        return root;
    }
}
