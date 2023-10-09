namespace ArrayListTask
{
    public class ListProgram
    {
        static void Main(string[] args)
        {
            MyList<int> numbersList = new MyList<int>(10);

            for (int i = 0; i < numbersList.Capacity; i++)
            {
                numbersList.Add(i);
            }

            Console.WriteLine("Список чисел: " + numbersList.ToString());

            numbersList.Add(10);

            Console.WriteLine("Список чисел после добавления 11 элемента: " + numbersList.ToString());
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);
            Console.WriteLine();

            bool isDelete = numbersList.Remove(10);

            Console.WriteLine("Результат удаления элемента со значением 10: " + isDelete);
            Console.WriteLine("Список чисел: " + numbersList.ToString());
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);
            Console.WriteLine();

            isDelete = numbersList.Remove(56);

            Console.WriteLine("Результат удаления элемента со значением 56: " + isDelete);
            Console.WriteLine("Список чисел: " + numbersList.ToString());
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);
            Console.WriteLine();

            numbersList.RemoveAt(4);

            Console.WriteLine("Список чисел после удаления элемента лежащего по индексу 4: " + numbersList.ToString());
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);
            Console.WriteLine();

            bool isContains = numbersList.Contains(3);

            Console.WriteLine("Список чисел содержит элемент со значением 3: " + isContains);

            isContains = numbersList.Contains(17);

            Console.WriteLine("Список чисел содержит элемент со значением 17: " + isContains);
            Console.WriteLine();

            MyList<int> newNumbresList = new MyList<int>(0);
            int[] numbers = new int[5] { 2, 4, 6, 8, 10 };
            newNumbresList.CopyTo(numbers, 0);

            Console.WriteLine("Результат копирования массива чисел новым списком: " + newNumbresList.ToString());
            Console.WriteLine();

            newNumbresList.Clear();

            Console.WriteLine("Результат очистки нового списка чисел: " + newNumbresList.ToString());
            Console.WriteLine();
            Console.WriteLine("Ниже представлен результат работы итератора, который последовательно печатает значение элементов списка:");
            Console.WriteLine();

            foreach (int number in numbersList)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();

            numbersList.Capacity = 100;

            Console.WriteLine();
            Console.WriteLine("Характеристки списка после увеличения вместимости до 100 единицы: ");
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);

            numbersList.TrimExcess();

            Console.WriteLine();
            Console.WriteLine("Характеристики списка после применения метода TrimExcess: ");
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);
        }
    }
}
