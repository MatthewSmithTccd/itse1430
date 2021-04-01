using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    /// <summary>Validates an object.</summary>
    public class ObjectValidator
    {
       
        public List<ValidationResult> TryValidate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, context, errors, true);

            return errors;
        }
        public void Validate (IValidatableObject value)
        {
            var context = new ValidationContext(value);

            Validator.ValidateObject(value, context, true);
        }
    }
}
