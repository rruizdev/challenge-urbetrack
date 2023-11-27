using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Services;
using NetChallenge.Core.Database;
using NetChallenge.Infrastructure.Abstractions;
using NetChallenge.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ChallengeContext>(options => options
    .UseInMemoryDatabase("ChallengeDB"));

builder.Services.AddScoped<IOfficeRentalService, OfficeRentalService>();

builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
