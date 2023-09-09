namespace PasswordGeneratorLibrary
{
    public interface IPasswordText : IText
    {
        public int Count { get; set; }
    }

    public class PasswordText : IPasswordText
    {
        private LinkedList<char> text;
        private int count;

        public LinkedList<char> Text
        {
            get => text;
            set => text = value;
        }

        public int Count
        {
            get => count;
            set
            {
                if (value >= 1)
                    count = value;
            }
        }

        public PasswordText(int size)
        {
            Count = size;
            text = new LinkedList<char>();
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

        public void UpdateTextSize(int size, IAlphabet alphabet)
        {
            if (Text == null)
                Text = new LinkedList<char>();

            if (size > Count && size >= 1)
            {
                Count = size;

                // Initialize password with start values
                while (Text.Count < size)
                    Text.AddFirst(alphabet.Alphabet[0]);
            }
            else if (size < Count && size >= 1)
            {
                Count = size;

                while (size < Text.Count)
                    Text.RemoveFirst();
            }
            else
            {
                Count = 1;
                Text.AddLast(alphabet.Alphabet[0]);
            }
        }
    }
}