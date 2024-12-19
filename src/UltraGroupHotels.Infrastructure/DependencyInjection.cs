using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UltraGroupHotels.Application.Implementations.Common.Email;
using UltraGroupHotels.Application.Implementations.Data;
using UltraGroupHotels.Application.Users.Common.Authorization;
using UltraGroupHotels.Domain.Bookings;
using UltraGroupHotels.Domain.Hotels;
using UltraGroupHotels.Domain.Implementations;
using UltraGroupHotels.Domain.Rooms;
using UltraGroupHotels.Domain.Users;
using UltraGroupHotels.Infrastructure.Authorization;
using UltraGroupHotels.Infrastructure.Email;
using UltraGroupHotels.Infrastructure.Persistence;
using UltraGroupHotels.Infrastructure.Persistence.Repositories;

namespace UltraGroupHotels.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddAuthentication(configuration);
        services.AddEmail(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(options => 
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IApplicationDbContext>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
                sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IGuestRepository, GuestRepository>();

        return services;
    }

    public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHashingService, HashingService>();
        services.AddScoped<IJwtService, JwtService>();
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.AddHttpContextAccessor();

        return services;
    }

    public static IServiceCollection AddEmail(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.Configure<EmailOptions>(configuration.GetSection("SmtpEmail"));

        return services;
    }
}
