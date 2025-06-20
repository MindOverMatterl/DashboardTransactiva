using TransActiva.Application;
using TransActiva.Application.Interfaces;
using TransActiva.Infrastructure;
using TransActiva.Infrastructure.Persistence;
using TransActiva.Infrastructure.Repositories;
using TransActiva.Infrastructure.UnitOfWork;
using TransActiva.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using MediatR;
using TransActiva.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 💾 Database context (MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TransactivaDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null
            );
        }));
// Este comentario es para forzar el redeploy
// 🧠 MediatR (solo Application)
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(TransActiva.Application.AssemblyReference).Assembly);
});

// 📦 Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoProductoRepository, PedidoProductoRepository>();
builder.Services.AddScoped<IPagoRepository, PagoRepository>();
builder.Services.AddScoped<IBoletaRepository, BoletaRepository>();
builder.Services.AddScoped<IPreparacionRepository, PreparacionRepository>();
builder.Services.AddScoped<IEnvioRepository, EnvioRepository>();
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
// 🧱 Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//"DefaultConnection": "server=127.0.0.1;port=3306;database=transactiva;user=transactiva_user;password=72882624V.;"
// 🔐 CORS (opcional si usas frontend separado)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// 🚀 Middleware
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseCors("AllowAll");
app.UseMiddleware<ExceptionHandlingMiddleware>(); // ← Aquí lo insertas
app.UseAuthorization();
app.MapControllers();

app.Run();
