﻿namespace PasswordGeneratorLibrary
{
    internal interface IAlphabet
    {
        public abstract string Alphabet { get; set; }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        protected string RemoveDuplicates(string inputAlphabet)
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

    internal class PasswordAlphabet : IAlphabet
    {
        public override string Alphabet
        {
            get => alphabet!;
            set
            {
                if (!String.IsNullOrEmpty(value))
                    alphabet = RemoveDuplicates(value);
                else if (alphabet == null) alphabet = Constants.SmallLetters;
            }
        }
    }
}
