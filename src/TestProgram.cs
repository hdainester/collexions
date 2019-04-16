using Chaotx.Collections.Trees;
using System;

public class TestProgram {
    public static void Main(string[] args) {
        // TestBinaryTree();
        // TestAVLTree();
        new TestShell().Run(); // 5 7 9 3 2  4
    }

    public static void TestBinaryTree() {
        BinaryTree<int> bt = new BinaryTree<int>();
        bt.Add(8, 12, 10, 9, 11, 14, 13, 15, 4, 2, 1, 3, 6, 5, 7);
        Console.Write(bt);

        foreach(int i in bt)
            Console.Write(i + " ");

        Console.WriteLine();
    }

    public static void TestAVLTree() {
        AVLTree<int> at = new AVLTree<int>();
        at.Add(1, 2, 3, 4, 5, 6, 7);
        Console.Write(at);

        foreach(int i in at)
            Console.Write(i + " ");

        Console.WriteLine();
    }
}