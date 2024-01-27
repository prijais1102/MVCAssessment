
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCAssessment.Models
{
    internal class BatchValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string? Batch = (string?)value;
                if (Batch.Length ==4)
                {
                    char[] chars = Batch.ToCharArray();
                    if (chars[0]=='B')
                    
                    {
                        for(int i = 1; i < 4; i++)
                        {
                            if (char.IsDigit(chars[i]))
                            {
                                return ValidationResult.Success;
                            }
                        }

                       
                    }

                }
            }
            return new ValidationResult(ErrorMessage ?? "Batch should start with B and end with three integers.");
        }

    }
}