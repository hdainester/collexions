using Chaotx.Collections.Trees;
using System;

public class TestProgram {
    public static void Main(string[] args) {
        // TestBinaryTree();
        TestAVLTree();
    }

    public static void TestBinaryTree() {
        BinaryTree<int> bt = new BinaryTree<int>();
        bt.Add(8, 12, 10, 9, 11, 14, 13, 15, 4, 2, 1, 3, 6, 5, 7);
        // bt.Add(8, 12, 10, 9, 11, 3, 2);
        Console.WriteLine(bt);
    }

    public static void TestAVLTree() {
        AVLTree<int> at = new AVLTree<int>();
        at.Add(1, 2, 3, 4);
        Console.WriteLine(at);
    }
}