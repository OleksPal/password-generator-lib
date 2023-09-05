namespace PasswordGeneratorLibrary
{
    public interface IOrder
    {
        public Order OrderBy { get; set; }

        public enum Order
        {
            Ascending,
            Descending
        }
    }
}
