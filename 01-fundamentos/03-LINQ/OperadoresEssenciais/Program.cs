namespace OperadoresEssenciais
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

            Console.WriteLine("----- Todos os produtos -----");

            foreach (var produto in produtos)
            {
                Console.WriteLine(produto);
            }

            // -----------------------------------------------------------------------------------------------

            // Operador de filtragem (Where)
            // Filtra com base em uma condição.
            // Exemplo: Encontrar todos os produtos que sejam da categoria hardware.
            var produtosDeHardware = produtos.Where(produto => produto.Categoria == "Hardware");

            Console.WriteLine("\n---------- Método Where ----------");
            Console.WriteLine("Produtos da categoria Hardware:\n");

            foreach (var produto in produtosDeHardware)
            {
                Console.WriteLine($"{produto.Nome}");
            }

            // -----------------------------------------------------------------------------------------------

            // Operador de projeção (Select)
            // Transforma os elementos da coleção. Podemos pegar algumas propriedades ou criar um objeto anônimo
            // Exemplo: Obter apenas o nome e o preço de cada elemento.
            var nomeEPrecos = produtos.Select(produto => new {NomeProduto = produto.Nome, PrecoProduto = produto.Preco});

            Console.WriteLine("\n---------- Método Select ----------");
            Console.WriteLine("Apenas nome e preço dos produtos:\n");

            foreach (var produto in nomeEPrecos)
            {
                Console.WriteLine($"Nome: {produto.NomeProduto} - Preço: {produto.PrecoProduto}");
            }

            // -----------------------------------------------------------------------------------------------

            // Operadores de ordenação (OrderBy e OrderByDescending)
            var ProdutosPorPreco = produtos.OrderBy(produto => produto.Preco);
            var ProdutosPorPrecoDesc = produtos.OrderByDescending(produto => produto.Preco);

            Console.WriteLine("\n---------- Métodos OrderBy e OrderByDescending ----------");
            Console.WriteLine("Produtos pelo preco em ordem crescente:\n");

            foreach (var produto in ProdutosPorPreco)
            {
                Console.WriteLine($"{produto.Nome}");
            }

            Console.WriteLine("\nProdutos pelo preco em ordem Decrescente:\n");

            foreach (var produto in ProdutosPorPrecoDesc)
            {
                Console.WriteLine($"{produto.Nome}");
            }

            // -----------------------------------------------------------------------------------------------

            // Operadores de seleção de elemento único (First, FirstOrDefault, Single, SingleOrDefault)
            // First() -> pega o primeiro elemento que satisfaça a condição e retorna uma excessão se não encontrar nada.
            // FirstOrDefault() -> pega o primeiro elemento que satisfaça a condição e retorna null se não encontrar nada.
            // Single() -> pega o único elemento que satisfaça a condição e retorna uma excessão se não encontrar nada.
            // SingleOrDefault()
            // -> pega o único elemento que satisfaça a condição e retorna excessão se achar mais de um. Se não encontrar nada retorna null.
            // Exemplo: Encontrar o produto com Id=3.
            var produtoId3 = produtos.FirstOrDefault(produto => produto.Id == 3);

            Console.WriteLine("\n---------- Método FirstOrDefault ----------");
            Console.WriteLine($"Produto com ID 3: {produtoId3.Nome}");

            // -----------------------------------------------------------------------------------------------
            // Operador de verificação de existência (Any)
            // Verifica se PELO MENOS UM elemento na coleção satisfaz a condição e retorna true ou false
            // Exemplo: Verificar se há produto em estoque.
            bool temProdutoEmEstoque = produtos.Any(produto => produto.Estoque > 0);

            Console.WriteLine("\n---------- Método Any ----------");
            Console.WriteLine($"Há produtos em estoque? {(temProdutoEmEstoque ? "SIM" : "NÃO")}");

            // -----------------------------------------------------------------------------------------------
            // Operadores de vagregação (Count, Sum, Average, Max, Min)
            // Realiza cálculos sobre a coleção
            // Exemplo: Calcular o valor total de todos os elementos da categoria Hardware.
            // Filtramos os elementos que são hardware, multiplicamos o preço pelo estoque, somamos todos os valores
            decimal valorTotalEstoqueHardware = produtos
                .Where(produto => produto.Categoria == "Hardware")
                .Sum(produto => produto.Preco * produto.Estoque);

            Console.WriteLine("\n---------- Métodos de agregação ----------");
            Console.WriteLine($"Valor total dos produtos de Hardware: {valorTotalEstoqueHardware:C}");

            // -----------------------------------------------------------------------------------------------
            // Combinação de operadores - criar consultas complexas de forma legível
            // Exemplo: Encontrar o nome dos dois produtos de hardware mais caros que possuem estoque e ordenar por preço.

            var resultado = produtos
                .Where(produto => produto.Categoria == "Hardware" && produto.Estoque > 0) // filtra hardware e em estoque
                .OrderByDescending(produto => produto.Preco) // Ordena do mais caro para o mais barato
                .Take(2) // pega os 2 primeiros da lista ordenada
                .Select(produto => produto.Nome); // Seleciona apenas o nome

            Console.WriteLine("\n---------- Combinação de operadores ----------");
            Console.WriteLine($"2 produtos de Hardware mais caros: ");

            foreach (var produto in resultado)
            {
                Console.WriteLine($" - {produto}");
            }
        }
    }
}
