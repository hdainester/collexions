using System.Collections.Generic;
using System.Text;
using System;

namespace Chaotx.Collections.Trees {
    public abstract class Tree<T> where T : struct, System.IComparable<T> {
        internal Tree<T> Parent {get; set;}
        internal TreeNode<T> Node {get; set;}

        public int Height {get; internal set;}

        public abstract void Add(T value);
        public abstract void Remove(T value);
        public abstract bool Contains(T value);

        public Tree(params T[] values) {
            Add(values);
        }

        public void Add(params T[] values) {
            foreach(var value in values)
                Add(value);
        }

        public void Remove(params T[] values) {
            foreach(var value in values)
                Remove(value);
        }
    }
}