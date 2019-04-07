using Chaotx.Collections.Trees;
using System;

public class TestProgram {
    public static void Main(string[] args) {
        BinaryTree<int> bt = new BinaryTree<int>();
        bt.Add(8, 12, 10, 9, 11, 14, 13, 15, 4, 2, 1, 3, 6, 5, 7);
        // bt.Add(8, 12, 10, 1, 3, 6, 5, 7);
        // bt.Add(6, 4, 3, 2, 5, 9, 8, 7);
        Console.WriteLine(bt);
    }
}