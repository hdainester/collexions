namespace Chaotx.Collections {
    internal class BinaryTreeNode<T> : TreeNode<T> where T : struct, System.IComparable<T> {
        public BinaryTreeNode(T value) : base(value) {}
    }
}