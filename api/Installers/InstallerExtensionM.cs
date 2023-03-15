namespace admissionapi.api.Installers;

 public static class InstallerExtensionM
    {
        public static void InstallServicesInAssembly(this WebApplicationBuilder builder)
        {
            var Installers = typeof(Program).Assembly.ExportedTypes.Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            Installers.ForEach(installer => installer.InstallServices(builder));
        }
    }