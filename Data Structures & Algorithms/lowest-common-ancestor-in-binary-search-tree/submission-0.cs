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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        var pSt = Search(root, p);
        var qSt = Search(root, q);

        Console.WriteLine($"p : {pSt.Count}, q: {qSt.Count}");
        while(pSt.Count != qSt.Count)
        {
            if(pSt.Count > qSt.Count) {pSt.Pop();}
            else qSt.Pop();
        }

        var lca = root;

        while (pSt.Count > 0 && qSt.Count > 0) {
            var pPeek = pSt.Pop();
            var qPeek = qSt.Pop();

            if (pPeek == qPeek) {
                lca = pPeek;
                break;
            }
        }
        return lca;
    }

    private Stack<TreeNode> Search(TreeNode root, TreeNode target) {
        Stack<TreeNode> st = new();
        if (root is null || target is null)
            return st;

        var current = root;
        st.Push(current);

        while (current != null && current != target) {
            if (target.val > current.val)
                current = current.right;
            else
                current = current.left;

            st.Push(current);
        }


        return st;
    }
}
