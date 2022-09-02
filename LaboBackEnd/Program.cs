using DbLabo;
using DbLabo.Repositories;
using LaboBackEnd.Context;
using LaboBLL.ServicesBLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using JwtBehavior.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
//public IConfiguration Configuration { get; }
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("index", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});
JwtSettings BindJwtSettings = new JwtSettings();
//Microsoft.Extensions.IConfiguration.Bind("JsonWebTokenKeys",BindJwtSettings);

builder.Configuration.Bind("JsonWebTokenKeys", BindJwtSettings);

builder.Services.AddTransient(typeof(UserRepository));
builder.Services.AddTransient(typeof(UserSericeBLL));
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

builder.Services.AddDbContext<DbConnect>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

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
