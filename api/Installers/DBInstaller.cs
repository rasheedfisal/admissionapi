using admissionapi.services.Data;
using admissionapi.services.IConfiguration;
using Microsoft.EntityFrameworkCore;

namespace admissionapi.api.Installers;

public class DBInstaller : IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}