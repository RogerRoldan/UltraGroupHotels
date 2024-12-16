using MediatR;

namespace UltraGroupHotels.Domain.Implementations;

public record DomainEvent(Guid Id) : INotification;
