namespace PasswordGeneratorLibrary
{
    internal class PasswordGenerator : Password
    {             
        public PasswordGenerator(IAlphabet alphabet = Constants.SmallLetters, ILength numberOfSymbols = 1, 
            string? startPosition = null, IOrder order = Order.Ascending) 
            : base(alphabet, numberOfSymbols, text, order)
        { }

        public static PasswordGenerator operator ++(PasswordGenerator previousPassword)
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