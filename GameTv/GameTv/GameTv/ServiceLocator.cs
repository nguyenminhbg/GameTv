using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace GameTv
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance { get; } = new ServiceLocator();
        private IContainer Container;
        private ContainerBuilder containerBuider;
        public ServiceLocator()
        {
            containerBuider = new ContainerBuilder();
        }
        public bool built;
        public void Build()
        {
            if (!built)
            {
                Container = containerBuider.Build();
                built = true;
            }
        }
        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
        public object Resolve(Type type)
        {
            return Container.Resolve(type);
        }
        public void RegisterInstance<TInterface, TImplementation>(TImplementation instance)
         where TImplementation : class, TInterface
        {
            containerBuider.RegisterInstance(instance).As<TInterface>();
        }

        public void RegisterInstance<TInterface, TImplementation>() where TImplementation : TInterface
        {
            containerBuider.RegisterType<TImplementation>().As<TInterface>().SingleInstance();
        }

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            containerBuider.RegisterType<TImplementation>().As<TInterface>().InstancePerLifetimeScope();
        }

        public void Register<T>() where T : class
        {
            containerBuider.RegisterType<T>()
                .InstancePerLifetimeScope();
        }
    }
}
