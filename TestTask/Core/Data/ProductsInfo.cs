namespace Core.Data;

public class ProductsInfo
{
    public string CategoryName { get; set; } = string.Empty;
    public string CategoryUrl { get; set; } = string.Empty;
    public int ProductCount { get; set; }
    public List<Product>? Products { get; set; }
}