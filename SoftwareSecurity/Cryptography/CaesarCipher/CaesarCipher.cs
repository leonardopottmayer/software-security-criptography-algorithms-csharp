using System.Globalization;
using System.Text;

namespace SoftwareSecurity.Cryptography.CaesarCipher
{
    public class CaesarCipher
    {
        #region Attributes

        protected List<char> LowerLetters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        protected List<char> UpperLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

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
            bool isLetterUpper = char.IsUpper(letter);
            int letterIndex = GetLetterIndex(letter, isLetterUpper);
            int newIndex = (letterIndex + defaultShift) % 26;

            return isLetterUpper ? UpperLetters[newIndex] : LowerLetters[newIndex];
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
            bool isLetterUpper = char.IsUpper(letter);
            int letterIndex = GetLetterIndex(letter, isLetterUpper);
            int newIndex = (letterIndex - defaultShift + 26) % 26;

            return isLetterUpper ? UpperLetters[newIndex] : LowerLetters[newIndex];
        }

        #endregion Decryption Auxiliar Methods

        #region General Auxiliar Methods

        /// <summary>
        /// Removes accents from the text.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected string RemoveAccents(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Gets the index of the letter in the list of letters.
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="isUpper"></param>
        /// <returns></returns>
        protected int GetLetterIndex(char letter, bool isUpper = false)
        {
            return isUpper ? UpperLetters.IndexOf(letter) : LowerLetters.IndexOf(letter);
        }

        #endregion General Auxiliar Methods
    }
}