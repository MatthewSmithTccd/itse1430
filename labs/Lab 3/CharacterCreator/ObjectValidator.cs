using System;

namespace CharacterCreator
{
    public class ObjectValidator
    {
        public ObjectValidator ( Character character ) 
        { 
            _character = character;
        }
  
        public string Validate()
        {
            if (_character.Validate(out var message))
                return "";

            return message;
        }

        private Character _character;
    }
}
