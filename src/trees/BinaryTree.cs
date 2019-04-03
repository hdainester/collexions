namespace Chaotx.Collections.Trees {
    public class BinaryTree<T> : Tree<T> where T : System.IComparable<T> {
        public BinaryTree() {
            Height = 0;
        }

        public BinaryTree(T value) {
            Value = value;
            Height = 1;
        }

        public override void Add(T value) {
            int res = value.CompareTo(Value);
            BinaryTree<T> newcomer = new BinaryTree<T>(value);

            if(res > 0) RightTree = newcomer;
            else LeftTree = newcomer;
            ++Height;
        }

        public override void Remove(T value) {
        }
    }
}