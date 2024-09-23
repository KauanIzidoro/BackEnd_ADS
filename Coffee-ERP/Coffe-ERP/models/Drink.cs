using System;

public abstract class Drink : Item
{
    // Atributos e Getters & Setters 
    public string Size {get; private set;}

    // Construtor 
    public Drink(string name, decimal price, string size) : base(name, price)
    {
        Size = size;
    }

    // Métodos
    public override abstract decimal ComputePrice();
    public override abstract string ToString();
}