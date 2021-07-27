using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Hashing
{
    public class Cryptology
    {
        public static string Encryption(string text)
        {
            char[] x = text.ToCharArray();
            string encryptedText = null;
            foreach (var item in x)
            {
                encryptedText += Convert.ToChar(item + 3);
            }
            return encryptedText;
        }
        public static string Decryption(string text)
        {
            char[] x = text.ToCharArray();
            string decryptedText = null;
            foreach (var item in x)
            {
                decryptedText += Convert.ToChar(item - 3);
            }
            return decryptedText;
        }
    }
}
