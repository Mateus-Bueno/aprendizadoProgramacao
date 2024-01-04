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
        //private Dictionary<string, decimal> valorArrecadado = new Dictionary<string, decimal>();
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
                if(veiculos.Contains(placa))
                {
                    Console.WriteLine("\nEste carro já se encontra no estacionamento.");
                }
                else
                {
                    VerificarPlaca(placa);
                    veiculos.Add(placa);
                }
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
        }

        public bool RemoverVeiculo()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite a placa do veículo para remover:");
            Console.WriteLine("-------------------------------------------");
            
            // Verifica se o veículo existe
                try
                {
                    string placa = Console.ReadLine();
                    VerificarPlaca(placa);

                    if(!veiculos.Contains(placa))
                    {
                        Console.WriteLine("Este veículo não se encontra aqui");
                        return false;
                    }

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
                    return true;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Ocorreu um erro ao informar o valor.");
                    Console.WriteLine("Por favor tente novamente");
                    return false;
                }
                catch(PlacaVaziaException)
                {
                    Console.WriteLine("Nenhuma placa inserida. Por favor tente novamente");
                    return false;
                }
                catch(PlacaInvalidaException)
                {
                    Console.WriteLine("\nFormato de placa inválido.");
                    Console.WriteLine("Certifique-se de atender ao padrão Mercosul ou Nacional Única");
                    return false;
                }
        }

        public void ListarVeiculos()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");

            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {                
                Console.WriteLine("Os veículos estacionados são:");                

                foreach(string placa in veiculos)
                {   
                    Console.WriteLine(placa.ToUpper().Insert(3, "-"));
                }
            }
            
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }

            Console.WriteLine("--------------------------------");
        }

        //Faz validações quanto a placa informada e retorna um erro caso exista
        public void VerificarPlaca(string placa)
        {

            if(string.IsNullOrWhiteSpace(placa))
            {
                throw new PlacaVaziaException();
            }

            if(placa.Length != 7)
            {
                throw new PlacaInvalidaException();
            }
            
            // Define os formatos de placa considerados válidos
            Regex padraoMercosul = new Regex("^[a-zA-Z]{3}[0-9][a-zA-Z]{1}[0-9]{2}$");
            Regex padraoNormal = new Regex("^[a-zA-Z]{3}[0-9]{4}$");


            if(padraoMercosul.IsMatch(placa) || padraoNormal.IsMatch(placa))
            {
            }
            else
            {
                throw new PlacaInvalidaException();
            }
        }

        public bool RelatorioDoDia()
        {
            Console.Clear();
            
            bool status;

            try
            {
                if(veiculos.Any())
                {
                    throw new EstacionamentoNaoVazioException();
                }

                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"O total arrecadado hoje foi {lucroDoDia:C}.");
                Console.WriteLine($"Funcionário responsável: {Funcionarios.verificarUsuario()}");
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

        public void MenuDeUsuario()
        {
            Console.Clear();
            Console.WriteLine($"Usuário atual: {Funcionarios.verificarUsuario()}");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite sua opção:");
            Console.WriteLine("1 - Cadastrar novo usuário");
            Console.WriteLine("2 - Alternar usuário atual");
            Console.WriteLine("------------------------------------------");
            switch(Console.ReadLine())
            {
                case "1":
                    Funcionarios.CadastrarNovoUsuario();
                    break;
                case "2":
                    Funcionarios.RealizarLogin();
                    break;
                default:
                    Console.WriteLine("\nOpção inválida");
                    break;
            }
        }
    }
}