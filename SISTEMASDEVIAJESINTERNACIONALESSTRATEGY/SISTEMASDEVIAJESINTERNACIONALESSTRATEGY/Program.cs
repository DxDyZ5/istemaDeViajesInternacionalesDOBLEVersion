using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorHotel;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorRentaCarros;
using SISTEMASDEVIAJESINTERNACIONALESSTRATEGY.ClasesGestorVuelo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGestorHotel, GestorHotel>();
builder.Services.AddScoped<IGestorRentaCarro, GestorRentaCarro>();
builder.Services.AddScoped<IGestorVuelo, GestorVuelo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(a => a.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
