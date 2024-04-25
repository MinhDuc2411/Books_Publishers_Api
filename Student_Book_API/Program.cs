using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server;
using Student_Book_API.Data;
using Student_Book_API.Models.Domain;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using Student_Book_API.BookSevice;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IBookReposi, BookReposi>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Register database
builder.Services.AddDbContext<DataDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


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
