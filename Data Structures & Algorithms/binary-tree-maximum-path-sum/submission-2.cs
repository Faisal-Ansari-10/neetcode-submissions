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
    private int _max = int.MinValue;
    private const int MIN = -10000;

    public int MaxPathSum(TreeNode root) {
        Dfs(root);
        return _max;
    }

    private int Dfs(TreeNode node)
    {
        if(node is null) return MIN;
        
        int left = Dfs(node.left);
        int right = Dfs(node.right);
        int max = Math.Max(left, right);
        max = Math.Max(max + node.val, node.val);
        _max = Math.Max(_max, max);
        _max = Math.Max(_max, left + right + node.val);

        return max;        
    }
}
