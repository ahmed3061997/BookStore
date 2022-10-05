using System.Text.Json.Serialization;

namespace BookStore.Core.Generic.Dto
{
    public class JwtToken
    {
        public string Token { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        [JsonIgnore]
        public DateTime RefreshTokenExpiresOn { get; set; }
    }
}
