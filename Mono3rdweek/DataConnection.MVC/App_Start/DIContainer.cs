using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DataConnection.DAL;
using DataConnection.Repository;
using DataConnection.Repository.Common;
using DataConnection.Service;
using DataConnection.Service.Common;

namespace DataConnection.MVC.App_Start
{
    public class DIContainer
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
           

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<EFPatientRepository>().As<IPatientRepository>();
            builder.RegisterType<PatientService>().As<IPatientService>();
            builder.RegisterType<HospitalContext>().AsSelf().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}