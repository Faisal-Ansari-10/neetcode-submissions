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
    public int GoodNodes(TreeNode root) {
        if(root is null) return 0;

        return GoodNodes(root, root.val);
    }

    private int GoodNodes(TreeNode node, int max)
    {
        if(node is null) return 0;

        int result = node.val >= max ? 1 : 0;
        max = Math.Max(max, node.val);
        result += GoodNodes(node.left, max);
        result += GoodNodes(node.right, max);

        return result;
    }
}
