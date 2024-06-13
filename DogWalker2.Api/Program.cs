using DogWalker2.Application.Customers;
using DogWalker2.Application.Dogs;
using DogWalker2.Infrastructure.Customers;
using DogWalker2.Infrastructure.Dogs;
using DogWalker2.Infrastructure.Services;
using DogWalker2.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Identity.Web;
using DogWalker2.Infrastructure;
using DogWalker.Infrastructure;
using DogWalker2.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCascadingAuthenticationState();

builder.Services.AddTransient<IDogRepository, DogRepository>();
builder.Services.AddScoped<IDogService, DogService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddPersistence(builder.Configuration);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

builder.Services.AddCors(options =>
 {
     options.AddPolicy("CorsPolicy",
                        policy =>
                        {
                            policy.WithOrigins("https://localhost:7055", "http://localhost:3000") // Add your client's origin(s) "http://localhost:5173", 
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowCredentials(); // Allow credentials (e.g., cookies, authentication headers)
                        });
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
