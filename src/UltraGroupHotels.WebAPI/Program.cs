using UltraGroupHotels.Application.Implementations;
using UltraGroupHotels.Infrastructure;
using UltraGroupHotels.WebAPI;
using UltraGroupHotels.WebAPI.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
    .AddInfraestructure(builder.Configuration)
    .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigration();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();