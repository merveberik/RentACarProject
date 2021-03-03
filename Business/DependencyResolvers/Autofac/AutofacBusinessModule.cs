using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Absrtact;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Absrtact;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarsService>().SingleInstance();  //IProductService görürse ProductManager versin demektir
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();  //çalışan uygulama içinde aspecti çağıra işlemi yapıyor

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
