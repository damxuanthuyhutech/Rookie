using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //////Cus
            /////1Chap nhan moi dia chi ip (public)
            //builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            builder.Services.AddDbContext<RookiesDbContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                                      //policy.WithOrigins("http://localhost:3000");
                                  });
            });


            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.MapControllers();

            app.Run();
        }
    }
}