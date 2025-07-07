public class Program
{
    public static void Main()
    {
        Console.WriteLine("---- Pedido ----");

        Console.WriteLine("Informe os produtos que você deseja: ");
        string pedido = Console.ReadLine().Trim();
        
        string[] itensDoPedido = pedido.Split(',');

        
    }
}