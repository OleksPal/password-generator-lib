namespace PasswordGeneratorLibrary
{
    internal abstract class Password
    {
        protected ILength numberOfSymbols;
        protected IPasswordText text;

        protected Password(ILength numberOfSymbols, IPasswordText text, string? startPosition = null)
        {
            this.numberOfSymbols = numberOfSymbols;            
            this.text = text;
        }

        public static Password operator ++(Password previousPassword)
        {
            var currentNode = previousPassword.text.Last;
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
    }
}