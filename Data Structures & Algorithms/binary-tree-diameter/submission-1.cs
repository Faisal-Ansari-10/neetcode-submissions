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
    public int DiameterOfBinaryTree(TreeNode root) {
        int diameter = 0;
        FindHeight(root, ref diameter);
        return diameter;
    }

    private static int FindHeight(TreeNode node, ref int diameter) {
        if (node is null)
            return 0;

        int left = FindHeight(node.left, ref diameter);
        int right = FindHeight(node.right, ref diameter);
        diameter = Math.Max(diameter, left + right);

        return Math.Max(left, right) + 1;
    }
}
