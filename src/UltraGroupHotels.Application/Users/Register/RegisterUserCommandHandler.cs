using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Users.Common.Authorization;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Users;

namespace UltraGroupHotels.Application.Users.Register;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ErrorOr<Guid>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHashingService _hashingService;

    public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IHashingService hashingService)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _hashingService = hashingService ?? throw new ArgumentNullException(nameof(hashingService));
    }

    public async Task<ErrorOr<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (userExists is not null)
        {
            return Error.Conflict("User.Conflict", "The user already exists");
        }

        string hashedPassword = _hashingService.HashPassword(request.Password);

        var user = new User(new Guid() ,request.FullName, request.Email, hashedPassword, Role.FromValue(request.Role));

        _userRepository.Add(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
