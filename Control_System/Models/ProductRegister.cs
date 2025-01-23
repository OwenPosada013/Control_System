namespace Control_System.Models
{
    public class ProductRegister
    {
        public int IdProductRegister { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Cant { get; set; }
        public string? TypeProduct { get; set; }
        public string Provider { get; set; }
    }
}
