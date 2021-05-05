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
    /// <summary> Represents a base implementation of character database. </summary>
    public class MemoryCharacterRoster : CharacterRoster
    {
        protected override Character AddCore ( Character character )
        {
            //Add the character
            character.Id = ++_nextId;
            _characters.Add(CloneCharacter(character));

            return character;
        }

        //public void Delete ( int id )
        protected override void DeleteCore (int id)
        {
            //Delete
            var existing = FindById(id);
            if (existing != null)
                _characters.Remove(existing);
        }

        //public Character Get ( int id )
        protected override Character GetCore ( int id )
        {
            //Get
            var existing = FindById(id);
            if (existing == null)
                return null;

            return CloneCharacter(existing);
        }

        protected override IEnumerable<Character> GetAllCore()
        {
            foreach (var item in _characters)
                yield return CloneCharacter(item);
            //return items;
        }

        protected override void UpdateCore ( int id, Character character )
        {
            //Must exist
            var existing = FindById(id) ?? throw new Exception("Character does not exist.");

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

        private readonly List<Character> _characters = new List<Character>();

        private int _nextId = 0;
    }


}