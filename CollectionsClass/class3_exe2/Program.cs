using System;

public class Program
{
    public static void Main()
    {
        var stockManager = new StockManager();

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção abaixo:");
            Console.WriteLine("1 - Adicionar um produto ao estoque");
            Console.WriteLine("2 - Remover um produto do estoque");
            Console.WriteLine("3 - Procurar por um produto no estoque");
            Console.WriteLine("4 - Listar todos os produtos do estoque");
            Console.WriteLine("5 - Sair");
            Console.Write("> ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(stockManager);
                    break;
                case "2":
                    RemoveProduct(stockManager);
                    break;
                case "3":
                    SearchProduct(stockManager);
                    break;
                case "4":
                    stockManager.ListProducts();
                    break;
                case "5":
                    Console.WriteLine("Saindo.");
                    return;
                default:
                    Console.WriteLine("Escolha uma opção válida.");
                    break;
            }
        }
    }

    private static void AddProduct(StockManager stockManager)
    {
        Console.Write("Nome do produto: ");
        string name = Console.ReadLine();
        Console.Write("Preço do produto: ");
        if (double.TryParse(Console.ReadLine(), out double price))
        {
            var product = new Product(name, price);
            stockManager.AddProduct(product);
        }
        else
        {
            Console.WriteLine("Preço possui um formato inválido.");
        }
    }

    private static void RemoveProduct(StockManager stockManager)
    {
        Console.Write("Nome do produto a ser removido: ");
        string name = Console.ReadLine();
        stockManager.RemoveProduct(name);
    }

    private static void SearchProduct(StockManager stockManager)
    {
        Console.Write("Nome do produto a ser buscado: ");
        string name = Console.ReadLine();
        string result = stockManager.SearchProduct(name);
        Console.WriteLine(result);
    }
}
