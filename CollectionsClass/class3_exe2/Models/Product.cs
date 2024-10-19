using System;
using System.Collections.Generic;

public class Product : IComparable<Product>
{
    // Atributos
    public string Name { get; private set; }
    public double Price { get; private set; }

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

    // Comparar por nome
    public int CompareTo(Product p)
    {
        if (p == null)
        {
            return 1;
        }
        return string.Compare(Name, p.Name, StringComparison.OrdinalIgnoreCase);
    }
}   