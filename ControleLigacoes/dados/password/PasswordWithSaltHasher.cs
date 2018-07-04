using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ControleLigacoes.dados.password
{
    class PasswordWithSaltHasher
    {
        public HashWithSaltResult HashWithSalt(string password, int saltLength, HashAlgorithm hashAlgo)
        {
            RNG rng = new RNG();
            byte[] saltBytes = rng.GenerateRandomCryptographicBytes(saltLength);
            return HashWithSalt(password, saltBytes, hashAlgo );
        }

        public HashWithSaltResult HashWithSalt(string password, string salt, HashAlgorithm hashAlgo)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
            return HashWithSalt(password, saltBytes, hashAlgo);
        }

        private HashWithSaltResult HashWithSalt(string password, byte[] saltBytes, HashAlgorithm hashAlgo)
        {
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);
            byte[] digestBytes = hashAlgo.ComputeHash(passwordWithSaltBytes.ToArray());
            return new HashWithSaltResult(Convert.ToBase64String(saltBytes), Convert.ToBase64String(digestBytes));

        }
    }
}
