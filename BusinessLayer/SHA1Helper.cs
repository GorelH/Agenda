using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer
{
    public static class SHA1Helper
    {
        /// <summary>
        /// Hash la chaine en SHA1
        /// </summary>
        /// <param name="data">Chaine non hashée</param>
        /// <returns>Chaine hashée</returns>
        public static string HashData(string data)
        {
            SHA1 sha1 = SHA1.Create();
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashData.Length; ++i)
            {
                sb.Append(hashData[i].ToString());
            }

            return sb.ToString();
        }
    }
}
