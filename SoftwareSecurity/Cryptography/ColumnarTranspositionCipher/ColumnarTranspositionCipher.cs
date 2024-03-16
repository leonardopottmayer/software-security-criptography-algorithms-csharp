using System.Text;

namespace SoftwareSecurity.Cryptography.ColumnarTranspositionCipher
{
    public class ColumnarTranspositionCipher
    {
        #region Constants

        protected const string DEFAULT_FILLING_CHARACTER = "\n";

        #endregion Constants

        #region Constructors

        public ColumnarTranspositionCipher() { }

        #endregion Constructors

        #region Encryption And Decryption Methods

        /// <summary>
        /// Encrypts the text using a specified amount of columns.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="amountOfColumns"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string Encrypt(string text, int amountOfColumns)
        {
            if (!AmountOfColumnsIsValid(text, amountOfColumns)) throw new ArgumentException("Invalid amount of columns.");

            var matrix = ConvertTextToMatrix(text, amountOfColumns);
            string encryptedText = ConvertMatrixToEncryptedText(matrix);

            return encryptedText;
        }

        /// <summary>
        /// Decrypts the text using a specified amount of columns.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="amountOfColumns"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string Decrypt(string text, int amountOfColumns)
        {
            if (!AmountOfColumnsIsValid(text, amountOfColumns)) throw new ArgumentException("Invalid amount of columns.");

            var matrix = ConvertEncryptedTextToMatrix(text, amountOfColumns);
            string decryptedText = ConvertMatrixToText(matrix);

            return decryptedText;
        }

        #endregion Encryption And Decryption Methods

        #region Encryption Auxiliar Methods

        /// <summary>
        /// Converts the original text to a matrix, with the specified amount of columns and a calculated amount of lines.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="amountOfColumns"></param>
        /// <returns></returns>
        protected string[,] ConvertTextToMatrix(string text, int amountOfColumns)
        {
            int characterCounter = 0;

            int amountOfLines = GetAmountOfLines(text, amountOfColumns);
            var matrix = new string[amountOfLines, amountOfColumns];

            for (int line = 0; line < amountOfLines; line++)
            {
                for (int col = 0; col < amountOfColumns; col++)
                {
                    if (characterCounter >= text.Length)
                    {
                        matrix[line, col] = DEFAULT_FILLING_CHARACTER;
                        continue;
                    }

                    string currentCharacter = Convert.ToString(text[characterCounter]);

                    matrix[line, col] = currentCharacter;
                    characterCounter++;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Generates the encrypted text reading the matrix elements in an diferent order.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        protected string ConvertMatrixToEncryptedText(string[,] matrix)
        {
            var sb = new StringBuilder();

            int colLength = matrix.GetLength(1);
            int lineLength = matrix.GetLength(0);

            for (int col = 0; col < colLength; col++)
            {
                for (int line = 0; line < lineLength; line++)
                {
                    string currentCharacter = matrix[line, col];
                    sb.Append(currentCharacter);
                }
            }

            return sb.ToString();
        }

        #endregion Encryption Auxiliar Methods

        #region Decryption Auxiliar Methods

        /// <summary>
        /// Converts the encrypted text to a matrix, with the specified amount of columns and a calculated amount of lines.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="amountOfColumns"></param>
        /// <returns></returns>
        protected string[,] ConvertEncryptedTextToMatrix(string text, int amountOfColumns)
        {
            int amountOfLines = GetAmountOfLines(text, amountOfColumns);
            var matrix = new string[amountOfLines, amountOfColumns];

            int colLength = matrix.GetLength(1);
            int lineLength = matrix.GetLength(0);

            int characterCounter = 0;

            for (int col = 0; col < colLength; col++)
            {
                for (int line = 0; line < lineLength; line++)
                {
                    string currentCharacter = Convert.ToString(text[characterCounter]);

                    matrix[line, col] = currentCharacter;
                    characterCounter++;
                }
            }

            return matrix;
        }

        /// <summary>
        /// Generates the original text reading the matrix elements in the correct order.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        protected string ConvertMatrixToText(string[,] matrix)
        {
            var sb = new StringBuilder();

            int colLength = matrix.GetLength(1);
            int lineLength = matrix.GetLength(0);

            for (int line = 0; line < lineLength; line++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    string currentCharacter = matrix[line, col];
                    if (currentCharacter != DEFAULT_FILLING_CHARACTER)
                    {
                        sb.Append(currentCharacter);
                    }
                }
            }

            return sb.ToString();
        }

        #endregion Decryption Auxiliar Methods

        #region Misc Auxiliar Methods

        /// <summary>
        /// Checks if the amount of columns is valid. It can't be greater than the length of the text and must be greater than 1.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="amountOfColumns"></param>
        /// <returns></returns>
        protected bool AmountOfColumnsIsValid(string text, int amountOfColumns) => amountOfColumns <= text.Length && amountOfColumns > 1;

        /// <summary>
        /// Calculates the amount of lines based on the text length and the amount of columns.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="amountOfColumns"></param>
        /// <returns></returns>
        protected int GetAmountOfLines(string text, int amountOfColumns) => (int)Math.Ceiling((decimal)text.Length / amountOfColumns);

        #endregion Misc Auxiliar Methods
    }
}
