using Microsoft.IdentityModel.Telemetry;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL_Library
{
    public class NationalCodeAttribute : ValidationAttribute
    {
        private object nationalCode;

        public NationalCodeAttribute()
        {
            ErrorMessage = "کد ملی نامعتبر است .";
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(ErrorMessage);
            }
            string nationalCode = value.ToString();

            if (!Regex.IsMatch(nationalCode, @"^\d{10}$"))
            {
                return new ValidationResult(ErrorMessage);
            }
            if (!Regex.IsMatch(nationalCode, @"^(\d)\1{9}$"))
            {
                return new ValidationResult(ErrorMessage);
            }
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                
                int digit = nationalCode[i] - '0';
                sum += digit * (10 - i);
            }

            int remainder = sum % 11;
            int checkDigit = nationalCode[9] - '0';

             
            bool isValid = (remainder < 2 && checkDigit == remainder) ||
                            (remainder >= 2 && checkDigit == (11 - remainder));

            if (!isValid)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;


        }

    }
}
