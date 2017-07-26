using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Contacts.Validators
{
    public class StringValidatorAttribute: ValidationAttribute
    {
        private readonly string _validatePattern;

        public StringValidatorAttribute(string validatePattern)
        {
            _validatePattern = validatePattern;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value==null)
            {
                return new ValidationResult("Value is null");
            }
            string stringDate = (string)value;
            Regex pattern = new Regex(_validatePattern);
            bool isMatched = pattern.IsMatch(stringDate);
            return isMatched ?
                ValidationResult.Success :
                new ValidationResult("Wrong format");
            
        }
    }
}