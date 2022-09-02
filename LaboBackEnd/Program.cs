using DbLabo;
using DbLabo.Repositories;
using LaboBackEnd.Context;
using LaboBLL.ServicesBLL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    //builder.Services.AddDbContext<Badge2022Context>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Badge2022Works")));

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
