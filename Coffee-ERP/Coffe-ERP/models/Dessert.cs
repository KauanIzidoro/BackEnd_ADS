using System;

public class Dessert : Item
{
    // Atributos e Getters & Setters
    public string Flavor {get; private set;}

    // Construtor
    public Dessert(string name, decimal price, string flavor) : base(name, price)
    {
        Flavor = flavor;
    }

   // Métodos
   public override decimal ComputePrice()
   {
    return Price;
   } 
   public override string ToString()
   {
    return $"Item: {Name}, Price: {Price:C}, Flavor: {Flavor}";
   }
   
}