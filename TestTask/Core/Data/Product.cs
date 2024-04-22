namespace Core.Data
{
    public class Product
    {
        public string Id { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
    }
}
