namespace TreeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<int> numbersTree = new BinarySearchTree<int>();

            numbersTree.Add(8);
            numbersTree.Add(3);
            numbersTree.Add(10);
            numbersTree.Add(1);
            numbersTree.Add(6);
            numbersTree.Add(9);
            numbersTree.Add(14);
            numbersTree.Add(4);
            numbersTree.Add(7);
            numbersTree.Add(13);
            numbersTree.Add(20);
            numbersTree.Add(11);
            numbersTree.Add(12);

            Console.WriteLine("Обход дерева в ширину до изменений:");

            numbersTree.GoAroundInWidth(data => Console.Write(data + " "));

            numbersTree.Remove(10);

            Console.WriteLine();
            Console.WriteLine("Обход дерева в ширину после удаления 10:");

            numbersTree.GoAroundInWidth(data => Console.Write(data + " "));

            Console.WriteLine();
            Console.WriteLine("Обход дерева в глубину:");

            numbersTree.GoAroundInDepth(data => Console.Write(data + " "));

            Console.WriteLine();
            Console.WriteLine("Обход дерева в глубину с рекурсией:");

            numbersTree.GoAroundInDepthRecursively(data => Console.Write(data + " "));
        }
    }
}
