using System;

public class Product
{
    // Atributos
    public string Name { get; set; }
    public double Price { get; set; }

    // Construtor 
    public Product(string name, double price)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Price = price >= 0 ? price : throw new ArgumentOutOfRangeException(nameof(price), "Price must be non-negative");
    }

    public override string ToString()
    {
        return $"Product: {Name}, Price: ${Price:F2}";
    }
}
