﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tutorial_13.Exceptions
{
    public class NoSuchCustomerException : Exception
    {
        public NoSuchCustomerException(string name) : base(name)
        {

        }
    }
}
