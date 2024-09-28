using System;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (char c in Characters)
            {
                if (i % Characters.GetLength(1) == 0) sb.Append("\n" + c); else sb.Append(" " + c);
                i++;
            }
            return sb.ToString();
        }
    }
}
