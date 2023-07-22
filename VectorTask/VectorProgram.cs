namespace Academits.Romanov.VectorTask
{
    public class VectorProgram
    {
        static void Main(string[] args)
        {
            //Vector test = new Vector(0);

            Vector vector1 = new Vector(3);

            Console.WriteLine("Первый вектор = " + vector1);

            Console.WriteLine();

            Vector vector2 = new Vector(new double[] { 3, 13 });

            Console.WriteLine("Второй вектор = " + vector2);

            Console.WriteLine();

            Vector vector3 = new Vector(vector2);

            Console.WriteLine("Третий вектор = " + vector3);

            Console.WriteLine();

            Vector vector4 = new Vector(5, new double[] { 7, -1, 28 });

            Console.WriteLine("Четвертый вектор = " + vector4);

            Console.WriteLine();

            Console.WriteLine("Размерность четвертого вектора = " + vector4.GetSize());

            Console.WriteLine();

            vector4.Coordinates = vector4.AddVector(vector2);

            Console.WriteLine("Сумма четвертого и второго вектора равна = " + vector4);

            vector2.Coordinates = vector2.SubtractVector(vector4);

            Console.WriteLine("Разность второго и четвертого вектора равна = " + vector2);

            Console.WriteLine();

            vector4.Coordinates = vector4.ToScale(2);

            Console.WriteLine("Результат увеличения четвертого вектора в два раза: " + vector4);

            Console.WriteLine();

            vector2.Coordinates = vector2.GetReverseVector();

            Console.WriteLine("Реузльтат реверсирования второго вектора: " + vector2);

            Console.WriteLine();

            Console.WriteLine("Длина второго вектора: " + vector2.GetVectorLength());

            Console.WriteLine();

            Vector vector5 = new Vector(vector2);

            Console.WriteLine("Вектор два и вектор пять равны: " + vector2.Equals(vector5));
            Console.WriteLine("Вектор два и вектор четыре равны: " + vector2.Equals(vector4));

            Console.WriteLine();

            Console.WriteLine("Хэш код вектор два: " + vector2.GetHashCode() + "; хэш код вектора пять: " + vector5.GetHashCode());
            Console.WriteLine("Хэш код вектор два: " + vector2.GetHashCode() + "; хэш код вектора четыре: " + vector4.GetHashCode());

            Console.WriteLine();

            vector2 = Vector.GetVectorsAddition(vector2, vector5);

            Console.WriteLine("Результат сложения второго и пятого вектора: " + vector2);

            vector4 = Vector.GetVectorsSubtraction(vector4, vector5);

            Console.WriteLine("Результат вычетания четвертого и пятого вектора: " + vector4);

            Console.WriteLine();

            Console.WriteLine("Результат скалярного произведения второго и четвертого вектора: " + Vector.GetVectorsScalarProduct(vector2, vector4));
        }
    }
}
