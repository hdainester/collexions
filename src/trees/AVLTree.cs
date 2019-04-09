using System;

namespace Chaotx.Collections.Trees {
    using Nodes;

    public class AVLTree<T> : BinaryTree<T> where T : struct, System.IComparable<T> {
        public override void Add(T value) {
            BinaryTreeNode<T> newNode = null;
            base.Add(value, ref newNode);

            BinaryTreeNode<T> top = newNode.Parent;
            BinaryTreeNode<T> cen = newNode;
            BinaryTreeNode<T> bot = null;

            while(top != null) {
                int bal = (top.Right == null ? 0: top.Right.Tree.Height)
                    - (top.Left == null ? 0 : top.Left.Tree.Height);

                if(Math.Abs(bal) == 2) {
                    int res = bot == null ? -1 : cen.Value.CompareTo(bot.Value);
                    BinaryTreeNode<T> piv = res < 0 ? cen : bot;
                    BinaryTreeNode<T> par = piv.Parent;

                    if(piv == par.Left)
                        RotateRight(top, cen, bot, piv);
                    else
                        RotateLeft(top, cen, bot, piv);

                    break;
                }

                bot = cen;
                cen = top;
                top = top.Parent;
            }
        }

        internal static void RotateLeft(
            BinaryTreeNode<T> top,
            BinaryTreeNode<T> cen,
            BinaryTreeNode<T> bot,
            BinaryTreeNode<T> piv)
        {
            BinaryTreeNode<T> anc = top.Parent;

            if(piv == bot)
                RotateRight(cen, bot, null, piv);

            top.Tree.Height = Math.Max(
                top.Left == null ? 0 : top.Left.Tree.Height,
                piv.Left == null ? 0 : piv.Left.Tree.Height) + 1;
            top.Right = piv.Left;

            // piv.Height = Math.Max(piv.Height, top.Left.Height) + 1;
            piv.Left = top;

            piv.Parent = anc;
            piv.Parent = anc;
            top.Parent = piv;

            if(anc != null) {
                anc.Left.Tree = piv.Tree;
                anc.Tree.Height = Math.Max(anc.Tree.Height, piv.Tree.Height+1);
            }
        }

        internal static void RotateRight(
            BinaryTreeNode<T> top,
            BinaryTreeNode<T> cen,
            BinaryTreeNode<T> bot,
            BinaryTreeNode<T> piv)
        {
            BinaryTreeNode<T> anc = top.Parent;

            if(piv == bot)
                RotateLeft(cen, bot, null, piv);

            top.Tree.Height = Math.Max(
                top.Right == null ? 0 : top.Right.Tree.Height,
                piv.Right == null ? 0 : piv.Right.Tree.Height) + 1;
            top.Left = piv.Right;

            // piv.Height = Math.Max(piv.Height, top.Height+1);
            piv.Right.Tree = top.Tree;

            piv.Parent = anc;
            top.Parent = piv;

            if(anc != null) {
                anc.Right.Tree = piv.Tree;
                anc.Tree.Height = Math.Max(anc.Tree.Height, piv.Tree.Height+1);
            }
        }
    }
}