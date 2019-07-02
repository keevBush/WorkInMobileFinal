using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WorkInMobileFinal.Extensions
{
    public static class PasswordSecurityExtension
    {
        public static string HashPassword(this string password)
        {

            byte[] salt = new byte[16];
            var h = new Rfc2898DeriveBytes(password, salt, 10000);
            var hashingBytes = h.GetBytes(20);

            return Convert.ToBase64String(hashingBytes);
        }
    }
}
