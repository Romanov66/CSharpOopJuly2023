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
                if (index < 0 || index >= coordinates.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен выходить за границы массива. Допустимые границы: от 0 до {coordinates.Length}. Текущее значение индекса: {index}");
                }

                return coordinates[index];
            }
            set
            {
                if (index < 0 || index >= coordinates.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), $"Индекс не должен выходить за границы массива. Допустимые границы: от 0 до {coordinates.Length}. Текущее значение индекса: {index}");
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
            this.coordinates = new double[coordinates.Length];

            Array.Copy(coordinates, this.coordinates, coordinates.Length);
        }

        public Vector(int size, double[] coordinates)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Размерность вектора не может быть <= 0! Текущее значение = {size}", nameof(size));
            }

            this.coordinates = new double[size];

            Array.Copy(coordinates, this.coordinates, coordinates.Length);
        }

        public override string ToString()
        {
            if (Size == 0)
            {
                return "{}";
            }

            StringBuilder stringBuilder = new();
            stringBuilder.Append('{');

            foreach (double coordinate in coordinates)
            {
                stringBuilder.Append($"{coordinate}, ");
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
                coordinates[i] += vector[i];
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
                if (coordinates[i] != 0)
                {
                    coordinates[i] -= vector[i];
                }
            }
        }

        public void MultiplyScalar(double scalar)
        {
            for (int i = 0; i < Size; i++)
            {
                coordinates[i] *= scalar;
            }
        }

        public void Reverse()
        {
            MultiplyScalar(-1);
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
                if (coordinates[i] != vector[i])
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

            for (int i = 0; i < Size; i++)
            {
                hash = prime * hash + coordinates[i].GetHashCode();
            }

            return hash;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector sumVector = new Vector(vector1);
            sumVector.Add(vector2);

            return sumVector;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector differenceVector = new Vector(vector1);
            differenceVector.Subtract(vector2);

            return differenceVector;
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int minLength = Math.Min(vector1.Size, vector2.Size);
            double scalarProduct = 0;

            for (int i = 0; i < minLength; i++)
            {
                scalarProduct += vector1[i] * vector2[i];
            }

            return scalarProduct;
        }
    }
}