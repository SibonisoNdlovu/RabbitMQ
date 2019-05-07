using Greeting.Domain.Interfaces;
using Greeting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Greeting.IOC
{
    public class DependencyContainer
    {
        private static IUnityContainer _container;
        public static void Initialize()
        {
            _container = new UnityContainer();
            Setup();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void Setup()
        {
            _container.RegisterType<IMessageBus, RabbitService>();
        }
    }
}
