namespace Chaotx.Collections.Trees {
    public class BinaryTree<T> : Tree<T> where T : struct, System.IComparable<T> {
        public BinaryTree() : this(default(T)) {}
        public BinaryTree(T value) {
            RootTree = this;
            Value = value;
            Height = 1;
            MaxLevelHeight.Add(1);
        }

        public override void Add(T value) {
            int res = value.CompareTo(Value);

            if(res > 0 && RightTree == null || res < 1 && LeftTree == null) {
                BinaryTree<T> newTree = new BinaryTree<T>(value);
                newTree.RootTree = RootTree;
                newTree.ParentTree = this;
                newTree.Depth = Depth+1;

                if(LeftTree == null && RightTree == null) {
                    if(newTree.Depth >= MaxLevelHeight.Count)
                        MaxLevelHeight.Add(1);

                    Tree<T> tree = this;
                    while(tree != null && (newTree.Depth - tree.Depth) >= tree.Height) {
                        tree._IncHeight();

                        if(tree.Height > MaxLevelHeight[tree.Depth])
                            MaxLevelHeight[tree.Depth] = tree.Height;

                        tree = tree.ParentTree;
                    }
                }

                if(res > 0) RightTree = newTree;
                else LeftTree = newTree;
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