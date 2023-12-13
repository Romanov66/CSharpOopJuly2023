namespace LambdasTask
{
    internal class PersonProgram
    {
        static void Main(string[] args)
        {
            List<Person> persons = new()
            {
                new Person("Иван", 26),
                new Person("Мария", 16),
                new Person("Евгений", 19),
                new Person("Эрнест", 34),
                new Person("Полина", 27),
                new Person("Олег", 52),
                new Person("Иван", 15),
                new Person("Олег", 7)
            };

            List<string> uniqueNames = persons
                .Select(p => p.Name)
                .Distinct()
                .ToList();

            Console.WriteLine("Уникальные имена в коллекции: " + string.Join(", ", uniqueNames));

            List<Person> minors = persons
                .Where(p => p.Age < 18)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Имена несовершеннолетних лиц:");

            foreach (Person person in minors)
            {
                Console.WriteLine(person.Name);
            }

            double minorsAverageAge = minors.Average(p => p.Age);

            Console.WriteLine();
            Console.WriteLine("Средний возраст несовершеннолетних: " + minorsAverageAge);
            Console.WriteLine();

            Dictionary<string, double> personsByName = persons
                .GroupBy(p => p.Name)
                .ToDictionary(g => g.Key, g => g.Average(g => g.Age));

            foreach (KeyValuePair<string, double> personsGroup in personsByName)
            {
                Console.WriteLine("Имя: {0}, средний возраст: {1}", personsGroup.Key, personsGroup.Value);
            }

            List<Person> mature = persons
                .Where(p => p.Age >= 20 && p.Age <= 45)
                .OrderByDescending(p => p.Age)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Перечень людей, чей возраст от 20 до 45 лет:");

            foreach (Person person in mature)
            {
                Console.WriteLine("Имя: {0}, возраст: {1}", person.Name, person.Age);
            }
        }
    }
}
