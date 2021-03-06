﻿using Microsoft.Owin.Hosting;
using System;
using Owin;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using QX_Frame.App.WebApi.Extends;
using System.Web.Http.Cors;
using Microsoft.Owin.Cors;

namespace OWIN.WebApi.Srv
{
    class AppStart
    {
        static void Main(string[] args)
        {
            //string baseAddress = "http://localhost:3999/";    //localhost visit
            string baseAddress = "http://+:3999/";              //all internet environment visit  
            try
            {
                WebApp.Start<StartUp>(url: baseAddress);
                Console.WriteLine("BaseIpAddress is " + baseAddress);
                Console.WriteLine("\nApplication Started !");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            for (;;)
            {
                Console.ReadLine();
            }
        }
    }
    //the start up configuration
    class StartUp
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            //appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.MapSignalR();
            HttpConfiguration config = new HttpConfiguration();

            // Web API configuration and services
            //跨域配置 //need reference from nuget
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            //enabing attribute routing
            config.MapHttpAttributeRoutes();
            // Web API Convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional },
                namespaces: new string[] { "OWIN.WebApi" }
            );
            config.Services.Replace(typeof(IHttpControllerSelector), new OWIN.WebApi.config.WebApiControllerSelector(config));

            //if config the global filter input there need not write the attributes
            //config.Filters.Add(new App.Web.Filters.ExceptionAttribute_DG());

            //new ClassRegisters(); //register ioc menbers

            appBuilder.UseWebApi(config);
        }
    }
}
