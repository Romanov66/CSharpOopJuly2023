using System.Text;

namespace Academits.Romanov.VectorTask
{
    public class Vector
    {
        private double[] coordinates;

        public int Size => coordinates.Length;

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен выходить за границы массива. Допустимые границы: от 0 до {Size - 1}. Текущее значение индекса: {index}");
                }

                return coordinates[index];
            }
            set
            {
                if (index < 0 || index >= Size)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен выходить за границы массива. Допустимые границы: от 0 до {Size - 1}. Текущее значение индекса: {index}");
                }

                coordinates[index] = value;
            }
        }

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Размерность вектора не может быть <= 0! Текущее значение = {size}", nameof(size));
            }

            coordinates = new double[size];
        }

        public Vector(Vector vector)
        {
            coordinates = new double[vector.Size];

            Array.Copy(vector.coordinates, coordinates, vector.Size);
        }

        public Vector(double[] coordinates)
        {
            if (coordinates.Length == 0)
            {
                throw new ArgumentException("Длина массива должна быть больше нуля!");
            }

            this.coordinates = new double[coordinates.Length];

            Array.Copy(coordinates, this.coordinates, coordinates.Length);
        }

        public Vector(int size, double[] coordinates)
        {
            if (coordinates.Length == 0)
            {
                throw new ArgumentException("Длина массива должна быть больше нуля!");
            }

            if (size <= 0 || size < coordinates.Length)
            {
                throw new ArgumentException($"Размерность вектора не может быть <= 0, либо меньше длины массива! Размерность вектора = {size}, длина массива: {coordinates.Length}", nameof(size));
            }

            this.coordinates = new double[size];

            Array.Copy(coordinates, this.coordinates, coordinates.Length);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append('{');

            foreach (double coordinate in coordinates)
            {
                stringBuilder
                    .Append(coordinate)
                    .Append(", ");
            }

            return stringBuilder
                .Remove(stringBuilder.Length - 2, 2)
                .Append('}')
                .ToString();
        }

        public void Add(Vector vector)
        {
            if (vector.Size > Size)
            {
                Array.Resize(ref coordinates, vector.Size);
            }

            for (int i = 0; i < vector.Size; i++)
            {
                coordinates[i] += vector.coordinates[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (vector.Size > Size)
            {
                Array.Resize(ref coordinates, vector.Size);
            }

            for (int i = 0; i < vector.Size; i++)
            {
                coordinates[i] -= vector.coordinates[i];
            }
        }

        public void MultiplyByScalar(double scalar)
        {
            for (int i = 0; i < Size; i++)
            {
                coordinates[i] *= scalar;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double sum = 0;

            foreach (double coordinate in coordinates)
            {
                sum += coordinate * coordinate;
            }

            return Math.Sqrt(sum);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(null, obj) || obj.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (Size != vector.Size)
            {
                return false;
            }

            for (int i = 0; i < Size; i++)
            {
                if (coordinates[i] != vector.coordinates[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            const int prime = 37;
            int hash = 1;

            foreach (double coordinate in coordinates)
            {
                hash = prime * hash + coordinate.GetHashCode();
            }

            return hash;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector sum = new Vector(vector1);
            sum.Add(vector2);

            return sum;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector difference = new Vector(vector1);
            difference.Subtract(vector2);

            return difference;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int minSize = Math.Min(vector1.Size, vector2.Size);
            double scalarProduct = 0;

            for (int i = 0; i < minSize; i++)
            {
                scalarProduct += vector1.coordinates[i] * vector2.coordinates[i];
            }

            return scalarProduct;
        }
    }
}