using Microsoft.AspNetCore.Mvc;
using TicketSelling.Core;
using TicketSelling.Core.Mappers;
using TicketSelling.Data;
using TicketSelling.Data.Mappers;
using TicketSelling.HostedServices;
using TicketSelling.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(DbModelMappingProfile));
builder.Services.AddHostedService<MigrationHostedService>();
builder.Services
    .AddData(builder.Configuration)
    .AddCore();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<SizeRequestMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
