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
    private int _k = 0;

    public int KthSmallest(TreeNode root, int k) {
        return Dfs(root, k);
    }

    private int Dfs(TreeNode node, int k)
    {
        if(node is null) return -1;
        int val = Dfs(node.left, k);
        if(val >= 0) return val;
        _k++;
        if(_k == k) return node.val;

        return Dfs(node.right, k);
    }
}
