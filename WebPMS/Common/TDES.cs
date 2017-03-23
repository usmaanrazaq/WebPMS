using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebPMS
{
    public class TDES
    {
        private static byte[] key = { 11, 22, 33, 14, 45, 36, 17, 38, 59, 60, 31, 32, 63, 64, 35, 56, 37, 48, 39, 40, 21, 32, 43, 44 };
        private static byte[] iv = { 34, 12, 121, 201, 88, 16, 66, 20 };

        public TDES()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string SHA512_Unicode(string input)
        {
            var bytes = System.Text.Encoding.Unicode.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        public static string EncryptString(string plainText)
        {
            return Convert.ToBase64String(EncryptBytes(plainText));
        }

        public static byte[] EncryptBytes(string plainText)
        {
            if (plainText.Length == 0)
            {
                return null;
            }

            //Declare a UTF8Encoding object so we may use the GetByte 
            //method to transform the plainText into a Byte array. 
            UTF8Encoding utf8encoder = new UTF8Encoding();
            byte[] inputInBytes = utf8encoder.GetBytes(plainText);

            // Create a new TripleDES service provider 
            TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();

            // The ICryptTransform interface uses the TripleDES 
            // crypt provider along with encryption key and init vector 
            // information 
            ICryptoTransform cryptoTransform = tdesProvider.CreateEncryptor(key, iv);

            // All cryptographic functions need a stream to output the 
            // encrypted information. Here we declare a memory stream 
            // for this purpose. 
            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);

            // Write the encrypted information to the stream. Flush the information 
            // when done to ensure everything is out of the buffer. 
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
            cryptStream.FlushFinalBlock();
            encryptedStream.Position = 0;

            // Read the stream back into a Byte array and return it to the calling 
            // method. 
            byte[] result = new byte[encryptedStream.Length];
            encryptedStream.Read(result, 0, (int)encryptedStream.Length);
            cryptStream.Close();

            return result;

        }

        public static string DecryptString(string inputString)
        {
            return DecryptBytes(Convert.FromBase64String(inputString));
        }


        public static string DecryptBytes(byte[] inputInBytes)
        {
            if (inputInBytes.Length == 0)
            {
                return null;
            }

            // UTFEncoding is used to transform the decrypted Byte Array 
            // information back into a string. 
            UTF8Encoding utf8encoder = new UTF8Encoding();
            TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();

            // As before we must provide the encryption/decryption key along with 
            // the init vector. 
            ICryptoTransform cryptoTransform = tdesProvider.CreateDecryptor(key, iv);

            // Provide a memory stream to decrypt information into 
            MemoryStream decryptedStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write);
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
            cryptStream.FlushFinalBlock();
            decryptedStream.Position = 0;

            // Read the memory stream and convert it back into a string 
            Byte[] result = new byte[decryptedStream.Length];
            decryptedStream.Read(result, 0, (int)decryptedStream.Length);
            cryptStream.Close();
            UTF8Encoding myutf = new UTF8Encoding();
            return myutf.GetString(result);

        }

        //Don't use anymore 
        private string EncodeDecode(string pString, bool pEncrypt, bool pFormatASCCodes)
        {

            string pStr = "String.SubString(i,1)";
            string result = "";
            int pStrCnt = 0;
            char charCode = ' ';
            int temp = 0;
            string string2 = "";


            if (!pEncrypt & pFormatASCCodes)
            {
                while (true)
                {
                    if (pString.Length == 0)
                    {
                        pString = string2;
                        break;
                    }
                    temp = Convert.ToInt16(pString.Substring(0, pString.IndexOf(":", 0)));
                    string2 += (char)temp;
                    pString = pString.Remove(0, pString.IndexOf(":", 0) + 1);

                }
            }

            for (int i = 0; i <= pString.Length - 1; i++)
            {
                if (pEncrypt)
                {
                    charCode = Convert.ToChar(pString.Substring(i, 1));
                    temp = charCode;
                    charCode = Convert.ToChar(pStr.Substring(pStrCnt, 1));
                    temp += charCode + i + pStrCnt;
                    if (temp > 245)
                    {
                        temp -= 245;
                    }
                    charCode = (char)temp;
                    if (pFormatASCCodes)
                    {
                        result += temp.ToString() + ":";

                    }
                    else
                    {
                        result += charCode.ToString();
                    }
                }
                else
                {
                    charCode = Convert.ToChar(pString.Substring(i, 1));
                    temp = charCode;
                    charCode = Convert.ToChar(pStr.Substring(pStrCnt, 1));
                    temp -= charCode;
                    temp -= i;
                    temp -= pStrCnt;
                    if (temp < 0)
                    {
                        temp += 245;
                    }
                    charCode = (char)temp;
                    result += charCode.ToString();

                }




                pStrCnt += 1;
                if (pStrCnt == pStr.Length)
                {
                    pStrCnt = 1;
                }

            }

            return result;

        }
    }
}