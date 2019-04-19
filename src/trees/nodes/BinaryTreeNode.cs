using System.Collections.Generic;

namespace Chaotx.Collections.Trees.Nodes {
    public class BinaryTreeNode<T> : TreeNode<T, BinaryTreeNode<T>>
    where T : struct, System.IComparable<T> {
        public BinaryTreeNode<T> Left {get; set;}
        public BinaryTreeNode<T> Right {get; set;}        

        internal BinaryTreeNode() : this(default(T)) {}
        internal BinaryTreeNode(T value) : this(value, null) {}
        internal BinaryTreeNode(T value, BinaryTreeNode<T> parent) : base(value, parent) {}

        public override void Add(T value, out BinaryTreeNode<T> newNode) {
            newNode = this;
            int res = value.CompareTo(Value);
            if(res == 0) return;

            if(res > 0 && Right == null || res < 0 && Left == null) {
                newNode = new BinaryTreeNode<T>(value, this);
                if(res > 0) Right = newNode;
                else Left = newNode;
                UpdateHeight(this);
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
                    RemoveNode(node, out oldNode);
                    UpdateHeight(node.Parent);
                    return;
                }
            }
        }

        // http://www.mathcs.emory.edu/~cheung/Courses/323/Syllabus/Trees/AVL-delete.html
        internal static void RemoveNode(BinaryTreeNode<T> node, out BinaryTreeNode<T> oldNode) {
            BinaryTreeNode<T> anc = node.Parent;
            oldNode = node;
                
            if(node.Left != null && node.Right != null) {
                BinaryTreeNode<T> pred = node.Right;
                while(pred.Left != null) pred = pred.Left;
                node.Value = pred.Value;
                RemoveNode(pred, out oldNode);
            } else if(node.Left == null && node.Right == null && anc != null) {
                if(anc.Left == node)
                    anc.Left = null;
                else anc.Right = null;
            } else {
                if(node.Left != null)
                    node.Left.Parent = anc;

                else if(node.Right != null)
                    node.Right.Parent = anc;
                    
                if(anc != null) {
                    if(anc.Left == node)
                        anc.Left = node.Left == null ? node.Right : node.Left;
                    else 
                        anc.Right = node.Left == null ? node.Right : node.Left;
                }
            }
        }

        internal static void UpdateHeight(BinaryTreeNode<T> node) {
            if(node == null) return;
            int oldHeight = node.Height;

            node.Height = System.Math.Max(
                node.Left != null ? node.Left.Height : 0,
                node.Right != null ? node.Right.Height : 0) + 1;

            if(node.Height != oldHeight)
                UpdateHeight(node.Parent);
        }
    }
}