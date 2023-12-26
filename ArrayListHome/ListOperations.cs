namespace ArrayListHome
{
    internal class ListOperations
    {
        static void Main(string[] args)
        {
            List<string> lines = new();

            try
            {
                using StreamReader reader = new("..\\..\\..\\Verse.txt");

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    lines.Add(currentLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл с таким названием отсутствует.");
            }

            Console.WriteLine("А вы могли бы?");

            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            List<int> numbers = new()
            {
                2, 24, 255, 13, 37, 48, 13, 99, 255, 47, 37, 24, 99, 6, 13
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

            List<int> uniqueNumbers = new(numbers.Count);

            foreach (int number in numbers)
            {
                if (!uniqueNumbers.Contains(number))
                {
                    uniqueNumbers.Add(number);
                }
            }

            Console.WriteLine("Уникальные числа списка: " + string.Join(", ", uniqueNumbers));
        }
    }
}