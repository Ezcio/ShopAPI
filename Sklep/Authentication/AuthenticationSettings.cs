namespace Sklep.Authentication
{
    public class AuthenticationSettings
    {
        public string JwkKey { get; set; }  
        public int JwkExpireDays { get; set; }
        public string JwkIssuer { get; set; }
    }
}
