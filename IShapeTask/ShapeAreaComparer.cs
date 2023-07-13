namespace Academits.Romanov.IShapeTask
{
    public class ShapeAreaComparer : IComparer<IShape>
    {
        public int Compare(IShape currentShape, IShape nextShape)
        {
            if (currentShape is null || nextShape is null)
            {
                throw new Exception("Некорректное значение параметра");
            }

            double currentShapeArea = currentShape.GetArea();
            double nextShapeArea = nextShape.GetArea();

            if (currentShapeArea > nextShapeArea)
            {
                return 1;
            }

            if (currentShapeArea < nextShapeArea)
            {
                return -1;
            }

            return 0;
        }
    }
}