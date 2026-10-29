using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL_Library
{
    public class FileSizeAttribute:ValidationAttribute
    {
        private readonly int _size;
        public FileSizeAttribute(int size) 
        {
        _size = size*1024*1024;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is byte[] filebytes && filebytes.Length > _size)
            {
                return new ValidationResult(ErrorMessage ?? "حجم فایل پیش از حد مجاز است.");
            }
            return ValidationResult.Success;
        }
    }
}
