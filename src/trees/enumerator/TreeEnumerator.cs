using System.Collections.Generic;
using System.Collections;
using System;

namespace Chaotx.Collections.Trees {
    using Nodes;

    internal abstract class TreeEnumerator<T, N> : IEnumerator<T>
        where T : struct, IComparable<T>
        where N : TreeNode<T, N>
    {
        protected Tree<T, N> Tree;
        protected N Node;

        public TreeEnumerator(Tree<T, N> tree) {
            Tree = tree;
            Node = Tree.Node;
        }

        public T Current {
            get {
                if(Node == null) throw new InvalidOperationException();
                else return Node.Value;
            }
        }

        object IEnumerator.Current {
            get {
                if(Node == null) throw new InvalidOperationException();
                else return Node.Value;
            }
        }

        public abstract bool MoveNext();

        public virtual void Dispose() {
            Node = null;
        }

        public virtual void Reset() {
            Node = Tree.Node;
        }
    }
}