using System.Collections.Generic;
using System.Text;
using System;

namespace Chaotx.Collections.Trees {
    using System.Collections;
    using Nodes;

    public abstract class Tree<T, N> : ICollection<T>
        where T : struct, System.IComparable<T>
        where N : TreeNode<T, N>
    {
        internal N Node {get; set;}
        public virtual int Height => Node == null ? 0 : Node.Height;
        public virtual bool IsReadOnly => false;
        public int Count {get; private set;}
        
        public Tree(params T[] values) {
            Add(values);
        }

        public virtual void Add(T value) {
            ++Count;
            N newNode = null;
            Node.Add(value, out newNode);
        }

        public virtual bool Remove(T value) {
            N oldNode = null;
            Node.Remove(value, out oldNode);
            if(oldNode != null) --Count;
            return oldNode != null;
        }

        public void Add(params T[] values) {
            foreach(var value in values)
                Add(value);
        }

        public void Remove(params T[] values) {
            foreach(var value in values)
                Remove(value);
        }

        public void Clear() {
            Node = null;
        }

        public void CopyTo(T[] array, int arrayIndex) {
            foreach(T value in this)
                array[arrayIndex++] = value;
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public abstract bool Contains(T value);
        public abstract IEnumerator<T> GetEnumerator();
    }
}