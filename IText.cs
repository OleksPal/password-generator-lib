namespace PasswordGeneratorLibrary
{
    public interface IText
    {
        public LinkedList<char> Text { get; set; }

        public void SetStart(string startPosition, IAlphabet alphabet);

        public void Reset(IAlphabet alphabet);

        public bool IsMax(IAlphabet alphabet);

        public void UpdateTextSize(int size, IAlphabet alphabet, ILength numberOfSymbols);

        public string ToString();
    }

    internal class PasswordText : IText
    {
        public LinkedList<char> Text
        {
            get => Text;
            set => Text = value;
        }

        public void SetStart(string startPosition, IAlphabet alphabet)
        {
            if (alphabet.IsContains(startPosition))
            {
                var currentNode = Text.First;

                int stringIndex = 0;
                while (currentNode != null && stringIndex != startPosition.Length)
                {
                    currentNode.Value = startPosition[stringIndex];
                    currentNode = currentNode.Next;
                    stringIndex++;
                }
            }
        }

        public void Reset(IAlphabet alphabet)
        {
            var currentNode = Text.First;

            while (currentNode != null)
            {
                currentNode.Value = alphabet.Alphabet[0];
                currentNode = currentNode.Next;
            }
        }

        public bool IsMax(IAlphabet alphabet)
        {
            var currentNode = Text.Last;
            while (currentNode != null)
            {
                if (currentNode.Value != alphabet.Alphabet[^1])
                    return false;
                currentNode = currentNode.Previous;
            }
            return true;
        }

        public override string ToString()
        {
            string result = String.Empty;
            var currentNode = Text.First;
            while (currentNode != null)
            {
                result += currentNode.Value.ToString();
                currentNode = currentNode.Next;
            }
            return result;
        }

        public void UpdateTextSize(int size, IAlphabet alphabet, ILength numberOfSymbols)
        {
            if (Text == null)
                Text = new LinkedList<char>();

            if (size > numberOfSymbols.Count && size >= 1)
            {
                numberOfSymbols.Count = size;

                // Initialize password with start values
                while (Text.Count < size)
                    Text.AddFirst(alphabet.Alphabet[0]);
            }
            else if (size < numberOfSymbols.Count && size >= 1)
            {
                numberOfSymbols.Count = size;

                while (size < Text.Count)
                    Text.RemoveFirst();
            }
            else
            {
                numberOfSymbols.Count = 1;
                Text.AddLast(alphabet.Alphabet[0]);
            }
        }
    }
}