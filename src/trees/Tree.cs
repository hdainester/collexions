using System.Collections.Generic;
using System.Text;
using System;

namespace Chaotx.Collections.Trees {
    public abstract class Tree<T> where T : struct, System.IComparable<T> {
        public Tree<T> RootTree {get; protected set;}
        public Tree<T> LeftTree {get; protected set;}
        public Tree<T> RightTree {get; protected set;}
        public Tree<T> ParentTree {get; protected set;}

        public int Height {get; protected set;}
        public int Depth {get; protected set;}
        public T Value {get; protected set;}

        private List<int> maxLevelHeight = new List<int>();
        public List<int> MaxLevelHeight {
            get {return ParentTree == null
                ? maxLevelHeight
                : ParentTree.MaxLevelHeight;}
            protected set {maxLevelHeight = value;}
        }

        public abstract void Add(T value);
        public abstract void Remove(T value);

        public Tree(params T[] values) {
            Add(values);
        }

        public void Add(params T[] values) {
            foreach(var value in values)
                Add(value);
        }

        public override string ToString() {
            T?[][] field = ToField();
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

        public delegate void TreeAction(Tree<T> tree);
        public void Traverse(TreeAction action) {
            Traverse(this, action, 0 ,0);
        }

        protected T?[][] ToField() {
            T?[][] field = new T?[Height][];
            int width = (int)Math.Pow(2, Height-1)*2 - 1;

            for(int h = 0; h < Height; ++h)
                field[h] = new T?[width];

            FillField(this, field, field[0].Length/2);
            return field;
        }

        private static void FillField(Tree<T> tree, T?[][] field, int i) {
            if(tree == null) return;
            field[tree.Depth][i] = tree.Value;
            int height = tree.MaxLevelHeight[tree.Depth];
            FillField(tree.LeftTree, field, i - (int)Math.Pow(2, height-2));
            FillField(tree.RightTree, field, i + (int)Math.Pow(2, height-2));
        }

        protected void Traverse(Tree<T> tree, TreeAction action, int left, int right) {
            if(tree == null) return;
            action(tree);
            Traverse(tree.LeftTree, action, left+1, right);
            Traverse(tree.RightTree, action, left, right+1);
        }

        internal void _IncHeight() {
            ++Height;
        }
    }
}