using System;

namespace Chaotx.Collections.Trees {
    using Nodes;

    public class AVLTree<T> : BinaryTree<T> where T : struct, System.IComparable<T> {
        public override void Add(T value) {
            AVLTreeNode<T> newNode = new AVLTreeNode<T>();
            base.Add(value, newNode);

            BinaryTreeNode<T> top = newNode.Parent;
            BinaryTreeNode<T> cen = newNode;
            BinaryTreeNode<T> bot = null;

            while(top != null) {
                int bal = (top.Right == null ? 0: top.Right.Tree.Height)
                    - (top.Left == null ? 0 : top.Left.Tree.Height);

                if(Math.Abs(bal) == 2) {
                    if(top.Left == cen) {
                        if(cen.Left == bot)
                            RotateRight(top, cen, bot, cen);
                        else
                            RotateRight(top, cen, bot, bot);
                    } else {
                        if(cen.Right == bot)
                            RotateLeft(top, cen, bot, cen);
                        else
                            RotateLeft(top, cen, bot, bot);
                    }

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

            if(piv == bot) {
                RotateRight(cen, bot, null, piv);
                BinaryTreeNode<T> n = cen;
                cen = bot;
                bot = n;
            }

            if(bot == null)
                piv.Tree.Height = top.Tree.Height;

            top.Tree.Height = Math.Max(
                top.Left == null ? 0 : top.Left.Tree.Height,
                piv.Left == null ? 0 : piv.Left.Tree.Height) + 1;

            top.Right = piv.Left;

            if(piv.Left != null)
                piv.Left.Parent = top;

            piv.Left = top;
            piv.Parent = anc;
            top.Parent = piv;

            if(anc != null) {
                if(bot == null) anc.Left = piv;
                else anc.Right = piv;
                anc.Tree.Height = Math.Max(anc.Left == null ? 0 : anc.Left.Tree.Height, piv.Tree.Height) + 1;
            }
        }

        internal static void RotateRight(
            BinaryTreeNode<T> top,
            BinaryTreeNode<T> cen,
            BinaryTreeNode<T> bot,
            BinaryTreeNode<T> piv)
        {
            BinaryTreeNode<T> anc = top.Parent;

            if(piv == bot) {
                RotateLeft(cen, bot, null, piv);
                BinaryTreeNode<T> n = cen;
                cen = bot;
                bot = n;
            }

            if(bot == null) piv.Tree.Height = top.Tree.Height;
            top.Tree.Height = Math.Max(
                top.Right == null ? 0 : top.Right.Tree.Height,
                piv.Right == null ? 0 : piv.Right.Tree.Height) + 1;

            top.Left = piv.Right;

            if(piv.Right != null)
                piv.Right.Parent = top;

            piv.Right = top;
            piv.Parent = anc;
            top.Parent = piv;

            if(anc != null) {
                if(bot == null) anc.Right = piv;
                else anc.Left = piv;
                anc.Tree.Height = Math.Max(anc.Right == null ? 0 : anc.Right.Tree.Height, piv.Tree.Height) + 1;
            }
        }
    }
}