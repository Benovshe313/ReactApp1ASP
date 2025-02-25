
using Microsoft.EntityFrameworkCore;
using ReactApp1.Server.Data;
using ReactApp1.Server.Middlewares;
using ReactApp1.Server.Repositories.Abstract;
using ReactApp1.Server.Repositories.Concrete;

namespace ReactApp1.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                //   options.OutputFormatters.Insert(0, new VCardOutputFormatter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });


            var conn = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<StudentDbContext>(opt =>
            {
                opt.UseSqlServer(conn);
            });

            var app = builder.Build();
            // Configure the HTTP request pipeline.
            app.UseMiddleware<GlobalErrorHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCustomAuthMiddleware();
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
