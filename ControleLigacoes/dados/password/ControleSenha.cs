using System.Security.Cryptography;

namespace ControleLigacoes.dados.password
{
    public class ControleSenha
    {
        private static ControleSenha _instance;
        private HashAlgorithm _hashAlgorithm;

        private ControleSenha()
        {

        }

        public static ControleSenha Instance => _instance ?? (_instance = new ControleSenha());

        private int SaltLength => 64;
        private HashAlgorithm HashAlgorithm => _hashAlgorithm ?? (_hashAlgorithm = SHA512.Create());

        public bool ValidarSenhaAtual(string hashSalt,string hashDigest, string senhaInformada)
        {
            HashWithSaltResult hashWithSalt = new HashWithSaltResult(hashSalt, hashDigest);
            return ValidarSenhaAtual(hashWithSalt, senhaInformada);
            
        }

        public bool ValidarSenhaAtual(HashWithSaltResult hashWithSalt, string senhaInformada)
        {
            PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
            HashWithSaltResult hws = pwHasher.HashWithSalt(senhaInformada, hashWithSalt.Salt, HashAlgorithm);
            return hws.Digest.Equals(hashWithSalt.Digest);

        }

        public bool ValidarSenhas(string senhaInformada, string senhaConfirmacao)
        {
            return senhaInformada.Equals(senhaConfirmacao); 
        }

        public HashWithSaltResult GerarNovaSenha(string senhaInformada)
        {
            PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
            return pwHasher.HashWithSalt(senhaInformada, SaltLength, HashAlgorithm);
        }
        
    }
}


