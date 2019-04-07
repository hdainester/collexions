using System.Collections.Generic;
using System.Text;
using System;

namespace Chaotx.Collections.Trees {
    public class BinaryTree<T> : Tree<T> where T : struct, System.IComparable<T> {
        internal BinaryTree<T> Left {get; set;}
        internal BinaryTree<T> Right {get; set;}

        public BinaryTree() : this(null) {}
        internal BinaryTree(BinaryTreeNode<T> rootNode) {
            Node = rootNode;
            Height = 1;
        }

        public override void Add(T value) {
            if(Node == null) {
                Node = new BinaryTreeNode<T>(value);
                Height = 1;
                return;
            }

            int res = value.CompareTo(Node.Value);
            if(res > 0 && Right == null || res < 1 && Left == null) {
                BinaryTree<T> newTree = new BinaryTree<T>(new BinaryTreeNode<T>(value));
                newTree.Node.Depth = Node.Depth+1;
                newTree.Parent = this;

                if(Left == null && Right == null) {
                    Tree<T> tree = this;
                    while(tree != null && (newTree.Node.Depth - tree.Node.Depth) >= tree.Height) {
                        ++tree.Height;
                        tree = tree.Parent;
                    }
                }

                if(res > 0) Right = newTree;
                else Left = newTree;
            } else {
                if(res > 0) Right.Add(value);
                else Left.Add(value);
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
            T?[][] field = new T?[tree.Height][];
            int width = (int)Math.Pow(2, tree.Height-1)*2 - 1;

            for(int h = 0; h < tree.Height; ++h)
                field[h] = new T?[width];

            FillField(tree, field, field[0].Length/2);
            return field;
        }

        private static void FillField(BinaryTree<T> tree, T?[][] field, int i) {
            FillField(tree, tree, field, i);
        }

        private static void FillField(BinaryTree<T> root, BinaryTree<T> tree, T?[][] field, int i) {
            if(tree == null) return;
            field[tree.Node.Depth][i] = tree.Node.Value;
            int height = GetMaxLevelHeight(root, tree.Node.Depth);
            FillField(root, tree.Left, field, i - (int)Math.Pow(2, height-2));
            FillField(root, tree.Right, field, i + (int)Math.Pow(2, height-2));
        }

        private static int GetMaxLevelHeight(BinaryTree<T> tree, int level) {
            if(tree == null) return 0;
            int maxHeightL = 0;
            int maxHeightR = 0;

            if(tree.Node.Depth < level) {
                maxHeightL = GetMaxLevelHeight(tree.Left, level);
                maxHeightR = GetMaxLevelHeight(tree.Right, level);
            } else return tree.Height;

            return Math.Max(maxHeightL, maxHeightR);
        }
    }
}