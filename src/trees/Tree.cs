using System.Collections.Generic;
using System.Text;
using System;

namespace Chaotx.Collections.Trees {
    using System.Collections;
    using Nodes;

    public abstract class Tree<ValueType, TreeType, NodeType>
        : ICollection<ValueType>
        where ValueType : struct, System.IComparable<ValueType>
        where TreeType : Tree<ValueType, TreeType, NodeType>
        where NodeType : TreeNode<ValueType, TreeType, NodeType>
    {
        internal abstract NodeType Node {get; set;}
        public int Height {get; internal set;}

        public int Count => throw new NotImplementedException();
        public bool IsReadOnly => throw new NotImplementedException();

        public abstract void Add(ValueType value);
        public abstract void Remove(ValueType value);
        public abstract bool Contains(ValueType value);

        public Tree(params ValueType[] values) {
            Add(values);
        }

        public void Add(params ValueType[] values) {
            // TODO: this is a temporary workaround to prevent
            // AVL-Trees from adding values into subtrees after
            // the Tree referenced by 'this' has been rotated
            // into lower levels
            int initDepth = Node == null ? -1 : Node.Depth;
            Tree<ValueType, TreeType, NodeType> tree = this;
            foreach(var value in values) {
                tree.Add(value);
                while(tree.Node.Parent != null)
                    tree = tree.Node.Parent.Tree;
            }

            // foreach(var value in values)
            //     Add(value);
        }

        public void Remove(params ValueType[] values) {
            foreach(var value in values)
                Remove(value);
        }

        public void Clear() {
            throw new NotImplementedException();
        }

        public void CopyTo(ValueType[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        bool ICollection<ValueType>.Remove(ValueType item) {
            throw new NotImplementedException();
        }

        public IEnumerator<ValueType> GetEnumerator() {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }
    }
}