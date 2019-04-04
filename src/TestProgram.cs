using Chaotx.Collections.Trees;

using System;

public class TestProgram {
    public static void Main(string[] args) {
        BinaryTree<int> bt = new BinaryTree<int>(8);
        bt.Add(5);
        bt.Add(10);
        bt.Add(4);
        bt.Add(6);
        bt.Add(9);
        bt.Add(11);

        Console.WriteLine(bt);
    }
}