namespace Chaotx.Collections.Trees {
    public class BinaryTree<T> : Tree<T> where T : struct, System.IComparable<T> {
        public BinaryTree() : this(default(T)) {}
        public BinaryTree(T value) {
            RootTree = this;
            Value = value;
            Height = 1;
        }

        public override void Add(T value) {
            int res = value.CompareTo(Value);

            if(res > 0 && RightTree == null || LeftTree == null) {
                BinaryTree<T> newTree = new BinaryTree<T>(value);
                newTree.RootTree = RootTree;
                newTree.ParentTree = this;
                newTree.Depth = Depth+1;

                if(LeftTree == null && RightTree == null) _IncHeight(newTree);
                if(res > 0) RightTree = newTree; else LeftTree = newTree;
            } else {
                if(res > 0) RightTree.Add(value);
                else LeftTree.Add(value);
            }
        }

        public override void Remove(T value) {
            throw new System.NotImplementedException();
        }
    }
}