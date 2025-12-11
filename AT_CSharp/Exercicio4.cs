using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public static class Exercicio4
    {
        public static void Run()
        {
            DateTime nascimento;

            while (true)
            {
                Console.Write("Digite sua data de nascimento (dd/mm/aaaa): ");
                if (DateTime.TryParse(Console.ReadLine(), out nascimento))
                {
                    break;
                }
                Console.WriteLine("Data inválida! Tente novamente no formato dia/mês/ano.");
            }

            DateTime hoje = DateTime.Today;

            DateTime proximoNiver = nascimento.AddYears(hoje.Year - nascimento.Year);

            if (proximoNiver < hoje)
            {
                proximoNiver = proximoNiver.AddYears(1);
            }

            TimeSpan diferenca = proximoNiver - hoje;
            int diasRestantes = diferenca.Days;

            Console.WriteLine($"\nData atual: {hoje:dd/MM/yyyy}");
            Console.WriteLine($"Próximo aniversário: {proximoNiver:dd/MM/yyyy}");
            Console.WriteLine($"Faltam {diasRestantes} dias para seu aniversário.");

            if (diasRestantes == 0)
            {
                Console.WriteLine("Parabéns! Hoje é o seu aniversário!");
            }
            else if (diasRestantes < 7)
            {
                Console.WriteLine("Faltam menos de uma semana! Prepare a festa!");
            }
        }
    }
}
