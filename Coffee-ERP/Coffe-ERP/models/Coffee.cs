using System;

public class Coffee : Drink 
{
    // Atributos e Getters & Setters 
    public string Type {get; private set;}

    // Contrutor 
    public Coffee(string name, decimal price, string size, string type) : base(name, price, size)
    {
        Type = type;
        price = ComputePrice();
    }

    // Métodos 
    public override decimal ComputePrice()
    {
        return Size == "Grande" ? Price * 2 : Price; 
    }

    public override string ToString()
    {
        return $"Item: {Name}, Price: {Price:C}, Size: {Size}, Type: {Type}";
    }
}