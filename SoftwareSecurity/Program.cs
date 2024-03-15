using SoftwareSecurity.Cryptography.CaesarCipher;
using SoftwareSecurity.Cryptography.VigenereCipher;

namespace SoftwareSecurity
{
    class Program
    {
        public static void Main()
        {
            TestVigenereCipher();
            TestCaesarCipher();
        }

        public static void TestVigenereCipher()
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

        public static void TestCaesarCipher()
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
    }
}