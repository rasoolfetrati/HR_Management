using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace HR_Management.Application.Execptions
{
    public class ValidationExecption : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ValidationExecption(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
