using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<ContactsContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddCors();
    builder.Services.AddControllers();

    // Dodanie konfiguracji JWT
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });

    builder.Services.AddAuthorization();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    // Dodanie middleware uwierzytelniania i autoryzacji
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}

// Logger do konsolki
var logger = app.Services.GetRequiredService<ILogger<Program>>();

// Sprawdzanie po³¹czenia z baz¹ danych
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ContactsContext>();
    try
    {
        dbContext.Database.OpenConnection();
        dbContext.Database.CloseConnection();
        logger.LogInformation("Po³¹czenie z baz¹ danych zosta³o nawi¹zane pomyœlnie.");
    }
    catch (Exception ex)
    {
        logger.LogError($"B³¹d po³¹czenia z baz¹ danych: {ex.Message}");
    }
}

app.Run();
