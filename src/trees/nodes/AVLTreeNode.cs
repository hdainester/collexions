namespace Chaotx.Collections {
    internal class AVLTreeNode<T> : BinaryTreeNode<T> where T : struct, System.IComparable<T> {
        public int Balance {get; set;}

        public AVLTreeNode(T value) : base(value) {}
    }
}