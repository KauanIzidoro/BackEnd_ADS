using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        // Algumas configurações anteriores para implementar a solução do Exercício 1
        Random rnd = new Random();
        string[] products_name = { "Iphone 16", "Macbook M1", "Apple Watch", "Ventilador de teto", "Container Docker" };

        // Instâncias do array de produtos para representar o estoque
        Product[] products = new Product[products_name.Length];
        for (int i = 0; i < products_name.Length; i++)
        {
            products[i] = new Product(products_name[i], (rnd.Next(1000, 5000) * rnd.NextDouble()));
        }

        // Primeira solução:
        /*  OrderByDescending() é um método LINQ (Language-Integrated Query), 
            que são recursos da Classe Colletions e ajudam na tarefa de consultas, ordenações e outra operação semelhante.
            Como parâmetro do método, note que existe uma expressão lambda (p => p.Price), que significa: 
            para cada p de products, use p.Price para comparação.
            Take(n) retorna os n primeiros objetos.
            ToArray() retorna os dados com Array, pois quando usado um método LINQ os dados são transformados
            em IEnumerable<T> que proporciona uma melhor flexibilidade e eficiência, permitindo uma consulta seja apenas 
            realizada quando necessário (Esta técnica se chama Lazy Evaluation).
        */
        Console.WriteLine("Primeira solução: ");
        var answer = products.OrderByDescending(p => p.Price).Take(2).ToArray();
        foreach (var p in answer)
        {
            Console.WriteLine(p);
        }
        //Segunda solução:
        /*  Note que foi realizado a interface IComparable<> na Classe Product assim estabelecendo
            que a forma de comparação será feita com o atributo Price, ou seja, é possível usar o método Sort() para ordenar
            os produtos no array. Observe o uso do operador índice (^) que retorna o (array.Length - n-ésimo) do array.
            (disponível em C# 8.*).
        */
        Console.WriteLine("\nSegunda solução: ");
        Array.Sort(products);
        Console.WriteLine(products[^1]);
        Console.WriteLine(products[^2]);

        // Terceira solução:
        /*  Esta solução é baseada em brute force, para encontrar o produto mais caro
            podemos utilizar da seguinte fórmula:
            Dado dois valores a, b podemos encontrar o maior entre eles fazendo:
            (a+b+|a-b|)/2 
            o retorno desta fórmula será sempre o maior valor entre os dois números (a,b).
        */
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
        // Produto mais caro
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].Price == 0)
            {
                Console.WriteLine("Product: " + products[i].Name + ", Price: " + Math.Round(res[0], 2));
            }
        }
        // Segundo produto mais caro
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].Price == ans[1])
            {
                Console.WriteLine("Product: " + products[i].Name + ", Price: " + Math.Round(ans[1], 2));
            }
        }


    }
}