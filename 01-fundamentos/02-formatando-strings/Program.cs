public class Program
{
    public static void Main()
    {
        string nome = "Robert";
        int idade = 30;
        string mensagemFormatada = string.Format("O nome dela é {0}´e ela tem {1} anos.", nome, idade);
        Console.WriteLine(mensagemFormatada);
        Console.WriteLine("---------------------------------");

        double preco = 19.99;
        int quantidade = 1500;
        DateTime hoje = DateTime.Now;

        string formatoMoeda = string.Format("Preco do produto: {0:C}", preco);
        Console.WriteLine(formatoMoeda);
        Console.WriteLine("---------------------------------");

        string formatoNumero = string.Format("Quantidade em estoque: {0:N0}", quantidade);
        Console.WriteLine(formatoNumero);
        Console.WriteLine("---------------------------------");

        double desconto = 0.25;
        string formatoPorcentagem = string.Format("Desconto de {0:P}", desconto);
        Console.WriteLine(formatoPorcentagem);
        Console.WriteLine("---------------------------------");

        string formatoDecimal = string.Format("Valor com 4 casas decimais: {0:F4}", preco);
        Console.WriteLine(formatoDecimal);
        Console.WriteLine("---------------------------------");

        string formatoDataCurta = string.Format("Data de hoje (curta): {0:d}", hoje);
        Console.WriteLine(formatoDataCurta);
        Console.WriteLine("---------------------------------");

        string formatoDataLonga = string.Format("Data de hoje (longa): {0:D}", hoje);
        Console.WriteLine(formatoDataLonga);
        Console.WriteLine("---------------------------------");

        string formatoPersonalizado = string.Format("formato personalizado: {0:dd/MM/yyyy HH:mm:ss}", hoje);
        Console.WriteLine(formatoPersonalizado);
        Console.WriteLine("---------------------------------");

    }
}