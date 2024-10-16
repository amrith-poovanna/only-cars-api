using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Auto.Entities;
using Autos.Interface;
using Autos.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<autodbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("autodb")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Repository
builder.Services.AddScoped<IAuto, AutoRepository>();

//JSON Serializer
builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
    options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();

//Enable CORS
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//app.UseSwagger();
//app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    //c.RoutePrefix = string.Empty;  // Serves Swagger at the root
});


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
