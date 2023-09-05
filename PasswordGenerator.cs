namespace PasswordGeneratorLibrary
{
    internal class PasswordGenerator : Password
    {             
        public PasswordGenerator(ILength numberOfSymbols, IPasswordText text,
            string? startPosition = null) 
            : base(numberOfSymbols, text, startPosition)
        { }  
    }
}