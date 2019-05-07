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
    public class GreetingChannel : ChannelBase<GreetingModel>
    {
        public GreetingChannel(string channelName, IConnection connection) : base(channelName, connection)
        {

        }

        public override bool Publish(GreetingModel payLoad)
        {
            return base.Publish(payLoad);
        }

        public override void Subscribe(Action<GreetingModel> action)
        {
            base.Subscribe(action);
        }
    }
}
