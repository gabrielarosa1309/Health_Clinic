using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//PARA OS TOKENS------------------------------------------------------

//Não esquecer de adicionar os 2 nuggets seguintes
//System.IdentityModel.Tokens.Jwt
//Microsoft.AspNetCore.Authentication.JwtBearer


//Adiciona serviço de Jwt Bearer (forma de autenticação)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        //Valida quem está solicitando
        ValidateIssuer = true,

        //Valida quem está recebendo
        ValidateAudience = true,

        //Define se o tempo de expiração será validado
        ValidateLifetime = true,

        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("projeto-health_clinic-webapi-chave-autenticacao")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(50),

        //Nome do issuer (de onde está vindo)
        ValidIssuer = "webApi.health_clinic.manha",

        //Nome do audience (para onde está indo)
        ValidAudience = "webApi.health_clinic.manha"

    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
//Adiciona informações sobre a API no Swagger
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
