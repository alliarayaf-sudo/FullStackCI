namespace FullStackCI.Dtos
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string Username { get; set; }
    }
}
