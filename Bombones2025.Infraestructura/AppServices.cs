using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Servicios.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Infraestructura
{
    public static class AppServices
    {//encargada de inyectar los servicios
        private static IServiceProvider _serviceProvider;//INTERFAZ ME PERMITE CREAR LOS SERVICIOS QUE YO VOY A INYECTAR
        public static void Inicializar()
        {
            var services = new ServiceCollection();
            services.AddScoped<IPaisRepositorio, PaisRepositorio>();
            services.AddScoped<IChocolateRepositorio, ChocolateRepositorio>();
            services.AddScoped<IFrutoSecoRepositorio, FrutoSecoRepositorio>();
            services.AddScoped<IRellenoRepositorio, RellenoRepositorio>();
            services.AddScoped<ITipoDePagoRepositorio, TipoDePagoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            services.AddScoped<IPaisServicio, PaisServicio>();
            services.AddScoped<IChocolateServicio, ChocolateServicio>();
            services.AddScoped<IFrutoSecoServicio, FrutoSecoServicio>();
            services.AddScoped<IRellenoServicio, RellenoServicio>();
            services.AddScoped<ITipoDePagoServicio, TipoDePagoServicio>();
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();

            _serviceProvider = services.BuildServiceProvider();
            //defino una conexion de servicios, luego creo un proveedor de servicios
        }

        public static IServiceProvider? ServiceProvider=>
            _serviceProvider ?? throw new NotImplementedException("DEPENDENCIAS NO ESTABLECIDAS");



    }
}
