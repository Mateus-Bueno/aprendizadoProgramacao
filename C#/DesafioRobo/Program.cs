using DesafioRobo.Models;

class Program
{
    static void Main()
    {

        string velocidades = Console.ReadLine();
        string[] v = velocidades.Split(' ');

        Robo robo = new Robo(Convert.ToInt32(v[0]), Convert.ToInt32(v[1]));
        
        string comandos = Console.ReadLine();


        for(int i = 0; i < comandos.Length; i++)
        {
            if(comandos[i].Equals('A'))
            {
                robo.Acelerar();
            }

            else if(comandos[i].Equals('D'))
            {
                robo.Desacelerar();
            }
            
            else
            {
                Console.WriteLine($"O {i} caracter é inválido");
            }
        }

        Console.WriteLine(robo.VelocidadeAtual);


    }
}

