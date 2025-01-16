using admissionapi.api.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;
using MotorX.Api.Services;

namespace admissionapi.api.Installers;

public class MvcInstaller : IInstaller
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor?.HttpContext?.Request;
                var uri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent());
                return new UriService(uri);
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IImageProcessor, ImageProcessor>();
        }
    }