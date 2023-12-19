using CursoAvanade.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Pessoa pessoa1 = new Pessoa();

        pessoa1.Nome = "zé";
        pessoa1.Idade = 50;

        pessoa1.Apresentar();

        Calculadora calculadora = new Calculadora();

        calculadora.Potencia(3, 3);
        calculadora.Seno(60);
        calculadora.Coseno(60);
        calculadora.RaizQuadrada(25);

    }
}