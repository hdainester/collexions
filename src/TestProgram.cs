using Chaotx.Collections.Trees;
using System;

public class TestProgram {
    public static void Main(string[] args) {
        // TestBinaryTree();
        // TestAVLTree();
        new TestShell().Run();
    }

    public static void TestBinaryTree() {
        BinaryTree<int> bt = new BinaryTree<int>();
        // bt.Add(5, 3, 6, 1, 2, 4, 7);
        bt.Add(8, 12, 10, 9, 11, 14, 13, 15, 4, 2, 1, 3, 6, 5, 7);
        Console.WriteLine(bt);
    }

    public static void TestAVLTree() {
        AVLTree<int> at = new AVLTree<int>();
        at.Add(1, 2, 3, 4, 5, 6, 7);
        // at.Add(7, 6, 5, 4, 3, 2, 1);
        // at.Add(3, 1, 2);
        // at.Add(1, 3, 2);
        // at.Add(1, 2, 3, 5, 4);
        // at.Add(3, 4, 5, 1, 2);
        Console.WriteLine(at);
    }
}