using System.Reflection;
using Clinica.DoPovo.Aplicacao.Pacientes.Profiles;
using Clinica.DoPovo.Aplicacao.Pacientes.Servicos;
using Clinica.DoPovo.Dominio.Pacientes.Servicos;
using Clinica.DoPovo.Infra.Pacientes.Mapeamentos;
using Clinica.DoPovo.Infra.Pacientes.Repositorios;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.OpenApi.Models;
using NHibernate;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Clinica do Povo.API", Version = "v1" });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddSingleton<ISessionFactory>(factory => 
{
    string connectionString = builder.Configuration.GetConnectionString("MySql");
    return Fluently.Configure()
    .Database((MySQLConfiguration.Standard.ConnectionString(connectionString)
    .FormatSql()
    .ShowSql()))
    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<PacienteMap>()) 
    .BuildSessionFactory();
});

builder.Services.AddScoped<NHibernate.ISession>(factory => factory.GetService<ISessionFactory>()!.OpenSession());
builder.Services.AddScoped<ITransaction>(factory => factory.GetService<ISession>()!.BeginTransaction());

builder.Services.AddAutoMapper(typeof(PacientesProfile));
builder.Services.Scan(scan => scan
    .FromAssemblyOf<PacientesAppServico>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<PacientesServico>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

builder.Services.Scan(scan => scan
    .FromAssemblyOf<PacientesRepositorio>()
        .AddClasses()
            .AsImplementedInterfaces()
                .WithScopedLifetime());

var app = builder.Build();
app.UseCors(c =>
{
c.AllowAnyHeader();
c.AllowAnyMethod();
c.AllowAnyOrigin();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Clinica do Povo.API");
                c.DisplayRequestDuration();
            });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
