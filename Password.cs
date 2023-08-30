namespace PasswordGeneratorLibrary
{
    public class Password
    {
        private int numberOfSymbols;
        private string? alphabet;
        private LinkedList<char> text;
        private Order orderBy;

        public enum Order
        {
            Ascending,
            Descending
        }

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

        public string Alphabet
        {
            get => alphabet!;
            set
            {
                if (!String.IsNullOrEmpty(value))
                    alphabet = RemoveDuplicates(value);
                else if (alphabet == null) alphabet = Constants.SmallLetters;
            }
        }

        public LinkedList<char> Text
        {
            get => text;
            private set => text = value;
        }

        public Order OrderBy
        {
            get => orderBy;
            set
            {
                if (value != orderBy)
                    Alphabet = Reverse(Alphabet);
                orderBy = value;
            }
        }

        public Password(string alphabet = Constants.SmallLetters, int numberOfSymbols = 1, 
            string? startPosition = null, Order order = Order.Ascending)
        {
            Alphabet = alphabet;
            NumberOfSymbols = numberOfSymbols;
            if (!String.IsNullOrEmpty(startPosition))
                SetStart(startPosition);
            OrderBy = order;
        }

        public static Password operator ++(Password previousPassword)
        {
            var currentNode = previousPassword.Text.Last;
            // Index of node’s value in alphabet
            int alphabetIndex = previousPassword.Alphabet.IndexOf(currentNode.Value);

            if (alphabetIndex < previousPassword.Alphabet.Length - 1)
                currentNode.Value = previousPassword.Alphabet[++alphabetIndex];
            else
            {
                while (currentNode != null)
                {
                    if (currentNode.Previous == null) // Can’t increase previous value
                        return previousPassword;
                    currentNode.Value = previousPassword.Alphabet[0];
                    currentNode = currentNode.Previous;
                    alphabetIndex = previousPassword.Alphabet.IndexOf(currentNode.Value);
                    if (alphabetIndex < previousPassword.Alphabet.Length - 1)
                    {
                        currentNode.Value = previousPassword.Alphabet[++alphabetIndex];
                        break;
                    }
                }
            }
            return previousPassword;
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

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public bool IsMax()
        {
            var currentNode = Text.Last;
            while (currentNode != null)
            {
                if (currentNode.Value != Alphabet[^1])
                    return false;
                currentNode = currentNode.Previous;
            }
            return true;
        }

        private string RemoveDuplicates(string inputAlphabet)
        {
            HashSet<char> hashSet = new HashSet<char>();
            for (int i = 0; i < inputAlphabet.Length; i++)
                hashSet.Add(inputAlphabet[i]);

            string result = String.Empty;
            foreach (var element in hashSet)
                result += element;

            return result;
        }

        public void Reset()
        {
            var currentNode = Text.First;

            while (currentNode != null)
            {
                currentNode.Value = Alphabet[0];
                currentNode = currentNode.Next;
            }
        }

        public void SetStart(string startPosition)
        {
            if (IsContains(startPosition))
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

        private bool IsContains(string value)
        {
            bool isContains = true;
            foreach (char symbol in value)
            {
                if (!Alphabet.Contains(symbol))
                {
                    isContains = false;
                    break;
                }
            }
            return isContains;
        }
    }
}