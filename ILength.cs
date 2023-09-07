namespace PasswordGeneratorLibrary
{
    public interface ILength
    {
        public int Count { get; set; }
    }

    internal class NumberOfSymbols : ILength
    {
        public int Count
        {
            get => Count;
            set
            {
                if (value >= 1)
                    Count = value;
            }
        }
    }
}