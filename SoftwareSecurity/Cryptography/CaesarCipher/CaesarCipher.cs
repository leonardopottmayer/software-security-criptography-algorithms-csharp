using SoftwareSecurity.Cryptography.Utils;
using System.Text;

namespace SoftwareSecurity.Cryptography.CaesarCipher
{
    public class CaesarCipher
    {
        #region Attributes

        protected CharacterManipulator Manipulator = new CharacterManipulator();

        #endregion Attributes

        #region Constructors

        public CaesarCipher() { }

        #endregion Constructors

        #region Encryption And Decryption Methods

        /// <summary>
        /// Encrypts the text using the default Caesas Cipher shift value of 3.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            var sb = new StringBuilder();

            foreach (char textCharacter in text.ToCharArray())
            {
                char characterToAppend = textCharacter;

                if (char.IsLetter(textCharacter))
                {
                    characterToAppend = RotateLetter(textCharacter);
                }

                sb.Append(characterToAppend);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Decrypts the text using the default Caesas Cipher shift value of 3.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Decrypt(string text)
        {
            var sb = new StringBuilder();

            foreach (char textCharacter in text.ToCharArray())
            {
                char characterToAppend = textCharacter;

                if (char.IsLetter(textCharacter))
                {
                    characterToAppend = RotateLetterReverse(textCharacter);
                }

                sb.Append(characterToAppend);
            }

            return sb.ToString();
        }

        #endregion Encryption And Decryption Methods

        #region Encryption Auxiliar Methods

        /// <summary>
        /// Rotates the text letter using the default Caesas Cipher shift value of 3.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        protected char RotateLetter(char letter)
        {
            int defaultShift = 3;
            bool isUpperLetter = char.IsUpper(letter);
            int letterIndex = Manipulator.GetLetterIndex(letter, isUpperLetter);
            int newIndex = (letterIndex + defaultShift) % 26;

            return Manipulator.GetLetterByIndex(newIndex, isUpperLetter);
        }

        #endregion Encryption Auxiliar Methods

        #region Decryption Auxiliar Methods

        /// <summary>
        /// Rotates the text letter in the reverse direction using the default Caesas Cipher shift value of 3.
        /// </summary>
        /// <param name="letter"></param>
        /// <returns></returns>
        protected char RotateLetterReverse(char letter)
        {
            int defaultShift = 3;
            bool isUpperLetter = char.IsUpper(letter);
            int letterIndex = Manipulator.GetLetterIndex(letter, isUpperLetter);
            int newIndex = (letterIndex - defaultShift + 26) % 26;

            return Manipulator.GetLetterByIndex(newIndex, isUpperLetter);
        }

        #endregion Decryption Auxiliar Methods
    }
}