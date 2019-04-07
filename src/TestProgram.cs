using Chaotx.Collections.Trees;

using System;

public class TestProgram {
    public static void Main(string[] args) {
        BinaryTree<int> bt = new BinaryTree<int>(8);
        bt.Add(12, 10, 9, 11, 14, 13, 15, 4, 2, 1, 3, 6, 5, 7);
        Console.WriteLine(bt);
    }
}