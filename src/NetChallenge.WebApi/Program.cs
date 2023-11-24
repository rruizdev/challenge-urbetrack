using NetChallenge.Application.Services;
using NetChallenge.Application.Abstractions;
using NetChallenge.Application.Validations;
using NetChallenge.Infrastructure.Abstractions;
using NetChallenge.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOfficeValidations, OfficeValidations>();
builder.Services.AddScoped<ILocationValidations, LocationValidations>();
builder.Services.AddScoped<IBookingValidations, BookingValidations>();

builder.Services.AddScoped<IOfficeRentalService, OfficeRentalService>();

builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
