namespace PasswordGeneratorLibrary
{
    public abstract class Password
    {
        public IPasswordText text;
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
    }
}