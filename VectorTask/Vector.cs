using System.Text;

namespace Academits.Romanov.VectorTask
{
    public class Vector
    {
        private double[] Coordinates;

        public int Size
        {
            get
            {
                return Coordinates.Length;
            }
        }

        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Coordinates.Length)
                {
                    throw new ArgumentOutOfRangeException($"Некорректное значение. Индекс не может быть меньше 0 и больше количества компонентов. Текущее значение: {index}", nameof(index));
                }

                return Coordinates[index];
            }
            set
            {
                if (index < 0 || index >= Coordinates.Length)
                {
                    throw new ArgumentOutOfRangeException($"Некорректное значение. Индекс не может быть меньше 0 и больше количества компонентов. Текущее значение: {index}", nameof(index));
                }

                Coordinates[index] = value;
            }
        }

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Размерность вектора не может быть <= 0! Текущее значение = {size}", nameof(size));
            }

            Coordinates = new double[size];
        }

        public Vector(Vector vector)
        {
            if (vector.Size <= 0)
            {
                throw new ArgumentException($"Размерность переданного вектора не может быть <= 0! Текущее значение = {vector.Size}", nameof(vector.Size));
            }

            Coordinates = new double[vector.Size];

            Array.Copy(vector.Coordinates, Coordinates, vector.Size);
        }

        public Vector(double[] coordinates)
        {
            if (coordinates.Length <= 0)
            {
                throw new ArgumentException($"Размерность переданного вектора не может быть <= 0! Текущее значение = {coordinates.Length}", nameof(coordinates.Length));
            }

            Coordinates = new double[coordinates.Length];

            Array.Copy(coordinates, Coordinates, coordinates.Length);
        }

        public Vector(int size, double[] coordinates)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Размерность вектора не может быть <= 0! Текущее значение = {size}", nameof(size));
            }

            if (size > coordinates.Length)
            {
                Array.Resize(ref coordinates, size);
            }

            Coordinates = new double[size];

            Array.Copy(coordinates, Coordinates, size);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Size; i++)
            {
                if (i == Size - 1)
                {
                    stringBuilder.Append($"{Coordinates[i]}");
                }
                else
                {
                    stringBuilder.Append($"{Coordinates[i]}, ");
                }
            }

            return $"{{{stringBuilder}}}";
        }

        public void Add(Vector vector)
        {
            if (vector.Size > Size)
            {
                Array.Resize(ref Coordinates, vector.Size);
            }

            for (int i = 0; i < vector.Size; i++)
            {
                Coordinates[i] = Coordinates[i] + vector[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (vector.Size > Size)
            {
                Array.Resize(ref Coordinates, vector.Size);
            }

            for (int i = 0; i < vector.Size; i++)
            {
                if (Coordinates[i] == 0)
                {
                    Coordinates[i] = 0;
                }
                else
                {
                    Coordinates[i] = Coordinates[i] - vector[i];
                }
            }
        }

        public void MyltiplyScalar(double scalar)
        {
            for (int i = 0; i < Size; i++)
            {
                Coordinates[i] = Coordinates[i] * scalar;
            }
        }

        public void Reverse()
        {
            MyltiplyScalar(-1);
        }

        public double GetLength()
        {
            double sum = 0;

            for (int i = 0; i < Size; i++)
            {
                sum += Coordinates[i] * Coordinates[i];
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
                if (Coordinates[i] != vector[i])
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
                hash = prime * hash + Coordinates[i].GetHashCode();
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

        public static Vector GetScalarProduct(Vector vector1, Vector vector2)
        {
            if (vector1.Size < vector2.Size)
            {
                Array.Resize(ref vector1.Coordinates, vector2.Size);
            }

            Vector scalarProductVector = new Vector(vector1.Size);

            for (int i = 0; i < scalarProductVector.Size; i++)
            {
                scalarProductVector[i] = vector1[i] * vector2[i];
            }

            return scalarProductVector;
        }
    }
}