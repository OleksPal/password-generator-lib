namespace PasswordGeneratorLibrary
{
    public struct Password
    {
        private int numberOfSymbols;
        private string? alphabet;
        public LinkedList<char> password;

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

        public Password(string alphabet = Constants.SmallLetters, int numberOfSymbols = 1)
        {
            Alphabet = alphabet;
            NumberOfSymbols = numberOfSymbols;
            password = new LinkedList<char>();

            // initialize password with start values
            for (int i = 0; i < numberOfSymbols; i++)
                password.AddLast(alphabet[0]);
        }

        public static Password operator ++(Password password)
        {
            var currentNode = password.password.Last;
            int index = password.Alphabet.IndexOf(currentNode.Value);
            var referenceLastNode = password.password.Last.ValueRef;

            if (index < password.Alphabet.Length)
            {
                currentNode.Value = 'b';
                return password;
            }
            return password;
        }

        public override string ToString()
        {
            string result = String.Empty;
            var currentNode = password.First;
            while (currentNode != null)
            {
                result += currentNode.Value.ToString();
                currentNode = currentNode.Next;
            }
            return result;
        }
    }
}