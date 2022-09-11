namespace Kodlama.io.Devs.Application.Features.Authentications.Dtos
{
    public class AccessTokenDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
