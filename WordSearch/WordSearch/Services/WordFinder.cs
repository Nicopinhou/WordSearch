using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearch.Entities;
namespace WordSearch.Services
{
    internal class WordFinder
    {
        static public void WordFind(char[,] Characters, params string[] words) {
            ConsoleColor Color = Console.ForegroundColor;
            int i = 0;
            foreach (char c in Characters)
            {
                Console.ForegroundColor = Color;
                for (int b = 0; b < words.Length; b++)
                {
                    if (!(Console.ForegroundColor == ConsoleColor.Yellow) && FindInAllDirection(Characters, words[b], new OrderedPairs( (int)Math.Ceiling((double)(i / Characters.GetLength(1))), i % Characters.GetLength(1) ))) Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (!(c == '\0'))
                {
                    if (i % Characters.GetLength(1) == 0) Console.Write(("\n " + c));
                    else Console.Write(" " + c);
                }
                else if (i % Characters.GetLength(1) == 0) Console.Write("\n _");
                else Console.Write(" _");
                i++;
            }
            Console.ForegroundColor = Color;
        }
        static public void WordFind(Board board, params string[] words)
        {
            WordFind(board.Characters, words);
        }

        static public bool FindInAllDirection(char[,] Characters, string Word, OrderedPairs Pos) {
            for (int i = 0; i < Word.Length; i++) {
                if (Direction(Characters, Word, new OrderedPairs(- 1, -1),new OrderedPairs(Pos.Y + i, Pos.X + i))) return true;
                if (Direction(Characters, Word, new OrderedPairs(- 1, 0), new OrderedPairs(Pos.Y + i, Pos.X))) return true;
                if (Direction(Characters, Word, new OrderedPairs(- 1, 1), new OrderedPairs(Pos.Y + i, Pos.X - i))) return true;
                if (Direction(Characters, Word, new OrderedPairs(0, -1), new OrderedPairs(Pos.Y, Pos.X + i))) return true;
                if (Direction(Characters, Word, new OrderedPairs(0, 1) , new OrderedPairs(Pos.Y, Pos.X - i))) return true;
                if (Direction(Characters, Word, new OrderedPairs(1, -1), new OrderedPairs(Pos.Y - i, Pos.X + i))) return true;
                if (Direction(Characters, Word, new OrderedPairs(1, 0), new OrderedPairs(Pos.Y - i, Pos.X))) return true;
                if (Direction(Characters, Word, new OrderedPairs(1, 1), new OrderedPairs(Pos.Y - i, Pos.X - i))) return true;
            }
            return false;
        }
        static public bool Direction(char[,] Characters, string Word, OrderedPairs Vel, OrderedPairs Pos)
        {
            bool Find = false;
            try
            {
                for (int i = 0; i < Word.Length; i++)
                {
                    Find = false;
                    if (!(Characters[Pos.Y + Vel.Y * i, Pos.X + Vel.X * i] == Word[i])) break;
                    Find = true;
                }
            } catch (Exception e)
            {
                return false;
            }
            return Find;
        }
    }
}
