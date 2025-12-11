using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public static class Exercicio10
    {
        public static void Run()
        {
            Random random = new Random();
            int numeroSecreto = random.Next(1, 51);

            int tentativasMaximas = 5;
            int tentativaAtual = 1;

            Console.WriteLine("Adivinhe o número secreto entre 1 e 50.");
            Console.WriteLine($"Você tem {tentativasMaximas} tentativas.");

            while (tentativaAtual <= tentativasMaximas)
            {
                Console.Write($"\nTentativa {tentativaAtual} de {tentativasMaximas}: ");
                string entrada = Console.ReadLine();

                try
                {
                    int palpite = int.Parse(entrada);

                    if (palpite < 1 || palpite > 50)
                    {
                        Console.WriteLine("Erro: O número deve ser entre 1 e 50!");
                        continue;
                    }

                    if (palpite == numeroSecreto)
                    {
                        Console.WriteLine("Parabéns! Você acertou o número!");
                        return;
                    }
                    else if (palpite < numeroSecreto)
                    {
                        Console.WriteLine("Dica: O número secreto é MAIOR.");
                    }
                    else
                    {
                        Console.WriteLine("Dica: O número secreto é MENOR.");
                    }

                    tentativaAtual++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro: Entrada inválida! Por favor, digite apenas números.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro inesperado: {ex.Message}");
                }
            }

            Console.WriteLine($"\nGame Over! Suas tentativas acabaram.");
            Console.WriteLine($"O número secreto era: {numeroSecreto}");
        }
    }
}
