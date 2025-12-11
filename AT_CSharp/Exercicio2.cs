using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public static class Exercicio2
    {
        public static void Run()
        {
            Console.Write("Digite seu nome completo: ");
            string entrada = Console.ReadLine();

            char[] caracteres = entrada.ToCharArray();

            for (int i = 0; i < caracteres.Length; i++)
            {
                char letraOriginal = caracteres[i];

                if ((letraOriginal >= 'A' && letraOriginal <= 'Z') ||
                    (letraOriginal >= 'a' && letraOriginal <= 'z'))
                {
                    char letraDeslocada = (char)(letraOriginal + 2);

                    caracteres[i] = letraDeslocada;
                }
            }

            string saida = new string(caracteres);

            Console.WriteLine("Nome Cifrado: " + saida);
        }
    }
}
