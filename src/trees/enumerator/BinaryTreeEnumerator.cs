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
            if(nodeStack.Count > 0) {
                Node = nodeStack.Pop();
                PushNodes(this, Node.Right);
                return true;
            }

            return false;
        }

        public override void Dispose() {
            base.Dispose();
            nodeStack.Clear();
            Node = null;
        }

        public override void Reset() {
            nodeStack.Clear();
            PushNodes(this, Tree.Node);
        }

        private static void PushNodes(BinaryTreeEnumerator<T> it,  BinaryTreeNode<T> node) {
            while(node != null) {
                it.nodeStack.Push(node);
                node = node.Left;
            }
        }
    }
}