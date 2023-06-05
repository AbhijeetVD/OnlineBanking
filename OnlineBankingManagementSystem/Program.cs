using Microsoft.EntityFrameworkCore;
using OnlineBankingManagementSystem.BLL.Services;
using OnlineBankingManagementSystem.DAL.Repositories;
using OnlineBankingManagementSystem.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
 builder.Configuration.GetConnectionString("SQLServer")
 ));

builder.Services.AddEndpointsApiExplorer();
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");
    options.AddPolicy("AllowLocalhost",
    builder => builder.WithOrigins("frontend_url")
    .AllowAnyMethod()
    .AllowAnyHeader());
});
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = " CtsBank", Version = "v1" });
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT <strong>Authorization</strong> header using the Bearer scheme. <br/>
                        Enter your token in the text box below.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        Array.Empty<string>()
        }
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IAccountService,  AccountService>();
builder.Services.AddScoped<ITransactionRepo, TransactionRepo>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.UseAuthentication();
app.MapControllers();

app.Run();
