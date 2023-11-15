using EventBus.Messages.Common;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Order.API.Consumers;
using Order.Application.Extensions;
using Order.Infrastructure.Extensions;
using Order.Infrastructure.Persistence;
using Order.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApplicationServices();
builder.Services.AddInfrastureServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BasketCheckoutConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(builder.Configuration["EventBusSettings:Location"], builder.Configuration["EventBusSettings:Port"], "/", h =>
        {
            h.Username(builder.Configuration["EventBusSettings:UserName"]);
            h.Password(builder.Configuration["EventBusSettings:Password"]);

        });

        cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
        {
            c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
        });

    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase<OrderContext>((ctx, services) =>
{
    var logger = services.GetService<ILogger<OrderContextSeed>>();
    OrderContextSeed.SeedAsync(ctx, logger).Wait();

});

app.MapControllers();

app.Run();