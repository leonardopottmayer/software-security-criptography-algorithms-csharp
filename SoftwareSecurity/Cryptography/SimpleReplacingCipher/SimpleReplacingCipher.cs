using System.Text;

namespace SoftwareSecurity.Cryptography.SimpleReplacingCipher
{
    public class SimpleReplacingCipher
    {
        #region Constructors

        public SimpleReplacingCipher() { }

        #endregion Constructors

        #region Encryption And Decryption Methods

        /// <summary>
        /// Encrypts the given text using the given mapping. Replacing each character with its mapped value.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="mapping"></param>
        /// <returns></returns>
        public string Encrypt(string text, IDictionary<char, char> mapping)
        {
            ValidateMapping(mapping);

            string encryptedText = ReplaceCharWithMapping(text, mapping);
            return encryptedText;
        }

        /// <summary>
        /// Decrypts the given text using the given mapping. Replacing each character with its mapped value.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="mapping"></param>
        /// <returns></returns>
        public string Decrypt(string text, IDictionary<char, char> mapping)
        {
            ValidateMapping(mapping);

            string decryptedText = ReplaceCharWithMappingReverse(text, mapping);
            return decryptedText;
        }

        #endregion Encryption And Decryption Methods

        #region Helper Methods

        /// <summary>
        /// Replaces each character with its mapped value.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="mapping"></param>
        /// <returns></returns>
        protected string ReplaceCharWithMapping(string text, IDictionary<char, char> mapping)
        {
            var sb = new StringBuilder();

            foreach (char character in text.ToCharArray())
            {
                if (mapping.ContainsKey(character))
                {
                    char mappedValue = mapping[character];
                    sb.Append(mappedValue);
                }
                else
                {
                    sb.Append(character);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Reverses the mapping and replaces each character with its original value.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="mapping"></param>
        /// <returns></returns>
        protected string ReplaceCharWithMappingReverse(string text, IDictionary<char, char> mapping)
        {
            var sb = new StringBuilder();

            foreach (char character in text.ToCharArray())
            {
                if (MappingContainsValue(mapping, character, out char key))
                {
                    sb.Append(key);
                }
                else
                {
                    sb.Append(character);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Validates the given mapping, checking if there are more than one keys with the same value.
        /// </summary>
        /// <param name="mapping"></param>
        /// <exception cref="Exception"></exception>
        protected void ValidateMapping(IDictionary<char, char> mapping)
        {
            var valueCounts = new Dictionary<char, int>();

            foreach (var item in mapping)
            {
                if (valueCounts.ContainsKey(item.Value))
                {
                    valueCounts[item.Value]++;
                }
                else
                {
                    valueCounts[item.Value] = 1;
                }
            }

            foreach (var count in valueCounts)
            {
                if (count.Value > 1)
                {
                    throw new Exception($"There are more than one keys with the same value '{count.Key}'.");
                }
            }
        }

        /// <summary>
        /// Checks if the given mapping contains the given value, an returns the corresponding key.
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected bool MappingContainsValue(IDictionary<char, char> mapping, char value, out char key)
        {
            key = ' ';

            foreach (var item in mapping)
            {
                if (item.Value == value)
                {
                    key = item.Key;
                    return true;
                }
            }

            return false;
        }

        #endregion Helper Methods
    }
}
