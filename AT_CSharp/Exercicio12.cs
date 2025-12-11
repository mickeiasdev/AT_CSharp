using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public class Contato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Contato(string nome, string telefone, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
        }
    }

    public abstract class ContatoFormatter
    {
        public abstract void ExibirContatos(List<Contato> contatos);
    }
    public class MarkdownFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("\n## Lista de Contatos");
            foreach (var c in contatos)
            {
                Console.WriteLine($"- **Nome:** {c.Nome}");
                Console.WriteLine($"  - Telefone: {c.Telefone}");
                Console.WriteLine($"  - Email: {c.Email}");
            }
        }
    }

    public class TabelaFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("\n--------------------------------------------------------------------------------");
            Console.WriteLine("| Nome                 | Telefone            | Email                          |");
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (var c in contatos)
            {
                Console.WriteLine($"| {c.Nome.PadRight(20)} | {c.Telefone.PadRight(19)} | {c.Email.PadRight(30)} |");
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
        }
    }

    public class RawTextFormatter : ContatoFormatter
    {
        public override void ExibirContatos(List<Contato> contatos)
        {
            Console.WriteLine("\n--- Texto Puro ---");
            foreach (var c in contatos)
            {
                Console.WriteLine($"Nome: {c.Nome} | Telefone: {c.Telefone} | Email: {c.Email}");
            }
        }
    }

    public static class Exercicio12
    {
        static string arquivo = "contatos.txt";

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Adicionar Contato");
                Console.WriteLine("2 - Listar Contatos");
                Console.WriteLine("3 - Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                if (opcao == "3") break;

                switch (opcao)
                {
                    case "1":
                        AdicionarContato();
                        break;
                    case "2":
                        ListarContatos();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void AdicionarContato()
        {
            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Telefone: ");
                string fone = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();

                if (nome.Contains(",") || fone.Contains(",") || email.Contains(","))
                {
                    Console.WriteLine("Erro: Vírgulas não permitidas.");
                    return;
                }

                using (StreamWriter sw = File.AppendText(arquivo))
                {
                    sw.WriteLine($"{nome},{fone},{email}");
                }
                Console.WriteLine("Salvo!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao salvar: " + ex.Message);
            }
        }

        static void ListarContatos()
        {
            if (!File.Exists(arquivo))
            {
                Console.WriteLine("Nenhum contato cadastrado.");
                return;
            }

            List<Contato> listaContatos = new List<Contato>();

            try
            {
                string[] linhas = File.ReadAllLines(arquivo);
                foreach (string linha in linhas)
                {
                    string[] dados = linha.Split(',');
                    if (dados.Length >= 3)
                    {
                        listaContatos.Add(new Contato(dados[0], dados[1], dados[2]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao ler arquivo: " + ex.Message);
                return;
            }

            if (listaContatos.Count == 0)
            {
                Console.WriteLine("Arquivo vazio.");
                return;
            }

            Console.WriteLine("\nEscolha o formato de exibição:");
            Console.WriteLine("1 - Markdown");
            Console.WriteLine("2 - Tabela");
            Console.WriteLine("3 - Texto Puro");
            Console.Write("Formato: ");
            string escolha = Console.ReadLine();

            ContatoFormatter formatter;

            switch (escolha)
            {
                case "1":
                    formatter = new MarkdownFormatter();
                    break;
                case "2":
                    formatter = new TabelaFormatter();
                    break;
                default:
                    formatter = new RawTextFormatter();
                    break;
            }

            formatter.ExibirContatos(listaContatos);
        }
    }
}
