namespace Academits.Romanov.VectorTask
{
    public class VectorProgram
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(3);
            Vector vector2 = new Vector(new double[] { 3, 13, 7, 89, 34 });
            Vector vector3 = new Vector(5, new double[] { 7, -1, 28 });

            Console.WriteLine("Координаты первого вектора = " + vector1);
            Console.WriteLine("Координаты второго вектора = " + vector2);
            Console.WriteLine("Координаты третьего вектора = " + vector3);
            Console.WriteLine();

            vector1.Add(vector2);
            vector2.Subtract(vector3);
            vector3.MyltiplyScalar(3);

            Console.WriteLine("Координаты первого вектора после прибавления второго = " + vector1);
            Console.WriteLine("Координаты второго вектора после вычитании третьего = " + vector2);
            Console.WriteLine("Координаты третьего вектора после умножения на 3 = " + vector3);
            Console.WriteLine();

            vector2.Reverse();

            Console.WriteLine("Реузльтат реверсирования второго вектора: " + vector2);
            Console.WriteLine();
            Console.WriteLine("Длина первого вектора: " + Math.Round(vector1.GetLength(), 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("Длина второго вектора: " + Math.Round(vector2.GetLength(), 2, MidpointRounding.AwayFromZero));
            Console.WriteLine("Длина третьего вектора: " + Math.Round(vector3.GetLength(), 2, MidpointRounding.AwayFromZero));
            Console.WriteLine();

            vector1 = new Vector(vector3);

            Console.WriteLine("Вектор один и вектор три равны: " + vector1.Equals(vector3));
            Console.WriteLine("Вектор один и вектор два равны: " + vector1.Equals(vector2));
            Console.WriteLine();
            Console.WriteLine("Хэш код вектор один: " + vector1.GetHashCode());
            Console.WriteLine("Хэш код вектор два: " + vector2.GetHashCode());
            Console.WriteLine("Хэш код вектор три: " + vector3.GetHashCode());
            Console.WriteLine();

            vector1 = Vector.GetSum(vector1, vector3);
            vector2 = Vector.GetDifference(vector3, vector1);
            vector3 = Vector.GetScalarProduct(vector1, vector2);

            Console.WriteLine("Координаты первого вектора = " + vector1);
            Console.WriteLine("Координаты второго вектора = " + vector2);
            Console.WriteLine("Координаты третьего вектора = " + vector3);
        }
    }
}
