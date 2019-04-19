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
                    bal = (top.Right != null ? top.Right.Height : 0)
                        - (top.Left != null ? top.Left.Height : 0);

                    if(Math.Abs(bal) > 1) {
                        Rotate(top, cen, bot);
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

        public override bool Remove(T value) {
            BinaryTreeNode<T> oldNode;
            Node.Remove(value, out oldNode);
            if(oldNode == null) return false;

            BinaryTreeNode<T> top = oldNode.Parent;
            BinaryTreeNode<T> cen;
            BinaryTreeNode<T> bot;
            BinaryTreeNode<T> anc;
            int bal;

            while(top != null) {
                cen = (top.Right != null ? top.Right.Height : 0)
                    > (top.Left != null ? top.Left.Height : 0)
                    ? top.Right : top.Left;

                bot = cen == null ? null
                    : (cen.Right != null ? cen.Right.Height : 0)
                    > (cen.Left != null ? cen.Left.Height : 0)
                    ? cen.Right : cen.Left;

                anc = top.Parent;
                bal = (top.Right != null ? top.Right.Height : 0)
                    - (top.Left != null ? top.Left.Height : 0);

                if(Math.Abs(bal) > 1)
                    Rotate(top, cen, bot);

                top = anc;
            }

            if(oldNode.Parent == null)
                Node = oldNode.Left != null && oldNode.Right == null ? oldNode.Left
                    : oldNode.Right != null && oldNode.Left == null ? oldNode.Right : null;
            else while(Node.Parent != null)
                Node = Node.Parent;

            --Count;
            return true;
        }

        internal static void Rotate(
            BinaryTreeNode<T> top,
            BinaryTreeNode<T> cen,
            BinaryTreeNode<T> bot)
        {
            BinaryTreeNode<T> anc = top.Parent;

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

            BinaryTreeNode<T>.UpdateHeight(anc);
        }

        internal static void RotateLeft(
            BinaryTreeNode<T> top,
            BinaryTreeNode<T> cen,
            BinaryTreeNode<T> bot)
        {
            BinaryTreeNode<T> anc = top.Parent;
            if(cen.Left != null) cen.Left.Parent = top;

            top.Right = cen.Left;
            cen.Left = top;
            cen.Parent = anc;
            top.Parent = cen;

            if(anc != null) {
                if(anc.Left == top)
                    anc.Left = cen;
                else anc.Right = cen;
            }

            BinaryTreeNode<T>.UpdateHeight(top);
        }

        internal static void RotateRight(
            BinaryTreeNode<T> top,
            BinaryTreeNode<T> cen,
            BinaryTreeNode<T> bot)
        {
            BinaryTreeNode<T> anc = top.Parent;
            if(cen.Right != null) cen.Right.Parent = top;

            top.Left = cen.Right;
            cen.Right = top;
            cen.Parent = anc;
            top.Parent = cen;

            if(anc != null) {
                if(anc.Left == top)
                    anc.Left = cen;
                else anc.Right = cen;
            }

            BinaryTreeNode<T>.UpdateHeight(top);
        }
    }
}