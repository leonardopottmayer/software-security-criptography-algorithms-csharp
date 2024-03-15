using SoftwareSecurity.Cryptography.VigenereCipher;

namespace SoftwareSecurity
{
    class Program
    {
        public static void Main()
        {
            TestVigenereCipher();
        }

        public static void TestVigenereCipher()
        {
            var vigenereCipher = new VigenereCipher();

            string textToEncrypt = "THEY DRINK 1/5 THE TEA";
            string encryptionKey = "DUH";

            string encryptResult = vigenereCipher.Encrypt(textToEncrypt, encryptionKey);
            string descryptResult = vigenereCipher.Decrypt(encryptResult, encryptionKey);
        }
    }
}