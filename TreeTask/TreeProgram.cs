namespace TreeTask
{
    internal class TreeProgram
    {
        static void Main(string[] args)
        {
            TreeNode<int> node1 = new TreeNode<int>(8);
            TreeNode<int> node2 = new TreeNode<int>(3);
            TreeNode<int> node3 = new TreeNode<int>(10);
            TreeNode<int> node4 = new TreeNode<int>(1);
            TreeNode<int> node5 = new TreeNode<int>(6);
            TreeNode<int> node6 = new TreeNode<int>(14);
            TreeNode<int> node7 = new TreeNode<int>(4);
            TreeNode<int> node8 = new TreeNode<int>(7);
            TreeNode<int> node9 = new TreeNode<int>(13);

            TreeNode<int>[] treeNodes = { node1, node2, node3, node4, node5, node6, node7, node8, node9 };
            Tree<int> tree = new Tree<int>();

            foreach (TreeNode<int> node in treeNodes)
            {
                tree.Add(node);
            }

            Console.WriteLine("Обход дерева в ширину:");

            tree.RunWide();

            Console.WriteLine();

            Console.WriteLine("Обход дерева в глубину с рекурсией:");

            tree.RunHighRecursivly(tree.RootNode);

            Console.WriteLine();

            Console.WriteLine("Обход дерева в глубину:");

            tree.RunHigh();

            Console.WriteLine();

            Console.Write("Введите значение искомого узла: ");
            int inputNumber = int.Parse(Console.ReadLine());

            TreeNode<int> node10 = tree.FindNote(inputNumber);

            if (node10 is null)
            {
                Console.WriteLine("Искомый узел отсутвует");
            }

            Console.WriteLine();

            TreeNode<int> node11 = new TreeNode<int>(9);
            tree.Add(node11);
            TreeNode<int> node12 = new TreeNode<int>(20);
            tree.Add(node12);
            TreeNode<int> node13 = new TreeNode<int>(11);
            tree.Add(node13);
            TreeNode<int> node14 = new TreeNode<int>(12);
            tree.Add(node14);

            tree.Remove(10);
        }
    }
}
