using FluentValidation;
using GerenciamentoDeCampanhas.Api.Application.Behavior;
using GerenciamentoDeCampanhas.Api.Application.Commands.AtualizarCampanha;
using GerenciamentoDeCampanhas.Api.Application.Commands.CriarCampanha;
using GerenciamentoDeCampanhas.Api.Application.Commands.RedirecionamentoCampanha;
using GerenciamentoDeCampanhas.Api.Middleware;
using GerenciamentoDeCampanhas.Infrastructure.MongoDB;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gerenciamento e Redirecionamento de Campanhas",
        Version = "v1",
        Description = 
        "A API foi desenvolvida em .NET 8 e usa MongoDB como banco de dados. Sua fun��o � gerenciar campanhas, permitindo a cria��o, edi��o e execu��o de redirecionamentos." +
        "Cada campanha possui uma lista de URLs, com a op��o de definir o n�mero de cliques por URL. O objetivo principal � redirecionar usu�rios a partir de um link exclusivo " +
        "da campanha, respeitando o limite de cliques por URL.",
        Contact = new OpenApiContact
        {
            Email = "espedrosantos@gmail.com",
            Name = "Pedro Eduardo dos Santos",
            Url = new Uri("https://www.linkedin.com/in/pedro-eduardo/")
        }
    });
});
builder.Services.ConfigureMongo();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddTransient<IValidator<CriarCampanhaCommand>, CriarCampanhaCommandValidator>();
builder.Services.AddTransient<IValidator<AtualizarCampanhaCommand>, AtualizarCampanhaCommandValidator>();
builder.Services.AddTransient<IValidator<RedirecionamentoCampanhaCommand>, RedirecionamentoCampanhaCommandValidator>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowAnyOriginPolicy");

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Campanhas API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
