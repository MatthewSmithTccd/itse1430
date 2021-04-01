/*
 * Character Creator
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 */
using System;

namespace CharacterCreator
{
    public class Character
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

        /// <summary>Validates the character data is correct.</summary>
        /// <param name="error">The error message if any.</param>
        /// <returns>True if character is valid.</returns>
        public bool Validate ( out string error )
        {
            //Title is required
            if (String.IsNullOrEmpty(Name))
            {
                error = "Name is required.";
                return false;
            };

            if (String.IsNullOrEmpty(Profession))
            {
                error = "Profession is required.";
                return false;
            };

            if (String.IsNullOrEmpty(Race))
            {
                error = "Race is required.";
                return false;
            };

            if (StrengthAttribute < 0 || StrengthAttribute > 100)
            {
                error = "Must be between 1-100";
                return false;
            };
            if (IntelligenceAttribute < 0 || IntelligenceAttribute > 100)
            {
                error = "Must be between 1-100";
                return false;
            };
            if (AgilityAttribute < 0 || AgilityAttribute > 100)
            {
                error = "Must be between 1-100";
                return false;
            };
            if (ConstitutionAttribute < 0 || ConstitutionAttribute > 100)
            {
                error = "Must be between 1-100";
                return false;
            };
            if (CharismaAttribute < 0 || CharismaAttribute > 100)
            {
                error = "Must be between 1-100";
                return false;
            };

            error = "";
            return true;
        }

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
