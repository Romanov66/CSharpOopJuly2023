using Academits.Romanov.VectorTask;
using System.Text;

namespace Academits.Romanov.MatrixTask
{
    public class Matrix
    {
        public double[,] CoordinatesArrays { get; set; }

        public Matrix(int rowsCount, int columnsCount)
        {
            CoordinatesArrays = new double[rowsCount, columnsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    CoordinatesArrays[i, j] = 0;
                }
            }
        }

        public Matrix(Matrix matrix)
        {
            CoordinatesArrays = new double[matrix.CoordinatesArrays.GetLength(0), matrix.CoordinatesArrays.GetLength(1)];

            for (int i = 0; i < matrix.CoordinatesArrays.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.CoordinatesArrays.GetLength(1); j++)
                {
                    CoordinatesArrays[i, j] = matrix.CoordinatesArrays[i, j];
                }
            }
        }

        public Matrix(double[,] coordinatesArrays)
        {
            CoordinatesArrays = new double[coordinatesArrays.GetLength(0), coordinatesArrays.GetLength(1)];

            for (int i = 0; i < coordinatesArrays.GetLength(0); i++)
            {
                for (int j = 0; j < coordinatesArrays.GetLength(1); j++)
                {
                    CoordinatesArrays[i, j] = coordinatesArrays[i, j];
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            CoordinatesArrays = new double[vectors.Length, vectors[0].Coordinates.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                for (int j = 0; j < vectors[0].Coordinates.Length; j++)
                {
                    CoordinatesArrays[i, j] = vectors[i].Coordinates[j];
                    double temp = CoordinatesArrays[i, j];
                }
            }
        }

        public int GetColumnsAmount()
        {
            return GetRow(0).GetSize();
        }

        public int GetRowsAmount()
        {
            return CoordinatesArrays.Length / GetColumnsAmount();
        }

        public Vector GetRow(int index)
        {
            double[] coordinates = new double[CoordinatesArrays.GetLength(1)];

            for (int i = 0; i < CoordinatesArrays.GetLength(1); i++)
            {
                coordinates[i] = CoordinatesArrays[index, i];
                double r = coordinates[i];
            }

            return new Vector(coordinates);
        }

        public Vector GetColumn(int index)
        {
            double[] coordinates = new double[CoordinatesArrays.GetLength(0)];

            for (int i = 0; i < CoordinatesArrays.GetLength(0); i++)
            {
                coordinates[i] = CoordinatesArrays[i, index];
                double temp = coordinates[i];
            }

            return new Vector(coordinates);
        }

        public Matrix TransposeMatrix()
        {
            Vector[] vectors = new Vector[CoordinatesArrays.GetLength(1)];

            for (int i = 0; i < CoordinatesArrays.GetLength(1); i++)
            {

                vectors[i] = GetColumn(i);
            }

            return new Matrix(vectors);
        }

        public Matrix ToScaleUp(double scalar)
        {
            Matrix resultMatrix = new Matrix(CoordinatesArrays);

            for (int i = 0; i < CoordinatesArrays.GetLength(0); i++)
            {
                for (int j = 0; j < CoordinatesArrays.GetLength(1); j++)
                {
                    resultMatrix.CoordinatesArrays[i, j] *= scalar;
                }
            }

            return resultMatrix;
        }

        public double FindDeterminant()
        {
            Vector resultRow = GetRow(0);
            double determinant = 0;

            for (int i = 0; i < resultRow.Coordinates.Length; i++)
            {
                determinant += resultRow.Coordinates[i] * GetAlgebDop(i + 1, CoordinatesArrays);
            }

            return determinant;
        }

        public double GetAlgebDop(int columnNumber, double[,] coordinatesArrays)
        {
            Matrix matrix = new Matrix(GetNewMatrix(columnNumber - 1, coordinatesArrays));
            Matrix resultMatrix = new Matrix(matrix);
            double algebDop = 0;

            for(int i = 0; i < matrix.CoordinatesArrays.GetLength(0); i++)
            {              
                while(resultMatrix.CoordinatesArrays.GetLength(0) != 2)
                {
                    resultMatrix.CoordinatesArrays = GetNewMatrix(i, resultMatrix.CoordinatesArrays);
                }

                double a = matrix.CoordinatesArrays[0, i];
                double b = Math.Pow(-1, i + 1 + 1);
                double c1 = resultMatrix.CoordinatesArrays[0, 0];
                double c2 = resultMatrix.CoordinatesArrays[1, 1];
                double c3 = resultMatrix.CoordinatesArrays[0, 1];
                double c4 = resultMatrix.CoordinatesArrays[1, 0];

                double result = matrix.CoordinatesArrays[0, i] * Math.Pow(-1, i + 1 + 1) * (resultMatrix.CoordinatesArrays[0, 0] * resultMatrix.CoordinatesArrays[1, 1] - resultMatrix.CoordinatesArrays[0, 1] * resultMatrix.CoordinatesArrays[1, 0]);

                algebDop += matrix.CoordinatesArrays[0, i] * Math.Pow(-1, i + 1 + 1) * (resultMatrix.CoordinatesArrays[0, 0] * resultMatrix.CoordinatesArrays[1, 1] - resultMatrix.CoordinatesArrays[0, 1] * resultMatrix.CoordinatesArrays[1, 0]);

                resultMatrix.CoordinatesArrays = matrix.CoordinatesArrays;
            }

            return Math.Pow(-1, columnNumber + 1) * algebDop;
        }

        /*public double GetAlgebDop(int columnNumber, double[,] coordinatesArrays)
        {
             Matrix matrix = new Matrix(coordinatesArrays);

            if (coordinatesArrays.GetLength(0) == 2 && coordinatesArrays.GetLength(1) == 2)
            {
                double algebDop = coordinatesArrays[0, 0] * coordinatesArrays[1, 1] - coordinatesArrays[0, 1] * coordinatesArrays[1, 0];
                return algebDop;
            }

            if(coordinatesArrays.GetLength(0) == CoordinatesArrays.GetLength(0) && coordinatesArrays.GetLength(1) == CoordinatesArrays.GetLength(1))
            {
                return Math.Pow(-1, columnNumber + 1) * coordinatesArrays[0, columnNumber - 1] * GetAlgebDop(columnNumber, GetNewMatrix(columnNumber - 1, coordinatesArrays));
            }
                        
            return Math.Pow(-1, columnNumber + 1) * coordinatesArrays[0, 0] * GetAlgebDop(columnNumber, GetNewMatrix(0, coordinatesArrays));
        }*/

        public double[,] GetNewMatrix(int index, double[,] coordinatesArrays)
        {
            double[,] newArrays = new double[coordinatesArrays.GetLength(0) - 1, coordinatesArrays.GetLength(1)];

            for (int i = 0; i < newArrays.GetLength(0); i++)
            {
                for (int j = 0; j < newArrays.GetLength(1); j++)
                {
                    newArrays[i, j] = coordinatesArrays[i + 1, j];
                    double c = newArrays[i, j];
                }
            }

            Matrix matrix = new Matrix(newArrays);

            matrix = matrix.TransposeMatrix();

            newArrays = new double[matrix.CoordinatesArrays.GetLength(0) - 1, matrix.CoordinatesArrays.GetLength(1)];

            for (int i = 0; i < newArrays.GetLength(0); i++)
            {
                for (int j = 0; j < newArrays.GetLength(1); j++)
                {
                    if (i >= index)
                    {
                        newArrays[i, j] = matrix.CoordinatesArrays[i + 1, j];
                        double v = newArrays[i, j]; 
                    }
                    else
                    {
                        newArrays[i, j] = matrix.CoordinatesArrays[i, j];
                        double b = newArrays[i, j];
                    }                    
                }
            }

            return new Matrix(newArrays).TransposeMatrix().CoordinatesArrays;
        }

        public Vector MultiplyVector (Vector vector)
        {
            Vector resultVector = new Vector(vector);
            Matrix resultMatrix = new Matrix(CoordinatesArrays);

            if (vector.Coordinates.Length != CoordinatesArrays.GetLength(1))
            {
                if(vector.Coordinates.Length > CoordinatesArrays.GetLength(1))
                {
                    resultMatrix = new Matrix(CoordinatesArrays.GetLength(0), vector.Coordinates.Length);

                    for (int i = 0; i < CoordinatesArrays.GetLength(0); i++)
                    {
                        for (int j = 0; j < CoordinatesArrays.GetLength(1); j++)
                        {
                            resultMatrix.CoordinatesArrays[i, j] = CoordinatesArrays[i, j];
                        }
                    }
                }
                else
                {
                    resultVector = new Vector(resultMatrix.CoordinatesArrays.GetLength(1));

                    for(int i = 0; i < vector.Coordinates.Length; i++)
                    {
                        resultVector.Coordinates[i] = vector.Coordinates[i];
                    }
                }
            }

            Vector newVector = new Vector(resultVector.Coordinates.Length);

            for (int i = 0; i < resultMatrix.CoordinatesArrays.GetLength(0); i++)
            {
                for (int j = 0; j < resultMatrix.CoordinatesArrays.GetLength(1); j++)
                {
                    newVector.Coordinates[i] += resultMatrix.CoordinatesArrays[i, j] * resultVector.Coordinates[j];
                }
            }

            return newVector;
        }

        public Matrix AddMatrix(Matrix inputMatrix)
        {
            Matrix resultMatrix = new Matrix(CoordinatesArrays);
            Matrix resultInputMatrix = new Matrix(inputMatrix);

            if(resultMatrix.CoordinatesArrays.GetLength(0) != inputMatrix.CoordinatesArrays.GetLength(0) || resultMatrix.CoordinatesArrays.GetLength(1) != inputMatrix.CoordinatesArrays.GetLength(1))
            {
                if(resultMatrix.CoordinatesArrays.GetLength(0) != inputMatrix.CoordinatesArrays.GetLength(0) && resultMatrix.CoordinatesArrays.GetLength(1) == inputMatrix.CoordinatesArrays.GetLength(1))
                {
                    if(resultMatrix.CoordinatesArrays.GetLength(0) > inputMatrix.CoordinatesArrays.GetLength(0))
                    {
                        resultInputMatrix = new Matrix(resultMatrix.CoordinatesArrays.GetLength(0), resultInputMatrix.CoordinatesArrays.GetLength(1));

                        for(int i = 0; i < resultInputMatrix.CoordinatesArrays.GetLength(0); i++)
                        {
                            for(int j = 0; j < resultInputMatrix.CoordinatesArrays.GetLength(1); j++)
                            {
                                resultInputMatrix.CoordinatesArrays[i, j] = CoordinatesArrays[i, j];
                            }
                        }
                    }
                    else
                    {
                        resultMatrix = new Matrix(resultInputMatrix.CoordinatesArrays.GetLength(0), resultMatrix.CoordinatesArrays.GetLength(1));

                        for (int i = 0; i < resultMatrix.CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < resultMatrix.CoordinatesArrays.GetLength(1); j++)
                            {
                                resultMatrix.CoordinatesArrays[i, j] = resultInputMatrix.CoordinatesArrays[i, j];
                            }
                        }
                    }
                }
                else if(resultMatrix.CoordinatesArrays.GetLength(0) == inputMatrix.CoordinatesArrays.GetLength(0) && resultMatrix.CoordinatesArrays.GetLength(1) != inputMatrix.CoordinatesArrays.GetLength(1))
                {
                    if (resultMatrix.CoordinatesArrays.GetLength(1) > inputMatrix.CoordinatesArrays.GetLength(1))
                    {
                        resultInputMatrix = new Matrix(resultInputMatrix.CoordinatesArrays.GetLength(0), resultMatrix.CoordinatesArrays.GetLength(1));

                        for (int i = 0; i < resultInputMatrix.CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < resultInputMatrix.CoordinatesArrays.GetLength(1); j++)
                            {
                                resultInputMatrix.CoordinatesArrays[i, j] = CoordinatesArrays[i, j];
                            }
                        }
                    }
                    else
                    {
                        resultMatrix = new Matrix(resultMatrix.CoordinatesArrays.GetLength(0), resultInputMatrix.CoordinatesArrays.GetLength(1));

                        for (int i = 0; i < resultMatrix.CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < resultMatrix.CoordinatesArrays.GetLength(1); j++)
                            {
                                resultMatrix.CoordinatesArrays[i, j] = resultInputMatrix.CoordinatesArrays[i, j];
                            }
                        }
                    }
                }
                else
                {
                    if(resultMatrix.CoordinatesArrays.GetLength(0) < inputMatrix.CoordinatesArrays.GetLength(0) && resultMatrix.CoordinatesArrays.GetLength(1) > inputMatrix.CoordinatesArrays.GetLength(1))
                    {
                        resultMatrix = new Matrix(inputMatrix.CoordinatesArrays.GetLength(0), resultMatrix.CoordinatesArrays.GetLength(1));
                        resultInputMatrix = new Matrix(resultMatrix);

                        for(int i = 0; i < CoordinatesArrays.GetLength(0); i++)
                        {
                            for(int j = 0; j < CoordinatesArrays.GetLength(1); j++)
                            {
                                resultMatrix.CoordinatesArrays[i, j] = CoordinatesArrays[i, j];
                            }
                        }

                        for (int i = 0; i < inputMatrix.CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < inputMatrix.CoordinatesArrays.GetLength(1); j++)
                            {
                                resultInputMatrix.CoordinatesArrays[i, j] = inputMatrix.CoordinatesArrays[i, j];
                            }
                        }
                    }
                    else if(resultMatrix.CoordinatesArrays.GetLength(0) > inputMatrix.CoordinatesArrays.GetLength(0) && resultMatrix.CoordinatesArrays.GetLength(1) < inputMatrix.CoordinatesArrays.GetLength(1))
                    {

                        resultMatrix = new Matrix(resultMatrix.CoordinatesArrays.GetLength(0), inputMatrix.CoordinatesArrays.GetLength(1));
                        resultInputMatrix = new Matrix(resultMatrix);

                        for (int i = 0; i < CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < CoordinatesArrays.GetLength(1); j++)
                            {
                                resultMatrix.CoordinatesArrays[i, j] = CoordinatesArrays[i, j];
                            }
                        }

                        for (int i = 0; i < inputMatrix.CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < inputMatrix.CoordinatesArrays.GetLength(1); j++)
                            {
                                resultInputMatrix.CoordinatesArrays[i, j] = inputMatrix.CoordinatesArrays[i, j];
                            }
                        }
                    }
                    else if(resultMatrix.CoordinatesArrays.GetLength(0) < inputMatrix.CoordinatesArrays.GetLength(0) && resultMatrix.CoordinatesArrays.GetLength(1) < inputMatrix.CoordinatesArrays.GetLength(1))
                    {
                        resultMatrix = new Matrix(inputMatrix.CoordinatesArrays.GetLength(0), inputMatrix.CoordinatesArrays.GetLength(1));
                        resultInputMatrix = new Matrix(resultMatrix);

                        for (int i = 0; i < CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < CoordinatesArrays.GetLength(1); j++)
                            {
                                resultMatrix.CoordinatesArrays[i, j] = CoordinatesArrays[i, j];
                            }
                        }

                        for (int i = 0; i < inputMatrix.CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < inputMatrix.CoordinatesArrays.GetLength(1); j++)
                            {
                                resultInputMatrix.CoordinatesArrays[i, j] = inputMatrix.CoordinatesArrays[i, j];
                            }
                        }
                    }
                    else
                    {
                        resultMatrix = new Matrix(CoordinatesArrays.GetLength(0), CoordinatesArrays.GetLength(1));
                        resultInputMatrix = new Matrix(resultMatrix);

                        for (int i = 0; i < CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < CoordinatesArrays.GetLength(1); j++)
                            {
                                resultMatrix.CoordinatesArrays[i, j] = CoordinatesArrays[i, j];
                            }
                        }

                        for (int i = 0; i < inputMatrix.CoordinatesArrays.GetLength(0); i++)
                        {
                            for (int j = 0; j < inputMatrix.CoordinatesArrays.GetLength(1); j++)
                            {
                                resultInputMatrix.CoordinatesArrays[i, j] = inputMatrix.CoordinatesArrays[i, j];
                            }
                        }
                    }
                }
            }

            Matrix newMatrix = new Matrix(resultMatrix.CoordinatesArrays.GetLength(0), resultMatrix.CoordinatesArrays.GetLength(1));

            for(int i = 0; i < resultMatrix.CoordinatesArrays.GetLength(0); i++)
            {
                for(int j = 0; j < resultMatrix.CoordinatesArrays.GetLength(1); j++)
                {
                    newMatrix.CoordinatesArrays[i, j] = resultMatrix.CoordinatesArrays[i, j] + resultInputMatrix.CoordinatesArrays[i, j];
                }
            }

            return newMatrix;
        }

        public override string ToString()
        {
            StringBuilder coordinates = new StringBuilder();

            for (int i = 0; i < CoordinatesArrays.GetLength(0); i++)
            {
                coordinates.Append("{ ");

                for (int j = 0; j < CoordinatesArrays.GetLength(1); j++)
                {
                    if (j == CoordinatesArrays.GetLength(1) - 1)
                    {
                        coordinates.Append(CoordinatesArrays[i, j]);
                    }
                    else
                    {
                        coordinates.Append(CoordinatesArrays[i, j] + ", ");
                    }
                }

                if (i == CoordinatesArrays.GetLength(0) - 1)
                {
                    coordinates.Append(" }");
                }
                else
                {
                    coordinates.Append(" }, ");
                }

            }

            return "{ " + coordinates.ToString() + " }";
        }
    }
}