using System.Collections.Generic;
using System.Collections;

namespace Chaotx.Collections.Trees.Nodes {
    public abstract class TreeNode<T, N>
        where T : struct, System.IComparable<T>
        where N : TreeNode<T, N>
    {
        public virtual T Value {get; set;}
        public virtual N Parent {get; set;}
        public virtual int Depth => Parent == null ? 0 : Parent.Depth+1;
        public int Height {get; internal set;}

        internal TreeNode() : this(default(T)) {}
        internal TreeNode(T value) {
            Value = value;
        }

        public abstract void Add(T value, out N newNode);
        public abstract void Remove(T value, out N oldNode);
    }
}