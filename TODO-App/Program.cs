using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TODO_App.Data;
using TODO_App.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer("Data Source=KUKICRO\\SQLEXPRESS;Initial Catalog=TODO;Integrated Security=True")
);
builder.Services.AddTransient<ZadatakService>();
builder.Services.AddTransient<KorisnikService>();


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

AppDbInitializer.Seed(app);

app.Run();
