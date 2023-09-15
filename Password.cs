namespace PasswordGeneratorLibrary
{
    public abstract class Password
    {
        public IPasswordText text;
        public IAlphabet alphabet;
         
        protected Password(IPasswordText text, IAlphabet alphabet, string? startPosition)
        {
            this.text = text;
            this.alphabet = alphabet;

            text.UpdateTextSize(text.Count, this.alphabet);            

            if (!String.IsNullOrEmpty(startPosition))
                text!.SetStart(startPosition, alphabet);
        }
    }
}