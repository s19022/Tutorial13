using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_13.Exceptions
{
    public class NoSuchConfectioneryException : Exception
    {
        public NoSuchConfectioneryException(string message) : base(message)
        {

        }
    }
}
