using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordSearch.Entities;
using WordSearch.Entities.Exceptions;

namespace WordSearch.Services
{
    internal class GenerateBoard
    {
        static public Board Generate(int height, int width, params string[] HinddenWords) {
            if (HinddenWords.Any(s => s.Length > height && s.Length > width)) throw new ToLargeWordException("Palavra muinto grande para o tamanho do tabuleiro");
            if (HinddenWords.Sum(s => s.Length) > width * height) throw new ToManyWordsException("Nao cabe todas as palavras no tabuleiro");

            HashSet<char> Chars = new HashSet<char>();
            char[,] Characters = new char[height, width];
            Random ramdom = new Random();

            foreach (string word in HinddenWords) { 
                foreach (char c in word) { 
                    Chars.Add(c);
                }
                bool hasletter = true;
                sbyte VelX = (sbyte)ramdom.Next(-1, 2);
                sbyte VelY = (sbyte)ramdom.Next(-1, 2);
                int X = ramdom.Next(0, width);
                int Y = ramdom.Next(0, height);
                for(int count = 0; hasletter && (count <= 1000); count++)  {
                    hasletter = false;
                    VelX = (sbyte)ramdom.Next(-1, 2);
                    VelY = (sbyte)ramdom.Next(-1, 2);
                    X = ramdom.Next(0, width);
                    Y = ramdom.Next(0, height);
                    for (int i = 0; i < word.Length; i++) {
                        try
                        {
                            if (!(Characters[Y + VelY * i , X + VelX * i] == '\0') || (VelX == 0 && VelY == 0)) hasletter = true;
                        } catch (Exception e)
                        {
                            hasletter = true;
                        }
                    }
                    Console.WriteLine(count);
                }
                if (hasletter == true) break;
                for (int i = 0; i < word.Length; i++)
                {

                    Characters[Y + VelY * i, X + VelX * i] = word[i];

                }
            }

            return new Board(Characters);
        }
    }
}
