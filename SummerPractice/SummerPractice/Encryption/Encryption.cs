using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SummerPractice.Encryption
{
    public static class Encryption
    {
        public static string GetHash(string plaintext)
        {
            var sha = new SHA1Managed();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(plaintext));
            return Convert.ToBase64String(hash);
        }
        public static bool CompareHash(string basePassword, string password)
        {
            var sha = new SHA1Managed();
            byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash) == basePassword;
        }
        
    }
}