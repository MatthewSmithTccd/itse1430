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
using System.Linq;

namespace CharacterCreator.Memory
{
    /// <summary> Represents a database of characters. </summary>
    public class MemoryCharacterRoster : ICharacterRoster
    {
        public Character Add ( Character character )
        {
            //Validation
            //  Check for null and valid character
            if (character == null)
                throw new ArgumentNullException(nameof(character));

            new ObjectValidator().Validate(character);
            
            //Must be unique
            var existing = FindByName(character.Name);
            if (existing != null)
            {
                throw new InvalidOperationException("Character name must be unique.");
                //error = "Character name must be unique";
                //return null;
            };

            //Add the character
            //replacing with the suggested code from the assignment
            //character.Id = ++_id;
            character.Id = ++_nextId;
            _characters.Add(CloneCharacter(character));

            //error = null;
            return character;
        }

        public void Delete ( int id )
        {
            //Validation
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");
            };
            //error = null;

            //Delete
            var existing = FindById(id);
            if (existing != null)
                _characters.Remove(existing);
        }

        public Character Get ( int id )
        {
            //Validation
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");
            };
            //error = null;

            //Get
            var existing = FindById(id);
            if (existing == null)
                return null;

            return CloneCharacter(existing);
        }

        public IEnumerable<Character> GetAll ()
        {
            foreach (var item in _characters)
                yield return CloneCharacter(item);
            //return items;
        }

        public void Update ( int id, Character character )
        {
            //Validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            //  Check for null and valid character
            if (character == null)
                throw new ArgumentOutOfRangeException(nameof(character));

            new ObjectValidator().Validate(character);

            //Must be unique
            var existing = FindByName(character.Name);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Character name must be unique.");

            //Must exist
            existing = FindById(id) ?? throw new Exception("Character does not exist.");

            //Update the character
            CopyCharacter(existing, character);
        }

        private Character CloneCharacter ( Character character )
        {
            var target = new Character() {
                Id = character.Id
            };

            CopyCharacter(target, character);
            return target;
        }

        private void CopyCharacter ( Character target, Character source )
        {
            target.Name = source.Name;
            target.Profession = source.Profession;
            target.Race = source.Race;
            target.Biography = source.Biography;
            target.StrengthAttribute = source.StrengthAttribute;
            target.IntelligenceAttribute = source.IntelligenceAttribute;
            target.AgilityAttribute = source.AgilityAttribute;
            target.ConstitutionAttribute = source.ConstitutionAttribute;
            target.CharismaAttribute = source.CharismaAttribute;
        }

        private Character FindById ( int id )
        {
            foreach (var item in _characters)
            {
                if (item.Id == id)
                    return item;
            };

            return null;
        }

        private Character FindByName ( string name )
        {
            foreach (var item in _characters)
            {
                //Match character by name, case insensitive
                if (String.Compare(item.Name, name, true) == 0)
                    return item;
            };

            return null;
        }

        
        private readonly List<Character> _characters = new List<Character>();

        private int _nextId = 0;
    }


}