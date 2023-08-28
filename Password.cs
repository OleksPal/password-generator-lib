namespace PasswordGeneratorLibrary
{
    public class Password
    {
        private int numberOfSymbols;
        private string? alphabet;
        private LinkedList<char> text;

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
                if (value != String.Empty && value != null)
                    alphabet = RemoveDuplicates(value);
                else if (alphabet == null) alphabet = Constants.SmallLetters;
            }
        }

        public LinkedList<char> Text
        {
            get => text;
            private set => text = value;
        }

        public Password(string alphabet = Constants.SmallLetters, int numberOfSymbols = 1)
        {
            Alphabet = alphabet;
            NumberOfSymbols = numberOfSymbols;           
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
    }
}