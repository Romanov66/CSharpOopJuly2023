using Academits.Romanov.IShapeTask;

namespace IShapeTask
{
    public class ShapePerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape currentShape, IShape nextShape)
        {
            if (currentShape is null || nextShape is null)
            {
                throw new Exception("Некорректное значение параметра");
            }

            double currentShapePerimeter = currentShape.GetPerimeter();
            double nextShapePerimeter = nextShape.GetPerimeter();

            if (currentShapePerimeter > nextShapePerimeter)
            {
                return 1;
            }

            if (currentShapePerimeter < nextShapePerimeter)
            {
                return -1;
            }

            return 0;
        }
    }
}