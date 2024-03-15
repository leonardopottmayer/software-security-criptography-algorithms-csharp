using System.Globalization;
using System.Text;

namespace SoftwareSecurity.Cryptography.Utils
{
    public class CharacterManipulator
    {
        #region Attributes

        protected List<char> LowerLetters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        protected List<char> UpperLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        #endregion Attributes

        #region Constructors

        public CharacterManipulator() { }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Removes accents from the text.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string RemoveAccents(string input)
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
        public int GetLetterIndex(char letter, bool isUpper = false)
        {
            return isUpper ? UpperLetters.IndexOf(letter) : LowerLetters.IndexOf(letter);
        }

        /// <summary>
        /// Returns a specific lower or upper letter by its index in the alphabet.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="isUpper"></param>
        /// <returns></returns>
        public char GetLetterByIndex(int index, bool isUpper = false)
        {
            if (index < 0 || index > 25) throw new ArgumentOutOfRangeException(nameof(index));

            return isUpper ? UpperLetters[index] : LowerLetters[index];
        }

        #endregion Methods
    }
}
