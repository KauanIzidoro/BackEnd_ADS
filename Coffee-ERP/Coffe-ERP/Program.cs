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

        string sample_json = "{\n id: 93321\n time: 10/17/2024 21:34:45\n room: B2-4 \n}";

        app.MapGet("/", () => "Status: OK!");
        app.MapGet("/orders", () => order);
        app.MapGet("/room4", () => sample_json);
        Console.WriteLine(order);
        app.Run();
    }
}