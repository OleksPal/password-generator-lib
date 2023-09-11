namespace PasswordGeneratorLibrary
{
    public class PasswordGenerator : Password
    {             
        public PasswordGenerator(IPasswordText numberOfSymbols, IAlphabet alphabet, IOrder orderBy,
            string? startPosition = null) 
            : base(numberOfSymbols, alphabet, orderBy, startPosition)
        { }

        public static PasswordGenerator operator ++(PasswordGenerator previousPassword)
        {
            PasswordGenerator newPassword = new PasswordGenerator(previousPassword.text,
                previousPassword.alphabet, previousPassword.orderBy);

            LinkedListNode<char>? currentNode = newPassword.text.Text.Last;
            // Index of node’s value in alphabet
            int alphabetIndex = newPassword.alphabet.Alphabet.IndexOf(currentNode!.Value);

            if (alphabetIndex < newPassword.alphabet.Alphabet.Length - 1)
                currentNode.Value = newPassword.alphabet.Alphabet[++alphabetIndex];
            else
            {
                while (currentNode != null)
                {
                    if (currentNode.Previous == null) // Can’t increase previous value
                        return newPassword;
                    currentNode.Value = newPassword.alphabet.Alphabet[0];
                    currentNode = currentNode.Previous;
                    alphabetIndex = newPassword.alphabet.Alphabet.IndexOf(currentNode.Value);
                    if (alphabetIndex < newPassword.alphabet.Alphabet.Length - 1)
                    {
                        currentNode.Value = newPassword.alphabet.Alphabet[++alphabetIndex];
                        break;
                    }
                }
            }            
            return newPassword;
        }
    }
}