using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace WebAssetsTransfer.Functions
{
    public class cls_encriptacion
    {
        public static class DESEncryption
        {
            private static byte[] key = new byte[0];
            private static byte[] IV = new byte[]
			{
				38,
				55,
				206,
				48,
				28,
				64,
				20,
				16
			};
            private static string sKey = "!5663a#N";
            public static string EncryptString(string text)
            {
                string result;
                try
                {
                    cls_encriptacion.DESEncryption.key = System.Text.Encoding.UTF8.GetBytes(cls_encriptacion.DESEncryption.sKey.Substring(0, 8));
                    System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(text);
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                    System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, des.CreateEncryptor(cls_encriptacion.DESEncryption.key, cls_encriptacion.DESEncryption.IV), System.Security.Cryptography.CryptoStreamMode.Write);
                    cryptoStream.Write(byteArray, 0, byteArray.Length);
                    cryptoStream.FlushFinalBlock();
                    result = System.Convert.ToBase64String(memoryStream.ToArray());
                    return result;
                }
                catch (System.Exception)
                {
                }
                result = string.Empty;
                return result;
            }
            public static string DecryptString(string text)
            {
                string result;
                try
                {
                    cls_encriptacion.DESEncryption.key = System.Text.Encoding.UTF8.GetBytes(cls_encriptacion.DESEncryption.sKey.Substring(0, 8));
                    System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
                    byte[] byteArray = System.Convert.FromBase64String(text);
                    System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
                    System.Security.Cryptography.CryptoStream cryptoStream = new System.Security.Cryptography.CryptoStream(memoryStream, des.CreateDecryptor(cls_encriptacion.DESEncryption.key, cls_encriptacion.DESEncryption.IV), System.Security.Cryptography.CryptoStreamMode.Write);
                    cryptoStream.Write(byteArray, 0, byteArray.Length);
                    cryptoStream.FlushFinalBlock();
                    result = System.Text.Encoding.UTF8.GetString(memoryStream.ToArray());
                    return result;
                }
                catch (System.Exception)
                {
                }
                result = string.Empty;
                return result;
            }
        }
    }
}
