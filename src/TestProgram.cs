using Chaotx.Collections.Trees;
using System;

public class TestProgram {
    public static void Main(string[] args) {
        TestBinaryTree();
        
        for(int i = 0; i < Console.WindowWidth; ++i)
            Console.Write("-");

        TestAVLTree();
    }

    public static void TestBinaryTree() {
        BinaryTree<int> bt = new BinaryTree<int>();
        // bt.Add(8, 12, 10, 9, 11, 14, 13, 15, 4, 2, 1, 3, 6, 5, 7);
        // bt.Add(4, 2, 1, 3, 6, 5, 7);
        bt.Add(9, 5, 3, 2, 4, 7, 6, 8, 10, 11);
        bt.Remove(5);
        bt.Remove(8);
        bt.Remove(9);
        bt.Remove(3);
        Console.Write(bt);

        // foreach(int i in bt)
        //     Console.Write(i + " ");

        // Console.WriteLine();
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