using System.Runtime.InteropServices;
using WordSearch.Entities;

namespace WordSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board a = new Board()
            {
                Characters = new char[,] { { 'a', 'a', 'b' },
                                          { 'b', 'a', 't' }  }
            };
            Console.WriteLine(a);
        }
    }
}