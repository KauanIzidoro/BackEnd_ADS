using System;

public class Item
{
    // Atributos e Getters & Setters 
    public string Name {get; private set; }
    public decimal Price {get; private set; }

    // Construtor 
    public Item(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    // Métodos
    public virtual decimal ComputePrice()
    {
        return Price;
    }

    // ToString
    public override string ToString()
    {
        return $"Item: {Name}, Price: {Price:C}";
    }

}
