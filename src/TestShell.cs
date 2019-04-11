using Chaotx.Collections.Trees;

using System.Linq;
using System;

public class TestShell {
    public bool IsRunning {get; private set;}
    public AVLTree<int> Tree {get; private set;} = new AVLTree<int>();

    public void Run() {
        IsRunning = true;
        while(IsRunning)
            Read();
    }

    private void Read() {
        Console.Write(">> ");
        ParseArgs(Console.ReadLine().Split(' '));
    }

    private void ParseArgs(string[] args) {
        if(args.Length == 0) return;
        bool treeChanged = false;
        string cmd = args[0];

        switch(cmd) {
            case "add":
                try {
                    for(int i = 1; i < args.Length; ++i) {
                        Tree.Add(Int32.Parse(args[i]));
                        treeChanged = true;

                        while(Tree.Node.Parent != null)
                            Tree = Tree.Node.Parent.Tree as AVLTree<int>;
                    }
                } catch(Exception) {
                    Console.WriteLine(">> usage: add {<number>}+");
                }

                break;

            case "rem":
                try {
                    for(int i = 1; i < args.Length; ++i) {
                        Tree.Remove(Int32.Parse(args[i]));
                        treeChanged = true;

                        while(Tree.Node.Parent != null)
                            Tree = Tree.Node.Parent.Tree as AVLTree<int>;
                    }
                } catch(Exception) {
                    Console.WriteLine(">> not implemented");
                    // Console.WriteLine(">> usage: rem {<number>}+");
                }

                break;

            case "res":
                Tree = new AVLTree<int>();
                Console.WriteLine(">> tree has been reset");
                break;

            case "quit":
                IsRunning = false;
               break;

            case "help":
                Console.WriteLine(">> [{0, -4}]: Add a <number> to the Tree", "add");
                Console.WriteLine(">> [{0, -4}]: Remove a <number> from the Tree", "rem");
                Console.WriteLine(">> [{0, -4}]: Reset the Tree", "res");
                Console.WriteLine(">> [{0, -4}]: Quit the Shell", "quit");
                break;

            default:
                Console.WriteLine(">> unknown command");
                break;
        }
        
        if(treeChanged)
            PrintTree();
    }

    private void PrintTree() {
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine(Tree);
        Console.WriteLine("---------------------------------------------------------");
    }
}