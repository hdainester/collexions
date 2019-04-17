using System.Collections.Generic;

namespace Chaotx.Collections.Trees.Nodes {
    public class BinaryTreeNode<T> : TreeNode<T, BinaryTreeNode<T>>
    where T : struct, System.IComparable<T> {
        public BinaryTreeNode<T> Left {get; set;}
        public BinaryTreeNode<T> Right {get; set;}        

        internal BinaryTreeNode() : this(default(T)) {}
        internal BinaryTreeNode(T value) : base(value) {}

        public override void Add(T value, out BinaryTreeNode<T> newNode) {
            newNode = this;
            int res = value.CompareTo(Value);
            if(res == 0) return;

            if(res > 0 && Right == null || res < 1 && Left == null) {
                newNode = new BinaryTreeNode<T>(value);
                newNode.Value = value;
                newNode.Parent = this;

                if(res > 0) Right = newNode;
                else Left = newNode;
                newNode.IncHeight();
            } else {
                if(res > 0) Right.Add(value, out newNode);
                else Left.Add(value, out newNode);
            }
        }

        public override void Remove(T value, out BinaryTreeNode<T> oldNode) {
            Stack<BinaryTreeNode<T>> nodeStack = new Stack<BinaryTreeNode<T>>();
            nodeStack.Push(this);
            oldNode = null;
            int cmp;

            BinaryTreeNode<T> node = this;
            while(node != null) {
                cmp = node.Value.CompareTo(value);

                if(cmp > 0)
                    node = node.Left;
                else if(cmp < 0)
                    node = node.Right;
                else {
                    RemoveNode(node);
                    oldNode = node;
                    return;
                }
            }
        }

        // http://www.mathcs.emory.edu/~cheung/Courses/323/Syllabus/Trees/AVL-delete.html
        internal static void RemoveNode(BinaryTreeNode<T> node) {
            BinaryTreeNode<T> anc = node.Parent;

            if(node.Left == null && node.Right == null) {
                if(anc.Left == node) {
                    if(anc.Right == null)
                        anc.DecHeight();

                    anc.Left = null;
                } else {
                    if(anc.Left == null)
                        anc.DecHeight();

                    anc.Right = null;
                }
            } else if(node.Left != null && node.Right != null) {
                BinaryTreeNode<T> pred = node.Right;
                while(pred.Left != null) pred = pred.Left;
                node.Value = pred.Value;
                RemoveNode(pred);
            } else {
                if(anc.Left == node) {
                    if(anc.Left.Height > anc.Left.Height)
                        anc.DecHeight();

                    anc.Left = node.Left == null ? node.Right : node.Left;
                } else {
                    if(anc.Right.Height > anc.Left.Height)
                        anc.DecHeight();

                    anc.Right = node.Left == null ? node.Right : node.Left;
                }
            }
        }

        public void IncHeight() {
            if(Parent != null) {
                BinaryTreeNode<T> sib = Parent.Left == this
                    ? Parent.Right : Parent.Left;

                if(sib == null || sib.Height <= Height)
                    Parent.IncHeight();
            }

            ++Height;
        }

        public void DecHeight() {
            if(Parent != null) {
                BinaryTreeNode<T> sib = Parent.Left == this
                    ? Parent.Right : Parent.Left;

                if(sib == null || sib.Height < Height)
                    Parent.DecHeight();
            }

            --Height;
        }
    }
}