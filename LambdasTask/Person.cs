namespace LambdasTask
{
    public class Person
    {
        private string name;
        private int age;

        public string Name
        {
            get => name;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value), "Имя не может быть null");
                }

                name = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Возраст не может быть меньше нуля", nameof(value));
                }

                age = value;
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}