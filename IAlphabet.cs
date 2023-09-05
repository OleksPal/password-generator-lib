namespace PasswordGeneratorLibrary
{
    public interface IAlphabet
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

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string RemoveDuplicates(string inputAlphabet)
        {
            HashSet<char> hashSet = new HashSet<char>();
            for (int i = 0; i < inputAlphabet.Length; i++)
                hashSet.Add(inputAlphabet[i]);

            string result = String.Empty;
            foreach (var element in hashSet)
                result += element;

            return result;
        }

        protected bool IsContains(string value)
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
