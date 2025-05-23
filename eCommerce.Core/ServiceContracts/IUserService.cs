using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

public interface IUserService
{
    Task<AuthenticationResponse?> Login(LoginRequest request);
    Task<AuthenticationResponse?> Register(RegisterRequest request);
}