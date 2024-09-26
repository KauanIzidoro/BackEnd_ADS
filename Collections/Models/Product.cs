public class Product : IComparable<Product>
{
    // Propriedades públicas
    public string Name { get; set; }
    public double Price { get; set; }

    // Construtor
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    // Sobrescrevendo o método ToString
    public override string ToString()
    {
        return $"Product: {Name}, Price: {Price:C}";
    }

    public int CompareTo(Product p)
    {
        if (p == null)
        {
            return 1;
        }
        return Price.CompareTo(p.Price);
    }
}
