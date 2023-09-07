namespace PasswordGeneratorLibrary
{
    internal abstract class Password
    {
        protected ILength numberOfSymbols;
        protected IAlphabet alphabet;
        protected IText text;
        protected IOrder orderBy;
         
        protected Password(ILength numberOfSymbols, IAlphabet alphabet, IOrder orderBy,
            string? startPosition)
        {
            this.alphabet = alphabet;
            this.orderBy = orderBy;
            this.numberOfSymbols = numberOfSymbols;
            text.UpdateTextSize(numberOfSymbols.Count, this.alphabet, this.numberOfSymbols);            

            if (!String.IsNullOrEmpty(startPosition))
                text!.SetStart(startPosition, alphabet);
        }

        public static Password operator ++(Password previousPassword)
        {
            LinkedListNode<char>? currentNode = previousPassword.text.Text.Last;
            // Index of node’s value in alphabet
            int alphabetIndex = previousPassword.alphabet.Alphabet.IndexOf(currentNode!.Value);

            if (alphabetIndex < previousPassword.alphabet.Alphabet.Length - 1)
                currentNode.Value = previousPassword.alphabet.Alphabet[++alphabetIndex];
            else
            {
                while (currentNode != null)
                {
                    if (currentNode.Previous == null) // Can’t increase previous value
                        return previousPassword;
                    currentNode.Value = previousPassword.alphabet.Alphabet[0];
                    currentNode = currentNode.Previous;
                    alphabetIndex = previousPassword.alphabet.Alphabet.IndexOf(currentNode.Value);
                    if (alphabetIndex < previousPassword.alphabet.Alphabet.Length - 1)
                    {
                        currentNode.Value = previousPassword.alphabet.Alphabet[++alphabetIndex];
                        break;
                    }
                }
            }
            return previousPassword;
        }

        
    }
}