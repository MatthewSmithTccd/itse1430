/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 * May 5, 2021
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CharacterCreator
{
    /// <summary> Represents a database of characters. </summary>
    public abstract class CharacterRoster : ICharacterRoster
    {
        public Character Add ( Character character )
        {
            //Validation
            //  Check for null and valid character
            if (character == null)
                throw new ArgumentNullException(nameof(character));

            ObjectValidator.Validate(character);

            //Must be unique
            var existing = FindCharacterByName(character.Name);
            if (existing != null)
            {
                throw new InvalidOperationException("Character name must be unique.");
            };

            //Add the character
            return AddCore(character);
        }

        /// <summary>
        /// Adds the character to the database.</summary>
        /// <param name="character">The character to add.</param>
        /// <returns>The new character.</returns>
        protected abstract Character AddCore ( Character character );

        public void Delete ( int id )
        {
            //Validation
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");
            };

            //Delete
            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        public Character Get ( int id )
        {
            //Validation
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");
            };

            //Get
            return GetCore(id);
        }

        protected abstract Character GetCore ( int id );

        public IEnumerable<Character> GetAll ()
        {
            return GetAllCore() ?? Enumerable.Empty<Character>();
        }

        protected abstract IEnumerable<Character> GetAllCore ();

        public void Update ( int id, Character character )
        {
            //Validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than 0.");

            //  Check for null and valid character
            if (character == null)
                throw new ArgumentNullException(nameof(character));

            ObjectValidator.Validate(character);

            //Must be unique
            var existing = FindCharacterByName(character.Name);
            if (existing != null && existing.Id != id)
                throw new InvalidOperationException("Character name must be unique.");

            try
            {
                UpdateCore(id, character);
            }catch (ArgumentException e)
            {
                throw;
            }catch (InvalidOperationException e)
            {
                throw;
            }catch (Exception e)
            {
                throw new Exception("Update failed", e);
            };

            UpdateCore(id, character);
        }

        protected abstract void UpdateCore ( int id, Character character );

        protected virtual Character FindCharacterByName ( string name )
        {
            foreach (var item in GetAllCore())
            {
                //Match character by name, case insensitive
                if (String.Compare(item.Name, name, true) == 0)
                    return item;
            };

            return null;
        }
    }


}