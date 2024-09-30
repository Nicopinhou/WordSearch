using System.Runtime.InteropServices;
using WordSearch.Entities;
using WordSearch.Services;
using System.Collections.Generic;

namespace WordSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Caça Palavras \n \nCriar\n");
                List<string> respostas = new List<string>();
                Console.ReadLine();
                try
                {
                    Console.Clear();
                    respostas.Clear();
                    Console.Write("Largura:");
                    respostas.Add(Console.ReadLine());
                    Console.Clear();
                    Console.Write("Altura:");
                    respostas.Add(Console.ReadLine());
                    Console.Clear();
                    Console.Write("Palavras para esconder (use \",\" para separar as palavras):");
                    respostas.Add(Console.ReadLine());
                    Console.Clear();
                    Console.Write("Seed (deixe vazio para seed aleatoria):");
   
                    respostas.Add(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Gerando...");
                    Board board = GenerateBoard.Generate(int.Parse(respostas[1]), int.Parse(respostas[0]), (respostas[3] == "")? new Random() : new Random(int.Parse(respostas[3])) ,respostas[2].ToUpper().Split(",").Select(p => p.Trim()).ToArray());
                       
                    Console.Clear();
                    Console.WriteLine($"Ache as palavras: {respostas[2].ToUpper()}");
                    Console.WriteLine(board + "\n \n Enter para mostrar a resposta");
                    Console.ReadLine();
                    Console.Clear();
                    WordFinder.WordFind(board, respostas[2].ToUpper().Split(",").Select(p => p.Trim()).ToArray());
                    Console.WriteLine("\n \n Enter para voltar pro menu");
                    Console.ReadLine();
                    
                } catch (Exception e) {
                    respostas.Clear();
                    Console.WriteLine("ERROR:" + e.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
