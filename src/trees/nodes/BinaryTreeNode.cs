namespace Chaotx.Collections.Trees.Nodes {
    public class BinaryTreeNode<T> : TreeNode<T, BinaryTreeNode<T>>
    where T : struct, System.IComparable<T> {
        public BinaryTreeNode<T> Left {get; set;}
        public BinaryTreeNode<T> Right {get; set;}        

        internal BinaryTreeNode() : this(default(T)) {}
        internal BinaryTreeNode(T value) : base(value) {}

        public override void Add(T value, out BinaryTreeNode<T> newNode) {
            newNode = null;
            int res = value.CompareTo(Value);

            if(res > 0 && Right == null || res < 1 && Left == null) {
                newNode = new BinaryTreeNode<T>(value);
                newNode.Value = value;
                newNode.Parent = this;
                newNode.Height = 1;

                if(Left == null && Right == null) {
                    // update height of ancestors
                    BinaryTreeNode<T> ancestor = this;
                    while(ancestor != null && (newNode.Depth - ancestor.Depth) >= ancestor.Height) {
                        ++ancestor.Height;
                        ancestor = ancestor.Parent;
                    }
                }

                if(res > 0) Right = newNode;
                else Left = newNode; // TODO (for now duplicate values will traverse to the left)
            } else {
                if(res > 0) Right.Add(value, out newNode);
                else Left.Add(value, out newNode); // TODO (for now duplicate values will traverse to the left)
            }
        }

        public override void Remove(T value, out BinaryTreeNode<T> oldNode) {
            throw new System.NotImplementedException();
        }

        public void IncHeight() {
            BinaryTreeNode<T> sib = Parent == null ? null
                : Parent.Left == this ? Right : Left;

            if(sib != null && sib.Height <= Height)
                Parent.IncHeight();

            ++Height;
        }

        public void DecHeight() {
            BinaryTreeNode<T> sib = Parent == null ? null
                : Parent.Left == this ? Right : Left;

            if(sib != null && sib.Height < Height)
                Parent.DecHeight();

            --Height;
        }
    }
}