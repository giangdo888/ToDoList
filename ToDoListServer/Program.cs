
using Microsoft.EntityFrameworkCore;
using ToDoListServer.Data;
using ToDoListServer.Interfaces.IRepositories;
using ToDoListServer.Interfaces.IServices;
using ToDoListServer.Repositories;
using ToDoListServer.Services;
using ToDoListServer.Utilities.Middleware;

namespace ToDoListServer
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
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ToDoListDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //configure logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            //inject repository
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();

            //inject service
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IToDoItemService, ToDoItemService>();

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

            //Register the exception-handling middleware
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.Run();
        }
    }
}
