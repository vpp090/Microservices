using BrokerMessagesR.Common;
using MassTransit;
using Order.API.Consumers;
using Order.Application.Extensions;
using Order.Infrastructure.Extensions;
using Order.Infrastructure.Persistence;
using Order.API.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddApplicationServices();
builder.Services.AddInfrastureServices(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<BasketCheckoutConsumer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BasketCheckoutConsumer>();

    builder.Services.AddMassTransit(config =>
    {
        config.UsingRabbitMq((ctx, cfg) =>
        {
            cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);

            cfg.ReceiveEndpoint(EventBusConstants.BasketCheckoutQueue, c =>
            {
                c.ConfigureConsumer<BasketCheckoutConsumer>(ctx);
            });
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
    OrderContextSeed
            .SeedAsync(ctx, logger)
            .Wait();

});

app.MapControllers();

app.Run();