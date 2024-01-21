using PokemonReviewApp.Data;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Installing services to the program. Could be connection to the DB, etc.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();


//Using the <<repository pattern>>, see GetPokemon(). Start the backtrace in IPokemonRepository.cs in Interface folder.
//Its being implemented in PokemonRepository.cs in Repository folder.
//Lastly its being used in PokemonController.cs in Controllers folder.
//Before its finally being added here as a service.
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();


//Populate the data from the Seed class with dummy data. If the data already exists in the DB, it will not be re-populated.
//When running Add-Migration InitialCreate and update-database commands via Package Manager console, it didnt work at first
//The tables were created, but I had to open a terminal in the folder:
//PokemonReviewApp\bin\Debug\net8.0
//Where the PokemonReviewApp.dll was located, and ran:
//dotnet PokemonReviewApp.dll seeddata 
//in the terminal.
//All credits to chatGPT for this one.
if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}


    // Configure the HTTP request pipeline. Middelware
    if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
