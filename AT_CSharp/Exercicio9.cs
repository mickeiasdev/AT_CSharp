using System;
using System.Collections.Generic;
using System.Text;

namespace AT_CSharp
{
    public static class Exercicio9
    {
        static string caminhoArquivo = "estoque.txt";
        static int limiteMaximo = 5;

        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU ===");
                Console.WriteLine("1 - Inserir Produto");
                Console.WriteLine("2 - Listar Produtos");
                Console.WriteLine("3 - Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                if (opcao == "3") break;

                switch (opcao)
                {
                    case "1":
                        InserirProduto();
                        break;
                    case "2":
                        ListarProdutos();
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        static void InserirProduto()
        {
            int quantidadeAtual = 0;
            if (File.Exists(caminhoArquivo))
            {
                quantidadeAtual = File.ReadAllLines(caminhoArquivo).Length;
            }

            if (quantidadeAtual >= limiteMaximo)
            {
                Console.WriteLine("\nLimite de produtos atingido! Não é possível cadastrar mais.");
                return;
            }

            try
            {
                Console.Write("\nNome do Produto: ");
                string nome = Console.ReadLine();

                if (nome.Contains(","))
                {
                    Console.WriteLine("Erro: O nome não pode conter vírgulas.");
                    return;
                }

                Console.Write("Quantidade em estoque: ");
                int quantidade = int.Parse(Console.ReadLine());

                Console.Write("Preço Unitário: ");
                double preco = double.Parse(Console.ReadLine());

                string linha = $"{nome},{quantidade},{preco}";

                using (StreamWriter sw = File.AppendText(caminhoArquivo))
                {
                    sw.WriteLine(linha);
                }

                Console.WriteLine("Produto salvo com sucesso!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro: Certifique-se de digitar números válidos para quantidade e preço.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        static void ListarProdutos()
        {
            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine("\nNenhum produto cadastrado (Arquivo não existe).");
                return;
            }

            try
            {
                using (StreamReader sr = new StreamReader(caminhoArquivo))
                {
                    string linha;
                    bool arquivoVazio = true;

                    Console.WriteLine("\n--- Lista de Produtos ---");

                    while ((linha = sr.ReadLine()) != null)
                    {
                        arquivoVazio = false;
                        string[] dados = linha.Split(',');

                        if (dados.Length == 3)
                        {
                            string nome = dados[0];
                            string qtd = dados[1];
                            string precoStr = dados[2];

                            if (double.TryParse(precoStr, out double preco))
                            {
                                Console.WriteLine($"Produto: {nome} | Quantidade: {qtd} | Preço: {preco:C}");
                            }
                        }
                    }

                    if (arquivoVazio)
                    {
                        Console.WriteLine("Nenhum produto cadastrado (Arquivo vazio).");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ler arquivo: {ex.Message}");
            }
        }
    }
}
