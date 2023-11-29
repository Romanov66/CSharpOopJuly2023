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

        public Range? GetIntersection(Range range)
        {
            if (From >= range.To || To <= range.From)
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetUnion(Range range)
        {
            if (From > range.To || To < range.From)
            {
                return new Range[] { new(From, To), new(range.From, range.To) };
            }

            return new Range[] { new(Math.Min(From, range.From), Math.Max(To, range.To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if (From > range.To || To < range.From)
            {
                return new Range[] { new(From, To) };
            }

            if (From < range.From && To > range.To)
            {
                return new Range[] { new(From, To) };
            }

            if (From >= range.From && To > range.To)
            {
                return new Range[] { new(range.To, To) };
            }

            if (From < range.From && To <= range.To)
            {
                return new Range[] { new(From, range.From) };
            }

            return new Range[] { };
        }

        public override string ToString()
        {
            return $"({From}; {To})";
        }
    }
}