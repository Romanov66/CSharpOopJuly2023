namespace Test
{
    internal class Vector
    {

        /*double[] vectorsSum;

        if (GetSize() > vector.GetSize())
        {
            Vector resultInputVector = new Vector(GetSize(), vector.Coordinates);

            vectorsSum = new double[GetSize()];

            for (int i = 0; i < GetSize(); i++)
            {
                vectorsSum[i] = Coordinates[i] + resultInputVector.Coordinates[i];
            }

            return vectorsSum;
        }

        if (GetSize() < vector.GetSize())
        {
            Vector resultVector = new Vector(vector.GetSize(), Coordinates);

            vectorsSum = new double[vector.GetSize()];

            for (int i = 0; i < vector.GetSize(); i++)
            {
                vectorsSum[i] = resultVector.Coordinates[i] + vector.Coordinates[i];
            }

            return vectorsSum;
        }

        vectorsSum = new double[GetSize()];

        for (int i = 0; i < GetSize(); i++)
        {
            vectorsSum[i] = Coordinates[i] + vector.Coordinates[i];
        }

        return vectorsSum;*/


        /*double[] vectorsDifference;

        if (GetSize() > vector.GetSize())
        {
            Vector resultInputVector = new Vector(GetSize(), vector.Coordinates);

            vectorsDifference = new double[GetSize()];

            for (int i = 0; i < GetSize(); i++)
            {
                vectorsDifference[i] = Coordinates[i] - resultInputVector.Coordinates[i];
            }

            return vectorsDifference;
        }

        if (GetSize() < vector.GetSize())
        {
            Vector resultVector = new Vector(vector.GetSize(), Coordinates);

            vectorsDifference = new double[vector.GetSize()];

            for (int i = 0; i < vector.GetSize(); i++)
            {
                vectorsDifference[i] = resultVector.Coordinates[i] - vector.Coordinates[i];
            }

            return vectorsDifference;
        }

        vectorsDifference = new double[GetSize()];

        for (int i = 0; i < GetSize(); i++)
        {
            vectorsDifference[i] = Coordinates[i] - vector.Coordinates[i];
        }

        return vectorsDifference;*/


        /*double[] vectorScaling = new double[GetSize()];

        for (int i = 0; i < GetSize(); i++)
        {
            vectorScaling[i] = Coordinates[i] * scalar;
        }

        return vectorScaling;*/


        /*double[] reverseVector = Coordinates;

        for (int i = 0; i < GetSize(); i++)
        {
            if (reverseVector[i] == 0)
            {
                continue;
            }

            reverseVector[i] *= -1;
        }

        return reverseVector;*/



        /*if (vector1.Size > vector2.Size)
        {
            Vector resultVector2 = new Vector(vector1.GetSize(), vector2.Coordinates);

            sumVector = new Vector(vector1.GetSize());

            for (int i = 0; i < vector1.GetSize(); i++)
            {
                sumVector.Coordinates[i] = vector1.Coordinates[i] + resultVector2.Coordinates[i];
            }

            return sumVector;
        }

        if (vector1.GetSize() < vector2.GetSize())
        {
            Vector resultVector1 = new Vector(vector2.GetSize(), vector1.Coordinates);

            sumVector = new Vector(vector2.GetSize());

            for (int i = 0; i < vector2.GetSize(); i++)
            {
                sumVector.Coordinates[i] = resultVector1.Coordinates[i] + vector2.Coordinates[i];
            }

            return sumVector;
        }

        sumVector = new Vector(vector1.GetSize());

        for (int i = 0; i < vector1.GetSize(); i++)
        {
            sumVector.Coordinates[i] = vector1.Coordinates[i] + vector2.Coordinates[i];
        }

        return sumVector;*/


        /*Vector subtractionVector;

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

        return subtractionVector;*/

        /*double scalarProductVector = 0;

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

return scalarProductVector;*/
    }
}
