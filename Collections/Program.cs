using System;

class Program
{
    public static void Main(string[] args)
    {
        Random rnd = new Random();
        // Array que representa o estoque de produtos
        Product[] products = new Product[]
        {
            new Product("Laptop", rnd.Next(1000, 5000)*rnd.NextDouble()),
            new Product("Iphone 16", rnd.Next(499, 5000)*rnd.NextDouble()),
            new Product("MacBook M1", rnd.Next(99, 5000)*rnd.NextDouble()),
            new Product("Samsung Galaxy", rnd.Next(199, 5000)*rnd.NextDouble()),
            new Product("10kg de frango", rnd.Next(299, 5000)*rnd.NextDouble()),
            new Product("Batata temperada", rnd.Next(399, 5000)*rnd.NextDouble())
        };

        // Primeira solução:
        // OrderByDescending() é um método LING (Language-Integrated Query), 
        // que são recursos da Classe Colletions e ajudam na tarefa de consultas, ordenações e outra operação semelhante.
        // Como parâmetro do método, note que existe uma expressão lambda (p => p.Price), que significa: 
        // para cada p de products, use p.Price para comparação.
        // Take(n) retorna os n primeiros objetos.
        // ToArray() retorna os dados com Array, pois quando usado um método LINQ os dados são transformados
        // em IEnumerable<T> que proporciona uma melhor flexibilidade e eficiência, permitindo uma consulta seja apenas 
        // realizada quando necessário (Esta técnica se chama Lazy Evaluation).
        Console.WriteLine("Primeira solução:");
        var answer = products.OrderByDescending(p => p.Price).Take(2).ToArray();
        foreach (var product in answer)
        {
            Console.WriteLine(product.ToString());
        }

        // Segunda Solução:
        // Como foi implementada a interface IComparable<T> na Classe Product 
        // estabelecemos que a comparação será feita com base no atributo Price (Uso do CompareTo()), e 
        // é possível usar o método Array.Sort() para ordenar de forma crescente o array de produtos
        // note o uso do operador índice (^) que retorna o [array.Lenght - n-ésimo] do array. (disponível em C# ^8.0).
        Console.WriteLine("\nSegunda Solução:");
        Array.Sort(products);
        Console.WriteLine(products[^1]);
        Console.WriteLine(products[^2]);




    }
}