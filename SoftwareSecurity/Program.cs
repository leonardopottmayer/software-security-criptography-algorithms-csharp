using SoftwareSecurity.Cryptography.CaesarCipher;
using SoftwareSecurity.Cryptography.ColumnarTranspositionCipher;
using SoftwareSecurity.Cryptography.LinearTranspositionCipher;
using SoftwareSecurity.Cryptography.RailFenceCipher;
using SoftwareSecurity.Cryptography.SimpleReplacingCipher;
using SoftwareSecurity.Cryptography.VigenereCipher;

namespace SoftwareSecurity
{
    class Program
    {
        public static void Main()
        {
            ExecuteVigenereCipher();
            ExecuteCaesarCipher();
            ExecuteColumnarTranspositionCipher();
            ExecuteLinearTranspositionCipher();
            ExecuteSimpleReplacingCipher();
            ExecuteRailFenceCipher();
        }

        public static void ExecuteVigenereCipher()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Executing {nameof(VigenereCipher)}");
            Console.WriteLine("--------------------------------------------------");

            var vigenereCipher = new VigenereCipher();

            string textToEncrypt = "THEY DRINK 1/5 THE TEA";
            string encryptionKey = "DUH";

            Console.WriteLine($"Text to be encrypted: {textToEncrypt}");
            Console.WriteLine($"Encryption key: {encryptionKey}");

            string encryptResult = vigenereCipher.Encrypt(textToEncrypt, encryptionKey);
            string decryptResult = vigenereCipher.Decrypt(encryptResult, encryptionKey);

            Console.WriteLine($"Encrypted text: {encryptResult}");
            Console.WriteLine($"Decrypted text: {decryptResult}");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        public static void ExecuteCaesarCipher()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Executing {nameof(CaesarCipher)}");
            Console.WriteLine("--------------------------------------------------");

            var caesarCipher = new CaesarCipher();

            string textToEncrypt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%¨&*()-_=+{[}]\\|;:'\",<.>/?";

            Console.WriteLine($"Text to be encrypted: {textToEncrypt}");

            string encryptResult = caesarCipher.Encrypt(textToEncrypt);
            string decryptResult = caesarCipher.Decrypt(encryptResult);

            Console.WriteLine($"Encrypted text: {encryptResult}");
            Console.WriteLine($"Decrypted text: {decryptResult}");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        public static void ExecuteColumnarTranspositionCipher()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Executing {nameof(ColumnarTranspositionCipher)}");
            Console.WriteLine("--------------------------------------------------");

            var columnarTranspositionCipher = new ColumnarTranspositionCipher();

            int amountOfColumns = 7;
            string textToEncrypt = "VAMOS ATACAR O SUL NO FINAL DESTA SEMANA";

            Console.WriteLine($"Text to be encrypted: {textToEncrypt}");

            string encryptResult = columnarTranspositionCipher.Encrypt(textToEncrypt, amountOfColumns);
            string decryptResult = columnarTranspositionCipher.Decrypt(encryptResult, amountOfColumns);

            Console.WriteLine($"Encrypted text: {encryptResult}");
            Console.WriteLine($"Decrypted text: {decryptResult}");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        public static void ExecuteLinearTranspositionCipher()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Executing {nameof(LinearTranspositionCipher)}");
            Console.WriteLine("--------------------------------------------------");

            var linearTranspositionCipher = new LinearTranspositionCipher();

            int amountOfColumns = 7;
            string textToEncrypt = "VAMOS ATACAR O SUL NO FINAL DESTA SEMANA";

            Console.WriteLine($"Text to be encrypted: {textToEncrypt}");

            string encryptResult = linearTranspositionCipher.Encrypt(textToEncrypt, amountOfColumns);
            string decryptResult = linearTranspositionCipher.Decrypt(encryptResult, amountOfColumns);

            Console.WriteLine($"Encrypted text: {encryptResult}");
            Console.WriteLine($"Decrypted text: {decryptResult}");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        public static void ExecuteSimpleReplacingCipher()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Executing {nameof(SimpleReplacingCipher)}");
            Console.WriteLine("--------------------------------------------------");

            var simpleReplacing = new SimpleReplacingCipher();

            string textToEncrypt = "VAMOS ATACAR O SUL NO FINAL DESTA SEMANA";

            Console.WriteLine($"Text to be encrypted: {textToEncrypt}");

            IDictionary<char, char> mapping = new Dictionary<char, char>()
            {
                {' ', ' '},
                {'V', 'A'},
                {'A', 'M'},
                {'M', 'O'},
                {'O', 'S'},
                {'S', 'T'},
                {'T', 'C'},
                {'C', 'R'},
                {'R', 'U'},
                {'U', 'L'},
                {'L', 'N'},
                {'N', 'F'},
                {'F', 'I'},
                {'I', 'D'},
                {'D', 'E'},
                {'E', 'Y'},
            };

            string encryptResult = simpleReplacing.Encrypt(textToEncrypt, mapping);

            // If we change the mapping, it becomes impossible to recover the original text
            //mapping = new Dictionary<char, char>()
            //{
            //    {' ', ' '},
            //    {'O', 'A'},
            //    {'N', 'B'},
            //    {'M', 'C'},
            //    {'L', 'D'},
            //    {'K', 'E'},
            //    {'J', 'F'},
            //    {'I', 'G'},
            //    {'H', 'H'},
            //    {'G', 'I'},
            //    {'F', 'J'},
            //    {'E', 'K'},
            //    {'D', 'L'},
            //    {'C', 'M'},
            //    {'B', 'N'},
            //    {'A', 'O'},
            //};

            string decryptResult = simpleReplacing.Decrypt(encryptResult, mapping);

            Console.WriteLine($"Encrypted text: {encryptResult}");
            Console.WriteLine($"Decrypted text: {decryptResult}");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }

        public static void ExecuteRailFenceCipher()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Executing {nameof(RailFenceCipher)}");
            Console.WriteLine("--------------------------------------------------");

            var railFenceCipher = new RailFenceCipher();

            int amountOfRails = 7;
            string textToEncrypt = "VAMOS ATACAR O SUL AMANHA";

            Console.WriteLine($"Text to be encrypted: {textToEncrypt}");

            string encryptResult = railFenceCipher.Encrypt(textToEncrypt, amountOfRails);
            string decryptResult = railFenceCipher.Decrypt(encryptResult, amountOfRails);

            Console.WriteLine($"Encrypted text: {encryptResult}");
            Console.WriteLine($"Decrypted text: {decryptResult}");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine();
        }
    }
}