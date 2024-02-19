using Biblioteca.Application.Intefaces;
using Biblioteca.Application;
using Biblioteca.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Domain.Intefaces;
using Biblioteca.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var databaseType = builder.Configuration.GetSection("DatabaseType").Value;

if (databaseType == "SQLite")
{
    builder.Services.AddDbContext<BibliotecaDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"),
        options => options.MigrationsAssembly("Biblioteca.Infrastructure")));
}
else
{
    builder.Services.AddDbContext<BibliotecaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SQLiteConnection"),
        options => options.MigrationsAssembly("Biblioteca.Infrastructure")));
}

var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseCors("AllowOrigin");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var dbContext = services.GetRequiredService<BibliotecaDbContext>();

        dbContext.Database.Migrate();

        dbContext.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao criar ou migrar o banco de dados.");
    }
}

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
