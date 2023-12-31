﻿namespace PasswordGeneratorLibrary
{
    public interface IAlphabet
    {
        public string Alphabet { get; set; }

        public void ChangeOrder();

        internal bool IsContains(string value);
    }

    public class PasswordAlphabet : IAlphabet
    {
        private string alphabet;
        public string Alphabet
        {
            get => alphabet!;
            set
            {
                if (!String.IsNullOrEmpty(value))
                    alphabet = RemoveDuplicates(value);
                else if (alphabet == null) alphabet = Constants.SmallLetters;
            }
        }

        public void ChangeOrder() 
        {
            char[] charArray = Alphabet.ToCharArray();
            Array.Reverse(charArray);
            Alphabet = new string(charArray);
        }

        private string RemoveDuplicates(string inputAlphabet)
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
