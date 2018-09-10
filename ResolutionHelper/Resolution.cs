namespace ResolutionHelper
{
    public class Resolution
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int DisplayMemoryKb { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Resolution resolution))
                return false;

            return GetHashCode() == resolution.GetHashCode();
        }

        public override int GetHashCode()
        {
            var hashCode = 859600377;
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"{Width}x{Height}";
        }
    }
}
