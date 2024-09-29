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
                OrderedPairs Vel = new OrderedPairs();
                OrderedPairs Pos = new OrderedPairs();
                Vel.X = (sbyte)ramdom.Next(-1, 2);
                Vel.Y = (sbyte)ramdom.Next(-1, 2);
                Pos.X = ramdom.Next(0, width);
                Pos.Y = ramdom.Next(0, height);
                for(int count = 0; hasletter && (count <= 500); count++)  {
                    hasletter = false;
                    Vel.X = (sbyte)ramdom.Next(-1, 2);
                    Vel.Y = (sbyte)ramdom.Next(-1, 2);
                    Pos.X = ramdom.Next(0, width);
                    Pos.Y = ramdom.Next(0, height);
                    for (int i = 0; i < word.Length; i++) {
                        try
                        {
                            if (!(Characters[Pos.Y + Vel.Y * i , Pos.X + Vel.X * i] == '\0') || (Vel.X == 0 && Vel.Y == 0)) hasletter = true;
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

                    Characters[Pos.Y + Vel.Y * i, Pos.X + Vel.X * i] = word[i];

                }
                
            }
            for (int Y = 0; Y < Characters.GetLength(0); Y++)
            {
                for (int X = 0; X < Characters.GetLength(1); X++)
                {
                    if ((Characters[Y, X] == '\0')) {
                         bool Word = true;

                        for (int count = 0; Word && (count <= 500); count++)
                        {
                            Console.WriteLine(count);
                            Console.WriteLine(new Board(Characters));
                            Word = false;
                            Characters[Y, X] = Chars.ElementAt(ramdom.Next(0, Chars.Count));
                            Console.WriteLine(Characters[Y, X]);
                            foreach (string strin in HinddenWords)
                            {
                                if (WordFinder.FindInAllDirection(Characters, strin, new OrderedPairs(Y, X))) Word = true;
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
