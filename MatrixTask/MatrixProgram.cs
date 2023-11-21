using Academits.Romanov.VectorTask;

namespace Academits.Romanov.MatrixTask
{
    public class MatrixProgram
    {
        static void Main(string[] args)
        {            
            Matrix matrix1 = new Matrix(3, 5);

            Console.WriteLine("Использование конструктора, возвращающий матрицу с нулями: " + matrix1);

            Console.WriteLine();

            Matrix matrix2 = new Matrix(matrix1);

            Console.WriteLine("Использование конструктора, возвращающий копию матрицы: " + matrix2);

            Console.WriteLine();

            double[,] x =
            {
                {2, 3, 15 },
                {13, 6, 12 },
                {14, 7, 14 },
            };

            Matrix matrix3 = new Matrix(x);
                        
            Console.WriteLine("Использование конструктора, возвращающий матрицу на основе двумерного массива: " + matrix3);

            Console.WriteLine();

            Vector vector1 = new Vector(new double[] { 3, 13, 3, 5 });
            Vector vector2 = new Vector(new double[] { 7, 21, 90, 8 });
            Vector vector3 = new Vector(new double[] { 23, 78, 199, 13 });
            Vector vector4 = new Vector(new double[] { 49, 56, 78, 89 });

            Vector[] vectors = new Vector[] { vector1, vector2, vector3, vector4 };

            Matrix matrix4 = new Matrix(vectors);

            Console.WriteLine("Использование конструктора, возвращающий матрицу на основе массива векторов: " + matrix4);

            Console.WriteLine();

            matrix3 = matrix4.TransposeMatrix();

            Console.WriteLine("Транспонирование матрицы: " + matrix3);

            Console.WriteLine();

            matrix3 = matrix3.ToScaleUp(2);

            Console.WriteLine("Результат умножения на скаляр: " + matrix3);

            Console.WriteLine();

            double determinant = matrix3.FindDeterminant();

            Console.WriteLine("Определитель матрицы равен: " + determinant);

            Console.WriteLine();

            /*double[,] f = matrix3.GetNewMatrix(2, matrix3.CoordinatesArrays);

            Matrix matrix5 = new Matrix(f);

            Console.WriteLine(matrix5.ToString());*/

            Vector vector5 = new Vector(new double[] { 2, 3, 5 });

            Matrix matrix5 = new Matrix(x);

            vector5 = matrix5.MultiplyVector(vector5);

            Console.WriteLine("Результат умножения матрицы на ветктор: " + vector5);

            Console.WriteLine();

            matrix5 = matrix5.AddMatrix(matrix3);

            Console.WriteLine("Результат умножения матрицы на матрицу: " + matrix5);

            Console.WriteLine();

        }
    }
}
