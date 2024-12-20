using System.Text.Json;

namespace UltraGroupHotels.WebAPI.Common.http;

public static class CustomStatusCodePagesExtensions
{
    public static IApplicationBuilder UseCustomStatusCodePages(this IApplicationBuilder app)
    {
        return app.UseStatusCodePages(async context =>
        {
            var response = context.HttpContext.Response;

            if (response.StatusCode == StatusCodes.Status401Unauthorized)
            {
                response.ContentType = "application/json";
                var problemDetails = new
                {
                    title = "Unauthorized",
                    status = 401,
                    detail = "You are not authorized to access this resource."
                };

                await response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }

            if (response.StatusCode == StatusCodes.Status403Forbidden)
            {
                response.ContentType = "application/json";
                var problemDetails = new
                {
                    title = "Forbidden",
                    status = 403,
                    detail = "You do not have the required role to perform this action."
                };

                await response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            }
        });
    }
}