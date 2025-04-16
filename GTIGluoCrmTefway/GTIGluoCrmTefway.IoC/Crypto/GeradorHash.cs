using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.IoC.Crypto
{
    using System.Security.Cryptography;
    using System.Text;

    namespace HashGenerator
    {
        public static class GeradorHash
        {
            /// <summary>
            /// Concatena duas strings, gera um hash MD5 e retorna o hash.
            /// </summary>
            /// <param name="str1">Primeira string</param>
            /// <param name="str2">Segunda string</param>
            /// <returns>Hash MD5 da concatenação das duas strings</returns>
            public static string GenerateMD5Hash(string str1, string str2)
            {
                // Concatenar as duas strings
                string concatenatedString = str1 + str2;

                // Gerar o hash MD5 a partir da string concatenada
                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.UTF8.GetBytes(concatenatedString);
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    // Converter os bytes do hash para uma string hexadecimal
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("x2"));
                    }

                    return sb.ToString();
                }
            }
        }
    }
}
