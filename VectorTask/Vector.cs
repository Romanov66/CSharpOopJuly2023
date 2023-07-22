namespace Academits.Romanov.VectorTask
{
    public class Vector
    {
        public double[] Coordinates { get; set; }

        public int ElementsAmount { get; set; }

        public Vector(int elementsAmount)
        {
            if (elementsAmount <= 0)
            {
                throw new ArgumentException($"Размерность вектора не может быть <= 0! Текущее значение = {elementsAmount}", nameof(elementsAmount));
            }

            ElementsAmount = elementsAmount;

            Coordinates = new double[elementsAmount];

            for (int i = 0; i < Coordinates.Length; i++)
            {
                Coordinates[i] = 0;
            }
        }

        public Vector(Vector inputVector)
        {
            Coordinates = new double[inputVector.Coordinates.Length];

            for (int i = 0; i < inputVector.Coordinates.Length; i++)
            {
                Coordinates[i] = inputVector.Coordinates[i];
            }
        }

        public Vector(double[] coordinates)
        {
            Coordinates = new double[coordinates.Length];

            for (int i = 0; i < coordinates.Length; i++)
            {
                Coordinates[i] = coordinates[i];
            }
        }

        public Vector(int elementsAmount, double[] coordinates)
        {
            if (elementsAmount <= 0)
            {
                throw new ArgumentException("Недопустимое значение для вектора!");
            }

            ElementsAmount = elementsAmount;

            if (ElementsAmount > coordinates.Length)
            {
                Coordinates = new double[ElementsAmount];

                for (int i = 0; i < ElementsAmount; i++)
                {
                    if (i <= coordinates.Length - 1)
                    {
                        Coordinates[i] = coordinates[i];
                    }
                    else
                    {
                        Coordinates[i] = 0;
                    }
                }
            }
            else
            {
                Coordinates = new double[coordinates.Length];

                for (int i = 0; i < coordinates.Length; i++)
                {
                    Coordinates[i] = coordinates[i];
                }
            }
        }

        public int GetSize()
        {
            return Coordinates.Length;
        }

        public override string ToString()
        {
            return "{ " + string.Join(", ", Coordinates) + " }";
        }

        public double[] AddVector(Vector inputVector)
        {
            double[] vectorsSum;

            if (GetSize() > inputVector.GetSize())
            {
                Vector resultInputVector = new Vector(GetSize(), inputVector.Coordinates);

                vectorsSum = new double[GetSize()];

                for (int i = 0; i < GetSize(); i++)
                {
                    vectorsSum[i] = Coordinates[i] + resultInputVector.Coordinates[i];
                }

                return vectorsSum;
            }

            if (GetSize() < inputVector.GetSize())
            {
                Vector resultVector = new Vector(inputVector.GetSize(), Coordinates);

                vectorsSum = new double[inputVector.GetSize()];

                for (int i = 0; i < inputVector.GetSize(); i++)
                {
                    vectorsSum[i] = resultVector.Coordinates[i] + inputVector.Coordinates[i];
                }

                return vectorsSum;
            }

            vectorsSum = new double[GetSize()];

            for (int i = 0; i < GetSize(); i++)
            {
                vectorsSum[i] = Coordinates[i] + inputVector.Coordinates[i];
            }

            return vectorsSum;
        }

        public double[] SubtractVector(Vector inputVector)
        {
            double[] vectorsDifference;

            if (GetSize() > inputVector.GetSize())
            {
                Vector resultInputVector = new Vector(GetSize(), inputVector.Coordinates);

                vectorsDifference = new double[GetSize()];

                for (int i = 0; i < GetSize(); i++)
                {
                    vectorsDifference[i] = Coordinates[i] - resultInputVector.Coordinates[i];
                }

                return vectorsDifference;
            }

            if (GetSize() < inputVector.GetSize())
            {
                Vector resultVector = new Vector(inputVector.GetSize(), Coordinates);

                vectorsDifference = new double[inputVector.GetSize()];

                for (int i = 0; i < inputVector.GetSize(); i++)
                {
                    vectorsDifference[i] = resultVector.Coordinates[i] - inputVector.Coordinates[i];
                }

                return vectorsDifference;
            }

            vectorsDifference = new double[GetSize()];

            for (int i = 0; i < GetSize(); i++)
            {
                vectorsDifference[i] = Coordinates[i] - inputVector.Coordinates[i];
            }

            return vectorsDifference;
        }

        public double[] ToScale(double scalar)
        {
            double[] vectorScaling = new double[GetSize()];

            for (int i = 0; i < GetSize(); i++)
            {
                vectorScaling[i] = Coordinates[i] * scalar;
            }

            return vectorScaling;
        }

        public double[] GetReverseVector()
        {
            double[] reverseVector = Coordinates;

            for (int i = 0; i < GetSize(); i++)
            {
                if (reverseVector[i] == 0)
                {
                    continue;
                }

                reverseVector[i] *= -1;
            }

            return reverseVector;
        }

        public double GetVectorLength()
        {
            double coordinatesSquaredSum = 0;

            for (int i = 0; i < GetSize(); i++)
            {
                coordinatesSquaredSum += Math.Pow(Coordinates[i], 2);
            }

            return Math.Round(Math.Sqrt(coordinatesSquaredSum), 2, MidpointRounding.AwayFromZero);
        }

        public override bool Equals(object inputObject)
        {
            if (ReferenceEquals(this, inputObject))
            {
                return true;
            }

            if (ReferenceEquals(null, inputObject) || inputObject.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)inputObject;

            if (GetSize() != vector.GetSize())
            {
                return false;
            }

            bool isEqual = true;

            for (int i = 0; i < GetSize(); i++)
            {
                if (Coordinates[i] != vector.Coordinates[i])
                {
                    isEqual = false;

                    break;
                }
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            int primeNumber = 37;
            int hash = 1;

            hash = primeNumber * hash + ElementsAmount;

            for (int i = 0; i < GetSize(); i++)
            {
                hash = primeNumber * hash + Coordinates[i].GetHashCode();
            }

            return hash;
        }

        public static Vector GetVectorsAddition(Vector vector1, Vector vector2)
        {
            Vector additionVector;

            if (vector1.GetSize() > vector2.GetSize())
            {
                Vector resultVector2 = new Vector(vector1.GetSize(), vector2.Coordinates);

                additionVector = new Vector(vector1.GetSize());

                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    additionVector.Coordinates[i] = vector1.Coordinates[i] + resultVector2.Coordinates[i];
                }

                return additionVector;
            }

            if (vector1.GetSize() < vector2.GetSize())
            {
                Vector resultVector1 = new Vector(vector2.GetSize(), vector1.Coordinates);

                additionVector = new Vector(vector2.GetSize());

                for (int i = 0; i < vector2.GetSize(); i++)
                {
                    additionVector.Coordinates[i] = resultVector1.Coordinates[i] + vector2.Coordinates[i];
                }

                return additionVector;
            }

            additionVector = new Vector(vector1.GetSize());

            for (int i = 0; i < vector1.GetSize(); i++)
            {
                additionVector.Coordinates[i] = vector1.Coordinates[i] + vector2.Coordinates[i];
            }

            return additionVector;
        }

        public static Vector GetVectorsSubtraction(Vector vector1, Vector vector2)
        {
            Vector subtractionVector;

            if (vector1.GetSize() > vector2.GetSize())
            {
                Vector resultVector2 = new Vector(vector1.GetSize(), vector2.Coordinates);

                subtractionVector = new Vector(vector1.GetSize());

                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    subtractionVector.Coordinates[i] = vector1.Coordinates[i] - resultVector2.Coordinates[i];
                }

                return subtractionVector;
            }

            if (vector1.GetSize() < vector2.GetSize())
            {
                Vector resultVector1 = new Vector(vector2.GetSize(), vector1.Coordinates);

                subtractionVector = new Vector(vector2.GetSize());

                for (int i = 0; i < vector2.GetSize(); i++)
                {
                    subtractionVector.Coordinates[i] = resultVector1.Coordinates[i] - vector2.Coordinates[i];
                }

                return subtractionVector;
            }

            subtractionVector = new Vector(vector1.GetSize());

            for (int i = 0; i < vector1.GetSize(); i++)
            {
                subtractionVector.Coordinates[i] = vector1.Coordinates[i] - vector2.Coordinates[i];
            }

            return subtractionVector;
        }

        public static double GetVectorsScalarProduct(Vector vector1, Vector vector2)
        {
            double scalarProductVector = 0;

            if (vector1.GetSize() > vector2.GetSize())
            {
                Vector resultVector2 = new Vector(vector1.GetSize(), vector2.Coordinates);

                for (int i = 0; i < vector1.GetSize(); i++)
                {
                    scalarProductVector += vector1.Coordinates[i] * resultVector2.Coordinates[i];
                }

                return scalarProductVector;
            }

            if (vector1.GetSize() < vector2.GetSize())
            {
                Vector resultVector1 = new Vector(vector2.GetSize(), vector1.Coordinates);

                for (int i = 0; i < vector2.GetSize(); i++)
                {
                    scalarProductVector += resultVector1.Coordinates[i] * vector2.Coordinates[i];
                }

                return scalarProductVector;
            }

            for (int i = 0; i < vector1.GetSize(); i++)
            {
                scalarProductVector += vector1.Coordinates[i] * vector2.Coordinates[i];
            }

            return scalarProductVector;
        }
    }
}