namespace HashTableTask
{
    public class HashTableProgram
    {
        static void Main(string[] args)
        {
            List<int> numbersList = new List<int>(3)
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11
            };

            HashTable<int> hashTable = new HashTable<int>(numbersList);

            Console.WriteLine("Содержимое хэш-таблицы: " + hashTable);
            Console.WriteLine("Количество компонентов до изменения: " + hashTable.Count);

            hashTable.Remove(7);
            hashTable.Add(81);
            hashTable.Add(101);

            Console.WriteLine("Содержимое хэш-таблицы после удаления компонента со значением 7 и добавление компонентов со значениями 81 и 101: " + hashTable);
            Console.WriteLine("Количество компонентов после изменения: " + hashTable.Count);
            Console.WriteLine();
            Console.WriteLine("Хэш-таблица содержит компонент со значением 101: " + hashTable.Contains(101));
            Console.WriteLine("Хэш-таблица содержит компонент со значением 81: " + hashTable.Contains(81));
            Console.WriteLine("Хэш-таблица содержит компонент со значением 3: " + hashTable.Contains(3));
            Console.WriteLine("Хэш-таблица содержит компонент со значением 99: " + hashTable.Contains(99));
            Console.WriteLine();

            int[] numbersArray = new int[12];
            hashTable.CopyTo(numbersArray, 0);

            Console.WriteLine("Массив чисел: " + string.Join(", ", numbersArray));
            Console.WriteLine();
            Console.WriteLine("Ниже представлен проход по хэш-таблицы с помощью конструкции foreach:");

            foreach (int number in hashTable)
            {
                Console.WriteLine("Компонент хэш-таблице: " + number);
            }
        }
    }
}
