using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Users.Common.Authorization;
using UltraGroupHotels.Domain.Users;

namespace UltraGroupHotels.Application.Users.Login;

public sealed class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ErrorOr<LoginUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IHashingService _hashingService;
    private readonly IJwtService _jwtService;

    public LoginUserCommandHandler(IUserRepository userRepository, IHashingService hashingService, IJwtService jwtService)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _hashingService = hashingService ?? throw new ArgumentNullException(nameof(hashingService));
        _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
    }

    public async Task<ErrorOr<LoginUserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            Error.NotFound("User.NotFound", "The user was not found");
        }

        if (!_hashingService.VerifyHash(user!.Password, request.Password))
        {
            Error.Unauthorized("User.Unauthorized", "The password is incorrect");
        }

        string token = _jwtService.GenerateJwtToken(user);

        var userResponse = new LoginUserResponse(user.FullName, user.Email, token);

        return userResponse;
    }
}
