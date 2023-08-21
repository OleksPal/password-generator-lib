namespace PasswordGeneratorLibrary
{
    public struct Password
    {
        private int numberOfSymbols;
        private string alphabet;
        private char[] password;

        public int NumberOfSymbols
        {
            get => numberOfSymbols;
            set
            {
                if (value >= 1)
                    numberOfSymbols = value;
            }
        }

        public string Alphabet
        {
            get => alphabet;
            set
            {
                if (value != String.Empty && value != null)
                    alphabet = value;
            }
        }

        public Password(string alphabet, int numberOfSymbols = 1)
        {
            Alphabet = alphabet;
            NumberOfSymbols = numberOfSymbols;
            password = new char[numberOfSymbols];

            // Initialize password with default value
            for (int i = 0; i < numberOfSymbols; i++)
                password[i] = alphabet[0];
        }
    }
}