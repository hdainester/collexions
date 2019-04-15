using System.Collections.Generic;
using System.Text;
using System;

namespace Chaotx.Collections.Trees {
    using Nodes;

    public class BinaryTree<T> : Tree<T, BinaryTree<T>, BinaryTreeNode<T>>
    where T : struct, System.IComparable<T> {
        public static readonly BinaryTree<T> EmptyTree = new BinaryTree<T>();

        private BinaryTreeNode<T> node;
        internal override BinaryTreeNode<T> Node {
            get => node;
            set => node = value;
        }

        public BinaryTree(params T[] values) : base(values) {}

        public override void Add(T value) {
            // BinaryTreeNode<T> newNode = null;
            Add(value, new BinaryTreeNode<T>());
        }

        internal void Add(T value, BinaryTreeNode<T> newNode) {
            if(Node == null) {
                // new BinaryTreeNode<T>(value, this);
                newNode.Value = value;
                newNode.Tree = this;
                Node = newNode;
                // newNode = node;
                Height = 1;
                return;
            }

            int res = value.CompareTo(Node.Value);
            if(res > 0 && Node.Right == null || res < 1 && Node.Left == null) {
                // newNode = new BinaryTreeNode<T>(value);
                newNode.Value = value;
                newNode.Parent = Node;
                newNode.Tree.Height = 1;

                if(Node.Left == null && Node.Right == null) {
                    // update height of ancestors
                    BinaryTreeNode<T> ancestor = Node;
                    while(ancestor != null && (newNode.Depth - ancestor.Depth) >= ancestor.Tree.Height) {
                        ++ancestor.Tree.Height;
                        ancestor = ancestor.Parent;
                    }
                }

                if(res > 0) Node.Right = newNode;
                else Node.Left = newNode; // TODO (for no duplicate values will traverse to the left)
            } else {
                if(res > 0) Node.Right.Tree.Add(value, newNode);
                else Node.Left.Tree.Add(value, newNode); // TODO (for no duplicate values will traverse to the left)
            }
        }

        public override void Remove(T value) {
            throw new System.NotImplementedException();
        }

        public override bool Contains(T value) {
            throw new System.NotImplementedException();
        }

        public override string ToString() {
            T?[][] field = ToField(this);
            StringBuilder sb = new StringBuilder();

            int m = 0;
            string s;

            for(int x, y = 0; y < field.Length; ++y) {
                for(x = 0; x < field[0].Length; ++x) {
                    s = field[y][x].ToString();
                    if(s.Length > m) m = s.Length;
                }
            }

            for(int x, y = 0; y < field.Length; ++y) {
                for(x = 0; x < field[0].Length; ++x) {
                    s = field[y][x].ToString();
                    sb.AppendFormat("{0, -" + (m - s.Length)/2 + "}{1, -" + m + "}", " ", s);
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }

        internal static T?[][] ToField(BinaryTree<T> tree) {
            while(tree.Node.Parent != null) tree = tree.Node.Parent.Tree;
            T?[][] field = new T?[tree.Height][];
            int width = (int)Math.Pow(2, tree.Height-1)*2 - 1;

            for(int h = 0; h < tree.Height; ++h)
                field[h] = new T?[width];

            FillField(tree, field, field[0].Length/2);
            return field;
        }

        private static void FillField(BinaryTree<T> tree, T?[][] field, int i) {
            FillField(tree.Node, tree.Node, field, i);
        }

        private static void FillField(BinaryTreeNode<T> rootNode, BinaryTreeNode<T> node, T?[][] field, int i) {
            if(node == null) return;
            field[node.Depth][i] = node.Value;
            int height = GetMaxLevelHeight(rootNode, node.Depth);
            FillField(rootNode, node.Left, field, i - (int)Math.Pow(2, height-2));
            FillField(rootNode, node.Right, field, i + (int)Math.Pow(2, height-2));
        }

        private static int GetMaxLevelHeight(BinaryTreeNode<T> node, int level) {
            if(node == null) return 0;
            int maxHeightL = 0;
            int maxHeightR = 0;

            if(node.Depth < level) {
                maxHeightL = GetMaxLevelHeight(node.Left, level);
                maxHeightR = GetMaxLevelHeight(node.Right, level);
            } else return node.Tree.Height;

            return Math.Max(maxHeightL, maxHeightR);
        }

        internal void IncHeight() {
            BinaryTree<T> sib = Node.Parent == null ? null
                : Node.Parent.Left.Tree == this
                ? Node.Right.Tree : Node.Left.Tree;

            if(sib != null && sib.Height <= Height)
                Node.Parent.Tree.IncHeight();

            ++Height;
        }

        internal void DecHeight() {
            BinaryTree<T> sib = Node.Parent == null ? null
                : Node.Parent.Left.Tree == this
                ? Node.Right.Tree : Node.Left.Tree;

            if(sib != null && sib.Height < Height)
                Node.Parent.Tree.DecHeight();

            --Height;
        }
    }
}