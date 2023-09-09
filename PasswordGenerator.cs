namespace PasswordGeneratorLibrary
{
    public class PasswordGenerator : Password
    {             
        public PasswordGenerator(IPasswordText numberOfSymbols, IAlphabet alphabet, IOrder orderBy,
            string? startPosition = null) 
            : base(numberOfSymbols, alphabet, orderBy, startPosition)
        { }  
    }
}