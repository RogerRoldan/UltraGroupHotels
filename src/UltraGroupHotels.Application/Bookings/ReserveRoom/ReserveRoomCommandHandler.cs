using ErrorOr;
using MediatR;
using UltraGroupHotels.Application.Implementations.Common.Email;
using UltraGroupHotels.Domain.Bookings;
using UltraGroupHotels.Domain.Guest;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Rooms;
using UltraGroupHotels.Domain.SharedValueObjects;
using UltraGroupHotels.Domain.Users;
using UltraGroupHotels.Infrastructure.Persistence.Repositories;

namespace UltraGroupHotels.Application.Bookings.ReserveRoom;

public sealed class ReserveRoomCommandHandler : IRequestHandler<ReserveRoomCommand, ErrorOr<Guid>>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUserRepository _customerRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IGuestRepository _guestRepository;
    private readonly IHotelRepository _hotelRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmailService _emailService;

    public ReserveRoomCommandHandler(
        IRoomRepository roomRepository,
        IUserRepository customerRepository,
        IBookingRepository bookingRepository,
        IGuestRepository guestRepository,
        IHotelRepository hotelRepository,
        IUnitOfWork unitOfWork,
        IEmailService emailService
        )
    {
        _roomRepository = roomRepository;
        _customerRepository = customerRepository;
        _bookingRepository = bookingRepository;
        _guestRepository = guestRepository;
        _hotelRepository = hotelRepository;
        _unitOfWork = unitOfWork;
        _emailService = emailService;
    }

    public async Task<ErrorOr<Guid>> Handle(ReserveRoomCommand request, CancellationToken cancellationToken)
    {
        if(request.StartDate >= request.EndDate)
        {
            return Error.Validation("Booking", "Start date must be before end date");
        }

        if(request.StartDate < DateOnly.FromDateTime(DateTime.UtcNow))
        {
            return Error.Validation("Booking", "Start date must be in the future");
        }


        var room = await _roomRepository.GetByIdAsync(request.RoomId, cancellationToken);
        if(room is null)
        {
            return Error.NotFound(nameof(Room), "Room not found");
        }
        if (!room.IsActive)
        {
            return Error.Validation(nameof(Room), "Room is not active");
        }
        int maxiumumGuestsAllowed = room.QuantityGuests.Adults + room.QuantityGuests.Children;
        if(request.Guests.Count > maxiumumGuestsAllowed)
        {
            return Error.Validation("Booking", $"Room can only accommodate {maxiumumGuestsAllowed} guests");
        }


        var hotel = await _hotelRepository.GetByIdAsync(room.HotelId, cancellationToken);
        if(hotel is null)
        {
            return Error.NotFound(nameof(Hotel), "Hotel not found");
        }
        if (!hotel.IsActive)
        {
            return Error.Validation(nameof(Hotel), "Hotel is not active");
        }


        var customer = await _customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
        if(customer is null)
        {
            return Error.NotFound(nameof(User), "Customer not found");
        }

        if( await _bookingRepository.ExistsOverlappingReservationAsync(room, new DateRange(request.StartDate, request.EndDate), cancellationToken))
        {
            return Error.Validation("Booking", "Room is already reserved for the selected dates");
        }


        if (PhoneNumber.Create(request.EmergencyContactPhoneNumber) is not PhoneNumber phoneNumberCustomer)
        {
            return Error.Validation("Hotel.PhoneNumber", "Phone number is invalid");
        }

        var booking = Booking.MakeReservation(
            customer.Id,
            room,
            new DateRange(
                request.StartDate, 
                request.EndDate),
            new EmergencyContact(
                request.EmergencyContactFullName, 
                phoneNumberCustomer));

        _bookingRepository.Add(booking);

        var guests = request.Guests.Select(g => new Guest(Guid.NewGuid(),
                                                          booking.Id, 
                                                          g.FirstName, 
                                                          g.LastName, 
                                                          g.DateOfBirth,
                                                          Gender.Create(g.Gender), 
                                                          TypeDocument.Create(g.TypeDocument), 
                                                          new DocumentNumber(g.DocumentNumber), 
                                                          g.Email, 
                                                          PhoneNumber.Create(g.PhoneNumber)!)).ToList();

        _guestRepository.AddRange(guests);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        SendEmailBookingConfirmation(customer, hotel, room, booking);

        return booking.Id;
    }

    private void SendEmailBookingConfirmation(User customer, Hotel hotel, Room room, Booking booking)
    {
        string subject = $"Reservation Confirmation";

        string bodyMessage = $"Dear {customer.FullName},\n\n" +
                  $"Your reservation has been successfully confirmed at {hotel.Name}.\n\n" +
                  $"Reservation Number: {booking.Id}\n" +
                  $"Check-in Date: {booking.Duration.StartDate.ToShortDateString()}\n" +
                  $"Check-out Date: {booking.Duration.EndDate.ToShortDateString()}\n" +
                  $"Room Type: {room.RoomType.Value}\n\n" +
                  $"Thank you for choosing {hotel.Name}. We look forward to welcoming you soon.";

        _emailService.Send(customer.Email, subject, bodyMessage);
    }
}
