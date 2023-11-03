using Basket.API.Repositories;
using MassTransit;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddStackExchangeRedisCache(opt =>
    opt.Configuration = builder.Configuration.GetValue<string>("CacheSettings:ConnectionString")
) ;

builder.Services.AddScoped<IBasketRepository, ShoppingBasketRepository>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("localhost",5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
            
        });
    });
});

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



app.MapControllers();

app.Run();
