using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Estacionamento.Exceptions;
using System.ComponentModel;

namespace Estacionamento.Services
{
    public class EstacionamentoImp
    {
        public EstacionamentoImp(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        private decimal precoInicial = 0, precoPorHora = 0;
        private decimal lucroDoDia { get; set; } = 0;
        private decimal lucroNaoRegistrado = 0;
        public static Dictionary<string, List<string>> blocosEstacionamento = new Dictionary<string, List<string>>()
        {
            {"E1", new List<string>()},
            {"E2", new List<string>()},
            {"E3", new List<string>()},
            {"E4", new List<string>()}
        };
        public static Dictionary<string, decimal> lucroResponsavel = new Dictionary<string, decimal>();
        public static Dictionary<string, decimal> formaDePagamento = new Dictionary<string, decimal>()
        {
            {"Dinheiro", 0},
            {"Débito", 0},
            {"Pix", 0} 
        };


        public bool AdicionarVeiculo()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Digite a placa do veículo para estacionar:");
                Console.WriteLine("------------------------------------------------");
                string placa = Console.ReadLine();
                VerificarPlaca(placa);

                if(BuscarVeiculo(placa) != null)
                {
                    Console.WriteLine("Este carro já se encontra no estacionamento.");
                    Console.ReadKey();
                    return false;
                }
                else
                {
                    bool verifica;

                    do
                    {
                        verifica = true;
                        Console.Clear();
                        Console.WriteLine("Informe o bloco onde este veículo irá estacionar");
                        Console.WriteLine($"E1: {5 - blocosEstacionamento["E1"].Count} vagas     E3: {5 - blocosEstacionamento["E3"].Count} vagas");
                        Console.WriteLine($"E2: {5 - blocosEstacionamento["E2"].Count} vagas     E4: {5 - blocosEstacionamento["E4"].Count} vagas\n");
                        string bloco = VerificarCapacidadeBloco(Console.ReadLine().ToUpper());

                        switch(bloco.ToUpper())
                        {
                            case "E1":
                                blocosEstacionamento["E1"].Add(placa);
                                break;

                            case "E2":
                                blocosEstacionamento["E2"].Add(placa);
                                break;

                            case "E3":
                                blocosEstacionamento["E3"].Add(placa);
                                break;

                            case "E4":
                                blocosEstacionamento["E4"].Add(placa);
                                break;

                            case "F":
                                verifica = false;
                                Console.Clear();
                                Console.WriteLine("Este bloco já está cheio, tente novamente.");
                                Console.ReadKey();
                                break;

                            default:
                                verifica = false;
                                Console.Clear();
                                Console.WriteLine("Opção Inválida, tente novamente.");
                                Console.ReadKey();
                                break;
                        }
                    }
                    while(verifica == false);
                    
                    Console.Clear();
                    Console.WriteLine($"Veículo adicionado com sucesso!");
                    Console.WriteLine("\nPressione qualquer tecla para continuar");
                    Console.ReadKey();
                    return true;
                    
                }
            }   

            catch (PlacaVaziaException)
            {
                Console.Clear();
                Console.WriteLine("Nenhuma placa inserida. Por favor tente novamente");
                Console.ReadKey();
                return false;
            }   

            catch (PlacaInvalidaException)
            {
                Console.Clear();
                Console.WriteLine("Formato de placa inválido.");
                Console.WriteLine("Certifique-se de atender ao padrão Mercosul ou Nacional Única");
                Console.ReadKey();
                return false;
            }
        }

        public bool RemoverVeiculo()
        {

            
            // Verifica se o veículo existe
                try
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Digite a placa do veículo para remover:");
                    Console.WriteLine("-------------------------------------------");

                    string placa = Console.ReadLine();
                    VerificarPlaca(placa);
                    string bloco = BuscarVeiculo(placa);

                    if(BuscarVeiculo(placa) == null)
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

                    Console.Clear();
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine($"O valor total é {valorTotal:C}, selecione a forma de pagamento:");
                    Console.WriteLine("1 - Dinheiro");
                    Console.WriteLine("2 - Débito");
                    Console.WriteLine("3 - Pix");
                    Console.WriteLine("----------------------------------------------------------------------");

                    switch(Console.ReadLine())
                    {
                        case "1":
                            formaDePagamento["Dinheiro"] += valorTotal;
                            break;
                        
                        case "2":
                            formaDePagamento["Débito"] += valorTotal;
                            break;
                        
                        case "3":
                            formaDePagamento["Pix"] += valorTotal;
                            break;
                        
                        default:
                            Console.WriteLine("Opção inválida, a operação será encerrada");
                            return false;
                    }
                    

                    blocosEstacionamento[bloco].Remove(placa);

                    Console.Clear();
                    Console.WriteLine($"O veículo {placa.ToUpper().Insert(3, "-")} foi removido e o preço total foi de: {valorTotal:C}");

                    lucroDoDia += valorTotal;

                    if(Funcionarios.VerificarUsuario() == null)
                    {
                        lucroNaoRegistrado += valorTotal;
                    }
                    else
                    {
                        lucroResponsavel[Funcionarios.VerificarUsuario()] += valorTotal;
                    }

                    Console.WriteLine("\nPressione qualquer tecla para continuar");
                    Console.ReadKey();
                    return true;
                }
                catch(FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Ocorreu um erro ao informar o valor.");
                    Console.WriteLine("Por favor tente novamente");
                    Console.ReadKey();
                    return false;
                }
                catch(PlacaVaziaException)
                {
                    Console.Clear();
                    Console.WriteLine("Nenhuma placa inserida. Por favor tente novamente");
                    Console.ReadKey();
                    return false;
                }
                catch(PlacaInvalidaException)
                {
                    Console.Clear();
                    Console.WriteLine("\nFormato de placa inválido.");
                    Console.WriteLine("Certifique-se de atender ao padrão Mercosul ou Nacional Única");
                    Console.ReadKey();
                    return false;
                }

        }

        public void ListarVeiculos()
        {

            // Verifica se há veículos no estacionamento              

                foreach(var bloco in blocosEstacionamento)
                {
                    Console.Clear();                    
                    Console.WriteLine($"Bloco {bloco.Key}");                    

                    if (bloco.Value.Any())
                    {
                        Console.WriteLine("Os veículos estacionados são:");
                        Console.WriteLine("--------------------------------");

                        foreach(var veiculo in bloco.Value)
                        {
                            Console.WriteLine(veiculo.ToUpper().Insert(3, "-"));
                        }
                    }
                    else
                    {
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("Não há veículos estacionados.");
                    }

                    Console.WriteLine("\nPressione qualquer tecla para continuar");
                    Console.ReadKey();
                }

            Console.Clear();
        }

        public bool RelatorioDoDia()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Gerando Relatório");
            Console.WriteLine("Pressione qualquer tecla para continuar");
            Console.WriteLine("------------------------------------------------");
            Console.ReadKey();
            
            bool status;

            try
            {
                if(BuscarVeiculo())
                {
                    throw new EstacionamentoNaoVazioException();
                }

                Console.Clear();
                Console.WriteLine("-------------------------------------------------");

                foreach(var funcionario in lucroResponsavel)
                {
                    if(funcionario.Value != 0)
                    {
                        Console.WriteLine($"{funcionario.Key} finalizou {funcionario.Value:C} em pagamentos");
                    }
                }
                
                Console.WriteLine($"{lucroNaoRegistrado:C} em pagamentos não registraram operador");
                Console.WriteLine("-------------------------------------------------");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Foi arrecadado em pagamentos:");
                Console.WriteLine($"{formaDePagamento["Dinheiro"]:C} em dinheiro");
                Console.WriteLine($"{formaDePagamento["Débito"]:C} em Débito");
                Console.WriteLine($"{formaDePagamento["Pix"]:C} em Pix");
                Console.WriteLine("-------------------------------------------------");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"O total arrecadado hoje foi {lucroDoDia:C}.");
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

        public bool MenuDeUsuario()
        {
            Console.Clear();
            
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite sua opção:");
            Console.WriteLine("1 - Cadastrar novo usuário");
            Console.WriteLine("2 - Alternar usuário atual");
            Console.WriteLine("3 - Voltar");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Usuário atual: {Funcionarios.VerificarUsuario()}");
            switch(Console.ReadLine())
            {
                case "1":
                    return Funcionarios.CadastrarNovoUsuario();

                case "2":
                    return Funcionarios.RealizarLogin();
                    
                case "3":
                    return true;

                default:
                    Console.Clear();
                    Console.WriteLine("\nOpção inválida");
                    return false;  
            }
        }

        
        public void VerificarPlaca(string placa) // Faz validações quanto a placa informada e retorna um erro caso exista
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


        public bool BuscarVeiculo() // Retorna verdadeiro caso o veículo informado esteja no estacionamento
        {
            foreach(var bloco in blocosEstacionamento)
            {
                if(bloco.Value.Any())
                {
                    return true;
                }
            }

            return false;
        }


        public string BuscarVeiculo(string placa) // Retorna o bloco onde determinado veículo se encontra, ou nulo se não existir
        {
            foreach(var bloco in blocosEstacionamento)
            {
                if(bloco.Value.Contains(placa))
                {
                    return bloco.Key;
                }
            }

            return null;
        }


        public string VerificarCapacidadeBloco(string bloco) // Retorna um código de erro caso houver, do contrário, retorna o bloco informado
        {
            string padraoBloco = @"^E[1-4]$";

            if(!Regex.IsMatch(bloco, padraoBloco)) { return "invalido"; }

            if(blocosEstacionamento[bloco].Count < 5){ return bloco; }
            else { return "F"; };
        }
    }
}