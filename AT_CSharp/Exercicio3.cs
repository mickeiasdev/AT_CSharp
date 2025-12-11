using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public static class Exercicio3
    {
        public static void Run()
        {
            double num1 = LerNumero("Digite o primeiro número: ");
            double num2 = LerNumero("Digite o segundo número: ");

            Console.WriteLine("\nEscolha a operação:");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.Write("Opção: ");

            string inputOpcao = Console.ReadLine();
            int opcao;

            if (!int.TryParse(inputOpcao, out opcao) || opcao < 1 || opcao > 4)
            {
                Console.WriteLine("Erro: Opção inválida! Por favor, escolha entre 1 e 4.");
                return;
            }

            double resultado = 0;

            switch (opcao)
            {
                case 1:
                    resultado = num1 + num2;
                    Console.WriteLine($"\nResultado: {num1} + {num2} = {resultado}");
                    break;

                case 2:
                    resultado = num1 - num2;
                    Console.WriteLine($"\nResultado: {num1} - {num2} = {resultado}");
                    break;

                case 3:
                    resultado = num1 * num2;
                    Console.WriteLine($"\nResultado: {num1} * {num2} = {resultado}");
                    break;

                case 4:
                    if (num2 == 0)
                    {
                        Console.WriteLine("\nErro Crítico: Não é possível dividir por zero!");
                    }
                    else
                    {
                        resultado = num1 / num2;
                        Console.WriteLine($"\nResultado: {num1} / {num2} = {resultado}");
                    }
                    break;
            }
        }
        private static double LerNumero(string mensagem)
        {
            double numero;
            while (true)
            {
                Console.Write(mensagem);
                string entrada = Console.ReadLine();

                if (double.TryParse(entrada, out numero))
                {
                    return numero;
                }

                Console.WriteLine("Entrada inválida! Digite apenas números.");
            }
        }
    }
}
