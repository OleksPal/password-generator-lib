namespace PasswordGeneratorLibrary
{
    internal interface ILength
    {
        public int NumberOfSymbols { get; set; }
    }

    class NumberOfSymbols : ILength
    {
        public int NumberOfSymbols
        {
            get => numberOfSymbols;
            set
            {
                if (value > numberOfSymbols && value >= 1)
                {
                    numberOfSymbols = value;
                    if (Text == null)
                        Text = new LinkedList<char>();

                    // Initialize password with start values
                    while (Text.Count < value)
                        Text.AddFirst(alphabet[0]);
                }
                else if (value < numberOfSymbols && value >= 1)
                {
                    numberOfSymbols = value;

                    while (value < Text.Count)
                        Text.RemoveFirst();
                }
                else
                {
                    if (Text == null)
                    {
                        numberOfSymbols = 1;
                        Text = new LinkedList<char>();
                        Text.AddLast(alphabet[0]);
                    }
                }
            }
        }
    }
}