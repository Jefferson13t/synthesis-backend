using Synthesis.Repository;
using Synthesis.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using Microsoft.Extensions.Hosting;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Synthesis.Model;

var pack = new ConventionPack { new CamelCaseElementNameConvention() };
ConventionRegistry.Register("elementNameConvention", pack, x => true);

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy(name: "MyPolicy",
    Policy => {
        Policy.WithOrigins("http://localhost:5000/swagger/").AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>()
        }
    });

});

builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddScoped<AuthServices>();
builder.Services.AddTransient<IAuthServices, AuthServices>();

builder.Services.AddScoped<WorkspaceServices>();
builder.Services.AddScoped<WorkspaceRepository>();
builder.Services.AddTransient<IWorkspaceServices, WorkspaceServices>();
builder.Services.AddTransient<IWorkspaceRepository, WorkspaceRepository>();

builder.Services.AddScoped<ColumnServices>();
builder.Services.AddScoped<ColumnRepository>();
builder.Services.AddTransient<IColumnServices, ColumnServices>();
builder.Services.AddTransient<IColumnRepository, ColumnRepository>();

builder.Services.AddScoped<CardServices>();
builder.Services.AddScoped<CardRepository>();
builder.Services.AddTransient<ICardServices, CardServices>();
builder.Services.AddTransient<ICardRepository, CardRepository>();

builder.Services.AddScoped<FlagServices>();
builder.Services.AddScoped<FlagRepository>();
builder.Services.AddTransient<IFlagServices, FlagServices>();
builder.Services.AddTransient<IFlagRepository, FlagRepository>();

builder.Services.AddScoped<FlagCardAssociationServices>();
builder.Services.AddScoped<FlagCardAssociationRepository>();
builder.Services.AddTransient<IFlagCardAssociationServices, FlagCardAssociationServices>();
builder.Services.AddTransient<IFlagCardAssociationRepository, FlagCardAssociationRepository>();

builder.Services.AddScoped<MemberServices>();
builder.Services.AddScoped<MemberRepository>();
builder.Services.AddTransient<IMemberServices, MemberServices>();
builder.Services.AddTransient<IMemberRepository, MemberRepository>();

var key = Encoding.ASCII.GetBytes(DotNetEnv.Env.GetString("KEY"));

builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
