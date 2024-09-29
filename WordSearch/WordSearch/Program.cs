using System.Runtime.InteropServices;
using WordSearch.Entities;
using WordSearch.Services;

namespace WordSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WordFinder.WordFind(GenerateBoard.Generate(3, 4, "FOX","GEL","VEL","POS"), "FOX", "GEL", "VEL", "POS");
        }
    }
}
