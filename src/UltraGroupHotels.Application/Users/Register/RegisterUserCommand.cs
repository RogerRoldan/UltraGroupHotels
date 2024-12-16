using ErrorOr;
using MediatR;

namespace UltraGroupHotels.Application.Users.Register;

public record RegisterUserCommand(string FullName, string Email, string Password, string Role) : IRequest<ErrorOr<Guid>>;
