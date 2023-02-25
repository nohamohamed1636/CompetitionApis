using Core.Models.Context;
using Core.Repositories.Competitions;
using Core.Services.Competitions;
using Data.Repositories.Competitions;
using Microsoft.EntityFrameworkCore;
using Service.Competitions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<AppDbContext>();
#region Add Injection Scops
builder.Services.AddScoped<ICompetitionRepository, CompetitionRepository>();
builder.Services.AddScoped<ICompetitionService, CompetitionService>();
builder.Services.AddScoped<ICompetitionAnswerRepository, CompetitionAnswerRepository>();
builder.Services.AddScoped<ICompetitionTargteRepository, CompetitionTargteRepository>();
builder.Services.AddScoped<ICompetitiontargetService, CompetitiontargetService>();
#endregion

//fordbcontext
builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDb")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Migrate latest database changes during startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    // Here is the migration executed
    dbContext.Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
