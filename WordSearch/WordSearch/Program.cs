using System.Runtime.InteropServices;
using WordSearch.Entities;
using WordSearch.Services;

namespace WordSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WordFinder.WordFind(GenerateBoard.Generate(10, 10, "FOX","GEL"), "FOX", "GEL");
        }
    }
}
