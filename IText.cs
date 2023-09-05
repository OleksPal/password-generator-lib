namespace PasswordGeneratorLibrary
{
    public interface IText
    {
        public LinkedList<char> Text
        {
            get => Text;
            private set => Text = value;
        }

        public void SetStart(string startPosition);

        public void Reset();

        public bool IsMax();

        public string ToString()
        {
            string result = String.Empty;
            var currentNode = Text.First;
            while (currentNode != null)
            {
                result += currentNode.Value.ToString();
                currentNode = currentNode.Next;
            }
            return result;
        }
    }
}