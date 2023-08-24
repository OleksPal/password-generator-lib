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
                if (value >= 1)
                    numberOfSymbols = value;
            }
        }

        public string? Alphabet
        {
            get => alphabet;
            set
            {
                if (value != String.Empty && value != null)
                    alphabet = value;
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
            Text = new LinkedList<char>();

            // initialize password with start values
            for (int i = 0; i < numberOfSymbols; i++)
                Text.AddLast(alphabet[0]);
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
    }
}