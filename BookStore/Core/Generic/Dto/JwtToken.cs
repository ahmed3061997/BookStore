namespace BookStore.Core.Generic.Dto
{
    public class JwtToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
