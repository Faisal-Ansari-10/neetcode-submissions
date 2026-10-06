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
    public bool IsBalanced(TreeNode root) {
        bool subTreeIsBalanced = true;
        FindHeight(root, ref subTreeIsBalanced);
        return subTreeIsBalanced;
    }

    private int FindHeight(TreeNode root, ref bool subTreeIsBalanced) {
        if (root is null)
            return 0;
        if (!subTreeIsBalanced)
            return 0;

        int left = FindHeight(root.left, ref subTreeIsBalanced);
        if(!subTreeIsBalanced) return 0;
    
        int right = FindHeight(root.right, ref subTreeIsBalanced);
        if(!subTreeIsBalanced) return 0;
        
        subTreeIsBalanced = Math.Abs(left - right) <= 1;

        return Math.Max(left, right) + 1;
    }
}
