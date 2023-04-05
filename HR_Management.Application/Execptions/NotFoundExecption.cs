using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Execptions
{
    public class NotFoundExecption : ApplicationException
    {
        public NotFoundExecption(string name,object key)
            :base($"{name} ({key}) was not found!")
        {
            
        }
    }
}
