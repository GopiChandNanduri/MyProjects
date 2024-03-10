
using Microsoft.OpenApi.Models;

namespace ContosoRecipes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Contoso Recipes API",
                    Version = "v1",
                    Description = "A sample ASP.Net Core Web API that allows you work with recipe data.",
                    Contact = new OpenApiContact
                    {
                        Name = "Cecil Phillip",
                        Email = "dont@email.me",
                        Url = new Uri("https://twitter.com/cecilphillip"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT"),
                    }
                })).AddSwaggerGenNewtonsoftSupport();
        

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/error");
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            else
                app.UseExceptionHandler("/error");


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
