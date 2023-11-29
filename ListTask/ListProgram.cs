namespace ListTask
{
    internal class ListProgram
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> numbersList1 = new SinglyLinkedList<int>();

            numbersList1.Add(0, 3);
            numbersList1.Add(1, 13);
            numbersList1.Add(2, 26);
            numbersList1.Add(2, 18);

            Console.WriteLine("Содержимое списка: " + numbersList1);

            numbersList1[0] = 2;
            numbersList1.AddFirst(6);
            numbersList1.Revert();

            Console.WriteLine("Содержимое списка после изменений: " + numbersList1);
            Console.WriteLine("Элемент лежащий по индексу один: " + numbersList1[1]);
            Console.WriteLine("Значение удаленного элемента лежащего по индексу два: " + numbersList1.RemoveByIndex(2));
            Console.WriteLine("Список чисел после удаления значения элемента лежащего по индексу два: " + numbersList1);

            bool isRemoved = numbersList1.RemoveByData(18);

            if (isRemoved)
            {
                Console.WriteLine("Это распечатается, если элемент со значением 18 был удален.");
            }

            Console.WriteLine("Значение первого удаленного элемента: " + numbersList1.RemoveFirst());
            Console.WriteLine("Список чисел после удаления первого элемента и элемента со значением 18: " + numbersList1);
            Console.WriteLine();

            SinglyLinkedList<int> numbersList2 = numbersList1.Copy();
            numbersList2[1] = 10;

            Console.WriteLine("Содержимое копии списка чисел: " + numbersList1);
            Console.WriteLine("Содержимое копии списка чисел: " + numbersList2);
            Console.WriteLine("Количество элементов оригинального списка чисел: " + numbersList1.Count);
            Console.WriteLine("Количество элементов копированного списка чисел: " + numbersList2.Count);
        }
    }
}
