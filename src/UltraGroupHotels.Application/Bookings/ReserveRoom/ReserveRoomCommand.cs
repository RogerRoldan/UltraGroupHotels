﻿using ErrorOr;
using MediatR;

namespace UltraGroupHotels.Application.Bookings.ReserveRoom;

public record ReserveRoomCommand(
    Guid RoomId,
    Guid CustomerId,
    DateOnly StartDate,
    DateOnly EndDate,
    string EmergencyContactFullName,
    string EmergencyContactPhoneNumber,
    List<GuestCommand> Guests) : IRequest<ErrorOr<Guid>>;