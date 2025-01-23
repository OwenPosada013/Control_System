namespace Control_System.Models
{
    public class ProductSale
    {
        public int IdProductSale { get; set; }
        public int IdProductRegister { get; set; }
        public int Cant_Total { get; set; }
        public decimal Price_Total { get; set; }
        public DateTime Date { get; set; }
    }
}
