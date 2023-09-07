namespace PasswordGeneratorLibrary
{
    public interface IAlphabet
    {
        public string Alphabet { get; set; }

        public string Reverse(string s);

        public string RemoveDuplicates(string inputAlphabet);

        public bool IsContains(string value);
    }

    internal class PasswordAlphabet : IAlphabet
    {
        public string Alphabet
        {
            get => Alphabet!;
            set
            {
                if (!String.IsNullOrEmpty(value))
                    Alphabet = RemoveDuplicates(value);
                else if (Alphabet == null) Alphabet = Constants.SmallLetters;
            }
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string RemoveDuplicates(string inputAlphabet)
        {
            HashSet<char> hashSet = new HashSet<char>();
            for (int i = 0; i < inputAlphabet.Length; i++)
                hashSet.Add(inputAlphabet[i]);

            string result = String.Empty;
            foreach (var element in hashSet)
                result += element;

            return result;
        }

        public bool IsContains(string value)
        {
            bool isContains = true;
            foreach (char symbol in value)
            {
                if (!Alphabet.Contains(symbol))
                {
                    isContains = false;
                    break;
                }
            }
            return isContains;
        }
    }
}
