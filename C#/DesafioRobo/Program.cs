using DesafioRobo.Models;

class Program
{
    static void Main()
    {

        string velocidades = Console.ReadLine();
        string[] v = velocidades.Split(' ');

        Robo robo = new Robo(Convert.ToInt32(v[0]), Convert.ToInt32(v[1]));
        
        string comandos = Console.ReadLine();


        foreach(char comando in comandos)
        {
            if(comando.Equals('A'))
            {
                robo.Acelerar();
            }

            else if(comando.Equals('D'))
            {
                robo.Desacelerar();
            }
            
            else
            {
                Console.WriteLine($"O {comando} caracter é inválido");
            }
        }


        Console.WriteLine(robo.VelocidadeAtual);


    }
}

