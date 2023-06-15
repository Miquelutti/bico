using System;
using System.Security.Cryptography;
using System.Text;

namespace Bico.Domain.Services.Ecryption
{
    public static class EncryptionService
    {
        public static string PasswordEcryption(string password)
        {
            string hashedPassword;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
                hashedPassword = Convert.ToBase64String(hashedBytes);
            }

            return hashedPassword;
        }
    }
}
