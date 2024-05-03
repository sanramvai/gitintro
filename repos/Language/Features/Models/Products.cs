namespace Features.Models
{
    public class Products
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }

        public Products[] GetProducts()
        {
            Products kayak = new Products
            {
                Name = "Kayak",
                Price = 275M
            };
            Products lifejacket = new Products
            {
                Name = "Lifejacket",
                Price = 48.95M
            };
            return new Products[] { kayak, lifejacket,null };
        }

    }
}
