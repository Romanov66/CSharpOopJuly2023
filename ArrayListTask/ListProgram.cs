namespace ArrayListTask
{
    public class ListProgram
    {
        static void Main(string[] args)
        {
            CustomList<int> numbersList = new CustomList<int>(10);

            for (int i = 0; i < numbersList.Capacity; i++)
            {
                numbersList.Add(i);
            }

            Console.WriteLine("Список чисел: " + numbersList);

            numbersList.Add(10);

            Console.WriteLine("Список чисел после добавления 11 элемента: " + numbersList);
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);
            Console.WriteLine();

            bool isDelete = numbersList.Remove(10);

            Console.WriteLine("Результат удаления элемента со значением 10: " + isDelete);
            Console.WriteLine("Список чисел: " + numbersList);
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);
            Console.WriteLine();

            isDelete = numbersList.Remove(56);

            Console.WriteLine("Результат удаления элемента со значением 56: " + isDelete);
            Console.WriteLine("Список чисел: " + numbersList);
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);
            Console.WriteLine();

            numbersList.RemoveAt(4);

            Console.WriteLine("Список чисел после удаления элемента лежащего по индексу 4: " + numbersList);
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);
            Console.WriteLine();

            bool isContains = numbersList.Contains(3);

            Console.WriteLine("Список чисел содержит элемент со значением 3: " + isContains);

            isContains = numbersList.Contains(17);

            Console.WriteLine("Список чисел содержит элемент со значением 17: " + isContains);
            Console.WriteLine();

            int[] numbers = new int[20];
            numbersList.CopyTo(numbers, 0);

            Console.WriteLine("Результат копирования массива чисел новым списком: " + string.Join(", ", numbers));
            Console.WriteLine();

            CustomList<int> newNubersList = new CustomList<int>(numbers);

            Console.WriteLine("Список чисел нового списка: " + newNubersList);

            newNubersList.Clear();

            Console.WriteLine("Результат очистки нового списка чисел: " + newNubersList);
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
            Console.WriteLine("Характеристики списка после увеличения вместимости до 100 единицы: " + numbersList);
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);

            numbersList.TrimExcess();

            Console.WriteLine();
            Console.WriteLine("Характеристики списка после применения метода TrimExcess: " + numbersList);
            Console.WriteLine("Количество элементов списка: " + numbersList.Count);
            Console.WriteLine("Вместимость списка: " + numbersList.Capacity);

            Console.WriteLine();
            Console.WriteLine("Индекс элемента 5 = " + numbersList.IndexOf(5));
            Console.WriteLine("Индекс не существующего элемента 35 = " + numbersList.IndexOf(35));

            numbersList.Insert(9, 10);

            Console.WriteLine();
            Console.WriteLine("Характеристики списка после применения метода Insert: " + numbersList);

            int[] postalCodes1 = new int[] { 6300089, 6300090, 6300091 };
            int[] postalCodes2 = new int[] { 6300089, 6300090, 6300091 };
            int[] postalCodes3 = new int[] { 6300089, 6300093, 6300091 };

            CustomList<int> postalOffice1 = new CustomList<int>(postalCodes1);
            CustomList<int> postalOffice2 = new CustomList<int>(postalCodes2);
            CustomList<int> postalOffice3 = new CustomList<int>(postalCodes3);

            Console.WriteLine();
            Console.WriteLine("Почтовое отделение 1 содержит почтовые индексы почтового отделения 2: " + postalOffice1.Equals(postalOffice2));
            Console.WriteLine("Почтовое отделение 1 содержит почтовые индексы почтового отделения 3: " + postalOffice1.Equals(postalOffice3));
            Console.WriteLine("Почтовое отделение 2 содержит почтовые индексы почтового отделения 3: " + postalOffice2.Equals(postalOffice3));
            Console.WriteLine();
            Console.WriteLine("Хэш-код первого почтового отделения: " + postalOffice1.GetHashCode());
            Console.WriteLine("Хэш-код второго почтового отделения: " + postalOffice2.GetHashCode());
            Console.WriteLine("Хэш-код третьего почтового отделения: " + postalOffice3.GetHashCode());
        }
    }
}
