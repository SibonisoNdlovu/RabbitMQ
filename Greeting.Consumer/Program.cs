using Greeting.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Consume
{
    class Program
    {
        static void Main(string[] args)
        {
            IOC.DependencyContainer.Initialize();
            using (var messageService = IOC.DependencyContainer.Resolve<IMessageBus>())
            {
                Console.WriteLine("Listening for messages, press any key to close...");
                messageService.GreetingChannel.Subscribe(model =>
                {
                    Console.WriteLine($"Hello {model.Name}, I am your father.");
                });
                Console.ReadKey();
            }
        }
    }
}
