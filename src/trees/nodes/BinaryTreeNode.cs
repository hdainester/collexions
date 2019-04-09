namespace Chaotx.Collections.Trees.Nodes {
    public class BinaryTreeNode<T> : TreeNode<T, BinaryTree<T>, BinaryTreeNode<T>>
    where T : struct, System.IComparable<T> {
        public BinaryTreeNode<T> Left {get; set;}
        public BinaryTreeNode<T> Right {get; set;}        
        public override int Depth => Parent == null ? 0 : Parent.Depth+1;
        public override BinaryTree<T> Tree {
            get => base.Tree != null ? base.Tree : BinaryTree<T>.EmptyTree;
            set => base.Tree = value;
        }

        internal BinaryTreeNode(T value) : this(value, new BinaryTree<T>(value)) {}
        internal BinaryTreeNode(T value, BinaryTree<T> tree) : base(value, tree) {}
    }
}