namespace SoftwareSecurity.Cryptography.RailFenceCipher
{
    public class RailFenceCipher
    {
        public RailFenceCipher() { }

        public string Encrypt(string text, int key)
        {
            text = text.Replace(" ", "");

            char[,] rail = new char[key, text.Length];

            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    rail[i, j] = '\n';
                }
            }

            bool dirDown = false;
            int row = 0, col = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (row == 0 || row == key - 1)
                {
                    dirDown = !dirDown;
                }

                rail[row, col++] = text[i];

                if (dirDown)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            string result = "";
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    if (rail[i, j] != '\n')
                    {
                        result += rail[i, j];
                    }
                }
            }

            return result;
        }

        public string Decrypt(string cipher, int key)
        {
            char[,] rail = new char[key, cipher.Length];

            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < cipher.Length; j++)
                {
                    rail[i, j] = '\n';
                }
            }

            bool dirDown = true;
            int row = 0, col = 0;

            for (int i = 0; i < cipher.Length; i++)
            {
                if (row == 0)
                {
                    dirDown = true;
                }
                if (row == key - 1)
                {
                    dirDown = false;
                }

                rail[row, col++] = '*';

                if (dirDown)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            int index = 0;
            for (int i = 0; i < key; i++)
            {
                for (int j = 0; j < cipher.Length; j++)
                {
                    if (rail[i, j] == '*' && index < cipher.Length)
                    {
                        rail[i, j] = cipher[index++];
                    }
                }
            }

            string result = "";
            row = 0;
            col = 0;
            for (int i = 0; i < cipher.Length; i++)
            {
                if (row == 0)
                {
                    dirDown = true;
                }
                if (row == key - 1)
                {
                    dirDown = false;
                }

                if (rail[row, col] != '*')
                {
                    result += rail[row, col++];
                }

                if (dirDown)
                {
                    row++;
                }
                else
                {
                    row--;
                }
            }

            return result;
        }
    }
}