
using APIOpdracht_SteffVanWeereld.database;
using APIOpdracht_SteffVanWeereld.Services;
using Microsoft.EntityFrameworkCore;

namespace APIOpdracht_SteffVanWeereld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var activeDb = builder.Configuration.GetValue<string>("activeDb");

            if (activeDb == "MySQL")
            {
                var conn = builder.Configuration.GetSection("Databases:Mysql:ConnectionString").Value;
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(conn, ServerVersion.AutoDetect(conn)));
            }
            else if (activeDb == "InMemory")
            {
                builder.Services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("InMemoryDb"));
            }

            // Add services to the container.
            builder.Services.AddScoped<IBossesService, BossesService>();
            builder.Services.AddScoped<IQuestsService, QuestsService>();
            builder.Services.AddScoped<IRegionService, RegionService>();
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

            using(var scope = app.Services.CreateScope())
            {
                var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                appDbContext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
