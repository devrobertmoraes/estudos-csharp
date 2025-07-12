namespace SelecaoDeProdutosComLINQ
{
    public class Produto(int id, string nome, string categoria, decimal preco, int estoque)
    {
        public int Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public string Categoria { get; set; } = categoria;
        public decimal Preco { get; set; } = preco;
        public int Estoque { get; set; } = estoque;

        public override string ToString()
        {
            return $"ID: {Id} - Nome {Nome} - Categoria {Categoria} - Preco {Preco} - Estoque {Estoque}";
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // Base de dados em memória
            List<Produto> produtos =
            [
                new(1,"Teclado mecânico", "Hardware", 350.50m, 10),
                new(2,"Mouse Gamer", "Hardware", 150.50m, 25),
                new(3,"Monitor 27\"", "Hardware", 1800.50m, 05),
                new(4,"VS Code - Caneca", "Acessórios", 45.90m, 50),
                new(5,"Headset 7.1", "Hardware", 550.50m, 00),
                new(6,"Webcam 4K", "Hardware", 980.50m, 08),
                new(7,"Mochila para notebook", "Acessórios", 199.90m, 15)
            ];

            Console.WriteLine("---------- Todos os produtos do sistema ----------\b");
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }

            Console.WriteLine("\n---------- Todos os produtos da categoria 'Acessórios' ----------\n");

            var acessorios = produtos.Where(p => p.Categoria == "Acessórios");
            foreach (var produto in acessorios)
            {
                Console.WriteLine($"{produto.ToString()}");
            }

            Console.WriteLine("\n---------- O produto mais barato ----------\n");

            var produtoMaisBarato = produtos.OrderBy(p => p.Preco).FirstOrDefault();            
            Console.WriteLine($"{produtoMaisBarato.ToString()}");

            Console.WriteLine("\n---------- Quantidade total de ítens em estoque de todas as categorias ----------\n");

            var totalEmEstoque = produtos.Select(p => p.Estoque).Sum();
            var totalEmEstoque2 = produtos.Sum(p => p.Estoque);
            Console.WriteLine($"Total: {totalEmEstoque} unidades");
            Console.WriteLine($"Total: {totalEmEstoque2} unidades");

            Console.WriteLine("\n---------- Existe algum produto que custa mais de 2000,00? ----------\n");

            var custaMaisDe2000 = produtos.Any(p => p.Preco > 2000.00m);
            Console.WriteLine($"Algum produto custa mais de 2000,00 ? {(custaMaisDe2000 ? "SIM" : "NÃO")}");

            Console.WriteLine("\n---------- Produtos que não tem estoque ----------\n");

            var produtoSemEstoque = produtos.Where(p => p.Estoque == 0);
            
            foreach (var produto in produtoSemEstoque)
            {
                Console.WriteLine($"{produto.ToString()}");
            }

            Console.WriteLine("\n---------- Preço médio da categoria de Hardware ----------\n");

            var precoMedioHardware = produtos.Where(p => p.Categoria == "Hardware").Average(p => p.Preco);
            Console.WriteLine($"Preço médio: {precoMedioHardware:C}");
        }
    }
}
