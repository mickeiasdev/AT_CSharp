using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public double SalarioBase { get; set; }

        public virtual void ExibirSalario()
        {
            Console.WriteLine($"Funcionário: {Nome} | Cargo: {Cargo} | Salário: {SalarioBase:C}");
        }
    }

    public class Gerente : Funcionario
    {
        public override void ExibirSalario()
        {
            double salarioComBonus = SalarioBase * 1.20;

            Console.WriteLine($"Gerente: {Nome} | Cargo: {Cargo} | Salário Base: {SalarioBase:C} | Total com Bônus (20%): {salarioComBonus:C}");
        }
    }

    public static class Exercicio8
    {
        public static void Run()
        {
            Funcionario f1 = new Funcionario();
            f1.Nome = "Carlos";
            f1.Cargo = "Analista Jr";
            f1.SalarioBase = 3000.00;

            Gerente g1 = new Gerente();
            g1.Nome = "Ana";
            g1.Cargo = "Gerente de Projetos";
            g1.SalarioBase = 5000.00;

            Console.WriteLine("\n> Detalhes do Funcionário:");
            f1.ExibirSalario();

            Console.WriteLine("\n> Detalhes do Gerente:");
            g1.ExibirSalario();
        }
    }
}
