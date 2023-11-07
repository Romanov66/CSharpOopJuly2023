namespace HashTableTask
{
    public class HashTableProgram
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable = new HashTable<int>(10);

            List<int> numbers1 = new List<int>(3)
            {
                1, 2, 3
            };

            List<int> numbers2 = new List<int>(4)
            {
                4, 5, 6, 7
            };

            List<int> numbers3 = new List<int>(3)
            {
                8, 9, 10
            };

            hashTable.Add(numbers1);
            hashTable.Add(numbers2);
            hashTable.Add(numbers3);
            hashTable.Add(125);

            Console.WriteLine("Содержимое хэш-таблицы: " + hashTable.ToString());
            Console.WriteLine("Наличие значения 125 в хэш-таблице: " + hashTable.Contains(125));

            int[] numbers = new int[10];

            hashTable.CopyTo(numbers, 1);

            Console.WriteLine("Массив чисел: " + string.Join(", ", numbers));
            Console.WriteLine("Количество элементов хэш-таблицы: " + hashTable.Count);

            hashTable.Remove(125);

            Console.WriteLine("Содержимое хэш-таблицы: " + hashTable.ToString());
            Console.WriteLine("Количество элементов хэш-таблицы: " + hashTable.Count);

            foreach (List<int> list in hashTable)
            {
                Console.WriteLine(string.Join(", ", list));

                hashTable.Add(1);
            }
        }
    }
}
