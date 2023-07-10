namespace Academits.Romanov.RangeTask
{
    public class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double point)
        {
            return point >= From && point <= To;
        }

        public Range GetIntersectionInterval(double from, double to)
        {
            if (From >= to || To <= from)
            {
                return null;
            }

            double maxFrom = From > from ? From : from;
            double minTo = To < to ? To : to;

            return new Range(maxFrom, minTo);
        }

        public Range GetUnionInterval(double from, double to)
        {
            double minFrom = From < from ? From : from;
            double maxTo = To > to ? To : to;

            return new Range(minFrom, maxTo);
        }

        public Range[] GetUnionIntervalsArray(double from, double to)
        {
            Range range1 = new Range(From, To);
            Range range2 = new Range(from, to);

            return new Range[] { range1, range2 };
        }

        public Range GetDifferenceInterval(double from, double to)
        {
            if (From == from)
            {
                double newFrom = To - 1;

                return new Range(newFrom, To);
            }

            if (To == to)
            {
                double newTo = from - 1;

                return new Range(From, newTo);
            }

            return new Range(From, To);
        }

        public Range[] GetDifferenceIntervalsArray(double from, double to)
        {
            double newFrom = To - 1;
            double newTo = from - 1;

            Range range1 = new Range(From, newTo);
            Range range2 = new Range(newFrom, To);

            return new Range[] { range1, range2 };
        }
    }
}