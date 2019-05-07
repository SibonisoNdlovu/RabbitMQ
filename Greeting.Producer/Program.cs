using Greeting.Domain.Interfaces;
using Greeting.Domain.Models;
using Greeting.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Producer
{
    class Program
    {
        //This is the main project for entering a name and sending it via the messageBusHandler
        static void Main(string[] args)
        {
            IOC.DependencyContainer.Initialize();
            using (var messageBusService = IOC.DependencyContainer.Resolve<IMessageBus>())
            {
                var messageBusHandler = new MessageBusHandler(messageBusService.GreetingChannel);
                Console.WriteLine("Please enter name");
                var greeting = Console.ReadLine();
                messageBusHandler.SendMessage(greeting);
                Console.WriteLine("Message sent, press any key to close...");
                Console.ReadKey();
            }
        }
    }

    public class MessageBusHandler
    {
        private IMessageBusChannel<GreetingModel> _channel;
        public MessageBusHandler(IMessageBusChannel<GreetingModel> channel)
        {
            _channel = channel;
        }

        public bool SendMessage(string name)
        {
            if (_channel.Publish(new GreetingModel { Name = name }))
            {
                return true;
            }
            throw new Exception("Could not send message");
        }
    }
}
