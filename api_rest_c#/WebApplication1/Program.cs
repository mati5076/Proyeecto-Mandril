using System.Data.Common;
using System.Net;
using Microsoft.EntityFrameworkCore;
using WebApplication1.db;
using WebApplication1.models;
using WebApplication1.Patron_Repository;

var builder = WebApplication.CreateBuilder(args);

//servicios Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IMandrilRepository , MandrilRepository>();


var conectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<Dbconnect>(
    options => options.UseNpgsql(conectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}   

app.UseHttpsRedirection();
app.MapControllers();

app.Run();