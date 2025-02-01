using BLL.Utils;
using BLL.ServiceContracts;
using BLL.Services;
using DAL.DBContext;
using DAL.Repositories;
using DAL.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFilmsService, FilmsService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IFilmsRepository, FilmsRepository>();
builder.Services.AddAutoMapper(typeof(FilmsAutoMapper));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") 
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.WebHost.UseUrls("https://localhost:7269");

var app = builder.Build();

app.UseCors("AllowReactApp"); 

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("*"));
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
