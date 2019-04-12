using Chaotx.Collections.Trees;

using System.Linq;
using System.IO;
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
        ParseArgs(Console.ReadLine().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    private void ParseArgs(string[] args) {
        if(args.Length == 0) return;
        string cmd = args[0];

        switch(cmd) {
            case "add":
                try {
                    if(args.Length < 2)
                        throw new Exception("missing args");

                    for(int i = 1; i < args.Length; ++i) {
                        Tree.Add(Int32.Parse(args[i]));

                        while(Tree.Node.Parent != null)
                            Tree = Tree.Node.Parent.Tree as AVLTree<int>;
                    }

                    Console.WriteLine(">> value{0} added", args.Length > 2 ? "s" : "");
                } catch(Exception) {
                    Console.WriteLine(">> usage: add {<number>}+");
                }

                break;

            case "rem":
                try {
                    if(args.Length < 2)
                        throw new Exception("missing args");

                    for(int i = 1; i < args.Length; ++i) {
                        Tree.Remove(Int32.Parse(args[i]));

                        while(Tree.Node.Parent != null)
                            Tree = Tree.Node.Parent.Tree as AVLTree<int>;
                    }

                    Console.WriteLine(">> value{0} removed", args.Length > 2 ? "s" : "");
                } catch(Exception) {
                    Console.WriteLine(">> not implemented");
                }

                break;

            case "res":
                Tree = new AVLTree<int>();
                Console.WriteLine(">> tree has been reset");
                break;

            case "print":
                if(args.Length == 1) {
                    PrintSeperator();
                    PrintTree(Console.Out);
                    PrintSeperator();
                } else {
                    try {
                        Stream stream = File.Open(args[1], FileMode.Create);
                        PrintTree(new StreamWriter(stream));
                        stream.Close();
                        Console.WriteLine(">> tree printed to file: \"{0}\"", args[1]);
                    } catch(Exception) {
                        Console.WriteLine(">> usage: print [<filename>]");
                    }
                }

                break;

            case "quit":
                IsRunning = false;
                break;

            case "help":
                Console.WriteLine(">> [{0, -4}]: Add a <number> to the Tree", "add");
                Console.WriteLine(">> [{0, -4}]: Remove a <number> from the Tree", "rem");
                Console.WriteLine(">> [{0, -4}]: Reset the Tree", "res");
                Console.WriteLine(">> [{0, -4}]: Prints the tree to console or a file", "print");
                Console.WriteLine(">> [{0, -4}]: Quit the Shell", "quit");
                break;

            default:
                Console.WriteLine(">> unknown command");
                break;
        }
    }

    private void PrintTree() {
        PrintTree(Console.Out);
    }

    private void PrintTree(TextWriter wt) {
        wt.WriteLine(Tree);
        wt.Flush();
    }

    private void PrintSeperator() {
        for(int i = 0; i < Console.WindowWidth; ++i)
            Console.Write("-");
    }
}