class Product : IComparable<Product>
{
    // Atributos
    public string Name {get; private set; }
    public double Price {get; private set; }

    // Construtor
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    // ToString 
    public override string ToString()
    {
        return $"Product: {Name}, Price: {Price:C}";
    }

    // Método que deve ser implementado devido a realização da interface IComparable<>
    public int CompareTo(Product p)
    {
        if(p == null)
        {
            return 1;
        }
        return Price.CompareTo(p.Price);
    }
}