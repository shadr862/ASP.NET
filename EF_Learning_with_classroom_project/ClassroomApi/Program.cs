using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ClassroomApi.Data;
using ClassroomApi.Model;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// 👇 Add controllers and allow ignoring circular references
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// 👇 Register DB context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 👇 Register JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// 👇 Enable Swagger with JWT support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Classroom API", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter a valid JWT token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

// 👇 Add CORS policies
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy_1", policy =>
    {
        policy.WithOrigins(
                "http://example.com",
                "http://www.contoso.com",
                "http://localhost:5299",
                "http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });

    options.AddPolicy("Policy_2", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 👇 Use CORS (choose one)
app.UseCors("Policy_2"); // Use Policy_1 if you want restricted origins

// 👇 Enable Swagger always
app.UseSwagger();
app.UseSwaggerUI();

// 👇 Enable static files (for PDF or images if needed)
app.UseStaticFiles();

// 👇 Enable HTTPS redirection
app.UseHttpsRedirection();

// 👇 Enable authentication and authorization
app.UseAuthentication(); // 🔥 Must come before UseAuthorization
app.UseAuthorization();

// 👇 Use your exception middleware (make sure it's implemented)
app.UseMiddleware<ExceptionHandlingMiddleware>();

// 👇 Map endpoints
app.MapControllers();

// 👇 Start the app
app.Run();
