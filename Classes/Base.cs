﻿using System.Security.Cryptography;
using System.Text;

namespace SportsGrounds.Classes
{
    static public class Base
    {
        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
    }
}
