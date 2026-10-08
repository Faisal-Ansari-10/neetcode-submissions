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

public class Solution {
    public List<int> RightSideView(TreeNode root) {
        List<int> result = [];

        if (root is null)
            return result;

        Queue<TreeNode> q = new();
        q.Enqueue(root);

        while (q.Count > 0) {
            int levelCount = q.Count;

            while (levelCount-- > 0) {
                var node = q.Dequeue();
                if (levelCount == 0)
                    result.Add(node.val);
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
            }
        }

        return result;
    }
}
