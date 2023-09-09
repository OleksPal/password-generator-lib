namespace PasswordGeneratorLibrary
{
    public abstract class Password
    {
        protected IPasswordText text;
        protected IAlphabet alphabet;
        protected IOrder orderBy;
         
        protected Password(IPasswordText text, IAlphabet alphabet, IOrder orderBy,
            string? startPosition)
        {
            this.text = text;
            this.alphabet = alphabet;
            this.orderBy = orderBy;
            text.UpdateTextSize(text.Count, this.alphabet);            

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