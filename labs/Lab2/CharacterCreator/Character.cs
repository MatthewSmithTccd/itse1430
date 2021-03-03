using System;

namespace CharacterCreator
{
    /*
     *  Name: (Required) The name of the character.
        Profession: (Required) The profession of the character. The available professions are: Fighter, Hunter, Priest, Rogue and Wizard.
        Race: (Required) The race of the character. The available races are: Dwarf, Elf, Gnome, Half Elf and Human.
        Biography: The optional, biographic details of the character.

        Each character has a set of numeric attributes that define the character. The attributes are: Strength, Intelligence, Agility, Constitution and Charisma. For each attribute:

        An integral value is required.
        The value must be between 1 and 100.
        Ensure that the class is properly documented and follows the general guidelines outlined in class.
    */
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

        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }

        public string Profession
        {
            get { return _profession ?? ""; }
            set { _profession = value; }
        }

        public string Race
        {
            get { return _race ?? ""; }
            set { _race = value; }
        }

        public string Biography
        {
            get { return _biography ?? ""; }
            set { _biography = value; }
        }

        public int StrengthAttribute
        {
            get { return _strengthAttribute; }
            set { _strengthAttribute = value; }
        }

        public int IntelligenceAttribute
        {
            get { return _intelligenceAttribute; }
            set { _intelligenceAttribute = value; }
        }
        public int AgilityAttribute
        {
            get { return _agilityAttribute; }
            set { _agilityAttribute = value; }
        }
        public int ConstitutionAttribute
        {
            get { return _constitutionAttribute; }
            set { _constitutionAttribute = value; }
        }
        public int CharismaAttribute
        {
            get { return _charismaAttribute; }
            set { _charismaAttribute = value; }
        }
    }
}
