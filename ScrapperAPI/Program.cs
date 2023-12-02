
using Core.Interfaces;
using Infrestructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Services.ApplicationServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add daad services
builder.Services.AddScoped<IDaadScrapper, DaadScrapper>();

//add jobbank canada services
builder.Services.AddScoped<IJobBankCanadaCrapper, JobBankCanadaCrapper>();

//add limkedin services
builder.Services.AddScoped<ILinkedInScrapper, LinkedInScrapper>();

// add data provider services
builder.Services.AddScoped<IJobAndEjucationServices, JobAndEjucationServices>();


//Set DBContext
builder.Services.AddDbContext<AppDataContext>(options =>
{
    options.UseSqlServer("Server=.;Initial Catalog=ImmimatchDB;Integrated Security=true;TrustServerCertificate=True;");
});

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
