using BookApi.Database;
using BookApi.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IHostedService configuration
// sbuilder.Services.AddHostedService<EscribirArchivo>();

// * Congifuration Automapper
builder.Services.AddAutoMapper(typeof(Program));

// * Configuration Database 
builder.Services.AddNpgsql<DataContext>(builder.Configuration.GetConnectionString("defaultConnection"));

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
