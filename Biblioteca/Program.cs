using Biblioteca.Application.Intefaces;
using Biblioteca.Application;
using Biblioteca.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain.Intefaces;
using Biblioteca.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();


var databaseType = builder.Configuration.GetSection("DatabaseType").Value;
if (databaseType == "SQLite")
{
    builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));
}
else
{
    builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLiteConnection")));
}



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<BibliotecaDbContext>();
    dbContext.Database.Migrate();
}

app.MapControllers();

app.Run();
