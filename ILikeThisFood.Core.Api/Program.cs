using ILikeThisFood.Core.Api.Models;
using ILikeThisFood.Infra.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

builder.Services.Configure<ILikeThisFoodDatabaseSettings>(
    builder.Configuration.GetSection("ILikeThisFoodDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(options => options
                .SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
