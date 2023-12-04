namespace ArrayListHome
{
    internal class ListOperations
    {
        static void Main(string[] args)
        {
            List<string> verseLines = new();

            try
            {
                using StreamReader reader = new("..\\..\\..\\Verse.txt");

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    verseLines.Add(currentLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл с таким название отсутствует: " + e);
                throw;
            }

            Console.WriteLine("А вы могли бы?");

            foreach (string line in verseLines)
            {
                Console.WriteLine(line);
            }

            List<int> numbers = new()
            {
                2,
                24,
                255,
                13,
                37,
                48,
                13,
                99,
                255,
                47,
                37,
                24,
                99,
                6,
                13
            };

            Console.WriteLine();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine("Список после удаления четных чисел: " + string.Join(", ", numbers));

            List<int> uniqueNumbers = new();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (uniqueNumbers.IndexOf(numbers[i]) == -1)
                {
                    uniqueNumbers.Add(numbers[i]);
                }
            }

            Console.WriteLine("Уникальные числа списка: " + string.Join(", ", uniqueNumbers));
        }
    }
}