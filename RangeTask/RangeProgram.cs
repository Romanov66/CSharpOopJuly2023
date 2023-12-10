namespace Academits.Romanov.RangeTask
{
    public class RangeProgram
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(1, 7);
            Range range2 = new Range(3, 5);

            Console.WriteLine("Длина первого интервала составляет: " + range1.GetLength());
            Console.WriteLine("Длина воторого интервала составляет: " + range2.GetLength());
            Console.WriteLine();

            double point = 35;

            if (range1.IsInside(point))
            {
                Console.WriteLine($"Число {point} входит в интервал: " + range1);
            }
            else
            {
                Console.WriteLine($"Число {point} не входит в интервал: " + range1);
            }

            Console.WriteLine();

            Range? intersection = range1.GetIntersection(range2);

            if (intersection is null)
            {
                Console.WriteLine("Пересечений нет");
            }
            else
            {
                Console.WriteLine("Координаты интервала-пересечения: " + intersection);
            }

            Console.WriteLine();

            Range[] union = range1.GetUnion(range2);

            Console.WriteLine($"Координаты интервала-объединения: [{string.Join<Range>(", ", union)}]");
            Console.WriteLine();

            Range[] difference = range1.GetDifference(range2);

            Console.WriteLine($"Координаты разности интервалов: [{string.Join<Range>(", ", difference)}]");
            Console.WriteLine();
        }
    }
}
