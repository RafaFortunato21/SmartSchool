using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Data.Context;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

// builder.Services.AddDbContext<SmartContext>(
//     context => context.UseMySql(builder.Configuration.GetConnectionString("Default"))
// );

// builder.Services.AddDbContext<SmartContext>(options =>
//     options.UseMySql(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))));

builder.Services.AddDbContext<SmartContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MySqlConnection"))));

//builder.Services.AddSingleton<IRepository, Repository>();
//builder.Services.AddTransient<IApiVersionDescriptionProvider>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
}).AddApiExplorer(opt =>
{
    opt.GroupNameFormat = "'v'VVV";
    opt.SubstituteApiVersionInUrl = true;
}
);




builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var apiProviderDescription = builder.Services.BuildServiceProvider()
                                             .GetService<IApiVersionDescriptionProvider>();

builder.Services.AddSwaggerGen(options =>
{
    foreach (var description in apiProviderDescription.ApiVersionDescriptions)
    {
        options.SwaggerDoc(
                description.GroupName,
                new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "SmartSchool API",
                    Version = description.ApiVersion.ToString(),
                    TermsOfService = new Uri("https://TermoDeUsoSmartSchool.com"),
                    Description = "A descrição da WebAPI do SmartSchool",
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "SmartSchool License",
                        Url = new Uri("https://mit.com")
                    },
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Rafael Forunato",
                        Email = "fael.fortunato@gmail.com",
                        Url = new Uri("https://fs.rj.gov.br")

                    }
                }
            );
    }

    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);

    options.IncludeXmlComments(xmlCommentsFullPath);
});

var app = builder.Build();

var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger()
        .UseSwaggerUI(options =>
        {
            foreach (var item in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", item.GroupName.ToLowerInvariant());
            }

            
            
            options.RoutePrefix = "";
        });
    app.UseSwaggerUI();
// }

//app.UseHttpsRedirection();

app.UseAuthorization();
 //Add this line

app.MapControllers();

app.Run();
