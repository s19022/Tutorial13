using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_13.Exceptions
{
    public class NoCustomerWithNameException : Exception
    {
        public NoCustomerWithNameException(string name) : base(name)
        {

        }
    }
}
