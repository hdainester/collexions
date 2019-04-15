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
        public int Count => throw new NotImplementedException();
        public bool IsReadOnly => throw new NotImplementedException();
        
        public abstract bool Contains(T value);

        public Tree(params T[] values) {
            Add(values);
        }

        public virtual void Add(T value) {
            N newNode = null;
            Node.Add(value, out newNode);
        }

        public virtual void Remove(T value) {
            N oldNode = null;
            Node.Remove(value, out oldNode);
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
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item) {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator() {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }
    }
}