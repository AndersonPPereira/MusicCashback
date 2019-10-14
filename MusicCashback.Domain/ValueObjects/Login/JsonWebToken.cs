namespace MusicCashback.Domain.ValueObjects
{
    public class JsonWebToken
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string ExpiresIn { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; } = "bearer";
        public string Message { get; set; }
    }
}
