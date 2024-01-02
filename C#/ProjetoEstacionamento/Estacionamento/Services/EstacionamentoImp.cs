using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Estacionamento.Exceptions;

namespace Estacionamento.Services
{
    public class EstacionamentoImp
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private decimal lucroDoDia { get; set; } = 0;
        private List<string> veiculos = new List<string>();

        public EstacionamentoImp(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            Console.WriteLine("------------------------------------------------");
            string placa = Console.ReadLine();

            try
            {   
                VerificarCadastro(placa);

                veiculos.Add(placa);
            }   

            catch (PlacaVaziaException)
            {
                Console.WriteLine("\nNenhuma placa inserida. Por favor tente novamente\n");
            }   

            catch (PlacaInvalidaException)
            {
                Console.WriteLine("\nFormato de placa inválido.");
                Console.WriteLine("Certifique-se de atender ao padrão Mercosul ou Nacional Única");
            }      

            catch (CarroJaEstacionadoException)
            {
                Console.WriteLine("\nEste carro já se encontra no estacionamento.");
            }   
        }

        public void RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite a placa do veículo para remover:");
            Console.WriteLine("-------------------------------------------");

            string placa = "";
            placa = Console.ReadLine();
            
            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    Console.WriteLine("----------------------------------------------------------------------");

                    int horas = 0;
                    decimal valorTotal = 0; 

                    horas = Convert.ToInt32(Console.ReadLine());
                    valorTotal = precoInicial + precoPorHora * horas;

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa.ToUpper().Insert(3, "-")} foi removido e o preço total foi de: {valorTotal:C}");
                    lucroDoDia += valorTotal;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ocorreu um erro ao informar o valor.");
                    Console.WriteLine("Por favor tente novamente");
                }
                
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            Console.Clear();

            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Os veículos estacionados são:");
                

                foreach(string placa in veiculos)
                {   
                    Console.WriteLine(placa.ToUpper().Insert(3, "-"));
                }

                Console.WriteLine("--------------------------------");
            }
            
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
                Console.WriteLine("--------------------------------");
            }
        }

        public bool VerificarCadastro(string placa)
        {

            bool verificador = true;

            if(string.IsNullOrWhiteSpace(placa))
            {
                throw new PlacaVaziaException();
            }

            if(placa.Length > 8)
            {
                throw new PlacaInvalidaException();
            }

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                throw new CarroJaEstacionadoException();
            }

            Regex padraoMercosul = new Regex("^[a-zA-Z]{3}[0-9][a-zA-Z]{1}[0-9]{2}$");
            Regex padraoNormal = new Regex("^[a-zA-Z]{3}[0-9]{4}$");


            if(padraoMercosul.IsMatch(placa) || padraoNormal.IsMatch(placa))
            {
                return verificador;
            }

            else
            {
                throw new PlacaInvalidaException();
            }
        }

        public bool relatorioDoDia()
        {
            bool status;
            Funcionarios _func = new Funcionarios();

            try
            {
                Console.Clear();
                if(veiculos.Any())
                {
                    throw new EstacionamentoNaoVazioException();
                }

                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"O total arrecadado hoje foi {lucroDoDia:C}.");
                Console.WriteLine($"Funcionário responsável: {_func.verificarUsuario()}");
                Console.WriteLine("-------------------------------------------------");
                status = false;
            }
            catch (EstacionamentoNaoVazioException)
            {
                Console.WriteLine("Remova todos os veículos antes de encerrar.");
                status = true;
            }
            
            return status;
        }
    }
}