using System;
using System.Security.Cryptography;
using System.Text;

namespace Bico.Domain.Services.Ecryption
{
    public static class EncryptionService
    {
        public static string PasswordEcryption(string password)
        {
            int salt = 12;
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);


            return passwordHash;
        }
    }
}
