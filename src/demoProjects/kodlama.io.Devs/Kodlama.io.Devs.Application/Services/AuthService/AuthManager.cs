using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Services.AuthService;

public class AuthManager : IAuthService
{
    private readonly IUserOperationClaimRepository _userOperationClaimRepository;
    private readonly ITokenHelper _tokenHelper;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, ITokenHelper tokenHelper,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _userOperationClaimRepository = userOperationClaimRepository;
        _tokenHelper = tokenHelper;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
        return addedRefreshToken;
    }

    public async Task<AccessToken> CreateAccessToken(User user)
    {
        IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository
            .GetListAsync(u => u.UserId == user.Id, include: u => u.Include(u => u.OperationClaim));
        IList<OperationClaim> operationClaims = userOperationClaims.Items
            .Select(u => new OperationClaim { Id = u.OperationClaimId, Name = u.OperationClaim.Name }).ToList();

        AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
        return accessToken;
    }

    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
        return Task.FromResult(refreshToken);
    }

    public async Task<RefreshToken> GetByIpAddressRefreshToken(string ipAddress)
    {
        RefreshToken refreshToken = await _refreshTokenRepository
            .GetAsync(r => r.CreatedByIp == ipAddress, include: r => r.Include(c => c.User));
        return refreshToken;
    }

    public async Task<RefreshToken> UpdateRefreshToken(RefreshToken refreshToken)
    {
        RefreshToken newRefreshToken = await CreateRefreshToken(refreshToken.User, refreshToken.CreatedByIp);
        refreshToken.Token = newRefreshToken.Token;
        refreshToken.Created = newRefreshToken.Created;
        refreshToken.Expires = newRefreshToken.Expires;

        RefreshToken updatedRefreshToken = await _refreshTokenRepository.UpdateAsync(refreshToken);
        return updatedRefreshToken;
    }
}