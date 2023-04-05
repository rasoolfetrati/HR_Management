using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Exceptions
{
    public class BadRequestExecption : ApplicationException
    {
        public BadRequestExecption(string message):base(message)
        {
            
        }
    }
}
