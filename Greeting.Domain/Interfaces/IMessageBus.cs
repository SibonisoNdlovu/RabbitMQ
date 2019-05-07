using Greeting.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Domain.Interfaces
{
    public interface IMessageBus: IDisposable
    {
        IMessageBusChannel<GreetingModel> GreetingChannel { get; }
    }
}
