using AppAgendaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AppAgendaAPI;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCors();

        // adicionar middlewares (services):
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(option =>
            option.AddPolicy(name: "MyAllowSpecificOrigins",
             builder =>
             {
                 builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowAnyOrigin();
             }));



        // singleton ou transient
        //Validação Token
        var key = Encoding.ASCII.GetBytes("AbacateComBanana29/11/2003");
        builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

        });


        string strConn = builder.Configuration.GetConnectionString("BDFatec");
        builder.Services.AddDbContext<DBAgenda>(option => option.UseSqlServer(strConn));
        //builder.Services.AddDbContext<DBAgenda>(option => option.UseInMemoryDatabase("db")); // Linux não conecta no SQL Server


        WebApplication app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();


        app.UseCors("MyAllowSpecificOrigins");
        // usa o middleware (adiciona no pipeline de execução):
        app.MapControllers();
        app.Run();
    }
}
