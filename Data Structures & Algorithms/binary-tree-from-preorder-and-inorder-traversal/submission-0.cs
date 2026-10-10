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
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return BuildTree(preorder, inorder, 0, 0,preorder.Length);
    }

    private TreeNode BuildTree(int[] preorder, int[] inorder, int preStart, int inStart,
                               int inEnd) {
        if (inStart >= inEnd)
            return null;

        TreeNode node = new(preorder[preStart]);
        int i = inStart;

        for (; i < inEnd; i++) {
            if (inorder[i] == node.val)
                break;
        }

        int leftSize = i - inStart;

        node.left = BuildTree(preorder, inorder, preStart + 1, inStart, i);
        node.right = BuildTree(preorder, inorder, preStart + 1 + leftSize, i + 1, inEnd);

        return node;
    }
}
