using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public double MediaNotas { get; set; }

        public void ExibirDados()
        {
            Console.WriteLine("\n--- Ficha do Aluno ---");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Matrícula: {Matricula}");
            Console.WriteLine($"Curso: {Curso}");
            Console.WriteLine($"Média Final: {MediaNotas:F2}");
        }

        public string VerificarAprovacao()
        {
            if (MediaNotas >= 7.0)
            {
                return "Aprovado";
            }
            else
            {
                return "Reprovado";
            }
        }
    }

    public static class Exercicio6
    {
        public static void Run()
        {
            Aluno aluno = new Aluno();

            Console.Write("Digite o nome do aluno: ");
            aluno.Nome = Console.ReadLine();

            Console.Write("Digite a matrícula: ");
            aluno.Matricula = Console.ReadLine();

            Console.Write("Digite o curso: ");
            aluno.Curso = Console.ReadLine();

            while (true)
            {
                Console.Write("Digite a média das notas: ");
                if (double.TryParse(Console.ReadLine(), out double media))
                {
                    aluno.MediaNotas = media;
                    break;
                }
                Console.WriteLine("Erro: Digite um valor numérico válido para a média.");
            }

            aluno.ExibirDados();

            string status = aluno.VerificarAprovacao();
            Console.WriteLine($"Situação Acadêmica: {status}");
        }
    }
}
