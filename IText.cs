namespace PasswordGeneratorLibrary
{
    internal interface IText
    {
        public LinkedList<char> Text { get; set; }

        public void SetStart(string startPosition);

        public void Reset();

        public void Ismax();
    }

    internal class Text : IText
    {
        public LinkedList<char> Text
        {
            get => text;
            private set => text = value;
        }

        public void SetStart(string startPosition)
        {
            if (IsContains(startPosition))
            {
                var currentNode = Text.First;

                int stringIndex = 0;
                while (currentNode != null && stringIndex != startPosition.Length)
                {
                    currentNode.Value = startPosition[stringIndex];
                    currentNode = currentNode.Next;
                    stringIndex++;
                }
            }
        }

        public void Reset()
        {
            var currentNode = Text.First;

            while (currentNode != null)
            {
                currentNode.Value = Alphabet[0];
                currentNode = currentNode.Next;
            }
        }

        public bool IsMax()
        {
            var currentNode = Text.Last;
            while (currentNode != null)
            {
                if (currentNode.Value != Alphabet[^1])
                    return false;
                currentNode = currentNode.Previous;
            }
            return true;
        }
    }
}
