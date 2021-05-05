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
    public class Character : IValidatableObject
    {
        
        private string _name = "";
        private string _profession = "";
        private string _race = "";
        private string _biography = "";
        private int _strengthAttribute;
        private int _intelligenceAttribute;
        private int _agilityAttribute;
        private int _constitutionAttribute;
        private int _charismaAttribute;

        public override string ToString () => Name;

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name is required.");

            if (String.IsNullOrEmpty(Profession))
                yield return new ValidationResult("Profession is required.");

            if (String.IsNullOrEmpty(Race))
                yield return new ValidationResult("Race is required.");

            //Attributes between 1-100
            if (StrengthAttribute < 0 || StrengthAttribute > 100)
                yield return new ValidationResult("Strength attribute must be between 1-100.");

            if (IntelligenceAttribute < 0 || IntelligenceAttribute > 100)
                yield return new ValidationResult("Intelligence attribute must be between 1-100.");
            
            if (AgilityAttribute < 0 || AgilityAttribute > 100)
                yield return new ValidationResult("Agility attribute must be between 1-100.");
            
            if (ConstitutionAttribute < 0 || ConstitutionAttribute > 100)
                yield return new ValidationResult("Constitution attribute must be between 1-100.");
            
            if (CharismaAttribute < 0 || CharismaAttribute > 100)
                yield return new ValidationResult("Charisma attribute must be between 1-100.");
        }

        /// <summary>
        /// Unique identifier of the movie.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value?.Trim() ?? ""; }
        }

        /// <summary>
        /// Gets or sets the profession.
        /// </summary>
        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value; }
        }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value; }
        }

        /// <summary>
        /// Gets or sets the biography.
        /// </summary>
        public string Biography
        {
            get { return _biography ?? ""; }
            set { _biography = value; }
        }

        /// <summary>
        /// Gets or sets the strength attribute.
        /// </summary>
        public int StrengthAttribute
        {
            get { return _strengthAttribute; }
            set { _strengthAttribute = value; }
        }

        /// <summary>
        /// Gets or sets the intelligence attribute.
        /// </summary>
        public int IntelligenceAttribute
        {
            get { return _intelligenceAttribute; }
            set { _intelligenceAttribute = value; }
        }

        /// <summary>
        /// Gets or sets the agility attribute.
        /// </summary>
        public int AgilityAttribute
        {
            get { return _agilityAttribute; }
            set { _agilityAttribute = value; }
        }

        /// <summary>
        /// Gets or sets the constitution attribute.
        /// </summary>
        public int ConstitutionAttribute
        {
            get { return _constitutionAttribute; }
            set { _constitutionAttribute = value; }
        }

        /// <summary>
        /// Gets or sets the charisma attribute.
        /// </summary>
        public int CharismaAttribute
        {
            get { return _charismaAttribute; }
            set { _charismaAttribute = value; }
        }
    }

    

}
