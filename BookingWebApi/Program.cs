using BLL.Abstraction;
using BLL.Services;
using BookingWebApi.ExceptionHandling;
using DAL.Abstractions;
using DAL.Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using BookingWebApi.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// declare api input validation by using Fluent Validators
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AddHotelValidator>();

string? connectionString = builder.Configuration.GetConnectionString("BookingApi");
builder.Services.AddDbContext<BookingDbContext>(option =>
    option.UseSqlServer(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// declare Automapper for easier conversion models
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// declare ExceptionHandler to catch custom exceptions
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
