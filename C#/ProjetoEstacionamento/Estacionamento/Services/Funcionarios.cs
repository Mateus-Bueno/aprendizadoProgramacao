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

        public void RealizarLogin()
        {

        }

        public void CadastrarNovoUsuario()
        {
            string nomeDeUsuario;

            try
            {
                Console.WriteLine("Insira o nome do novo usuário");
                nomeDeUsuario = Console.ReadLine();

                if(nomeDeUsuario.Equals(NomesDeUsuario.Any()))
                {
                    throw new NomeDeUsuarioJaUsadoException();
                }
                else 
                {
                    NomesDeUsuario.Add(nomeDeUsuario);

                    Console.WriteLine("Insira a senha do novo usuário");
                    Senhas.Add(Console.ReadLine());
                }                
            }

            catch(NomeDeUsuarioJaUsadoException)
            {
                Console.WriteLine("Este nome de usuário já está sendo usado!");
                Console.WriteLine("Tente novamente");
            }           
        }

        public void RemoverUsuario()
        {
            
        }
    }
}