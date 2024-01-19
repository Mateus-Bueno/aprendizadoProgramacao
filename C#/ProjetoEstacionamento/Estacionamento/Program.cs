using Estacionamento.Services;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

//Invoca a configuração inicial do estacionamento
bool inicializadorEstacionamento = true;
decimal precoInicial = 0;
decimal precoPorHora = 0;

using(StreamReader sr = new StreamReader("LoginInfo.txt"))
{
    while(sr.EndOfStream == false)
    {
        string[] dadosDoUsuario = sr.ReadLine().Split("|");
        EstacionamentoImp.lucroResponsavel.Add(dadosDoUsuario[0], 0); 
    }
}

do
{
    Console.Clear();

    try
    {
        Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                          "Digite o preço inicial:");
        precoInicial = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Agora digite o preço por hora:");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());

        inicializadorEstacionamento = false;
    }
    catch(FormatException)
    {
        Console.WriteLine("Digite um preço válido!");
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }
}
while(inicializadorEstacionamento);


// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
EstacionamentoImp es = new EstacionamentoImp(precoInicial, precoPorHora);

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo               4 - alterar funcionario");
    Console.WriteLine("2 - Remover veículo                 5 - Encerrar");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("--------------------------------------------------------------\n");

    switch (Console.ReadLine())
    {
        case "1":
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            while(!es.MenuDeUsuario())
            { Console.ReadKey(); }
            break;

        case "5":
            exibirMenu = es.RelatorioDoDia();            
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar");
    Console.ReadKey();
}
Console.Clear();
Console.WriteLine("O programa se encerrou");
