namespace PasswordGeneratorLibrary
{
    public interface IText
    {
        public LinkedList<char> Text { get; set; }

        public void SetStart(string startPosition, IAlphabet alphabet);

        public void Reset(IAlphabet alphabet);

        public bool IsMax(IAlphabet alphabet);

        public void UpdateTextSize(int size, IAlphabet alphabet);

        public string ToString();
    }
}