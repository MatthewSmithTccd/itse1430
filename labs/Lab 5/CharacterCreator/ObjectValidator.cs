/*
 * Character Creator - Lab 4
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 * April 23, 2021
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharacterCreator
{
    public class ObjectValidator
    {

        public List<ValidationResult> TryValidate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);
            var errors = new List<ValidationResult>();

            Validator.TryValidateObject(value, context, errors, true);

            return errors;
        }

        public void Validate ( IValidatableObject value )
        {
            var context = new ValidationContext(value);

            Validator.ValidateObject(value, context, true);
        }
    }
}
