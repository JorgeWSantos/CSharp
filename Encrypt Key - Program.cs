using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Registry_Key_Encripted
{
    class Program
    {
        //hash usado para a criptografia
        private static string hash = "meuhash_&&$$";

        static void Main(string[] args)
        {
            //conferindo a existencia da key
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\SGP"))
            {
                //se a key NÂO existir é CRIADA.
                //caso EXISTA, NADA é ALTERADO.
                if (key == null)
                    EncryptKey();

            }
        }

        private static void EncryptKey()
        {
            //string que recebe a data criptografada
            string data_encrypt = String.Empty;

            //data_atual
            string data_atual = DateTime.Now.ToString().Substring(0, 10);

            //valor base
            byte[] encrypt_value = UTF8Encoding.UTF8.GetBytes(data_atual);

            //encrypt
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(encrypt_value, 0, encrypt_value.Length);
                    data_encrypt = Convert.ToBase64String(results, 0, results.Length);
                }
            }

            //criando key
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\SGP"))
            {
                //setando o value da 'key'
                key.SetValue("st", $"{data_encrypt}");
            }
        }
    }
}
