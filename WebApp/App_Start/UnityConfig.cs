using Domain;
using MyServices;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace WebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<ITerbilang, TerbilangUSD>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}