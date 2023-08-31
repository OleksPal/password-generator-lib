namespace PasswordGeneratorLibrary
{
    internal abstract class Password
    {
        protected ILength numberOfSymbols;
        protected IAlphabet alphabet;
        protected IText text;
        protected IOrder orderBy;

        protected Password(IAlphabet alphabet, ILength numberOfSymbols,
            IText text, IOrder orderBy)
        {
            this.alphabet = alphabet;
            this.numberOfSymbols = numberOfSymbols;            
            this.text = text;
            this.orderBy = orderBy;
        }
    }
}