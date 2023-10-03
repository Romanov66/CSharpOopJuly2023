namespace ListTask
{
    internal class ListProgram
    {
        static void Main(string[] args)
        {

            SinglyLinkedList<int> numbersList1 = new SinglyLinkedList<int>();

            ListItem<int> item1 = new ListItem<int>(1);
            ListItem<int> item2 = new ListItem<int>(2);
            ListItem<int> item3 = new ListItem<int>(3);

            numbersList1.Add(item1);
            numbersList1.Add(item2);
            numbersList1.Add(item3);

            Console.WriteLine("Первый элемент списка: " + numbersList1.GetFirstElementValue());
            Console.WriteLine("Элемент лежащий по индексу два: " + numbersList1.GetElementValue(2));
            Console.WriteLine("Список чисел до изменения: " + numbersList1.ToString());
            Console.WriteLine();
            Console.WriteLine("Предыдущее значение элемента, лежащего по индексу два, до замены: " + numbersList1.SetValue(2, 6));
            Console.WriteLine("Список чисел после изменения значения элемента лежащего по индексу два: " + numbersList1.ToString());
            Console.WriteLine();
            Console.WriteLine("Значение удаленного элемента лежащего по индеку два: " + numbersList1.RemoveValue(2));
            Console.WriteLine("Список чисел после удаления значения элемента лежащего по индексу два: " + numbersList1.ToString());
            Console.WriteLine();

            ListItem<int> item4 = new ListItem<int>(5);
            numbersList1.AddStart(item4);

            Console.WriteLine("Список чисел после добавления в начало нового элемента: " + numbersList1.ToString());

            ListItem<int> item5 = new ListItem<int>(18);
            numbersList1.Add(item5, 1);
            ListItem<int> item6 = new ListItem<int>(18);
            numbersList1.Add(item6, 2);

            Console.WriteLine("Список чисел после добавления новых элементов по индексам один и два: " + numbersList1.ToString());
            Console.WriteLine();

            bool isDelete = numbersList1.RemoveElement(18);

            if (isDelete == true)
            {
                Console.WriteLine("Это распечатается, если элемент со значением 18 был удален.");
            }

            Console.WriteLine("Значение первого удаленного элемента: " + numbersList1.RemoveStart());
            Console.WriteLine("Список чисел после удаления первого элемента и элемента со значением 18: " + numbersList1.ToString());
            Console.WriteLine();

            ListItem<int> item7 = new ListItem<int>(5);
            numbersList1.Add(item7);

            numbersList1.RevertList();

            Console.WriteLine("Результат реверсирования списка: " + numbersList1.ToString());
            Console.WriteLine();

            SinglyLinkedList<int> numbersList2 = numbersList1.CopyList();

            Console.WriteLine("Содержимое копии списка чисел: " + numbersList2.ToString());
            Console.WriteLine("Количество элементов оригинального списка чисел: " + numbersList1.GetLength());
            Console.WriteLine("Количество элементов копированного списка чисел: " + numbersList2.GetLength());
        }
    }
}
