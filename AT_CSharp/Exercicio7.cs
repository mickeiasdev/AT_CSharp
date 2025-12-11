using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public class ContaBancaria
    {
        public string Titular { get; set; }

        private decimal saldo;

        public ContaBancaria(string titular)
        {
            Titular = titular;
            saldo = 0;
        }

        public void Depositar(decimal valor)
        {
            if (valor > 0)
            {
                saldo += valor;
                Console.WriteLine($"Depósito de {valor:C} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("O valor do depósito deve ser positivo!");
            }
        }

        public void Sacar(decimal valor)
        {
            if (valor <= saldo)
            {
                saldo -= valor;
                Console.WriteLine($"Saque de {valor:C} realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente para realizar o saque!");
            }
        }

        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo atual: {saldo:C}");
        }
    }

    public static class Exercicio7
    {
        public static void Run()
        {
            ContaBancaria conta = new ContaBancaria("João Silva");
            Console.WriteLine($"Titular: {conta.Titular}");

            conta.Depositar(500);
            conta.ExibirSaldo();

            Console.WriteLine("Tentativa de saque: R$ 700,00");
            conta.Sacar(700);

            Console.WriteLine("Tentativa de saque: R$ 200,00");
            conta.Sacar(200);

            conta.ExibirSaldo();
        }
    }
}
