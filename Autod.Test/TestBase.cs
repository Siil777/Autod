using Autod.AplicationServices.Services;
using Autod.Core.Domain;
using Autod.Core.ServiceInterface;
using Autod.Data;
using Autod.Test.Macros;
using Autod.Test.Mock;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace Autod.Test

{
    //Part of a test infastructure xUnit
    public class TestBase
    {
        //service provider keeps an instance of IServiceProvider
        protected IServiceProvider serviceProvider { get; }

        //Constructor set services and build IServiceProvider
        protected TestBase()
        {

            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();


        }
        //Method to clean up recources after the test
        public void Dispose()
        {

        }
        //SVC utility method to conveniently retrieve a service from the IServiceProvider.
        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();


        }
        //T Macro to retrieve instances of macros from the IServiceProvider.
        protected T Macro<T>() where T : IMacros
        {
            return serviceProvider.GetService<T>();
        }



        //To register services ILandingPageServices, IHostEnvironment,
        //and configures an in-memory database for AutoContext
        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<ILandingPageServices, LandingPageServices>();
            services.AddScoped<ICarService, CarServiceServices>();
            services.AddScoped<IHostEnvironment, MockHostEnvironment>();





            services.AddDbContext<AutoContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }
        private void RegisterMacros(IServiceCollection services)
        {
            var macrosBaseType = typeof(IMacros);


            var macros = macrosBaseType.Assembly.GetTypes()
                .Where(x => macrosBaseType.IsAssignableFrom(x) && !x.IsInterface
                && !x.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);

            }


        }
    }
}
