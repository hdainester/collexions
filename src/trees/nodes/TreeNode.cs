namespace Chaotx.Collections.Trees.Nodes {
    public abstract class TreeNode<ValueType, TreeType, NodeType>
        where ValueType : struct, System.IComparable<ValueType>
        where TreeType : Tree<ValueType, TreeType, NodeType>
        where NodeType : TreeNode<ValueType, TreeType, NodeType>
    {
        public virtual ValueType Value {get; set;}
        public virtual TreeType Tree {get; set;}
        public virtual NodeType Parent {get; set;}
        public abstract int Depth {get;}

        public TreeNode() : this(default(ValueType)) {}
        public TreeNode(ValueType value) {
            Value = value;
        }

        public TreeNode(ValueType value, TreeType tree) {
            Value = value;
            Tree = tree;
            Tree.Node = this as NodeType;
        }
    }
}