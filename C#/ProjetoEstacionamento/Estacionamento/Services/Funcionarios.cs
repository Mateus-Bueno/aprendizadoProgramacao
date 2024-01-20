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

    public static class Funcionarios
    {
        private static string usuarioAtual;

        public static bool RealizarLogin()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("----------------------------");
                Console.WriteLine("Insira o nome de usuário:");
                Console.WriteLine("----------------------------");
                string nomeDeUsuario = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(nomeDeUsuario))
                {
                    throw new NomeDeUsuarioVazioException();
                }

                Console.Clear();
                Console.WriteLine("----------------------------");
                Console.WriteLine("Insira sua senha:");
                Console.WriteLine("----------------------------");
                string senha = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(senha))
                {
                    throw new SenhaVaziaException();
                }

                if(VerificarInformacoesDeLogin(nomeDeUsuario, senha))
                {
                    usuarioAtual = nomeDeUsuario;
                    Console.Clear();
                    Console.WriteLine("Login Realizado com sucesso");
                    Console.WriteLine($"Bem vindo(a) {nomeDeUsuario.ToUpper()}!");
                    Console.ReadKey();
                    return true;
                }
                else { return false; }
            }

            catch(InformacoesDeLoginIncorretasException)
            {
                Console.WriteLine("Nome de usuário ou senha Incorretos!");
                Console.WriteLine("Tente novamente");
                Console.ReadKey();
                return false;
            }

            catch(NomeDeUsuarioVazioException)
            {
                Console.WriteLine("O nome de usuário não pode ser vazio!");
                Console.ReadKey();
                return false;
            }

            catch(SenhaVaziaException)
            {
                Console.WriteLine("A senha não pode ser vazia!");
                Console.ReadKey();
                return false;
            }
        }


        public static bool CadastrarNovoUsuario()
        {
            Console.Clear();

            string nomeDeUsuario;
            string senha;
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
                    sr.WriteLine($"{nomeDeUsuario}|{senha}");                 
                }

                EstacionamentoImp.lucroResponsavel.Add(nomeDeUsuario, 0);

                Console.WriteLine("Deseja que este seja o usuário atual? s/n");
                switch(Console.ReadLine())
                {
                    case "s":
                        usuarioAtual = nomeDeUsuario;
                        Console.WriteLine($"Bem vindo(a) {nomeDeUsuario.ToUpper()}!");
                        Console.ReadKey();
                        break;                    
                    case "n":
                        break;
                    default:
                        Console.WriteLine("\nOpção Inválida");
                        Console.ReadKey();
                        break;
                }

                return true;
            }
            catch(NomeDeUsuarioJaUsadoException)
            {
                Console.WriteLine("\nNão foi possivel finalizar o cadastro");
                Console.WriteLine("Este nome de usuário já está sendo usado!");
                Console.ReadKey();
                return false;
            }

            catch(NomeDeUsuarioInvalidoException)
            {
                Console.WriteLine("O nome de usuário deve conter apenas letras!");
                Console.ReadKey();
                return false;
            }

            catch(NomeDeUsuarioVazioException)  
            {
                Console.WriteLine("O nome de usuário não pode ser vazio!");
                Console.ReadKey();
                return false;
            }

            catch(SenhaVaziaException)
            {
                Console.WriteLine("A senha não pode ser vazia!");
                Console.ReadKey();
                return false;
            }
            catch(SenhaInvalidaException)
            {
                Console.WriteLine("Senha inválida");
                Console.WriteLine("A senha deve conter 4 dígitos de 0 a 9");
                Console.ReadKey();
                return false;
            }
        }


        public static string VerificarUsuario()
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
        

        public static bool VerificarInformacoesDeLogin(string nomeDeUsuario, string senha)
        {
            using(StreamReader sr = new StreamReader("LoginInfo.txt"))
            {
                while(!sr.EndOfStream)
                {
                    string[] dadosDoUsuario = sr.ReadLine().Split('|');

                    if(dadosDoUsuario[0] == nomeDeUsuario.ToUpper() && dadosDoUsuario[1] == senha)
                    {
                        usuarioAtual = nomeDeUsuario;
                        return true;
                    }
                }

                throw new InformacoesDeLoginIncorretasException();
            }
        }
    }
}