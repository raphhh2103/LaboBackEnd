using DbLabo;
using DbLabo.Repositories;
using LaboBackEnd.Context;
using LaboBLL.ServicesBLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using JwtBehavior.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using LaboBackEnd.ServiceAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});
JwtSettings BindJwtSettings = new JwtSettings();
//Microsoft.Extensions.IConfiguration.Bind("JsonWebTokenKeys",BindJwtSettings);

builder.Configuration.Bind("JsonWebTokenKeys", BindJwtSettings);




builder.Services.AddTransient(typeof(UserRepository));
builder.Services.AddTransient(typeof(UserServiceBLL));
builder.Services.AddTransient(typeof(SkillRepository));
builder.Services.AddTransient(typeof(SkillServiceMapper));
builder.Services.AddTransient(typeof(EquipmentRepository));
builder.Services.AddTransient(typeof(EquipmentServiceMapper));
builder.Services.AddTransient(typeof(ChampRepository));
builder.Services.AddTransient(typeof(ChampServiceMapper));
builder.Services.AddTransient(typeof(BasicsStatisticRepository));
builder.Services.AddTransient(typeof(BasicsStatisticServiceMapper));
builder.Services.AddTransient(typeof(AffinityChampRepository));
builder.Services.AddTransient(typeof(AffinityChampServiceMapper));
builder.Services.AddTransient(typeof(JwtSettings));
builder.Services.AddTransient(typeof(AccountServiceAPI));

builder.Services.AddDbContext<DbConnect>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddSingleton(BindJwtSettings);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = BindJwtSettings.validateIssuerSigningKey,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(BindJwtSettings.IssuerSigningKey)),
        ValidateIssuer = BindJwtSettings.ValidateIssuer,
        ValidIssuer = BindJwtSettings.ValidIssuer,
        ValidateAudience = BindJwtSettings.ValidateAudience,
        ValidAudience = BindJwtSettings.ValidAudience,
        RequireExpirationTime = BindJwtSettings.RequireExpirationTime,
        ValidateLifetime = BindJwtSettings.RequireExpirationTime,
        ClockSkew = TimeSpan.FromDays(1),
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using Bearer scheme "
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {

                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = " Bearer"
                }
            },
            new string[]{}
        }
    });
});



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","LaboBackEnd V1"));
}
app.UseRouting();
app.UseCors("AllowAll");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
