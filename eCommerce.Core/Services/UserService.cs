using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        ApplicationUser? user = await _userRepository.GetUserByEmailAndPassword(request.Email, request.Password);

        if (user == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {
        ApplicationUser user = _mapper.Map<ApplicationUser>(request);
        
        ApplicationUser? response =  await _userRepository.AddUser(user);

        if (response == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(response) with { Success = true, Token = "token" };
    }
}