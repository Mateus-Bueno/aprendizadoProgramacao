using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estacionamento.Exceptions;

namespace Estacionamento.Services
{
    public class Funcionarios
    {

        private List<string> NomesDeUsuario = new List<string>();
        private List<string> Senhas = new List<string>();
        private static string usuarioAtual;

        public void RealizarLogin()
        {
            Console.Clear();

            string usuario;
            int usuarioID;

            try
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("Insira o nome de usuário:");
                Console.WriteLine("----------------------------");
                usuario = Console.ReadLine();

                if(NomesDeUsuario.Contains(usuario))
                {
                    usuarioID = NomesDeUsuario.IndexOf(usuario);

                    Console.WriteLine("Insira sua senha:");
                    if(Console.ReadLine().Equals(Senhas[usuarioID]))
                    {
                        usuarioAtual = usuario;
                    }
                    
                    else
                    {
                        throw new SenhaIncorretaException();
                    }
                    
                }
                else
                {
                    throw new NomeDeUsuarioNaoEncontradoException();
                }
            }

            catch(SenhaIncorretaException)
            {
                Console.WriteLine("Senha Incorreta!");
                Console.WriteLine("Tente novamente");
            }

            catch(NomeDeUsuarioNaoEncontradoException)
            {
                Console.WriteLine("Nome de usuario não encontrado!");
                Console.WriteLine("Tente novamente");
            }
        }

        public bool CadastrarNovoUsuario()
        {
            Console.Clear();

            string nomeDeUsuario;
            string senha;

            try
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Insira o nome do novo usuário:");
                Console.WriteLine("--------------------------------");
                nomeDeUsuario = Console.ReadLine();

                if(NomesDeUsuario.Contains(nomeDeUsuario))
                {
                    throw new NomeDeUsuarioJaUsadoException();
                }
                else if(string.IsNullOrWhiteSpace(nomeDeUsuario))
                {
                    throw new NomeDeUsuarioVazioException();
                }
                else 
                {
                    NomesDeUsuario.Add(nomeDeUsuario);

                    Console.WriteLine("\nInsira a senha do novo usuário:");
                    senha = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(senha))
                    {
                        throw new SenhaVaziaException();
                    }
                    else
                    {
                        Senhas.Add(senha);
                        Console.WriteLine("Deseja que este seja o usuário atual? s/n");
                        switch(Console.ReadLine())
                        {
                            case "s":
                                usuarioAtual = nomeDeUsuario;
                                break;
                            
                            case "n":
                                Console.WriteLine("Pressione qualquer tecla para continuar");
                                Console.ReadKey();
                                break;
                            default:
                                Console.WriteLine("\nOpção Inválida");
                                Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                                break;
                        }
                    }
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

            catch(NomeDeUsuarioVazioException)  
            {
                Console.WriteLine("O nome de usuário não pode ser vazio!");
                return false;
            }

            catch(SenhaVaziaException)
            {
                Console.WriteLine("A senha não pode ser vazia!");
                return false;
            }
        }

        public string verificarUsuario()
        {
            if(string.IsNullOrWhiteSpace(usuarioAtual))
            {
                return "";
                
            }
            else
            {
                return usuarioAtual;
            }
            
        }
    }
}