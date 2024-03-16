using SoftwareSecurity.Cryptography.CaesarCipher;
using SoftwareSecurity.Cryptography.ColumnarTranspositionCipher;
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
    }
}