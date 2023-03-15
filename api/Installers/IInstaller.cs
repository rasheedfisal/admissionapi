namespace admissionapi.api.Installers;

 public interface IInstaller
{
    void InstallServices(WebApplicationBuilder builder);
}