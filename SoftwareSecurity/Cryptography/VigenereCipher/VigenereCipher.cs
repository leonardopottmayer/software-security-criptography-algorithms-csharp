﻿using SoftwareSecurity.Cryptography.Utils;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftwareSecurity.Cryptography.VigenereCipher
{
    public class VigenereCipher
    {
        #region Attributes

        protected CharacterManipulator Manipulator = new CharacterManipulator();

        #endregion Attributes

        #region Constructors

        public VigenereCipher() { }

        #endregion Constructors

        #region Encryption And Decryption Methods

        /// <summary>
        /// Encrypts the text using a specified key.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string Encrypt(string text, string key)
        {
            if (!KeyIsValid(key)) throw new ArgumentException("Invalid key.");

            var builder = new StringBuilder();
            string cleanText = Manipulator.RemoveAccents(text);

            int replacedLettersCount = 0;

            foreach (char textCharacter in cleanText.ToCharArray())
            {
                char characterToAppend = textCharacter;

                if (char.IsLetter(textCharacter))
                {
                    char currentKeyLetter = GetNextKeyLetter(key, replacedLettersCount);
                    characterToAppend = ReplaceLetter(textCharacter, currentKeyLetter);
                    replacedLettersCount++;
                }

                builder.Append(characterToAppend);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Decrypts the text using a specified key.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string Decrypt(string text, string key)
        {
            if (!KeyIsValid(key)) throw new ArgumentException("Invalid key.");

            var builder = new StringBuilder();
            string cleanText = Manipulator.RemoveAccents(text);

            int replacedLettersCount = 0;

            foreach (char textCharacter in cleanText.ToCharArray())
            {
                char characterToAppend = textCharacter;

                if (char.IsLetter(textCharacter))
                {
                    char currentKeyLetter = GetNextKeyLetter(key, replacedLettersCount);
                    characterToAppend = ReplaceLetterReverse(textCharacter, currentKeyLetter);
                    replacedLettersCount++;
                }

                builder.Append(characterToAppend);
            }

            return builder.ToString();
        }

        #endregion Encryption And Decryption Methods

        #region Encryption Auxiliar Methods

        /// <summary>
        /// Calculates the next letter of the key, using the replaced letters count.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="replacedLettersCount"></param>
        /// <returns></returns>
        protected char GetNextKeyLetter(string key, int replacedLettersCount)
        {
            int index = replacedLettersCount % key.Length;
            char keyChar = key[index];

            return keyChar;
        }

        /// <summary>
        /// Verifies if the key contains only letters;
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected bool KeyIsValid(string key) => Regex.IsMatch(key, "^[a-zA-Z]*$");

        /// <summary>
        /// Replaces the text letter using the key letter.
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="keyLetter"></param>
        /// <returns></returns>
        protected char ReplaceLetter(char letter, char keyLetter)
        {
            int keyLetterPosition = Manipulator.GetLetterIndex(keyLetter, char.IsUpper(letter));
            char rotatedLetter = RotateLetter(letter, keyLetterPosition);

            return rotatedLetter;
        }

        /// <summary>
        /// Rotates the text letter using the key letter position (shift).
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        protected char RotateLetter(char letter, int shift)
        {
            bool isUpperLetter = char.IsUpper(letter);
            int letterIndex = Manipulator.GetLetterIndex(letter, isUpperLetter);
            int newIndex = letterIndex + shift;

            if (newIndex > 25) newIndex = newIndex - 25 - 1;

            return Manipulator.GetLetterByIndex(newIndex, isUpperLetter);
        }

        #endregion Encryption Auxiliar Methods

        #region Decryption Auxiliar Methods

        /// <summary>
        /// Replaces the text letter in the reverse direction using the key letter.
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="keyLetter"></param>
        /// <returns></returns>
        protected char ReplaceLetterReverse(char letter, char keyLetter)
        {
            int keyLetterPosition = Manipulator.GetLetterIndex(keyLetter, char.IsUpper(letter));
            char rotatedLetter = RotateLetterReverse(letter, keyLetterPosition);

            return rotatedLetter;
        }

        /// <summary>
        /// Rotates the text letter in the reverse direction using the key letter position (shift).
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="shift"></param>
        /// <returns></returns>
        protected char RotateLetterReverse(char letter, int shift)
        {
            bool isUpperLetter = char.IsUpper(letter);
            int letterIndex = Manipulator.GetLetterIndex(letter, isUpperLetter);
            int newIndex = letterIndex - shift;

            if (newIndex < 0) newIndex = 26 + newIndex;

            return Manipulator.GetLetterByIndex(newIndex, isUpperLetter);
        }

        #endregion Decryption Auxiliar Methods
    }
}
