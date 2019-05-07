using Greeting.Domain.Interfaces;
using Greeting.Domain.Models;
using Greeting.Producer;
using Greeting.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greeting.Tests
{
    [TestFixture]
    public class MessageBusTests
    {
        [Test(Description = "Publish should return true")]
        public void ServicePublishSuccess()
        {
            Mock<IMessageBusChannel<GreetingModel>> mock = new Mock<IMessageBusChannel<GreetingModel>>();
            mock.Setup(c => c.Publish(It.IsAny<GreetingModel>())).Returns(true);

            MessageBusHandler handler = new MessageBusHandler(mock.Object);
            Assert.AreEqual(handler.SendMessage("TestName"), true);

        }

        [Test(Description = "When publish fails, should throw")]
        public void ServicePublishFail() 
        {
            Mock<IMessageBusChannel<GreetingModel>> mock = new Mock<IMessageBusChannel<GreetingModel>>();
            mock.Setup(c => c.Publish(It.IsAny<GreetingModel>())).Throws(new Exception("Could not send message"));

            MessageBusHandler handler = new MessageBusHandler(mock.Object);
            Assert.Throws(Is.TypeOf<Exception>(), () => handler.SendMessage("TestName"), "Could not send message");
        }
    }
}
