using System;
using System.Security.Cryptography;

using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace DashBoardAPI.Services
{
    public static class Crypto
    {
        /// <summary>
        /// genere le sel ! 
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateSalt()
        {

            byte[] salt = new byte[128/8];

            using(RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            

            return  salt;
        }
        /// <summary>
        /// ash le mdp 
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string AshPassword(byte[] salt , string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password:password,
                salt:salt,
                prf:KeyDerivationPrf.HMACSHA512,
                iterationCount:100000,
                numBytesRequested:512/8
                ));

            return hashed;
        }

    }
}
