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
        var values = new List<int>();
        Dfs(root, values);

        for(int i = 1; i < values.Count; i++)
        {
            if(values[i] <= values[i - 1]) return false;
        }

        return true;
    }

    private void Dfs(TreeNode root, List<int> values)
    {
        if(root is null) return;

        Dfs(root.left, values);
        values.Add(root.val);
        Dfs(root.right, values);
    }
}
