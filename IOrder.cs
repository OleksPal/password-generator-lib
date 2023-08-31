namespace PasswordGeneratorLibrary
{
    internal interface IOrder
    {
        public Order OrderBy { get; set; }

        public enum Order
        {
            Ascending,
            Descending
        }
    }

    internal class PasswordOrder : IOrder
    {
        public Order OrderBy
        {
            get => orderBy;
            set
            {
                if (value != orderBy)
                    Alphabet = Alphabet.Reverse(Alphabet);
                orderBy = value;
            }
        }
    }
}
