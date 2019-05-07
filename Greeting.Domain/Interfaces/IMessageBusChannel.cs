using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Domain.Interfaces
{
    public interface IMessageBusChannel<TMessage>
    {
        bool Publish(TMessage payLoad);

        void Subscribe(Action<TMessage> action);
    }
}
