using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public static class Exercicio5
    {
        public static void Run()
        {
            DateTime dataFormatura = new DateTime(2027, 05, 01);
            Console.WriteLine($"Data de Formatura definida: {dataFormatura:dd/MM/yyyy}");

            DateTime dataAtualUsuario;

            while (true)
            {
                Console.Write("Digite a data atual (dd/MM/yyyy): ");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out dataAtualUsuario))
                {
                    if (dataAtualUsuario.Date > DateTime.Today)
                    {
                        Console.WriteLine("Erro: A data informada não pode ser no futuro! Tente novamente.");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Erro: Data inválida! Use o formato dd/mm/aaaa.");
                }
            }

            if (dataAtualUsuario.Date >= dataFormatura.Date)
            {
                Console.WriteLine("\nParabéns! Você já deveria estar formado!");
            }
            else
            {
                int anos = dataFormatura.Year - dataAtualUsuario.Year;
                int meses = dataFormatura.Month - dataAtualUsuario.Month;
                int dias = dataFormatura.Day - dataAtualUsuario.Day;

                if (dias < 0)
                {
                    meses--;
                    DateTime mesAnterior = dataFormatura.AddMonths(-1);
                    dias += DateTime.DaysInMonth(mesAnterior.Year, mesAnterior.Month);
                }

                if (meses < 0)
                {
                    anos--;
                    meses += 12;
                }

                // 4. Exibir Saídas Esperadas
                Console.WriteLine($"\nFaltam {anos} anos, {meses} meses e {dias} dias para sua formatura!");

                if (anos == 0 && meses < 6)
                {
                    Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
                }
            }
        }
    }
}
