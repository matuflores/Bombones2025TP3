using Bombones2025.Infraestructura;
using Bombones2025.Servicios.Servicios;
using Microsoft.Extensions.DependencyInjection;

namespace Bombones2025.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            AppServices.Inicializar();//aca hago que me cargue todas las dependencias y crea el serviceprovaider
            IUsuarioServicio usuarioServicio = AppServices.ServiceProvider
                .GetRequiredService<IUsuarioServicio>();
            //UsuarioServicio usuarioServicio = new UsuarioServicio();
            Application.Run(new FrmLogin(usuarioServicio));
        }
    }
}