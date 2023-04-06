using System;

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
