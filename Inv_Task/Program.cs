using Inv_Task.Core;
using Inv_Task.EF;
using Microsoft.EntityFrameworkCore;
 
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection",
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseHttpsRedirection();

app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();
