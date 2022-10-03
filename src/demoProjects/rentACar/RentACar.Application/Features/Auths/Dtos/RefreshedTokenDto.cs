using Core.Security.Entities;
using Core.Security.JWT;

namespace RentACar.Application.Features.Auths.Dtos;

public class RefreshedTokenDto
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }
}