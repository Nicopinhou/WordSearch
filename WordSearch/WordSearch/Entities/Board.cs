﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Entities
{
    internal class Board
    {
        public char[,] Characters { get; set; }

        public Board() { 
            Characters = new char[0,0];
        }

        public Board(char[,] characters)
        {
            Characters = characters.Clone() as char[,];
        }

        public Board(Board board)
        {
            Characters = board.Characters.Clone() as char[,];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (char c in Characters)
            {
                if (!(c == '\0'))
                {
                    if (i % Characters.GetLength(1) == 0) sb.Append("\n " + c);
                    else sb.Append(" " + c);
                }
                else if (i % Characters.GetLength(1) == 0) sb.Append("\n _");
                else sb.Append(" _");
                i++;
            }
            return sb.ToString();
        }
    }
}
