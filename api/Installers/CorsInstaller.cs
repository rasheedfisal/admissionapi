namespace admissionapi.api.Installers;

public class CorsInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        ;
                    });
            });
        }
    }