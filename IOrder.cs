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

    public class PasswordOrder : IOrder
    {
        private IOrder.Order orderBy;
        public IOrder.Order OrderBy
        {
            get => orderBy;
            set => orderBy = value;
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
