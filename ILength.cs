namespace PasswordGeneratorLibrary
{
    internal interface ILength
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
                if (value > Count && value >= 1)
                {
                    Count = value;
                    if (Text == null)
                        Text = new LinkedList<char>();

                    // Initialize password with start values
                    while (Text.Count < value)
                        Text.AddFirst(alphabet[0]);
                }
                else if (value < Count && value >= 1)
                {
                    Count = value;

                    while (value < Text.Count)
                        Text.RemoveFirst();
                }
                else
                {
                    if (Text == null)
                    {
                        Count = 1;
                        Text = new LinkedList<char>();
                        Text.AddLast(alphabet[0]);
                    }
                }
            }
        }
    }
}