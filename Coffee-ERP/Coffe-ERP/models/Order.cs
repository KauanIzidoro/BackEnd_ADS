using System;

public class Order : Item
{
    // Atributos e Getters & Setters
    public int OrderNumber {get; private set;}
    public string Client {get; private set;}
    public List<Item> Itens {get; private set;}
    public decimal Total {get; private set;}

    // Construtor 
    public Order(string name, decimal price, int ordernumber, string client, List<Item> itens) : base(name, price)
    {
        OrderNumber = ordernumber;
        Client = client;
        Itens = itens;
        Total = ComputeTotal();
    }

    // Métodos
    public void AddItem(Item item)
    {
        Itens.Add(item);
        Total = ComputeTotal();
    }
    public void RemoveItem(Item item)
    {
        Itens.Remove(item);
        Total = ComputeTotal();
    }
    public decimal ComputeTotal()
    {
        decimal total = 0;
        foreach (var item in Itens)
        {
            total += item.Price;
        }
        return total;
    }
    public override string ToString()
    {
        string itensDetails = "";
        foreach (var item in Itens)
        {
            itensDetails += $"{item.Name} - {item.Price:C}\n";
        }
        return $"Order Number: {OrderNumber}\n" +
               $"Client: {Client}\n" + 
               $"Itens:\n{itensDetails}" + 
               $"Total: {Total:C}";
    }
}