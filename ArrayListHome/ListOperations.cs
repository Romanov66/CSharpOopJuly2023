namespace ArrayListHome
{
    internal class ListOperations
    {
        static void Main(string[] args)
        {
            List<int> numbers = new();

            using (StreamReader reader = new("..\\..\\..\\Numbers.txt"))
            {
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    numbers.Add(Convert.ToInt32(currentLine));
                }
            };

            Console.WriteLine("Список после чтения файла: " + string.Join(", ", numbers.ToArray()));

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine("Список после удаления нечетных чисел: " + string.Join(", ", numbers.ToArray()));

            List<int> uniqNumbers = new();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers.IndexOf(numbers[i], i + 1) == -1)
                {
                    uniqNumbers.Add(numbers[i]);
                }
            }

            Console.WriteLine("Уникальные числа списка: " + string.Join(", ", uniqNumbers.ToArray()));
        }
    }
}