using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Decrypt_Registry_Key
{
    public class Program
    {
        static void Main(string[] args)
        {
            //hash
            string hash = "&eg0s@so%%luçõ&s&*";

            string data_decrypt = String.Empty;

            //abrindo a key
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\SGP"))
            {
                //se a key existir
                if (key != null)
                {
                    //pega o value da key
                    string key_value = key.GetValue("st").ToString();

                    //caso o value esteja vazio
                    //significa que o usuário tentou alterar o valor
                    if (String.IsNullOrEmpty(key_value))
                        MessageBox.Show("Sua licença expirou, entre em contato com a EGOS-TI\n para obter uma versão atualizada.", 
                                        "", MessageBoxButtons.OK, 
                                        MessageBoxIcon.Information);

                    try
                    {
                        //valor base
                        byte[] decrypt_value = Convert.FromBase64String(key_value);

                        //encrypt
                        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                        {
                            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                            using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                            {
                                ICryptoTransform transform = tripDes.CreateDecryptor();
                                byte[] results = transform.TransformFinalBlock(decrypt_value, 0, decrypt_value.Length);
                                data_decrypt = UTF8Encoding.UTF8.GetString(results);
                            }
                        }

                        DateTime data_expirar = Convert.ToDateTime(data_decrypt);//tenta converter os dados extraídos da regkey,
                                                                                 //caso não converta é porque o usuário tentou alterar o hash_value da key.

                        DateTime dt = Convert.ToDateTime("09/08/2019");

                        //caso a data de registro da key for maior que 7 dias.
                        if (data_expirar.AddDays(7) < dt)
                            MessageBox.Show("Sua licença expirou, entre em contato com a EGOS-TI\n para obter uma versão atualizada.",
                                            "", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                        //caso a data não tenha expirado
                        //executa o programa.
                        else
                        {
                            //executa o programa
                        }
                    }
                    catch (FormatException)//caso a data seja alterada, o formato decriptado ira vir em formato errado.
                    {
                        Registry.LocalMachine.DeleteSubKey(@"SOFTWARE\SGP");//deleta a subkey

                        MessageBox.Show("Sua licença expirou, entre em contato com a EGOS-TI\n para obter uma versão atualizada.", 
                                        "", MessageBoxButtons.OK, 
                                        MessageBoxIcon.Information);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message, 
                                        "", 
                                        MessageBoxButtons.OK, 
                                        MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
