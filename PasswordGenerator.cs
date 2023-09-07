namespace PasswordGeneratorLibrary
{
    internal class PasswordGenerator : Password
    {             
        public PasswordGenerator(ILength numberOfSymbols, IAlphabet alphabet, IOrder orderBy,
            string? startPosition = null) 
            : base(numberOfSymbols, alphabet, orderBy, startPosition)
        { }  
    }
}