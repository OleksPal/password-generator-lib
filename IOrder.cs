namespace PasswordGeneratorLibrary
{
    public interface IOrder
    {
        public Order OrderBy { get; set; }

        public string ChangeOrder(Order orderBy, IAlphabet alphabet);

        public enum Order
        {
            Ascending,
            Descending
        }
    }

    internal class PasswordOrder : IOrder
    {
        public IOrder.Order OrderBy
        {
            get => OrderBy;
            set => OrderBy = value;
        }

        public string ChangeOrder(IOrder.Order orderBy, IAlphabet alphabet)
        {
            if(this.OrderBy != orderBy)
            {
                this.OrderBy = orderBy;
                return alphabet.Reverse();
            }
            return alphabet.Alphabet;                
        }
    }
}
