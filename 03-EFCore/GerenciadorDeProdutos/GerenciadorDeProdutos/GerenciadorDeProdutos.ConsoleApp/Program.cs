using GerenciadorDeProdutos.Domain;
using GerenciadorDeProdutos.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GerenciadorDeProdutos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o gerenciador de produtos!");

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
                })
                .Build();

            var dbContext = host.Services.GetRequiredService<AppDbContext>();

            Console.WriteLine("\nOperação de adicionar (Create): ");
            Produto novoProduto = new Produto { Nome = "Caderno", Preco = 15.50m, Estoque = 50 };
            dbContext.Produtos.Add(novoProduto);
            dbContext.SaveChanges();
            Console.WriteLine($"Produto '{novoProduto.Nome}' foi adicionado com sucesso!");

            Console.WriteLine("\nOperação de leitura (Read): ");
            List<Produto> produtos = dbContext.Produtos.ToList();
            Console.WriteLine("Listando dos os produtos: ");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: R${produto.Preco}, Estoque: {produto.Estoque}");
            }

            Console.WriteLine("\nOperação de Atualização (Update): ");
            Produto produtoParaAtualizar = dbContext.Produtos.First();
            produtoParaAtualizar.Preco = 10.00m;
            produtoParaAtualizar.Estoque -= 5;
            dbContext.SaveChanges();
            Console.WriteLine($"Produto '{produtoParaAtualizar.Nome}' atualizado!");

            Console.WriteLine("\nOperação de Remoção (Delete): ");
            var produtoParaRemover = dbContext.Produtos.OrderBy(p => p.Id).Last();
            Console.WriteLine($"Removendo o produto '{produtoParaRemover.Nome}'...");
            dbContext.Produtos.Remove(produtoParaRemover);
            dbContext.SaveChanges();
            Console.WriteLine($"Produto removido!");

            Console.WriteLine("\nLista final de produtos:");
            produtos = dbContext.Produtos.ToList();
            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: R${produto.Preco}, Estoque: {produto.Estoque}");
            }
            Console.WriteLine("\nFim da execução.");
        }
    }
}
