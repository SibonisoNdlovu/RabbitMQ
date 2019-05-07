using Greeting.Domain.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Services
{
    public abstract class ChannelBase<T> : IMessageBusChannel<T>
    {
        private string _channelName;
        private IConnection _connection;
        private IModel _channel;

        public ChannelBase(string channelName, IConnection connection)
        {
            _channelName = channelName;
            _connection = connection;

            SetUpChannel(connection);
        }

        private void SetUpChannel(IConnection connection)
        {
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: _channelName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: true,
                                 arguments: null);
        }

        public virtual bool Publish(T payLoad)
        {
            try
            {
                var payloadString = JsonConvert.SerializeObject(payLoad);
                var data = Encoding.UTF8.GetBytes(payloadString);
                _channel.BasicPublish(exchange: "",
                                     routingKey: _channelName,
                                     basicProperties: null,
                                     body: data);
                return true;
            }
            catch (Exception ex)
            {
                //consider logging the exception 
                return false;
            }
        }

        public virtual void Subscribe(Action<T> action)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, payload) =>
            {
                var payLoadString = Encoding.UTF8.GetString(payload.Body);
                var data = JsonConvert.DeserializeObject<T>(payLoadString);

                action(data);
            };
            _channel.BasicConsume(queue: _channelName,
                                 autoAck: true,
                                 consumer: consumer);

        }
    }
}
