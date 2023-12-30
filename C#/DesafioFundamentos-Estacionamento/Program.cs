﻿using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;


bool inicializador = true;
decimal precoInicial = 0;
decimal precoPorHora = 0;

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

        inicializador = false;
    }
    catch(FormatException)
    {
        Console.WriteLine("Digite um preço válido!");
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
    }
}
while(inicializador);


// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("----------------------");
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");
    Console.WriteLine("----------------------");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            es.AdicionarVeiculo();
            break;

        case "2":
            es.RemoverVeiculo();
            break;

        case "3":
            es.ListarVeiculos();
            break;

        case "4":
            exibirMenu = es.relatorioDoDia();            
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
