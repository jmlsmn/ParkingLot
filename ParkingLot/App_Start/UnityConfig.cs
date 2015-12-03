using Microsoft.Practices.Unity;
using ParkingLot.Core.Domain;
using ParkingLot.Core.Interfaces.Repositories;
using ParkingLot.Core.Interfaces.Services;
using ParkingLot.Core.Repositories;
using ParkingLot.Core.Services;
using System.Web.Http;
using Unity.WebApi;

namespace ParkingLot
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IFeeService, FeeService>();
            container.RegisterType<IParkingSpaceService, ParkingSpaceService>();
            container.RegisterType<IVehicleService, VehicleService>();

            container.RegisterType<IRepository<ParkingSpace>, ParkingSpaceRepository>();
            container.RegisterType<IRepository<Vehicle>, VehicleRepository>();

            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}