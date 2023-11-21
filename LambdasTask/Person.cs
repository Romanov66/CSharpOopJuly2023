namespace LambdasTask
{
    public class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name), "Имя не может быть null");
            }

            if (age <= 0)
            {
                throw new ArgumentException("Возраст не может быть меньше нуля", nameof(age));
            }

            Name = name;
            Age = age;
        }

        /*public string Name
        {
            get 
            {
                return name; 
            }
            set 
            {
                if(value is null)
                {
                    throw new ArgumentNullException(nameof(value), "Имя не может быть null");
                }

                name = value; 
            }
        }

        public int Age
        {
            get 
            {
                return age;
            }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Возраст не может быть меньше нуля", nameof(value));
                }

                age = value; 
            }
        }*/
    }
}