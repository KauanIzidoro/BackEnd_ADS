using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        
        Item food = new Item("Pão assado", 199.90m);
        Item drink = new Coffee("Express", 1.99m, "Grande", "Express");
        Dessert dessert = new Dessert("Bolo", 34.12m, "Chocolate");

        List<Item> itens = new List<Item>();
        Order order = new Order("Pedido Completo", 0, 111, "Kauan Izidoro", itens);

        order.AddItem(food);
        order.AddItem(drink);
        order.AddItem(dessert);

        app.MapGet("/", () => "Status: OK!");
        app.MapGet("/orders", () => order); 
        app.Run();
    }
}