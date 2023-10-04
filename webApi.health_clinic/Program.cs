using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//PARA OS TOKENS------------------------------------------------------

//N�o esquecer de adicionar os 2 nuggets seguintes
//System.IdentityModel.Tokens.Jwt
//Microsoft.AspNetCore.Authentication.JwtBearer


//Adiciona servi�o de Jwt Bearer (forma de autentica��o)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        //Valida quem est� solicitando
        ValidateIssuer = true,

        //Valida quem est� recebendo
        ValidateAudience = true,

        //Define se o tempo de expira��o ser� validado
        ValidateLifetime = true,

        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projeto-health_clinic-webapi-chave-autenticacao")),

        //Valida o tempo de expira��o do token
        ClockSkew = TimeSpan.FromMinutes(50),

        //Nome do issuer (de onde est� vindo)
        ValidIssuer = "webApi.health_clinic.manha",

        //Nome do audience (para onde est� indo)
        ValidAudience = "webApi.health_clinic.manha"

    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
//Adiciona informa��es sobre a API no Swagger
options.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "API HealthClinic",

    Contact = new OpenApiContact
    {
        Name = "Gabriela Ramos",
        Url = new Uri("https://github.com/gabrielarosa1309/Health_Clinic")
    }
}));



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
