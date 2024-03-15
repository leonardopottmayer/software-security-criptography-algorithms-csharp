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
            var vigenereCipher = new VigenereCipher();

            string textToEncrypt = "THEY DRINK 1/5 THE TEA";
            string encryptionKey = "DUH";

            string encryptResult = vigenereCipher.Encrypt(textToEncrypt, encryptionKey);
            string descryptResult = vigenereCipher.Decrypt(encryptResult, encryptionKey);
        }

        public static void TestCaesarCipher()
        {
            var caesarCipher = new CaesarCipher();

            string textToEncrypt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%¨&*()-_=+{[}]\\|;:'\",<.>/?";

            string encryptResult = caesarCipher.Encrypt(textToEncrypt);
            string decryptResult = caesarCipher.Decrypt(encryptResult);
        }
    }
}