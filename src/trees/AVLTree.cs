using System;

namespace Chaotx.Collections.Trees {
    using Nodes;

    public class AVLTree<T> : BinaryTree<T> where T : struct, System.IComparable<T> {
        public override void Add(T value) {
            if(Node == null)
                base.Add(value);
            else {
                BinaryTreeNode<T> newNode = null;
                Node.Add(value, out newNode);

                BinaryTreeNode<T> top = newNode.Parent;
                BinaryTreeNode<T> cen = newNode;
                BinaryTreeNode<T> bot = null;
                int bal;

                while(top != null) {
                    bal = (top.Right == null ? 0: top.Right.Height)
                        - (top.Left == null ? 0 : top.Left.Height);

                    if(Math.Abs(bal) == 2) {
                        if(top.Left == cen) {
                            if(cen.Left == bot)
                                RotateRight(top, cen, bot);
                            else {
                                RotateLeft(cen, bot, null);
                                RotateRight(top, bot, cen);
                            }
                        } else {
                            if(cen.Right == bot)
                                RotateLeft(top, cen, bot);
                            else {
                                RotateRight(cen, bot, null);
                                RotateLeft(top, bot, cen);
                            }
                        }

                        break;
                    }

                    bot = cen;
                    cen = top;
                    top = top.Parent;
                }

                while(Node.Parent != null)
                    Node = Node.Parent;
            }
        }

        internal static void RotateLeft(
            BinaryTreeNode<T> top,
            BinaryTreeNode<T> cen,
            BinaryTreeNode<T> bot)
        {
            BinaryTreeNode<T> anc = top.Parent;
            if(bot == null) cen.Height = top.Height;

            int h = top.Height;
            top.Height = Math.Max(
                top.Left == null ? 0 : top.Left.Height,
                cen.Left == null ? 0 : cen.Left.Height) + 1;

            top.Right = cen.Left;
            if(cen.Left != null) cen.Left.Parent = top;

            cen.Left = top;
            cen.Parent = anc;
            top.Parent = cen;

            if(anc != null) {
                if(anc.Left == top) anc.Left = cen;
                else anc.Right = cen;
                h -= cen.Height;
                if(h < 0) anc.IncHeight();
                else if(h > 0) anc.DecHeight();
            }
        }

        internal static void RotateRight(
            BinaryTreeNode<T> top,
            BinaryTreeNode<T> cen,
            BinaryTreeNode<T> bot)
        {
            BinaryTreeNode<T> anc = top.Parent;
            if(bot == null) cen.Height = top.Height;

            int h = top.Height;
            top.Height = Math.Max(
                top.Right == null ? 0 : top.Right.Height,
                cen.Right == null ? 0 : cen.Right.Height) + 1;

            top.Left = cen.Right;
            if(cen.Right != null) cen.Right.Parent = top;

            cen.Right = top;
            cen.Parent = anc;
            top.Parent = cen;

            if(anc != null) {
                if(anc.Left == top) anc.Left = cen;
                else anc.Right = cen;
                h -= cen.Height;
                if(h < 0) anc.IncHeight();
                else if(h > 0) anc.DecHeight();
            }
        }
    }
}