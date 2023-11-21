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

        public Range GetIntersection(Range range)
        {
            if (From >= range.To || To <= range.From)
            {
                return null;
            }

            double maxFrom = From > range.From ? From : range.From;
            double minTo = To < range.To ? To : range.To;

            return new Range(maxFrom, minTo);
        }

        public Range[] GetUnion(Range range)
        {
            if (From <= range.From && To >= range.To)
            {
                return new Range[] { new(From, To) };
            }

            if (range.From <= From && range.To >= To)
            {
                return new Range[] { new(range.From, range.To) };
            }

            if (From > range.To || To < range.From)
            {
                return new Range[] { this, range };
            }

            double minFrom = From > range.From ? From : range.From;
            double maxTo = To < range.To ? To : range.To;

            return new Range[] { new(minFrom, maxTo) };
        }

        public Range[] GetDifference(Range range)
        {
            if (From < range.From && To > range.To)
            {
                return new Range[] { new(From, range.From), new(range.To, To) };
            }

            if (From == range.From)
            {
                return To > range.To ? new Range[] { new(range.To, To) } : new Range[] { };
            }

            if (To == range.To)
            {
                return From < range.From ? new Range[] { new(From, range.From) } : new Range[] { };
            }

            return new Range[] { };
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }
    }
}