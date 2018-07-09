namespace ControleLigacoes.dados.password
{
    public class HashWithSaltResult
    {
        public string Salt { get; set; }
        public string Digest { get; set; }

        public HashWithSaltResult(string salt, string digest)
        {
            Salt = salt;
            Digest = digest;
        }
    }
}
