﻿namespace BookStore.Core.Generic.Utils
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
        public double RefreshTokenDurationInMinutes { get; set; }
    }
}
