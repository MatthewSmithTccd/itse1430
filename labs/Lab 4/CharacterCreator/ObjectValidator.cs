/*
 * Character Creator - Lab 3
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 * April 1, 2021
 */
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
