using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OA.Data;
using OA.Repository;
using OA.Service;

namespace UserManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //for DB
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                        options.UseSqlServer(builder.Configuration["ConnectionStrings:DevConnection"],
                        a => a.MigrationsAssembly("OA.API")
                        ));
                //type will be decided from the calling layer
            builder.Services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));
            builder.Services.AddTransient<IUserService, UserService>();

        
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}