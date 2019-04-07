namespace Chaotx.Collections {
    internal class TreeNode<T> where T : struct, System.IComparable<T> {
        public T Value {get; set;}
        public int Depth {get; set;}

        public TreeNode() : this(default(T)) {}
        public TreeNode(T value) {
            Value = value;
        }
    }
}