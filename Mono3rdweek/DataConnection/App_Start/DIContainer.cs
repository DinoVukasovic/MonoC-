using Autofac.Integration.WebApi;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using DataConnection.Common;
using DataConnection.Service.Common;
using DataConnection.Service;
using DataConnection.Repository;
using DataConnection.Repository.Common;
using DataConnection.WebApi.Controllers;

namespace DataConnection.App_Start
{
    public class DIContainer
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PatientService>().As<IPatientService>();
            builder.RegisterType<PatientRepository>().As<IPatientRepository>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}