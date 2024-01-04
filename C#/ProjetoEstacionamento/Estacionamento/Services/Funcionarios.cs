using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Exceptions;

using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace Estacionamento.Services
{

    //Funciona como um registro de funcionário capaz de informar quem foi o responsável
    //pelo estacionamento
    public static class Funcionarios
    {
        private static string usuarioAtual;
        private static string usuarioID;
        private static int totalDeFuncionarios = File.ReadLines("LoginInfo.txt").Count();

        public static void RealizarLogin()
        {
            Console.Clear();

            try
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Insira o nome de usuário:");
                Console.WriteLine("----------------------------");
                string nomeDeUsuario = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(nomeDeUsuario))
                {
                    throw new NomeDeUsuarioVazioException();
                }

                Console.WriteLine("Insira sua senha:");
                string senha = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(senha))
                {
                    throw new SenhaVaziaException();
                }

                if(verificarInformacoesDeLogin(nomeDeUsuario, senha))
                {
                    usuarioAtual = nomeDeUsuario;
                    Console.Clear();
                    Console.WriteLine("Login Realizado com sucesso");
                    Console.WriteLine($"Bem vindo(a) {nomeDeUsuario.ToUpper()}!");

                }
            }

            catch(InformacoesDeLoginIncorretasException)
            {
                Console.WriteLine("Nome de usuário ou senha Incorretos!");
                Console.WriteLine("Tente novamente");
            }

            catch(NomeDeUsuarioVazioException)
            {
                Console.WriteLine("O nome de usuário não pode ser vazio!");
            }

            catch(SenhaVaziaException)
            {
                Console.WriteLine("A senha não pode ser vazia!");
            }
        }

        public static void CadastrarNovoUsuario()
        {
            Console.Clear();

            string nomeDeUsuario;
            string senha;
            Regex padraoNomeDeUsuario = new Regex("^[^0-9]$");
            Regex padraoSenha = new Regex("^[0-9]{4}$");

            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Insira o nome do novo usuário:");
                Console.WriteLine("--------------------------------");

                nomeDeUsuario = Console.ReadLine().ToUpper();

                if(string.IsNullOrWhiteSpace(nomeDeUsuario))
                {
                    throw new NomeDeUsuarioVazioException();
                }

                if(Regex.IsMatch(nomeDeUsuario, @"\d"))
                {
                    throw new NomeDeUsuarioInvalidoException();
                }

                using(StreamReader sr = new StreamReader("LoginInfo.txt"))
                {
                    while(!sr.EndOfStream)
                    {
                        string[] dadosDoUsuario = sr.ReadLine().Split('|');

                        if(dadosDoUsuario[0] == nomeDeUsuario.ToUpper())
                        {
                            throw new NomeDeUsuarioJaUsadoException();
                        }
                    }
                }

                Console.WriteLine("\nInsira a senha do novo usuário:");
                senha = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(senha))
                {
                    throw new SenhaVaziaException();
                }

                else if(!padraoSenha.IsMatch(senha))
                {
                    throw new SenhaInvalidaException();

                }

                using(StreamWriter sr = File.AppendText("LoginInfo.txt"))
                {
                    sr.WriteLine($"{nomeDeUsuario}|{senha}|0{totalDeFuncionarios}");                 
                }

                Console.WriteLine("Deseja que este seja o usuário atual? s/n");
                switch(Console.ReadLine())
                {
                    case "s":
                        usuarioAtual = nomeDeUsuario;
                        break;                    
                    case "n":
                        break;
                    default:
                        Console.WriteLine("\nOpção Inválida");
                        break;
                }
            }
            catch(NomeDeUsuarioJaUsadoException)
            {
                Console.WriteLine("\nNão foi possivel finalizar o cadastro");
                Console.WriteLine("Este nome de usuário já está sendo usado!");
            }

            catch(NomeDeUsuarioInvalidoException)
            {
                Console.WriteLine("O nome de usuário deve conter apenas letras!");
            }

            catch(NomeDeUsuarioVazioException)  
            {
                Console.WriteLine("O nome de usuário não pode ser vazio!");
            }

            catch(SenhaVaziaException)
            {
                Console.WriteLine("A senha não pode ser vazia!");
            }
            catch(SenhaInvalidaException)
            {
                Console.WriteLine("Senha inválida");
                Console.WriteLine("A senha deve conter 4 dígitos de 0 a 9");
            }
        }

        public static string verificarUsuario()
        {
            if(string.IsNullOrWhiteSpace(usuarioAtual))
            {
                return null;
                
            }
            else
            {
                return usuarioAtual.ToUpper();
            }
            
        }

        public static bool verificarInformacoesDeLogin(string nomeDeUsuario, string senha)
        {
            
            using(StreamReader sr = new StreamReader("LoginInfo.txt"))
            {
                while(!sr.EndOfStream)
                {
                    string[] dadosDoUsuario = sr.ReadLine().Split('|');

                    if(dadosDoUsuario[0] == nomeDeUsuario.ToUpper() && dadosDoUsuario[1] == senha)
                    {
                        usuarioID = dadosDoUsuario[2];
                        return true;
                    }
                }

                throw new InformacoesDeLoginIncorretasException();
            }
        }

        
    }
}