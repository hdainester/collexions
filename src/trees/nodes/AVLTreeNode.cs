namespace Chaotx.Collections.Trees.Nodes {
    public class AVLTreeNode<T> : BinaryTreeNode<T>
    where T : struct, System.IComparable<T> {
        public int Balance {get {return Right.Tree.Height - Left.Tree.Height;}}
        public AVLTreeNode(T value) : base(value) {}
    }
}