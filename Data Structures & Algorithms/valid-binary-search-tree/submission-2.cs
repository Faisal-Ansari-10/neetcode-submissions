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
    public bool IsValidBST(TreeNode root) {
        return IsValidBST(root, int.MinValue, int.MaxValue);
    }

    private bool IsValidBST(TreeNode root, int min, int max) {
        if (root is null)
            return true;

        if (!(root.val > min && root.val < max))
            return false;

        if (root.left != null && !IsValidBST(root.left, min, Math.Min(root.val, max)))
            return false;

        if (root.right != null && !IsValidBST(root.right, Math.Max(root.val, min), max))
            return false;

        return true;
    }
}
