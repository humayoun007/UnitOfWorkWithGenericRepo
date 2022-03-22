using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;

namespace TestProject
{
    public partial class Program
    {
        public static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigurationServices(services);
            services.AddLogging(c => c.AddConsole(opt => opt.LogToStandardErrorThreshold = LogLevel.Debug));
            IServiceProvider serviceProvider = services.BuildServiceProvider();



            ILogger<Program> logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
            logger.LogDebug("Starting Application");

            var allNotificaton = serviceProvider.GetService<INotifier>().GetNotification().Result;
            foreach (var item in allNotificaton)
            {
                Console.WriteLine(item.DateCreated);
            }

            //This won't compile as researchEngine doesn't have a public constructor and so can't be instantiated.
            //CarFactory<ResearchEngine> researchLine = new CarFactory<ResearchEngine>();
            //var researchEngine = researchLine.MakeEngine();

            ////Can instantiate new object of class with default public constructor
            //CarFactory<ProductionEngine> productionLine = new CarFactory<ProductionEngine>();
            //var productionEngine = productionLine.MakeEngine();
        }
    }

    

    //public class ProductionEngine { }
    //public class ResearchEngine
    //{
    //    private ResearchEngine() { }
    //}

    //public class CarFactory<TEngine> where TEngine : class, new()
    //{
    //    public TEngine MakeEngine()
    //    {
    //        return new TEngine();
    //    }
    //}
}
