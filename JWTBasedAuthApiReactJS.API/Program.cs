using JWTBasedAuthApiReactJS.CORE.Models;
using JWTBasedAuthApiReactJS.CORE.Repositories;
using JWTBasedAuthApiReactJS.CORE.Services;
using JWTBasedAuthApiReactJS.CORE.UOW;
using JWTBasedAuthApiReactJS.DATA;
using JWTBasedAuthApiReactJS.DATA.Repositories;
using JWTBasedAuthApiReactJS.DATA.UOW;
using JWTBasedAuthApiReactJS.SERVICE.Services;
using JWTBasedAuthApiReactJS.SHARED;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSqlConnection"),
        action => { 
            action.MigrationsAssembly("JWTBasedAuthApiReactJS.DATA");
        });
});



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped(typeof(ITransactionService), typeof(TransactionService));
builder.Services.AddScoped(typeof(ITransactionRepository), typeof(TransactionRepository));
builder.Services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
builder.Services.AddScoped(typeof(ICustomerService), typeof(CustomerService));

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapProfile>());



ConfigurationManager configuration = builder.Configuration;
var tokenOption = configuration.GetSection("TokenOption").Get<CustomTokenOptions>();




builder.Services.AddIdentity<UserApp, IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;
    opt.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();




builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


})
    .AddJwtBearer(options =>
     {
         options.SaveToken = true;
         options.RequireHttpsMetadata = false;
         options.TokenValidationParameters = new TokenValidationParameters()
         {
             ValidIssuer = tokenOption.Issuer,
             RoleClaimType = "Roles",
             IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOption.SecurityKey),
             ValidateIssuerSigningKey = true,
             ValidateAudience = true,
             ValidateIssuer = true,
             ValidateLifetime = true,
             ClockSkew = TimeSpan.Zero
         };
     });


builder.Services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOption"));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
