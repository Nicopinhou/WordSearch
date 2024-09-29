using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Entities.Exceptions
{
    internal class ToManyWordsException : BoardException
    {
        public ToManyWordsException(string message) : base(message) { }
    }
}
