using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSearch.Entities.Exceptions
{
    internal class ToLargeWordException : BoardException
    {
        public ToLargeWordException(string message) : base(message) { }
    }
}
