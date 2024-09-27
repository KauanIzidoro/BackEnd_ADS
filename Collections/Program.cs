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
            new Product("Batata temperada", rnd.Next(399, 5000)*rnd.NextDouble())
        };

        // Primeira solução:
        // OrderByDescending() é um método LINQ (Language-Integrated Query), 
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


        // Terceira Solução:
        double[] res = new double[2] { 0, 0 };
        for (int i = 0; i < products.Length; i++)
        {
            for (int j = i + 1; j < products.Length; j++)
            {
                double aux_maior = (products[i].Price + products[j].Price + Math.Abs(products[i].Price - products[j].Price)) / 2;

                if (aux_maior > res[0])
                {
                    res[1] = res[0];
                    res[0] = aux_maior;
                }
                else if (aux_maior > res[1])
                {
                    res[1] = aux_maior;
                }

            }
        }
        Console.WriteLine("\nTerceira Solucao:");
        // for (int l=0;l<res.Length;l++)
        // {
        //     Console.WriteLine(res[l]);

        // }
        // Console.WriteLine(Math.Round(res[0],2) + "," + Math.Round(res[1],2));
        for (int k = 0; k < products.Length; k++)
        {
            if (products[k].Price == res[0] || products[k].Price == res[1])
            {
                products[k].Price = 0.0;
            }
        }
        double[] aux_products = new double[products.Length];
        for (int i = 0; i < products.Length; i++)
        {
            aux_products[i] = products[i].Price;
        }
        // for (int i = 0; i < aux_products.Length; i++)
        // {
        //     Console.WriteLine(aux_products[i]);
        // }

        double[] ans = new double[2] { 0, 0 };
        for (int i = 0; i < products.Length; i++)
        {
            for (int j = i + 1; j < products.Length; j++)
            {
                double aux_maior = (aux_products[i] + aux_products[j] + Math.Abs(aux_products[i] - aux_products[j])) / 2;

                if (aux_maior > res[0])
                {
                    ans[1] = ans[0];
                    ans[0] = aux_maior;
                }
                else if (aux_maior > ans[1])
                {
                    ans[1] = aux_maior;
                }

            }
        }
        // Console.WriteLine(Math.Round(ans[1],2) + " , " + Math.Round(ans[0],2));
        // Console.WriteLine(Math.Round(res[0],2) + " , " +  Math.Round(res[1],2));

        // Produto mais caro
        for(int i=0;i<products.Length;i++)
        {
            if(products[i].Price == 0)
            {
                Console.WriteLine("Product: " + products[i].Name + ", Price: " + Math.Round(res[0],2));
            }
        }
        // Segundo produto mais caro
        for(int i=0;i<products.Length;i++)
        {
            if(products[i].Price == ans[1])
            {
                Console.WriteLine("Product: " + products[i].Name + ", Price: " + Math.Round(ans[1],2));
            }
        }




    }
}