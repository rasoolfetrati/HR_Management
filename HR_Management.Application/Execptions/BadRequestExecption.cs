using System;

namespace HR_Management.Application.Exceptions
{
    public class BadRequestExecption : ApplicationException
    {
        public BadRequestExecption(string message):base(message)
        {
            
        }
    }
}
