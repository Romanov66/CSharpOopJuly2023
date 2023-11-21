namespace LambdasTask
{
    internal class PersonProgram
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Иван", 26);
            Person person2 = new Person("Мария", 16);
            Person person3 = new Person("Евгений", 19);
            Person person4 = new Person("Эрнест", 34);
            Person person5 = new Person("Полина", 27);
            Person person6 = new Person("Олег", 52);
            Person person7 = new Person("Иван", 15);
            Person person8 = new Person("Олег", 7);

            List<Person> persons = new List<Person> { person1, person2, person3, person4, person5, person6, person7, person8 };

            List<string> uniqNamesList = persons
                .Select(person => person.Name)
                .Distinct()
                .ToList();

            Console.WriteLine("Уникальные имена в коллекции: " + string.Join(", ", uniqNamesList));

            List<Person> minors = persons
                .Where(person => person.Age < 18)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Имена несовершеннолетних лиц:");
            
            foreach (Person person in minors)
            {
                Console.WriteLine(person.Name);
            }            

            int minorsMiddleAge = (int) Math.Round(minors
                .Select(person => person.Age)
                .Average(), MidpointRounding.AwayFromZero);

            Console.WriteLine();
            Console.WriteLine("Средний возраст несовершеннолетних: " + minorsMiddleAge);
            Console.WriteLine();

            Dictionary<string, int> personsByName = persons
                .GroupBy(person => person.Name)
                .ToDictionary(person => person.Key, person =>
                {
                    double middleAge = person
                    .Select(person => person.Age)
                    .Average();

                    return (int)Math.Round(middleAge, MidpointRounding.AwayFromZero);
                });

            foreach(KeyValuePair<string, int> person in personsByName)
            {
                Console.WriteLine("Имя: {0}, средний возраст по данному имени: {1}", person.Key, person.Value);
            }

            List<Person> personsByMatureAge = persons
                .Where(person => person.Age >= 20 && person.Age <= 45)
                .OrderByDescending(person => person.Age)
                .ToList();

            Console.WriteLine();
            Console.WriteLine("Имя людей, чей возраст перечислен в порядке убывания и находится в диапазоне от 20 до 45 лет:");

            foreach(Person person in personsByMatureAge)
            {
                Console.WriteLine("Имя: {0}, возраст: {1}", person.Name, person.Age);
            }
        }
    }
}
