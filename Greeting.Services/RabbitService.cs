using Greeting.Domain.Interfaces;
using Greeting.Domain.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Services
{
    public class RabbitService : IMessageBus
    {
        private IConnection _connection;

        public RabbitService()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            _connection = factory.CreateConnection();
            CreateChannels();
        }
        public IMessageBusChannel<GreetingModel> GreetingChannel { get; private set; }

        public void Dispose()
        {
            if (_connection.IsOpen)
            {
                _connection.Close();
            }
            _connection = null;
        }

        private void CreateChannels()
        {
            GreetingChannel = new GreetingChannel("TheChannel", _connection);
        }
    }
}
