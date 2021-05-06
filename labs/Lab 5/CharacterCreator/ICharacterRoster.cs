/*
 * Character Creator - Lab 5
 * ITSE 1430
 * Spring 2021
 * Matthew Smith
 * May 5, 2021
 */
using System.Collections.Generic;

namespace CharacterCreator
{
    /// <summary>
    /// Represents a database of Characters.
    /// </summary>
    public interface ICharacterRoster
    {
        /// <summary>
        /// Adds a character to the database.
        /// </summary>
        /// <param name="character">The character to add.</param>
        /// <returns>The added character.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="character"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="character"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="character"/>Character is not unique.</exception>
        Character Add ( Character character);

        /// <summary>
        /// Deletes a character.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than one.</exception>
        void Delete ( int id);

        /// <summary>
        /// Gets a character, if any.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns>The character, if any.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> is less than one.</exception>
        Character Get ( int id );

        /// <summary>
        /// Gets all the characters.
        /// </summary>
        /// <returns>The characters.</returns>
        IEnumerable<Character> GetAll ();

        /// <summary>
        /// Updates an existing character.
        /// </summary>
        /// <param name="id">The ID of the character to update.</param>
        /// <param name="character">The updated character.</param>
        /// <exception cref="Exception">Character does not exist.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/> must be greater than zero.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="character"/> is null.</exception>
        /// <exception cref="ValidationException"><paramref name="character"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="character"/>Character is not unique.</exception>
        void Update ( int id, Character character);
    }
}