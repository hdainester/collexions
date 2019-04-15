using System.Collections.Generic;
using System.Text;
using System;

namespace Chaotx.Collections.Trees {
    using Nodes;

    public class BinaryTree<T> : Tree<T, BinaryTreeNode<T>>
    where T : struct, System.IComparable<T> {
        public BinaryTree(params T[] values) : base(values) {}

        public override void Add(T value) {
            if(Node == null)
                Node = new BinaryTreeNode<T>(value);
            else base.Add(value);
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
            T?[][] field = new T?[tree.Node.Height][];
            int width = (int)Math.Pow(2, tree.Node.Height-1)*2 - 1;

            for(int h = 0; h < tree.Node.Height; ++h)
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
            } else return node.Height;

            return Math.Max(maxHeightL, maxHeightR);
        }
    }
}