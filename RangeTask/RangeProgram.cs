namespace Academits.Romanov.RangeTask
{
    public class RangeProgram
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(3, 6);

            range1.From = 4.5;
            range1.To = 12;

            Console.WriteLine("Длина интервала составляет: " + range1.GetLength());

            Console.WriteLine();

            double point = 12;

            if (range1.IsInside(point))
            {
                Console.WriteLine($"Число {point} входит в интервал: [{range1.From}; {range1.To}]");
            }
            else
            {
                Console.WriteLine($"Число {point} не входит в интервал: [{range1.From}; {range1.To}]");
            }

            Console.WriteLine();

            Range range2 = new Range(8, 18);

            Range intersectionInterval = range1.GetIntersectionInterval(range2.From, range2.To);

            if (intersectionInterval is null)
            {
                Console.WriteLine("Пересечений нет");
            }
            else
            {
                Console.WriteLine($"Координаты интервала-пересечения: [{intersectionInterval.From}; {intersectionInterval.To}]");
            }

            Console.WriteLine();

            Range range3 = new Range(18, 24);

            if (range2.From <= range3.To && range2.To >= range3.From)
            {
                Range unionInterval = range2.GetUnionInterval(range3.From, range3.To);

                Console.WriteLine($"Координаты интервала-объединения: [{unionInterval.From}; {unionInterval.To}]");
            }
            else
            {
                Range[] unionIntervals = range2.GetUnionIntervalsArray(range3.From, range3.To);

                Range unionInterval1 = unionIntervals[0];
                Range unionInterval2 = unionIntervals[1];

                Console.WriteLine($"Координаты интервалов-объединения: [{unionInterval1.From}; {unionInterval1.To}], [{unionInterval2.From}; {unionInterval2.To}]");
            }

            Console.WriteLine();

            Range range4 = new Range(24, 28);

            if (range3.From >= range4.From && range3.To <= range4.To)
            {
                Console.WriteLine("Интервал не имеет концов");
            }
            else if ((range3.From == range4.From && range3.To > range4.To) || (range3.From < range4.From && range3.To == range4.To) 
                || range3.GetIntersectionInterval(range4.From, range4.To) is null)
            {
                Range differenceInterval = range3.GetDifferenceInterval(range4.From, range4.To);

                Console.WriteLine($"Координаты интервала-разности: [{differenceInterval.From}; {differenceInterval.To}]");
            }
            else
            {
                Range[] differenceIntervals = range3.GetDifferenceIntervalsArray(range4.From, range4.To);

                Range differenceInterval1 = differenceIntervals[0];
                Range differenceInterval2 = differenceIntervals[1];

                Console.WriteLine($"Координаты интервалов-разности: [{differenceInterval1.From}; {differenceInterval1.To}], [{differenceInterval2.From}; {differenceInterval2.To}]");
            }
        }
    }
}
