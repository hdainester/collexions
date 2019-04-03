namespace Chaotx.Collections.Trees {
    public abstract class Tree<T> where T : System.IComparable<T> {
        // internal class Node  {
        //     public T Value {get;}
        //     public Node Left {get; private set;}
        //     public Node Right {get; private set;}
        //     public Node Ancestor {get; private set;}
        //     public int Balance {get; protected set;}

        //     public Node(T value) {
        //         Value = value;
        //     }

        //     public virtual void ExpandRight(T value) {
        //         Left = new Node(value);
        //         Left.Ancestor = this;
        //     }

        //     public virtual void ExpandLeft(T value) {
        //         Right = new Node(value);
        //         Right.Ancestor = this;
        //     }
        // }

        public Tree<T> LeftTree {get; protected set;}
        public Tree<T> RightTree {get; protected set;}
        public T Value {get; protected set;}

        public int Height {get; protected set;}
        public int Depth {get; protected set;}

        public abstract void Add(T value);
        public abstract void Remove(T value);

        public override string ToString() {
            // TODO
            return null;
        }
    }
}