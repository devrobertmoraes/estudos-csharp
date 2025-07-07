public class Program
{
    public static void Main()
    {
        string fraseOriginal = " Olá, mundo da programação em C#! ";
        Console.WriteLine($"Frase original: {fraseOriginal} \b");

        // Principais métodos

        string emMinusculas = fraseOriginal.ToLower();
        string emMaiusculas = fraseOriginal.ToUpper();
        Console.WriteLine($"Minúsculas: '{emMinusculas}'");
        Console.WriteLine($"Maiúsculas: '{emMaiusculas}'");
        Console.WriteLine("---------------------------------");

        string semEspacos = fraseOriginal.Trim();
        Console.WriteLine($"String sem espaços: '{semEspacos}'");
        Console.WriteLine("---------------------------------");

        string palavraMundo = semEspacos.Substring(5, 5);
        Console.WriteLine($"Extraindo uma parte da string: '{palavraMundo}'");
        Console.WriteLine("---------------------------------");

        string novaFrase = semEspacos.Replace("C#", "CSharp");
        Console.WriteLine($"Frase com texto substituído: '{novaFrase}'");
        Console.WriteLine("---------------------------------");

        string[] palavras = semEspacos.Split(' ');
        Console.WriteLine("Palavras na frase:");
        foreach (string palavra in palavras)
        {
            Console.WriteLine($"- {palavra}");
        }
        Console.WriteLine("---------------------------------");

        bool comecaComOla = semEspacos.StartsWith("Olá");
        bool terminaComExclamacao = semEspacos.EndsWith("!");
        Console.WriteLine($"A frase começa com 'Olá'? {comecaComOla}");
        Console.WriteLine($"A frase termina com '!'? {terminaComExclamacao}");
        Console.WriteLine("---------------------------------");

        int tamanho = semEspacos.Length;
        Console.WriteLine($"Tamanho da string sem espaços: {tamanho} caracteres");
    }
}