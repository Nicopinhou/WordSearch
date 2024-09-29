using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Entities
{
    internal struct OrderedPairs
    {
        public int X = 0;
        public int Y = 0;

        public OrderedPairs() { }
        public OrderedPairs(int y, int x) { 
            X = x; 
            Y = y;
        }
    }
}
