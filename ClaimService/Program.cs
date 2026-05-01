using ClaimService_Application.DTO;
using ClaimService_Application.Interface;
using ClaimService_Application.Mapping;
using ClaimService_Infrastructure.Data;
using ClaimService_Infrastructure.Service;

using Microsoft.EntityFrameworkCore;
using Serilog;





var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ClaimServices.Filters.CustomExceptionFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));


builder.Services.AddScoped<IClaimService, ClaimService>();
builder.Services.AddScoped<IClaimDocService, ClaimDocService>();

builder.Services.AddAutoMapper(typeof(DtoMapping));

builder.Services.AddHttpClient<PolicyClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["PolicyAddress"] ?? "http://localhost:5171");
});


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
