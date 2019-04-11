namespace Chaotx.Collections.Trees.Nodes {
    public class AVLTreeNode<T> : BinaryTreeNode<T>
    where T : struct, System.IComparable<T> {
        private AVLTree<T> tree;
        public override BinaryTree<T> Tree {
            get => tree != null ? tree : tree = new AVLTree<T>();
            set => tree = value as AVLTree<T>;
        }

        public int Balance =>
            (Right == null ? 0 : Right.Tree.Height) -
            (Left == null  ? 0 : Left.Tree.Height);

        internal AVLTreeNode() : base() {}
        internal AVLTreeNode(T value) : this(value, null) {}
        internal AVLTreeNode(T value, AVLTree<T> tree) : base(value, tree) {}
    }
}