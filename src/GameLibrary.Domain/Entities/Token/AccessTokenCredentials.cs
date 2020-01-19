namespace GameLibrary.Domain.Entities.Token
{
    public class AccessTokenCredentials
    {
        public string CPF { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string GrantType { get; set; }
    }
}
