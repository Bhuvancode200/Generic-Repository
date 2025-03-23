using Generic_Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Generic_Repository.Data;

namespace Generic_Repository
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ✅ Ensure Configuration is Loaded
            var configuration = builder.Configuration;

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // ✅ Register DbContext
            builder.Services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(connectionString));

            // ✅ Register Generic Repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
