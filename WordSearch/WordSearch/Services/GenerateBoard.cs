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
                if (hasletter == true) return Generate(height,width,HinddenWords);
                for (int i = 0; i < word.Length; i++)
                {

                    Characters[Y + VelY * i, X + VelX * i] = word[i];

                }
                
            }
            for (int Y = 0; Y < Characters.GetLength(0); Y++)
            {
                for (int X = 0; X < Characters.GetLength(0); X++)
                {
                    if ((Characters[Y, X] == '\0')) {
                         bool Word = true;

                        for (int count = 0; Word && (count <= 1000); count++)
                        {
                            Console.WriteLine(count);
                            Console.WriteLine(new Board(Characters));
                            Word = false;
                            Characters[Y, X] = Chars.ElementAt(ramdom.Next(0, Chars.Count));
                            Console.WriteLine(Characters[Y, X]);
                            foreach (string strin in HinddenWords)
                            {
                                if (WordFinder.FindInAllDirection(Characters, strin, Y, X)) Word = true;
                            }

                        }
                            if (Word) return Generate(height, width, HinddenWords);
                        
                    }
                }
            }
            return new Board(Characters);
        }
    }
}
