using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploPOO.Models
{
    public class ContaCorrente
    {

        public ContaCorrente(string numeroConta, int saldoInicial)
        {
            NumeroConta = numeroConta;
            Saldo = saldoInicial;
        }
        public string NumeroConta { get; set; }

        private decimal Saldo;

        public void Sacar(decimal valor)
        {
            if(Saldo < valor)
            {
                Console.WriteLine("Seu Saldo é insuficiente para realizar este saque.");
            }
            else
            {
                Saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso");
            }
            
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de {valor:C} realizado com sucesso");
        }

        public void VerSaldo()
        {
            Console.WriteLine($"O Saldo da sua conta é de {Saldo:C}");
        }
    }
}