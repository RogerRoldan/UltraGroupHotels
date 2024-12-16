using ErrorOr;
using MediatR;

namespace UltraGroupHotels.Application.Users.Login;

public record LoginUserCommand(string Email, string Password) : IRequest<ErrorOr<LoginUserResponse>>;