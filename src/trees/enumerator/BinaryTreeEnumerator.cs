using Chaotx.Collections.Trees.Nodes;
using System.Collections.Generic;

namespace Chaotx.Collections.Trees {
    internal class BinaryTreeEnumerator<T> : TreeEnumerator<T, BinaryTreeNode<T>>
        where T : struct, System.IComparable<T>
    {
        private Stack<BinaryTreeNode<T>> nodeStack = new Stack<BinaryTreeNode<T>>();

        public BinaryTreeEnumerator(BinaryTree<T> tree) : base(tree) {
            Reset();
        }

        public override bool MoveNext() {
            if(Node != null) {
                if(Node.Right != null) nodeStack.Push(Node.Right);
                if(Node.Left != null) nodeStack.Push(Node.Left);
            }

            bool stackEmpty = nodeStack.Count == 0;
            if(!stackEmpty) Node = nodeStack.Pop();
            return !stackEmpty;
        }

        public override void Dispose() {
            base.Dispose();
            nodeStack.Clear();
            Node = null;
        }

        public override void Reset() {
            nodeStack.Clear();
            Node = null;

            if(Tree.Node != null)
                nodeStack.Push(Tree.Node);
        }
    }
}