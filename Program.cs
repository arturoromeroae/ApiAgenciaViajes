using AgenciaViajes.DbContexts;
using AgenciaViajes.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Config connection string
var connectionString = builder.Configuration.GetConnectionString("AgenciaBD");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Conf DI
builder.Services.AddScoped<IAerolineaRepository, AerolineaSQLRepository>();
builder.Services.AddScoped<IActividadRepository, ActividadSQLRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteSQLRepository>();
builder.Services.AddScoped<ICompraRepository, CompraSQLRepository>();
builder.Services.AddScoped<IHotelRepository, HotelSQLRepository>();
builder.Services.AddScoped<ITipoDocumentoRepository, TipoDocumentoSQLRepository>();
builder.Services.AddScoped<ITrabajadorRepository, TrabajadorSQLRepository>();
builder.Services.AddScoped<IVueloRepository, VueloSQLRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});

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
