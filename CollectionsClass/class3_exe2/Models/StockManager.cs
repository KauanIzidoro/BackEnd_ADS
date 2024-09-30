using System;
using System.Collections.Generic;
using System.Linq;

public class StockManager
{
    // Atributos
    private List<Product> Products { get; set; }

    // Construtor
    public StockManager()
    {
        Products = new List<Product>();
    }


    // Métodos
    public void AddProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        Products.Add(product);
        Console.WriteLine($"{product.Name} foi adicionado com sucesso ao estoque.");
    }

    public bool RemoveProduct(string name)
    {
        var product = Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (product != null)
        {
            Products.Remove(product);
            Console.WriteLine($"{name} foi removido com sucessso do estoque.");
            return true;
        }

        Console.WriteLine($"{name} não foi encontrado no estoque.");
        return false;
    }

    public string SearchProduct(string name)
    {
        var product = Products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return product != null ? product.ToString() : $"Product '{name}' não encontrado no estoque.";
    }

    public void ListProducts()
    {
        if (Products.Any())
        {
            Console.WriteLine("Produtos no estoque: ");
            foreach (var product in Products)
            {
                Console.WriteLine(product);
            }
        }
        else
        {
            Console.WriteLine("Não há produtos no estoque!");
        }
    }
}
