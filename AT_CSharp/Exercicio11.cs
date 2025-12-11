using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public static class Exercicio11
    {
        static string arquivo = "contatos.txt";

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== Gerenciador de Contatos ===");
                Console.WriteLine("1 - Adicionar novo contato");
                Console.WriteLine("2 - Listar contatos cadastrados");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                if (opcao == "3")
                {
                    Console.WriteLine("Encerrando programa...");
                    break;
                }

                switch (opcao)
                {
                    case "1":
                        AdicionarContato();
                        break;
                    case "2":
                        ListarContatos();
                        break;
                    default:
                        Console.WriteLine("❌ Opção inválida! Tente novamente.");
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
                string telefone = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                if (nome.Contains(",") || telefone.Contains(",") || email.Contains(","))
                {
                    Console.WriteLine("Erro: Os campos não podem conter vírgulas (usado como separador).");
                    return;
                }

                using (StreamWriter sw = File.AppendText(arquivo))
                {
                    sw.WriteLine($"{nome},{telefone},{email}");
                }

                Console.WriteLine("Contato cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar contato: {ex.Message}");
            }
        }

        static void ListarContatos()
        {
            if (!File.Exists(arquivo))
            {
                Console.WriteLine("\nNenhum contato cadastrado.");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(arquivo))
                {
                    string linha;
                    bool arquivoVazio = true;

                    Console.WriteLine("\nContatos cadastrados:");

                    while ((linha = sr.ReadLine()) != null)
                    {
                        arquivoVazio = false;
                        string[] dados = linha.Split(',');

                        if (dados.Length >= 3)
                        {
                            string nome = dados[0];
                            string telefone = dados[1];
                            string email = dados[2];

                            Console.WriteLine($"Nome: {nome} | Telefone: {telefone} | Email: {email}");
                        }
                    }

                    if (arquivoVazio)
                    {
                        Console.WriteLine("O arquivo existe, mas está vazio.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler contatos: {ex.Message}");
            }
        }
    }
}
